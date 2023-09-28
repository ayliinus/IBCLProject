using Context;
using Entity;
using Repository.AssetRepository;
using System.Text.Json;
using ViewModel;

namespace Business.AssetBusiness
{
    public class AssetBusinessService : IAssetBusinessService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAssetRepositoryService _assetRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        public AssetBusinessService(IAssetRepositoryService assetRepository, ApplicationDbContext context, IHttpClientFactory httpClientFactory)
        {
            _assetRepository = assetRepository;
            _httpClientFactory = httpClientFactory;
            _context = context;
        }

        public bool UpSertAsset()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var response = httpClient.GetAsync("https://api.example.com/data").Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var assetDto = JsonSerializer.Deserialize<AssetCreateVM>(content);

                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            var existingAsset = _assetRepository.GetFirst(a => a.Symbol == assetDto.Symbol);

                            if (existingAsset == null)
                            {
                                var newAsset = new Asset
                                {
                                    Symbol = assetDto.Symbol,
                                    LastPrice = assetDto.LastPrice,
                                };

                                _assetRepository.Add(newAsset);
                            }
                            else
                            {
                                existingAsset.LastPrice = assetDto.LastPrice;
                                _assetRepository.Update(existingAsset);
                            }

                            transaction.Commit();

                            return true; // Return true on success
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return false; 
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
