namespace MicroVideosCatalog.Application.Common;
public abstract record Command<T> : FluentValidator<T>, ICommandRequest<GenericResult>
    where T : class, ICommand
{
    public DateTime Timestamp { get; init; }
    public string CommandType { get; init; }
    protected Command()
    {
        Timestamp = DateTime.Now;
        CommandType = GetType().Name;
    }
}