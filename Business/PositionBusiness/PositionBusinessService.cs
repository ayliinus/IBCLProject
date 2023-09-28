using Context;
using Entity;
using Repository.PositionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

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

        public void AddPosition(PositionVM model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newPosition = new Position
                    {
                       Orders  = model.Orders,
                       PortfolioId = model.PortfolioId,
                       Rate = model.Rate,
                       IsActive = model.IsActive
                    };

                    _positionRepository.Add(newPosition);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public List<Position> GetAllPositions()
        {
            var result = _positionRepository.Get(w => w.CreatedAt != null).ToList();
            return result;
        }

        public bool UpdatePosition(int PositionId, PositionVM model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var existingPosition = _positionRepository.GetFirst(w => w.Id == PositionId);
                    if (existingPosition == null)
                    {
                        return false;
                    }

                    existingPosition.Orders = model.Orders;
                    existingPosition.PortfolioId = model.PortfolioId;
                    existingPosition.Rate = model.Rate;
                    existingPosition.IsActive = model.IsActive;

                    _positionRepository.Update(existingPosition);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
                return true;
            }
        }
    }
}
