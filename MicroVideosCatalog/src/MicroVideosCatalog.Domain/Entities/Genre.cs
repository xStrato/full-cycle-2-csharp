using MicroVideosCatalog.Domain.Common;

namespace MicroVideosCatalog.Domain.Entities;

public record Genre : Entity
{
    public string Name { get; private set; }
    protected Genre() { }
    public Genre(string name) : base() => Name = name;
    public Genre(Guid id, string name) : base(id) => Name = name;

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("'name' cannot be empty or null");
        Name = name;
    }
}