using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("get-people")]
        public IActionResult GetPeople()
        {
            return Ok(_personService.GetPeople());
        }
    }
}
