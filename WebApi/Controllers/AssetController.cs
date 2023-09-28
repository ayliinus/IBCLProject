using Business.AssetBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetBusinessService _assetBusinessService;
        public AssetController(IAssetBusinessService assetBusinessService)
        {
            _assetBusinessService = assetBusinessService;
        }

        [HttpPost("UpSertAsset")]
        public IActionResult UpSertAsset()
        {
            var upSert = _assetBusinessService.UpSertAsset();

            if (upSert)
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
