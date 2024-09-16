using FluentAssertions;

namespace FastProjects.ResultPattern.UnitTests;

public class ResultExtensionsTests
{
    [Fact]
    public void IsOk_ReturnsTrue_WhenStatusIsOk()
    {
        // Arrange
        //Act
        var result = Result.Success();
        
        // Assert
        result.IsOk().Should().BeTrue();
    }
    
    [Fact]
    public void IsCreated_ReturnsTrue_WhenStatusIsCreated()
    {
        // Arrange
        //Act
        var result = Result.Created();
        
        // Assert
        result.IsCreated().Should().BeTrue();
    }
    
    [Fact]
    public void IsError_ReturnsTrue_WhenStatusIsError()
    {
        // Arrange
        //Act
        var result = Result.Error();
        
        // Assert
        result.IsError().Should().BeTrue();
    }
    
    [Fact]
    public void IsForbidden_ReturnsTrue_WhenStatusIsForbidden()
    {
        // Arrange
        //Act
        var result = Result.Forbidden();
        
        // Assert
        result.IsForbidden().Should().BeTrue();
    }
    
    [Fact]
    public void IsUnauthorized_ReturnsTrue_WhenStatusIsUnauthorized()
    {
        // Arrange
        //Act
        var result = Result.Unauthorized();
        
        // Assert
        result.IsUnauthorized().Should().BeTrue();
    }
    
    [Fact]
    public void IsInvalid_ReturnsTrue_WhenStatusIsInvalid()
    {
        // Arrange
        //Act
        var result = Result.Invalid();
        
        // Assert
        result.IsInvalid().Should().BeTrue();
    }
    
    [Fact]
    public void IsNotFound_ReturnsTrue_WhenStatusIsNotFound()
    {
        // Arrange
        //Act
        var result = Result.NotFound();
        
        // Assert
        result.IsNotFound().Should().BeTrue();
    }
    
    [Fact]
    public void IsNoContent_ReturnsTrue_WhenStatusIsNoContent()
    {
        // Arrange
        //Act
        var result = Result.NoContent();
        
        // Assert
        result.IsNoContent().Should().BeTrue();
    }
    
    [Fact]
    public void IsConflict_ReturnsTrue_WhenStatusIsConflict()
    {
        // Arrange
        //Act
        var result = Result.Conflict();
        
        // Assert
        result.IsConflict().Should().BeTrue();
    }
    
    [Fact]
    public void IsCriticalError_ReturnsTrue_WhenStatusIsCriticalError()
    {
        // Arrange
        //Act
        var result = Result.CriticalError();
        
        // Assert
        result.IsCriticalError().Should().BeTrue();
    }
    
    [Fact]
    public void IsUnavailable_ReturnsTrue_WhenStatusIsUnavailable()
    {
        // Arrange
        //Act
        var result = Result.Unavailable();
        
        // Assert
        result.IsUnavailable().Should().BeTrue();
    }
}
