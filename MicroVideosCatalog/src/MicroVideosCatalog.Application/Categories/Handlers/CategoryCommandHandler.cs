namespace MicroVideosCatalog.Application.Categories.Handlers;
public record CategoryCommandHandler : IRequestCommandHandler<CreateCategoryCommand, GenericResult>
{
    public ICategoryRepository _categoryRepository { get; init; }
    public CategoryCommandHandler(ICategoryRepository categoryRepository)
        => _categoryRepository = categoryRepository;

    public async Task<GenericResult> HandleAsync(CreateCategoryCommand command, CancellationToken ct = default)
    {
        if (command.IsValid() is false)
            return new(false, string.Format("{0} state is invalid", command.CommandType), command.GetErrosFormatted());

        var category = new Category(command.Name);
        await _categoryRepository.AddAsync(category, ct);
        var commited = await _categoryRepository.UnitOfWork.Commit();

        if (commited is false)
            return new(false, string.Format("{0} cannot be fully executed", command.CommandType), new { Message = "database commit failed" });

        return new(true, string.Format("{0} was successfully executed", command.CommandType), category);
    }
}