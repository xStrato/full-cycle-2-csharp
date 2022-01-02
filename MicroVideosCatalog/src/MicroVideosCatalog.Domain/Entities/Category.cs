namespace MicroVideosCatalog.Domain.Entities;
public record Category : Entity<Category>, IAggegateRoot
{
    public string Name { get; private set; }
    protected Category() { }
    public Category(string name) : base() => Name = name;
    public Category(Guid id, string name) : base(id) => Name = name;
    protected override void ConfigureValidations(Validator ruler)
    {
        ruler.RuleFor(e => e.Id).NotEmpty().NotNull();
        ruler.RuleFor(e => e.Name).NotEmpty().NotNull();
    }
    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException($"'{nameof(name)}' cannot be empty or null");
        Name = name;
    }
}