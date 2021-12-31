namespace MicroVideosCatalog.Domain.UnitTests.Entities;

public class CategoryTests
{
    [Fact]
    [Trait("Category", "Domain/Entities")]
    public void Constructor_ValidParams_ShouldCreateCategory()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Movie");
        //Act
        var category = new Category(id, name);
        //Assert
        category.Should().NotBeNull();
    }

    [Fact]
    [Trait("Category", "Domain/Entities")]
    public void SetName_InvalidNameParams_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Movie");
        Category c = new(id, name);
        //Act
        var errorMsg = "'name' cannot be empty or null";
        //Assert
        c.Should().NotBeNull();
        c.Should().Invoking(_ => c.SetName(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg);
        c.Should().Invoking(_ => c.SetName("")).Should().Throw<ArgumentException>().WithMessage(errorMsg);
    }

    [Fact]
    [Trait("Category", "Domain/Entities")]
    public void SetId_InvalidGuidParams_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Movie");
        Category c = new(id, name);
        var errorMsg1 = "'id' cannot be empty or null";
        var errorMsg2 = "'id' is not a valid Guid";
        //Act
        //Assert
        c.Should().NotBeNull();
        c.Should().Invoking(_ => c.SetId(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        c.Should().Invoking(_ => c.SetId("")).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        c.Should().Invoking(_ => c.SetId(Guid.Empty)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
    }
}