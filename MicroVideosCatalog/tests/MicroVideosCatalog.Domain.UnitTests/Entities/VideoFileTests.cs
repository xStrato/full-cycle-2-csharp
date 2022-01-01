namespace MicroVideosCatalog.Domain.UnitTests.Entities;

public class VideoFileTests
{
    [Fact]
    [Trait("VideoFile", "Domain/Entities")]
    public void Constructor_ValidParams_ShouldCreateVideoFile()
    {
        //Arrange
        var (id, title, duaration) = (Guid.NewGuid(), "Inception.mp4", 1.30f);
        //Act
        var videoFile = new VideoFile(id, title, duaration);
        //Assert
        videoFile.Should().NotBeNull();
    }
    [Fact]
    [Trait("VideoFile", "Domain/Entities")]
    public void SetId_InvalidGuidParams_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, title, duaration) = (Guid.NewGuid(), "Inception.mp4", 1.30f);
        //Act
        var vf = new VideoFile(id, title, duaration);
        var errorMsg1 = "'id' cannot be empty or null";
        var errorMsg2 = "'id' is not a valid Guid";
        //Act
        //Assert
        vf.Should().NotBeNull();
        vf.Should().Invoking(_ => vf.SetId(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        vf.Should().Invoking(_ => vf.SetId("")).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        vf.Should().Invoking(_ => vf.SetId(Guid.Empty)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
    }
    [Fact]
    [Trait("VideoFile", "Domain/Entities")]
    public void SetTitle_InvalidNullAndEmptyParams_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, title, duaration) = (Guid.NewGuid(), "Inception.mp4", 1.30f);
        //Act
        var vf = new VideoFile(id, title, duaration);
        var errorMsg = "'title' cannot be empty or null";
        //Act
        //Assert
        vf.Should().NotBeNull();
        vf.Should().Invoking(_ => vf.SetTitle(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg);
        vf.Should().Invoking(_ => vf.SetTitle("")).Should().Throw<ArgumentException>().WithMessage(errorMsg);
    }
}