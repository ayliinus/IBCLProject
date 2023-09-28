using Context;
using Repository.PositionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.PositionBusiness
{
    public class PositionBusinessService : IPositionBusinessService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPositionRepositoryService _positionRepository;
        public PositionBusinessService(IPositionRepositoryService positionRepository, ApplicationDbContext context)
        {
            _positionRepository = positionRepository;
            _context = context;
        }
    }
}
