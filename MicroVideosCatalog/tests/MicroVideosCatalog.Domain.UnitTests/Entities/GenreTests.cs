using System;
using FluentAssertions;
using MicroVideosCatalog.Domain.Entities;
using Xunit;

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
        Genre c = new(id, name);
        var errorMsg = "'name' cannot be empty or null";
        //Act
        //Assert
        c.Should().Invoking(_ => c.SetName(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg);
        c.Should().Invoking(_ => c.SetName("")).Should().Throw<ArgumentException>().WithMessage(errorMsg);
    }

    [Fact]
    [Trait("Genre", "Domain/Entities")]
    public void SetId_InvalidParameter_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name) = (Guid.NewGuid(), "Horror");
        Genre c = new(id, name);
        var errorMsg1 = "'id' cannot be empty or null";
        var errorMsg2 = "'id' cannot have a default value";
        //Act
        //Assert
        c.Should().Invoking(_ => c.SetId(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        c.Should().Invoking(_ => c.SetId("")).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        c.Should().Invoking(_ => c.SetId(Guid.Empty)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
    }
}