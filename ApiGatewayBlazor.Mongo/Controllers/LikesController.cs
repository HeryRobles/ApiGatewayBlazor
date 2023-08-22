using ApiGatewayBlazor.Mongo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiGatewayBlazor.Mongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet("me-gusta")]
        public async Task<ActionResult<int>> ContarMeGusta()
        {
            int totalMeGusta = await _likeService.ContarMeGusta();
            return Ok(totalMeGusta);
        }

        [HttpGet("no-me-gusta")]
        public async Task<ActionResult<int>> ContarNoMeGusta()
        {
            int totalNoMeGusta = await _likeService.ContarNoMeGusta();
            return Ok(totalNoMeGusta);
        }
    }
}
