namespace MicroVideosCatalog.Application.Common;
public abstract record Query<T> : FluentValidator<T>, IQueryRequest<GenericResult>
    where T : class, IQuery
{
    public DateTime CreationTime { get; init; }
    public string QueryType { get; init; }
    protected Query()
    {
        CreationTime = DateTime.Now;
        QueryType = GetType().Name;
    }
}