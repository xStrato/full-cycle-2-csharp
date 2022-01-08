using MicroVideosCatalog.Domain.Common;
using MicroVideosCatalog.Domain.Interfaces;
using MicroVideosCatalog.Infrastructure.Data.Contexts;

namespace MicroVideosCatalog.Infrastructure.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public IUnitOfWork UnitOfWork => _videoCatalogContext;
    private VideoCatalogContext _videoCatalogContext { get; init; }
    public CategoryRepository(VideoCatalogContext videoCatalogContext)
        => _videoCatalogContext = videoCatalogContext;

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken ct = default)
        => await _videoCatalogContext.Categories.ToListAsync(ct);

    public Task<Category> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Category entity, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Category Update(Category entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Category entity)
    {
        throw new NotImplementedException();
    }

    public void Dispose() => _videoCatalogContext?.Dispose();
}