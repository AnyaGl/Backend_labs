using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("create-comment")]
        public IActionResult CreateComment(/*[FromForm]*/CreateCommentDTO comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _commentService.CreateComment(comment);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
                return Ok();
            }
            return BadRequest("Ошибка входных данных");
        }

        [HttpGet("get-comments-by-bike-id/{bikeId}")]
        public IActionResult GetCommentsByBikeId(int bikeId)
        {
            return Ok(_commentService.GetCommentsByBikeId(bikeId));
        }
    }
}
