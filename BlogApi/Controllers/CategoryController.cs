using Application.Queries;
using Implementation.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public CategoryController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IGetCategoriesQuery query)
            => Ok(await _handler.ExecuteQueryAsync(query, 0));
    }
}
