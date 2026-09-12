using Application.Commands;
using Application.DTO.User;
using Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController:ControllerBase
    {
        private readonly UseCaseHandler _useCaseHandler;

        public RegisterController(UseCaseHandler handler)
        {
            _useCaseHandler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterUserCommand command,
            [FromBody] UserRegisterDTO dto)
        {
            await _useCaseHandler.ExecuteCommandAsync(command, dto);
            return Ok();
        }
    }
}
