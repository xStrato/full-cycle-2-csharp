namespace MicroVideosCatalog.Domain.Interfaces;
public interface IRepository<T> : IDisposable where T : IAggegateRoot
{
    IUnitOfWork UnitOfWork { get; }
    Task<IEnumerable<T>> GetAllAsync(CancellationToken ct = default);
    Task<T> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(T entity, CancellationToken ct = default);
    T Update(T entity);
    void Delete(T entity);
}