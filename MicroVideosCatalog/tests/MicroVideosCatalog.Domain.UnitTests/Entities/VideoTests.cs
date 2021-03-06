namespace MicroVideosCatalog.Domain.UnitTests.Entities;
public class VideoTests
{
    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void Constructor_ValidParams_ShouldCreateVideo()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        //Act
        var v = new Video(title, desc, year, open);
        //Assert
        v.Should().NotBeNull();
    }

    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void SetId_InvalidGuidParams_ShouldThrowArgumentException()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        Video v = new(title, desc, year, open);
        var errorMsg1 = "'id' cannot be empty or null";
        var errorMsg2 = "'id' is not a valid Guid";
        //Act
        //Assert
        v.Should().NotBeNull();
        v.Should().Invoking(_ => v.SetId(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        v.Should().Invoking(_ => v.SetId("")).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        v.Should().Invoking(_ => v.SetId(Guid.Empty)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
    }

    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void SetTitle_InvalidTitleParams_ShouldThrowArgumentException()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        Video v = new(title, desc, year, open);
        var errorMsg = "'title' cannot be empty or null";
        //Act
        //Assert
        v.Should().NotBeNull();
        v.Should().Invoking(_ => v.SetTitle(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg);
        v.Should().Invoking(_ => v.SetTitle("")).Should().Throw<ArgumentException>().WithMessage(errorMsg);
    }

    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void SetYearLaunched_InvalidYearLaunchedParams_ShouldThrowArgumentException()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        Video v = new(title, desc, year, open);
        var errorMsg1 = "'yearLaunched' must be greater than 1700";
        var errorMsg2 = "'yearLaunched' is greater than current year";
        var invalidFutureDate = DateTime.Now.AddYears(1).Year;
        //Act
        //Assert
        v.Should().NotBeNull();
        v.Should().Invoking(_ => v.SetYearLaunched(1600)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        v.Should().Invoking(_ => v.SetYearLaunched(invalidFutureDate)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
    }

    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void AddT_ValidAndUniqueEntitiesParams_ShouldAddEntitiesToTheirLists()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        var video = new Video(title, desc, year, open);

        var category = new Category("Film");
        var genre = new Genre("Action");
        var castMember = new CastMember("DiCaprio", ECastMemberType.Type1);
        //Act
        video.Add(category);
        video.Add(genre);
        video.Add(genre);
        video.Add(castMember);
        video.Add(castMember);
        video.Add(castMember);
        //Assert
        video.Should().NotBeNull();
        video.Categories.Should().NotBeEmpty().And.HaveCount(1);
        video.Genres.Should().NotBeEmpty().And.HaveCount(1);
        video.CastMembers.Should().NotBeEmpty().And.HaveCount(1);
    }

    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void AddT_InvalidNullEntitiesParams_ShouldThrowArgumentException()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        Video v = new(title, desc, year, open);

        Category category = null;
        Genre genre = null;
        CastMember castMember = null;
        //Act
        var errorMsg1 = $"'{typeof(Category).Name}' cannot be null";
        var errorMsg2 = $"'{typeof(Genre).Name}' cannot be null";
        var errorMsg3 = $"'{typeof(CastMember).Name}' cannot be null";
        //Assert
        v.Should().NotBeNull();
        v.Should().Invoking(_ => v.Add(category)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        v.Should().Invoking(_ => v.Add(genre)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
        v.Should().Invoking(_ => v.Add(castMember)).Should().Throw<ArgumentException>().WithMessage(errorMsg3);
    }

    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void RemoveT_ValidEntitiesParams_ShouldRemoveEntitiesFromTheirLists()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        var video = new Video(title, desc, year, open);

        var category = new Category("Film");
        var genre = new Genre("Action");
        var castMember = new CastMember("DiCaprio", ECastMemberType.Type1);
        video.Add(category);
        video.Add(genre);
        video.Add(castMember);
        //Act
        video.Remove(category);
        video.Remove(genre);
        video.Remove(castMember);
        video.Remove(castMember);
        //Assert
        video.Should().NotBeNull();
        video.Categories.Should().BeEmpty();
        video.Genres.Should().BeEmpty();
        video.CastMembers.Should().BeEmpty();
    }
    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void RemoveT_InvalidNullParams_ShouldThrowArgumentException()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        Video v = new(title, desc, year, open);

        Category category = null;
        Genre genre = null;
        CastMember castMember = null;
        //Act
        var errorMsg1 = $"'{typeof(Category).Name}' cannot be null";
        var errorMsg2 = $"'{typeof(Genre).Name}' cannot be null";
        var errorMsg3 = $"'{typeof(CastMember).Name}' cannot be null";
        //Assert
        v.Should().NotBeNull();
        v.Should().Invoking(_ => v.Remove(category)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        v.Should().Invoking(_ => v.Remove(genre)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
        v.Should().Invoking(_ => v.Remove(castMember)).Should().Throw<ArgumentException>().WithMessage(errorMsg3);
    }
    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void SetT_ValidEntitiesParams_ShouldSetEntitiesToCorrespondingLists()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        var video = new Video(title, desc, year, open);

        var categories = new List<Category> { new("Film1") };
        var genres = new List<Genre> { new("Action1"), new("Action2") };
        var castMembers = new List<CastMember> { new("DiCaprio1", ECastMemberType.Type1), new("DiCaprio2", ECastMemberType.Type1), new("DiCaprio3", ECastMemberType.Type1) };
        //Act
        video.Set(categories);
        video.Set(genres);
        video.Set(castMembers);
        //Assert
        video.Should().NotBeNull();
        video.Categories.Should().NotBeEmpty().And.HaveCount(1);
        video.Genres.Should().NotBeEmpty().And.HaveCount(2);
        video.CastMembers.Should().NotBeEmpty().And.HaveCount(3);
    }
    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void SetT_InvalidNullParams_ShouldThrowArgumentException()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        Video v = new(title, desc, year, open);

        IList<Category> categories = null;
        IList<Genre> genres = null;
        IList<CastMember> castMembers = null;
        //Act
        var errorMsg1 = $"'{typeof(IList<Category>).Name}' cannot be empty or null";
        var errorMsg2 = $"'{typeof(IList<Genre>).Name}' cannot be empty or null";
        var errorMsg3 = $"'{typeof(IList<CastMember>).Name}' cannot be empty or null";
        //Assert
        v.Should().NotBeNull();
        v.Should().Invoking(_ => v.Set(categories)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        v.Should().Invoking(_ => v.Set(genres)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
        v.Should().Invoking(_ => v.Set(castMembers)).Should().Throw<ArgumentException>().WithMessage(errorMsg3);
        v.Should().Invoking(_ => v.Set(new List<Category>())).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        v.Should().Invoking(_ => v.Set(new List<Genre>())).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
        v.Should().Invoking(_ => v.Set(new List<CastMember>())).Should().Throw<ArgumentException>().WithMessage(errorMsg3);
    }
}