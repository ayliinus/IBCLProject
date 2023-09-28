using Business.PortfolioBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioBusinessService _portfolioBusinessService;
        public PortfolioController(IPortfolioBusinessService portfolioBusinessService)
        {
            _portfolioBusinessService = portfolioBusinessService;
        }
        [HttpPost("AddPortfolio")]
        public IActionResult AddPortfolio(PortfolioVM model)
        {
            _portfolioBusinessService.AddPortfolio(model);
            return Ok(model);
        }
        [HttpGet("GetAllPortfolios")]
        public IActionResult GetAllPortfolios()
        {
            var portfolios = _portfolioBusinessService.GetAllPortfolios();
            return Ok(portfolios);
        }
        [HttpPut("UpdatePortfolio/{id:int}")]
        public IActionResult UpdatePortfolio(int id, PortfolioVM model)
        {

                var result = _portfolioBusinessService.UpdatePortfolio(id, model);
                if (result)
                {
                    return Ok("Operation was successful.");
                }
                else
                {
                    return BadRequest("Operation failed.");
                }
               
            

        }
        [HttpGet("GetProfit/{id:int}")]
        public IActionResult GetProfit(int id)
        {
            var portfolios = _portfolioBusinessService.ProfitCheck(id);
            return Ok(portfolios);
        }
    }
}
