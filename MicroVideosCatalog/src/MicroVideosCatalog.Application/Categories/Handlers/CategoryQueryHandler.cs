using MicroVideosCatalog.Application.Categories.Queries;

namespace MicroVideosCatalog.Application.Categories.Handlers;
public record CategoryQueryHandler : IRequestQueryHandler<GetAllCategoriesQuery, GenericResult>
{
    public ICategoryRepository _categoryRepository { get; init; }
    public CategoryQueryHandler(ICategoryRepository categoryRepository)
        => _categoryRepository = categoryRepository;
    public async Task<GenericResult> HandleAsync(GetAllCategoriesQuery query, CancellationToken ct = default)
    {
        var categories = await _categoryRepository.GetAllAsync(ct);
        return new(true, string.Format("{0} was successfully executed", query.QueryType), categories);
    }
}