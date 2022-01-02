namespace MicroVideosCatalog.Domain.Entities;

public record Genre : Entity<Genre>, IAggegateRoot
{
    public string Name { get; private set; }
    private IList<Category> _categories { get; set; } = new List<Category>();
    public ReadOnlyCollection<Category> Categories => new(_categories);
    protected Genre() { }
    public Genre(string name) : base() => Name = name;
    public Genre(Guid id, string name) : base(id) => Name = name;
    public Genre(string name, IList<Category> categories) : base()
        => (Name, _categories) = (name, categories);
    public Genre(Guid id, string name, IList<Category> categories) : base(id)
        => (Name, _categories) = (name, categories);

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

    public void SetCategories(IList<Category> categories)
    {
        if (categories is null or { Count: <= 0 })
            throw new ArgumentException($"'{nameof(categories)}' cannot be empty or null");
        _categories = categories;
    }

    public void AddCategory(Category category)
    {
        if (category is null)
            throw new ArgumentException($"'{nameof(category)}' cannot be null");
        _categories.Add(category);
    }

    public void RemoveCategory(Category category)
    {
        if (category is null)
            throw new ArgumentException($"'{nameof(category)}' cannot be null");
        _categories.Remove(category);
    }
}