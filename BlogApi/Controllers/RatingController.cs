using Application.Commands;
using Application.DTO.Rating;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public RatingController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Rate(
            [FromServices] IRatePostCommand command,
            [FromBody] RatePostDTO dto)
        {
            await _handler.ExecuteCommandAsync(command, dto);
            return Ok();
        }
    }
}
