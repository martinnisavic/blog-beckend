using Application;
using DataAccess;
using Implementation;

namespace BlogApi.JWT
{
    public class ApplicationUserFactory
    {
        private readonly IHttpContextAccessor _httpAccessor;
        private readonly BlogDbContext _context;

        public ApplicationUserFactory(IHttpContextAccessor httpAccessor, BlogDbContext context)
        {
            _httpAccessor = httpAccessor;
            _context = context;
        }

        public IApplicationUser Create()
        {
            var user = _httpAccessor.HttpContext?.User;
            if ((user?.Identity?.IsAuthenticated!=true))
            {
                return new UnAuthorizedUser();
            }
            var roleName=user.FindFirst("Role")?.Value;  
            var allowedUseCases=_context.RoleUseCases
                .Where(x=>x.Role.Name== roleName)
                .Select(x => x.UseCase.Name)
                .ToList();
            return new JwtUser
            {
                Id = int.Parse(user.FindFirst("Id")?.Value ?? "0"),
                Email = user.FindFirst("Email")?.Value,
                Username = user.FindFirst("Username")?.Value,
                Role = roleName,
                AllowedUseCases = allowedUseCases
            };
        }
    }
}
