using Application.Commands;
using Application.DTO.Comment;
using Application.Queries;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public CommentController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostComments(
            [FromServices] IGetCommentsQuery query, int postId)
            => Ok(await _handler.ExecuteQueryAsync(query, postId));


    

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateComment(
        [FromServices] ICreateCommentCommand command,
        [FromBody] AddCommentDTO dto)
        {
            await _handler.ExecuteCommandAsync(command, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteComment([FromServices] IDeleteCommentCommand command, int id)
        {
            await _handler.ExecuteCommandAsync(command, id);
            return NoContent();
        }
    }
}
