using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Business.PositionBusiness
{
    public interface IPositionBusinessService
    {
        void AddPosition(PositionVM model);
        List<Position> GetAllPositions();
        bool UpdatePosition(int PositionId, PositionVM model);
    }
}
