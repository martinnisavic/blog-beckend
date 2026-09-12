using Application;
using BCrypt.Net;
using BlogApi.JWT;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly BlogDbContext _context;
        private readonly JwtHandler _handler;

        public AuthController(BlogDbContext context, JwtHandler handler)
        {
            _context = context;
            _handler = handler;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            
            if(user==null)
            {
                return Unauthorized();
            }
            if(user.ActivatedAt==null)
            {
                return Unauthorized("Account is not activated, check your email address!");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return Unauthorized();
            }
            return Ok(new JwtTokenResponse { Token = _handler.MakeToken(user) });
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult Me([FromServices] IApplicationUser user)
        {
            return Ok(new { user.Id, user.Username, user.Email });
        }

    }
}
