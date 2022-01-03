namespace MicroVideosCatalog.Application.UnitTests.Categories.Handlers;
public class CategoryCommandHandlerTests
{
    private List<Category> _categories { get; set; }
    private Mock<ICategoryRepository> _categoryRepository { get; init; }
    private CategoryCommandHandler _handler { get; init; }

    public CategoryCommandHandlerTests()
    {
        _categories = new List<Category>
        {
            new("Movie"),
            new("Vlog"),
            new("Serie"),
            new("Documentary"),
            new("Animation")
        };

        var mock = new AutoMocker();
        _handler = mock.CreateInstance<CategoryCommandHandler>();
        _categoryRepository = mock.GetMock<ICategoryRepository>();

        _categoryRepository.Setup(r => r.UnitOfWork.Commit()).ReturnsAsync(true);
        _categoryRepository.Setup(r => r.AddAsync(It.IsAny<Category>(), CancellationToken.None))
            .Callback<Category, CancellationToken>((t, _) => _categories.Add(t));
    }

    [Fact]
    [Trait("CategoryCommandHandler", "Application/Categories/Handlers")]
    public async Task HandleAsync_ValidCreateCategoryCommandParams_ShouldCreateAndPersistCommand()
    {
        //Arrange
        var command = new CreateCategoryCommand("Movie");
        Category createdCategory = null;
        _categoryRepository.Setup(r => r.AddAsync(It.IsAny<Category>(), CancellationToken.None))
            .Callback<Category, object>((t, _) => { createdCategory = t; _categories.Add(t); });
        //Act
        var result = await _handler.HandleAsync(command, CancellationToken.None);
        //Assert
        createdCategory.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Message.Should().Be(string.Format("{0} was successfully executed", command.CommandType));
        result.Data.Should().NotBeNull().And.BeOfType<Category>();
        _categories.Should().HaveCount(6);
        _categoryRepository.Verify(r => r.UnitOfWork.Commit(), Times.Once);
        _categoryRepository.Verify(r => r.AddAsync(createdCategory, CancellationToken.None), Times.Once);
    }

    [Fact]
    [Trait("CategoryCommandHandler", "Application/Categories/Handlers")]
    public async Task HandleAsync_InvalidCreateCategoryCommandParams_ShouldReturnSuccessFalse()
    {
        //Arrange
        var command = new CreateCategoryCommand("Mo");
        //Act
        var result = await _handler.HandleAsync(command, CancellationToken.None);
        //Assert
        result.Success.Should().BeFalse();
        result.Message.Should().Be(string.Format("{0} state is invalid", command.CommandType));
        result.Data.Should().NotBeNull().And.BeOfType<List<(string, string)>>();
        _categories.Should().HaveCount(5);
        _categoryRepository.Verify(r => r.UnitOfWork.Commit(), Times.Never);
        _categoryRepository.Verify(r => r.AddAsync(It.IsAny<Category>(), CancellationToken.None), Times.Never);
    }
}