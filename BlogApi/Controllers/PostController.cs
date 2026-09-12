using Application.Commands;
using Application.DTO.Paging;
using Application.DTO.Post;
using Application.Queries;
using DataAccess;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController: ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public PostController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost(
            [FromServices] ICreatePostCommand command,
            [FromBody] CreatePostDTO dto)
        {
            await _handler.ExecuteCommandAsync(command, dto);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts(
            [FromServices] IGetPostsQuery query,
            [FromQuery] PostSearch search)
        {
            return Ok(await _handler.ExecuteQueryAsync(query, search));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOnePost(
            [FromServices] IGetPostQuery query, int id                
            )=> Ok(await _handler.ExecuteQueryAsync(query, id));

        [HttpPut]
        public async Task<IActionResult> EditPost(
            [FromServices] IUpdatePostCommand command,
            [FromBody] UpdatePostDTO dto)
        {
            await _handler.ExecuteCommandAsync(command, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePost(
           [FromServices] IDeletePostCommand command, int id
           )
        {
            await (_handler.ExecuteCommandAsync(command, id));
            return NoContent();
        }
    }
}
