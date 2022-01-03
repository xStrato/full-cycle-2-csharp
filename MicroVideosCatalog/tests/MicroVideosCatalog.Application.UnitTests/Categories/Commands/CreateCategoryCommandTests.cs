namespace MicroVideosCatalog.Application.UnitTests.Categories.Commands;

public class CreateCategoryCommandTests
{
    [Fact]
    [Trait("CreateCategoryCommand", "Application/Categories/Commands")]
    public void Constructor_ValidCommandParams_ShouldCreateCommand()
    {
        //Arrange
        //Act
        var createCategoryCommand = new CreateCategoryCommand("Movie");
        //Assert
        createCategoryCommand.IsValid().Should().BeTrue();
        createCategoryCommand.GetValidationErros().Should().BeEmpty();
    }

    [Fact]
    [Trait("CreateCategoryCommand", "Application/Categories/Commands")]
    public void Constructor_InvalidCommandParams_ShouldReturnFalse()
    {
        //Arrange 
        //Act
        var createCategoryCommand = new CreateCategoryCommand("Mo");
        //Assert
        createCategoryCommand.IsValid().Should().BeFalse();
        createCategoryCommand.GetValidationErros().Should().NotBeEmpty();
    }
}