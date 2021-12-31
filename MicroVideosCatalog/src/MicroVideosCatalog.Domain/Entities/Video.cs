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
    private IList<Genre> _genre { get; set; } = new List<Genre>();
    public ReadOnlyCollection<Genre> Genres => new(_genre);
    private IList<CastMember> _castMember { get; set; } = new List<CastMember>();
    public ReadOnlyCollection<CastMember> CastMembers => new(_castMember);

    protected Video() { }
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

    public void SetTitle(string title)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentException("'title' cannot be empty or null");
        Title = title;
    }
    public void SetDescription(string description) => Description = description;
    public void SetYearLaunched(int yearLaunched)
    {
        if (yearLaunched >= 0 && yearLaunched <= 1700)
            throw new ArgumentException("'yearLaunched' must be greater than 1700");
        if (yearLaunched > DateTime.Now.Year)
            throw new ArgumentException("'yearLaunched' is greater than current year");
        YearLaunched = yearLaunched;
    }
    public void SetOpened(bool opened) => Opened = opened;
    public void SetRating(string rating) => Rating = rating;
    public void SetDuration(float duration) => Duration = duration;
    public void Add<T>(T entity) where T : Entity
    {
        (entity switch
        {
            Category e => new Action<T>(_ => _categories.Add(e)),
            Genre e => new Action<T>(_ => _genre.Add(e)),
            CastMember e => new Action<T>(_ => _castMember.Add(e)),
            _ => throw new ArgumentException($"type '{typeof(T).Name}' is not supported.")
        })(entity);
    }


    public void Set<T>(T entity) where T : Entity
    {
        (entity switch
        {
            Category e => new Action<T>(_ => _categories.Add(e)),
            Genre e => new Action<T>(_ => _genre.Add(e)),
            CastMember e => new Action<T>(_ => _castMember.Add(e)),
            _ => throw new ArgumentException($"type '{typeof(T).Name}' is not supported.")
        })(entity);
    }
}