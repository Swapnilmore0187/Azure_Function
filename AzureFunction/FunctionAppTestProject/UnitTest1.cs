using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FunctionApp.Tests;

public class FunctionAppTestProject
{
    [Fact]
    public void Run_Returns_OkObjectResult_WithExpectedGreeting()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<Function1>>();
        var function = new Function1(mockLogger.Object);

        var context = new DefaultHttpContext();
        HttpRequest request = context.Request;

        // Act
        IActionResult result = function.Run(request);

        // Assert
        var ok = Assert.IsType<OkObjectResult>(result);
        var content = Assert.IsType<string>(ok.Value);
        Assert.StartsWith("Welcome to Azure Functions!", content);
    }

    //[Fact]
    //public void Run_LogsInformation_Once()
    //{
    //    // Arrange
    //    var mockLogger = new Mock<ILogger<Function1>>();
    //    var function = new Function1(mockLogger.Object);

    //    var context = new DefaultHttpContext();
    //    HttpRequest request = context.Request;

    //    // Act
    //    function.Run(request);

    //    // Assert: verify that a Log with LogLevel.Information was written once.
    //    mockLogger.Verify(
    //        x => x.Log(
    //            It.Is<LogLevel>(l => l == LogLevel.Information),
    //            It.IsAny<EventId>(),
    //            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("C# HTTP trigger function processed a request.")),
    //            It.IsAny<Exception>(),
    //            It.IsAny<Func<object, Exception, string>>()),
    //        Times.Once);
    //}
}