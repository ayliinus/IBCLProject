using Business.AccountBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountBusinessService _accountBusinessService;
        public AccountController(IAccountBusinessService accountBusinessService)
        {
            _accountBusinessService = accountBusinessService;
        }
        [HttpPost("AddAccount")]
        public IActionResult AddAccount(AccountVM model)
        {
            _accountBusinessService.AddAccount(model);
            return Ok(model);
        }
        [HttpPost("Login")]
        public IActionResult Login(string email, string password)
        {
            var login = _accountBusinessService.Login(email, password);

            if (login)
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
