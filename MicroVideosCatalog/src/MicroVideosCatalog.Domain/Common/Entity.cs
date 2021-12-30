namespace MicroVideosCatalog.Domain.Common;
public abstract record Entity
{
    public Guid Id { get; private set; }
    public Entity() { }
    public Entity(Guid id) => Id = id;

    public void SetId(Guid id)
    {
        EnsureThatIsValidGuid(id.ToString());
        Id = id;
    }

    public void SetId(string id)
    {
        EnsureThatIsValidGuid(id);
        Id = Guid.Parse(id);
    }

    protected Guid GenerateGuid()
    {
        Id = Guid.NewGuid();
        return Id;
    }
    private static void EnsureThatIsValidGuid(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new ArgumentException("'id' cannot be empty or null");
        if (IsValidGuid(id))
            throw new ArgumentException("'id' cannot have a default value");
    }
    protected static bool IsValidGuid(string id) => Guid.TryParse(id, out var _);
}