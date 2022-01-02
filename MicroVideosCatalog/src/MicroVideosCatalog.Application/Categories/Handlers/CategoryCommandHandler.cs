namespace MicroVideosCatalog.Application.Categories.Handlers;
public record CategoryCommandHandler :
        IRequestCommandHandler<CreateCategoryCommand, GenericResult>
{
    public async Task<GenericResult> HandleAsync(CreateCategoryCommand command, CancellationToken ct = default)
    {
        if (command.IsValid() is false)
            return new(false, string.Format("{0} is not valid", command.CommandType), command.GetErrosFormatted());
        return new(true, string.Format("{0} is valid", command.CommandType), command.GetErrosFormatted());
    }
}