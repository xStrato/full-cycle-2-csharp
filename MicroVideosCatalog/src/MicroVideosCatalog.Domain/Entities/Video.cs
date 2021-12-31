using System.Collections.ObjectModel;
using MicroVideosCatalog.Domain.Common;

namespace MicroVideosCatalog.Domain.Entities;
public record Video : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int YearLaunched { get; private set; }
    public bool Opened { get; private set; }
    public string Rating { get; private set; }
    public float Duration { get; private set; }
    private IList<Category> _categories { get; set; } = new List<Category>();
    public ReadOnlyCollection<Category> Categories => new(_categories);
    private IList<Genre> _genres { get; set; } = new List<Genre>();
    public ReadOnlyCollection<Genre> Genres => new(_genres);
    private IList<CastMember> _castMembers { get; set; } = new List<CastMember>();
    public ReadOnlyCollection<CastMember> CastMembers => new(_castMembers);
    private IList<VideoFile> _videoFiles { get; set; } = new List<VideoFile>();
    public ReadOnlyCollection<VideoFile> VideoFiles => new(_videoFiles);

    protected Video() : base() { }
    public Video(Guid id, string title, string description, int yearLaunched, bool opened) : base(id)
    {
        Title = title;
        Description = description;
        YearLaunched = yearLaunched;
        Opened = opened;
    }
    public Video(string title, string description, int yearLaunched, bool opened) : base()
    {
        Title = title;
        Description = description;
        YearLaunched = yearLaunched;
        Opened = opened;
    }
    public Video(string title, string description, int yearLaunched, bool opened, string rating, float duration) : base()
    {
        Title = title;
        Description = description;
        YearLaunched = yearLaunched;
        Opened = opened;
        Rating = rating;
        Duration = duration;
    }
    public Video(string title, string description, int yearLaunched, float duration) : base()
    {
        Title = title;
        Description = description;
        YearLaunched = yearLaunched;
        Duration = duration;
    }
    public Video(string title, string description, int yearLaunched, float duration, IList<VideoFile> videoFiles) : base()
    {
        Title = title;
        Description = description;
        YearLaunched = yearLaunched;
        Duration = duration;
        _videoFiles = videoFiles;
    }
    public Video(string title, string description, int yearLaunched, float duration, IList<Category> categories, IList<Genre> genres, IList<CastMember> castMembers) : base()
    {
        Title = title;
        Description = description;
        YearLaunched = yearLaunched;
        Duration = duration;
        _categories = categories;
        _genres = genres;
        _castMembers = castMembers;
    }
    public void SetOpened(bool opened) => Opened = opened;
    public void SetRating(string rating) => Rating = rating;
    public void SetDuration(float duration) => Duration = duration;
    public void SetDescription(string description) => Description = description;
    public void SetTitle(string title)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentException("'title' cannot be empty or null");
        Title = title;
    }
    public void SetYearLaunched(int yearLaunched)
    {
        if (yearLaunched >= 0 && yearLaunched <= 1700)
            throw new ArgumentException("'yearLaunched' must be greater than 1700");
        if (yearLaunched > DateTime.Now.Year)
            throw new ArgumentException("'yearLaunched' is greater than current year");
        YearLaunched = yearLaunched;
    }
    public void Add<T>(T entity) where T : Entity
    {
        if (entity is null)
            throw new ArgumentException($"'{typeof(T).Name}' cannot be null");

        (entity switch
        {
            Category e => new Action<T>(_ => _categories.Add(e)),
            Genre e => new Action<T>(_ => _genres.Add(e)),
            CastMember e => new Action<T>(_ => _castMembers.Add(e)),
            _ => throw new ArgumentException($"type '{typeof(T).Name}' is not supported.")
        })(entity);
    }

    public void Remove<T>(T entity) where T : Entity
    {
        EnsureSupportedListTypes<T>();

        if (entity is null)
            throw new ArgumentException($"'{typeof(T).Name}' cannot be null");

        if (entity is Category e) _categories.Remove(e);
        if (entity is Genre g) _genres.Remove(g);
        if (entity is CastMember cm) _castMembers.Remove(cm);
    }

    public void Set<T>(IList<T> entities) where T : Entity
    {
        EnsureSupportedListTypes<T>();
        if (entities is null or { Count: <= 0 })
            throw new ArgumentException($"'{typeof(IList<T>).Name}' cannot be empty or  null");

        if (entities is IList<Category> e) _categories = e;
        if (entities is IList<Genre> g) _genres = g;
        if (entities is IList<CastMember> cm) _castMembers = cm;
    }

    private static void EnsureSupportedListTypes<T>() where T : Entity
    {
        var type = typeof(T);
        if (type == typeof(Category) || type == typeof(Genre) || type == typeof(CastMember))
            return;
        throw new ArgumentException($"type '{type.Name}' is not supported.");
    }


    public Video CreateVideoWithFiles(string title, string description, int yearLaunched, float duration, IList<Category> categories, IList<Genre> genres, IList<CastMember> castMembers, IList<VideoFile> videoFiles)
    {
        Title = title;
        Description = description;
        YearLaunched = yearLaunched;
        Duration = duration;
        _categories = categories;
        _genres = genres;
        _castMembers = castMembers;
        _videoFiles = videoFiles;
        return this;
    }

    public Video CreateVideoWithoutFiles(string title, string description, int yearLaunched, float duration, IList<Category> categories, IList<Genre> genres, IList<CastMember> castMembers)
    {
        Title = title;
        Description = description;
        YearLaunched = yearLaunched;
        Duration = duration;
        _categories = categories;
        _genres = genres;
        _castMembers = castMembers;
        return this;
    }
}