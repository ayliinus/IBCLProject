using Context;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.PositionRepository
{
    public class PositionRepositoryService : BaseRepository<Position>, IPositionRepositoryService
    {
        public PositionRepositoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
