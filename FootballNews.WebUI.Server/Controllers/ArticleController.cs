using FootballNews.Application.DTOs;
using FootballNews.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FootballNews.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddArticle(ArticleDto articleDto)
        {
            await _articleService.AddArticleAsync(articleDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articleService.DeleteArticleAsync(id);
            return Ok();
        }
    }
}