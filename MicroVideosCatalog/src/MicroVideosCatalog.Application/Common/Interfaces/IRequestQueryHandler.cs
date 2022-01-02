namespace MicroVideosCatalog.Application.Common.Interfaces;

public interface IRequestQueryHandler<in TRequest, TResponse> where TRequest : IQueryRequest<TResponse>
{
    Task<TResponse> HandleAsync(TRequest query, CancellationToken ct = default);
}