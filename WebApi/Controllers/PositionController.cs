using Business.PortfolioBusiness;
using Business.PositionBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionBusinessService _positionBusinessService;
        public PositionController(IPositionBusinessService positionBusinessService)
        {
            _positionBusinessService = positionBusinessService;
        }
        [HttpPost("AddPortfolio")]
        public IActionResult AddPosition(PositionVM model)
        {
            _positionBusinessService.AddPosition(model);
            return Ok(model);
        }
        [HttpGet("GetAllPortfolios")]
        public IActionResult GetAllPosition()
        {
            var portfolios = _positionBusinessService.GetAllPositions();
            return Ok(portfolios);
        }
        [HttpPut("UpdatePortfolio/{id:int}")]
        public IActionResult UpdatePosition(int id, PositionVM model)
        {

            var result = _positionBusinessService.UpdatePosition(id, model);
            if (result)
            {
                return Ok("Operation was successful.");
            }
            else
            {
                return BadRequest("Operation failed.");
            }



        }
    }
}
