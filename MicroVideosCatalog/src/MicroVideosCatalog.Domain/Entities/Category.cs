using MicroVideosCatalog.Domain.Common;

namespace MicroVideosCatalog.Domain.Entities;
public record Category : Entity
{
    public string Name { get; private set; }
    protected Category() { }
    public Category(string name) : base() => Name = name;
    public Category(Guid id, string name) : base(id) => Name = name;

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("'name' cannot be empty or null");
        Name = name;
    }
}