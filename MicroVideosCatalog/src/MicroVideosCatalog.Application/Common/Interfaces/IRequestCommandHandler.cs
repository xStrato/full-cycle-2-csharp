namespace MicroVideosCatalog.Application.Common.Interfaces;

public interface IRequestCommandHandler<in TRequest, TResponse> where TRequest : ICommandRequest<TResponse>
{
    Task<TResponse> HandleAsync(TRequest command, CancellationToken ct = default);
}