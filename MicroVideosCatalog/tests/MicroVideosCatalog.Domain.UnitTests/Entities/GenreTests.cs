namespace MicroVideosCatalog.Domain.UnitTests.Entities;

public class GenreTests
{
    [Fact]
    [Trait("Genre", "Domain/Entities")]
    public void Constructor_ValidParameters_ShouldCreateGenre()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Horror");
        //Act
        var genre = new Genre(id, name);
        //Assert
        genre.Should().NotBeNull();
    }

    [Fact]
    [Trait("Genre", "Domain/Entities")]
    public void SetName_InvalidParameter_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Horror");
        Genre g = new(id, name);
        var errorMsg = "'name' cannot be empty or null";
        //Act
        //Assert
        g.Should().NotBeNull();
        g.Should().Invoking(_ => g.SetName(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg);
        g.Should().Invoking(_ => g.SetName("")).Should().Throw<ArgumentException>().WithMessage(errorMsg);
    }

    [Fact]
    [Trait("Genre", "Domain/Entities")]
    public void SetId_InvalidParameter_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Horror");
        Genre g = new(id, name);
        var errorMsg1 = "'id' cannot be empty or null";
        var errorMsg2 = "'id' is not a valid Guid";
        //Act
        //Assert
        g.Should().NotBeNull();
        g.Should().Invoking(_ => g.SetId(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        g.Should().Invoking(_ => g.SetId("")).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        g.Should().Invoking(_ => g.SetId(Guid.Empty)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
    }

    [Fact]
    [Trait("Genre", "Domain/Entities")]
    public void AddCategory_InvalidCategory_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Horror");
        Genre g = new(id, name);
        var errorMsg1 = "'category' cannot be null";
        //Act
        //Assert
        g.Should().NotBeNull();
        g.Should().Invoking(_ => g.AddCategory(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
    }

    [Fact]
    [Trait("Genre", "Domain/Entities")]
    public void RemoveCategory_InvalidCategory_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Horror");
        Genre g = new(id, name);
        var errorMsg1 = "'category' cannot be null";
        //Act
        //Assert
        g.Should().NotBeNull();
        g.Should().Invoking(_ => g.RemoveCategory(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
    }

    [Fact]
    [Trait("Genre", "Domain/Entities")]
    public void SetCategories_InvalidCategories_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Horror");
        Genre g = new(id, name);
        var errorMsg1 = "'categories' cannot be empty or null";
        //Act
        //Assert
        g.Should().NotBeNull();
        g.Should().Invoking(_ => g.SetCategories(new List<Category>())).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        g.Should().Invoking(_ => g.SetCategories(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
    }
}