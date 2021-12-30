using System;
using FluentAssertions;
using MicroVideosCatalog.Domain.Entities;
using MicroVideosCatalog.Domain.Enums;
using Xunit;

namespace MicroVideosCatalog.Domain.UnitTests.Entities;

public class CastMemberTests
{
    [Fact]
    [Trait("CastMember", "Domain/Entities")]
    public void Constructor_ValidParameters_ShouldCreateCastMember()
    {
        //Arrange
        var (id, name, castMemberType) = (Guid.NewGuid(), "Horror", ECastMemberType.Type1);
        //Act
        var castMember = new CastMember(id, name, castMemberType);
        //Assert
        castMember.Should().NotBeNull();
    }

    [Fact]
    [Trait("CastMember", "Domain/Entities")]
    public void SetName_InvalidParameter_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name, castMember) = (Guid.NewGuid(), "Horror", ECastMemberType.Type1);
        CastMember c = new(id, name, castMember);
        var errorMsg = "'name' cannot be empty or null";
        //Act
        //Assert
        c.Should().Invoking(_ => c.SetName(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg);
        c.Should().Invoking(_ => c.SetName("")).Should().Throw<ArgumentException>().WithMessage(errorMsg);
    }

    [Fact]
    [Trait("CastMember", "Domain/Entities")]
    public void SetId_InvalidParameter_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name, castMember) = (Guid.NewGuid(), "Horror", ECastMemberType.Type1);
        CastMember c = new(id, name, castMember);
        var errorMsg1 = "'id' cannot be empty or null";
        var errorMsg2 = "'id' cannot have a default value";
        //Act
        //Assert
        c.Should().Invoking(_ => c.SetId(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        c.Should().Invoking(_ => c.SetId("")).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        c.Should().Invoking(_ => c.SetId(Guid.Empty)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
    }

    [Fact]
    [Trait("CastMember", "Domain/Entities")]
    public void SetCastMemberType_InvalidParameter_ShouldThrowArgumentException()
    {
        //Arrange
        var (id, name, castMember) = (Guid.NewGuid(), "Horror", ECastMemberType.Type1);
        CastMember c = new(id, name, castMember);
        var errorMsg1 = "'castMemberType' cannot be empty or null";
        var invalidMemberType = "Type3";
        var errorMsg2 = $"'{invalidMemberType}' cannot be parsed as 'ECastMemberType'";
        //Act
        //Assert
        c.Should().Invoking(_ => c.SetCastMemberType(null)).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        c.Should().Invoking(_ => c.SetCastMemberType("")).Should().Throw<ArgumentException>().WithMessage(errorMsg1);
        c.Should().Invoking(_ => c.SetCastMemberType(invalidMemberType)).Should().Throw<ArgumentException>().WithMessage(errorMsg2);
    }
}