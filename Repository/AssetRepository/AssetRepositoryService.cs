using Context;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AssetRepository
{
    public class AssetRepositoryService : BaseRepository<Asset>, IAssetRepositoryService
    {
        public AssetRepositoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
