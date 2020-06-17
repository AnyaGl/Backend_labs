using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;
        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet("get-types")]
        public IActionResult GetTypes()
        {
            return Ok(_typeService.GetTypes());
        }
    }
}
