namespace MicroVideosCatalog.Application.Common;
public abstract record Command<T> : FluentValidator<T>, ICommandRequest<GenericResult>
    where T : class, ICommand
{
    public DateTime CreationTime { get; init; }
    public string CommandType { get; init; }
    protected Command()
    {
        CreationTime = DateTime.Now;
        CommandType = GetType().Name;
    }
}