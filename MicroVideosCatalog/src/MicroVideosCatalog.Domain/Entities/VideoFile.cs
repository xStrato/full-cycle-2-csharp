namespace MicroVideosCatalog.Domain.Entities;

public record VideoFile : Entity<VideoFile>, IAggegateRoot
{
    public string Title { get; private set; }
    public float Duration { get; private set; }
    public string Url { get; private set; }

    protected VideoFile() : base() { }
    public VideoFile(string title, float duration) : base()
    {
        Title = title;
        Duration = duration;
    }
    public VideoFile(string title, float duration, string url) : base()
    {
        Title = title;
        Duration = duration;
        Url = url;
    }
    public VideoFile(Guid id, string title, float duration) : base(id)
    {
        Title = title;
        Duration = duration;
    }
    public VideoFile(Guid id, string title, float duration, string url) : base(id)
    {
        Title = title;
        Duration = duration;
        Url = url;
    }

    protected override void ConfigureValidations(Validator ruler)
    {
        ruler.RuleFor(e => e.Id).NotEmpty().NotNull();
        ruler.RuleFor(e => e.Title).NotEmpty().NotNull();
        ruler.RuleFor(e => e.Duration).NotEmpty().NotNull();
    }

    public void SetDuration(float duration) => Duration = duration;
    public void SetUrl(string url) => Url = url;
    public void SetTitle(string title)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentException($"'{nameof(title)}' cannot be empty or null");
        Title = title;
    }
}