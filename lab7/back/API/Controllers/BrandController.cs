using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("get-brands")]
        public IActionResult GetBrands()
        {
            return Ok(_brandService.GetBrands());
        }
    }
}
