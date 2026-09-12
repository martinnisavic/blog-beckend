using Application.DTO.User;
using Application.Queries;
using Implementation.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        public readonly UseCaseHandler _handler;
        public UserController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUsers([FromServices] IGetUsersQuery query,
            [FromQuery] UserSearch search)
        {
            return Ok(await _handler.ExecuteQueryAsync(query, search));
        }
    }
}
