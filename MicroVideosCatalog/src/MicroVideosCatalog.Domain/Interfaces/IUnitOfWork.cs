namespace MicroVideosCatalog.Domain.Interfaces;
public interface IUnitOfWork
{
    Task<bool> Commit(CancellationToken ct = default);
}