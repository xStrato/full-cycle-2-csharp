namespace MicroVideosCatalog.Domain.UnitTests.Entities;
public class VideoTests
{
    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void Constructor_ValidParameters_ShouldCreateVideo()
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
    public void SetId_InvalidParameter_ShouldThrowArgumentException()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        Video v = new(title, desc, year, open);
        var errorMsg1 = "'id' cannot be empty or null";
        var errorMsg2 = "'id' cannot have a default value";
        //Act
        //Assert
        v.Should().NotBeNull();
        v.Should().Invoking(_ => v.SetId(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        v.Should().Invoking(_ => v.SetId("")).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        v.Should().Invoking(_ => v.SetId(Guid.Empty)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
    }

    [Fact]
    [Trait("Video", "Domain/Entities")]
    public void SetTitle_InvalidParameter_ShouldThrowArgumentException()
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
    public void SetYearLaunched_InvalidParameter_ShouldThrowArgumentException()
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
    public void AddT_ValidParameter_ShouldAddEntitiesToTheirLists()
    {
        //Arrange
        var (title, desc, year, open) = ("Inception", "A intriguing movie indeed", 1990, true);
        var video = new Video(title, desc, year, open);

        var category = new Category("Film");
        var genre = new Genre("Action");
        var castMember = new CastMember("Di Caprio", ECastMemberType.Type1);
        //Act
        video.Add(category);
        video.Add(genre);
        video.Add(castMember);
        //Assert
        video.Should().NotBeNull();
        video.Categories.Should().NotBeEmpty().And.HaveCount(1);
        video.Genres.Should().NotBeEmpty().And.HaveCount(1);
        video.CastMembers.Should().NotBeEmpty().And.HaveCount(1);
    }
}