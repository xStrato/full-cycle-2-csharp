namespace MicroVideosCatalog.Domain.Common;
public abstract record Entity<T> : FluentValidator<T> where T : class
{
    public Guid Id { get; private set; }
    protected Entity() => Id = Guid.NewGuid();
    protected Entity(Guid id) => Id = id;

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

    private static void EnsureThatIsValidGuid(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new ArgumentException($"'{nameof(id)}' cannot be empty or null");
        if (IsValidGuid(id))
            throw new ArgumentException($"'{nameof(id)}' is not a valid Guid");
    }
    protected static bool IsValidGuid(string id) => Guid.TryParse(id, out var _);
}