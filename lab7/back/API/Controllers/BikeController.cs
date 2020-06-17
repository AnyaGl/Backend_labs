using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : Controller
    {
        private readonly IBikeService _bikeService;
        public BikeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        [HttpPost("create-bike")]
        public IActionResult CreateBike(/*[FromForm]*/CreateBikeDTO bike)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bikeService.CreateBike(bike);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
                return Ok();
            }
            return BadRequest("Ошибка входных данных");
        }

        [HttpGet("get-bikes")]
        public IActionResult GetBikes()
        {
            return Ok(_bikeService.GetBikes());
        }

        [HttpGet("get-bikes-by-filter")]
        public IActionResult GetBikesByFilter(int minPrice, int maxPrice, int personId, int minDiameter, int maxDiameter, int brandId, List<int> typeIds)
        {
            return Ok(_bikeService.GetBikesByFilter(minPrice, maxPrice, personId, minDiameter, maxDiameter, brandId, typeIds));
        }

        [HttpGet("get-bike-by-id/{id}")]
        public IActionResult GetBikeById(int id)
        {
            try
            {
                var bike = _bikeService.GetBikeById(id);
                return Ok(bike);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
