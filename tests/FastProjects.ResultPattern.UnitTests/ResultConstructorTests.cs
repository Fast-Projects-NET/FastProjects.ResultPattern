using FluentAssertions;

namespace FastProjects.ResultPattern.UnitTests;

public class ResultConstructorTests
{
    private class TestObject
    {
    }

    [Fact]
    public void Constructor_Should_InitializesStronglyTypedStringValue()
    {
        // Arrange
        const string expectedString = "test";

        // Act
        var result = new Result<string>(expectedString);
        
        // Assert
        result.Value.Should().Be(expectedString);
    }
    
    [Fact]
    public void Constructor_Should_InitializesStronglyTypedIntValue()
    {
        // Arrange
        const int expectedInt = 1;

        // Act
        var result = new Result<int>(expectedInt);
        
        // Assert
        result.Value.Should().Be(expectedInt);
    }
    
    [Fact]
    public void Constructor_Should_InitializesStronglyTypedObjectValue()
    {
        // Arrange
        var expectedObject = new TestObject();

        // Act
        var result = new Result<TestObject>(expectedObject);
        
        // Assert
        result.Value.Should().Be(expectedObject);
    }
    
    [Fact]
    public void Constructor_Should_InitializesStronglyTypedNullValue()
    {
        // Arrange
        object? nullObject = null;

        // Act
        var result = new Result<object>(nullObject!);
        
        // Assert
        result.Value.Should().BeNull();
    }
    
    [Theory]
    [InlineData(123)]
    [InlineData("test value")]
    public void Constructor_Should_InitializesStatusToOkGivenValue(object value)
    {
        // Arrange
        // Act
        var result = new Result<object>(value);
        
        // Assert
        result.Status.Should().Be(ResultStatus.Ok);
        result.Value.Should().Be(value);
    }
    
    [Theory]
    [InlineData(null)]
    public void Constructor_Should_InitializesStatusToOkGivenValue_WhenValueIsNull(object? value)
    {
        // Arrange
        // Act
        var result = new Result<object?>(value);
        
        // Assert
        result.Status.Should().Be(ResultStatus.Ok);
        result.Value.Should().Be(value);
    }
    
    [Theory]
    [InlineData(123)]
    [InlineData("test value")]
    public void Constructor_Should_InitializesValueUsingGenericFactoryMethodAndSetsStatusToOk(object value)
    {
        // Arrange
        // Act
        var result = Result.Success(value);
        
        // Assert
        result.Status.Should().Be(ResultStatus.Ok);
        result.Value.Should().Be(value);
    }
    
    [Theory]
    [InlineData(null)]
    public void Constructor_Should_InitializesValueUsingGenericFactoryMethodAndSetsStatusToOk_WhenValueIsNull(object? value)
    {
        // Arrange
        // Act
        var result = Result.Success(value);
        
        // Assert
        result.Status.Should().Be(ResultStatus.Ok);
        result.Value.Should().Be(value);
    }
    
    [Theory]
    [InlineData(123)]
    [InlineData("test value")]
    public void Created_Should_InitializesValueUsingGenericFactoryMethodAndSetsStatusToCreated(object value)
    {
        // Arrange
        // Act
        var result = Result.Created(value);
        
        // Assert
        result.Status.Should().Be(ResultStatus.Created);
        result.Value.Should().Be(value);
    }
    
    [Theory]
    [InlineData(null)]
    public void Created_Should_InitializesValueUsingGenericFactoryMethodAndSetsStatusToCreated_WhenValueIsNull(object? value)
    {
        // Arrange
        // Act
        var result = Result.Created(value);
        
        // Assert
        result.Status.Should().Be(ResultStatus.Created);
        result.Value.Should().Be(value);
    }
    
    [Fact]
    public void NoContent_Should_InitializesStatusToNoContent()
    {
        // Arrange
        // Act
        var result = Result.NoContent();
        
        // Assert
        result.Status.Should().Be(ResultStatus.NoContent);
    }
    
    [Fact]
    public void Error_Should_InitializesStatusToError()
    {
        // Arrange
        // Act
        var result = Result.Error();
        
        // Assert
        result.Status.Should().Be(ResultStatus.Error);
    }
    
