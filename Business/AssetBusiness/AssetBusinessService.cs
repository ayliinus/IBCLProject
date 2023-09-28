using Context;
using Entity;
using Repository.AssetRepository;
using System.Collections.Generic;
using System.Text.Json;
using ViewModel;

namespace Business.AssetBusiness
{
    public class AssetBusinessService : IAssetBusinessService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAssetRepositoryService _assetRepository;
        public AssetBusinessService(IAssetRepositoryService assetRepository, ApplicationDbContext context)
        {
            _assetRepository = assetRepository;
            _context = context;
        }


        public List<Asset> GetAllAssets()
        {
            var result = _assetRepository.Get(w => w.CreatedAt != null).ToList();
            return result;
        }

        public bool UpSertAsset()
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    
                    var response = httpClient.GetAsync("https://www.binance.me/api/v3/ticker/price?symbols=%5B%22ETHUSDT%22,%22BTCUSDT%22,%22AVAXUSDT%22%5D").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;
                        var assetDto = JsonSerializer.Deserialize<List<AssetVM>>(content);

                        using (var transaction = _context.Database.BeginTransaction())
                        {
                            try
                            {
                                foreach (var assetDtoItem in assetDto)
                                {
                                    var existingAsset = _assetRepository.GetFirst(a => a.Symbol == assetDtoItem.symbol);

                                    if (existingAsset == null)
                                    {
                                        var newAsset = new Asset
                                        {
                                            Symbol = assetDtoItem.symbol,
                                            LastPrice = double.Parse(assetDtoItem.price),
                                        };

                                        _assetRepository.Add(newAsset);
                                    }
                                    else
                                    {
                                        existingAsset.LastPrice = double.Parse(assetDtoItem.price);
                                        _assetRepository.Update(existingAsset);
                                    }
                                }

                                transaction.Commit();

                                return true; 
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
            }
            catch (Exception ex)
            {
             
                return false;
            }
        }

    }

}
