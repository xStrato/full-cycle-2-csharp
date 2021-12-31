namespace MicroVideosCatalog.Domain.UnitTests.Entities;

public class CategoryTests
{
    [Fact]
    [Trait("Category", "Domain/Entities")]
    public void Constructor_ValidParameters_ShouldCreateCategory()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Horror");
        //Act
        var category = new Category(id, name);
        //Assert
        category.Should().NotBeNull();
    }

    [Fact]
    [Trait("Category", "Domain/Entities")]
    public void SetName_InvalidParameter_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Horror");
        Category c = new(id, name);
        //Act
        var errorMsg = "'name' cannot be empty or null";
        //Assert
        c.Should().Invoking(_ => c.SetName(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg);
        c.Should().Invoking(_ => c.SetName("")).Should().Throw<ArgumentException>().WithMessage(errorMsg);
    }

    [Fact]
    [Trait("Category", "Domain/Entities")]
    public void SetId_InvalidParameter_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Horror");
        Category c = new(id, name);
        var errorMsg1 = "'id' cannot be empty or null";
        var errorMsg2 = "'id' is not a valid Guid";
        //Act
        //Assert
        c.Should().Invoking(_ => c.SetId(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        c.Should().Invoking(_ => c.SetId("")).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        c.Should().Invoking(_ => c.SetId(Guid.Empty)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
    }
}