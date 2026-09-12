using Application.Commands;
using Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivateAccountController:ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public ActivateAccountController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        [HttpGet("{code}")]
        public async Task<IActionResult> ActivateAccountCode(
            string code,
            [FromServices] IActivateAccountCommand command
            )
        {
            await _handler.ExecuteCommandAsync(command, code);
            return Ok("Account is activated, you can login now!");
        }

    }
}
