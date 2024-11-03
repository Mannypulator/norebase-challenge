using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using NoreBaseApiChallenge.Application.interfaces;

namespace NoreBaseApiChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LikeController : BaseController
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost("{articleId}")]
        public async Task<IActionResult> LikeArticleAsync(Guid articleId)
        {
            var response = await _likeService.LikeArticleAsync(articleId);
            return StatusCode(GetStatusCode(response.StatusCode), response);
        }

        [HttpGet("{articleId}")]
        public async Task<IActionResult> GetNumberOfArticleLikesAsync(Guid articleId)
        {
            var response = await _likeService.GetNumberOfArticleLikesAsync(articleId);
            return StatusCode(GetStatusCode(response.StatusCode), response);
        }

    }
}