    [Fact]
    public void Error_Should_InitializesStatusToErrorWithMessages()
    {
        // Arrange
        const string errorMessage = "error message";

        // Act
        var result = Result.Error(errorMessage);
        
        // Assert
        result.Status.Should().Be(ResultStatus.Error);
        result.Errors.Should().Contain(errorMessage);
    }
    
    [Fact]
    public void Invalid_Should_InitializesStatusToInvalid()
    {
        // Arrange
        // Act
        var result = Result.Invalid();
        
        // Assert
        result.Status.Should().Be(ResultStatus.Invalid);
    }
    
    [Fact]
    public void Invalid_Should_InitializesStatusToInvalidWithValidationErrors()
    {
        // Arrange
        var validationError = new ValidationError("Validation Error");

        // Act
        var result = Result.Invalid(validationError);
        
        // Assert
        result.Status.Should().Be(ResultStatus.Invalid);
        result.ValidationErrors.Should().Contain(validationError);
    }
    
    [Fact]
    public void NotFound_Should_InitializesStatusToNotFound()
    {
        // Arrange
        // Act
        var result = Result.NotFound();
        
        // Assert
        result.Status.Should().Be(ResultStatus.NotFound);
    }
    
    [Fact]
    public void NotFound_Should_InitializesStatusToNotFoundWithMessages()
    {
        // Arrange
        const string errorMessage = "error message";

        // Act
        var result = Result.NotFound(errorMessage);
        
        // Assert
        result.Status.Should().Be(ResultStatus.NotFound);
        result.Errors.Should().Contain(errorMessage);
    }
    
    [Fact]
    public void Forbidden_Should_InitializesStatusToForbidden()
    {
        // Arrange
        // Act
        var result = Result.Forbidden();
        
        // Assert
        result.Status.Should().Be(ResultStatus.Forbidden);
    }
    
    [Fact]
    public void Forbidden_Should_InitializesStatusToForbiddenWithMessages()
    {
        // Arrange
        const string errorMessage = "error message";

        // Act
        var result = Result.Forbidden(errorMessage);
        
        // Assert
        result.Status.Should().Be(ResultStatus.Forbidden);
        result.Errors.Should().Contain(errorMessage);
    }
    
    [Fact]
    public void Unauthorized_Should_InitializesStatusToUnauthorized()
    {
        // Arrange
        // Act
        var result = Result.Unauthorized();
        
        // Assert
        result.Status.Should().Be(ResultStatus.Unauthorized);
    }
    
    [Fact]
    public void Unauthorized_Should_InitializesStatusToUnauthorizedWithMessages()
    {
        // Arrange
        const string errorMessage = "error message";

        // Act
        var result = Result.Unauthorized(errorMessage);
        
        // Assert
        result.Status.Should().Be(ResultStatus.Unauthorized);
        result.Errors.Should().Contain(errorMessage);
    }
    
    [Fact]
    public void Conflict_Should_InitializesStatusToConflict()
    {
        // Arrange
        // Act
        var result = Result.Conflict();
        
        // Assert
        result.Status.Should().Be(ResultStatus.Conflict);
    }
    
    [Fact]
    public void Conflict_Should_InitializesStatusToConflictWithMessages()
    {
        // Arrange
        const string errorMessage = "error message";

        // Act
        var result = Result.Conflict(errorMessage);
        
        // Assert
        result.Status.Should().Be(ResultStatus.Conflict);
        result.Errors.Should().Contain(errorMessage);
    }
    
    [Fact]
    public void CriticalError_Should_InitializesStatusToCriticalError()
    {
        // Arrange
        // Act
        var result = Result.CriticalError();
        
        // Assert
        result.Status.Should().Be(ResultStatus.CriticalError);
    }
    
    [Fact]
    public void CriticalError_Should_InitializesStatusToCriticalErrorWithMessages()
    {
        // Arrange
        const string errorMessage = "error message";

        // Act
        var result = Result.CriticalError(errorMessage);
        
        // Assert
        result.Status.Should().Be(ResultStatus.CriticalError);
        result.Errors.Should().Contain(errorMessage);
    }
    
    [Fact]
    public void Unavailable_Should_InitializesStatusToUnavailable()
    {
        // Arrange
        // Act
        var result = Result.Unavailable();
        
        // Assert
        result.Status.Should().Be(ResultStatus.Unavailable);
    }
}
