using MicroVideosCatalog.Application.Categories.Queries;

namespace MicroVideosCatalog.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    public CategoryCommandHandler _commandHandler { get; set; }
    public CategoryQueryHandler _queryHandler { get; set; }
    public CategoryController(CategoryCommandHandler commandHandler, CategoryQueryHandler queryHandler)
    {
        _commandHandler = commandHandler;
        _queryHandler = queryHandler;
    }

    [HttpGet]
    public async Task<ActionResult<GenericResult>> GetAll(GetAllCategoriesQuery query, CancellationToken ct)
    {
        var result = await _queryHandler.HandleAsync(query, ct);
        if (result.Success is false)
            return BadRequest(result);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GenericResult>> Create(CreateCategoryCommand command, CancellationToken ct)
    {
        var result = await _commandHandler.HandleAsync(command, ct);
        if (result.Success is false)
            return BadRequest(result);
        return Ok(result);
    }
}