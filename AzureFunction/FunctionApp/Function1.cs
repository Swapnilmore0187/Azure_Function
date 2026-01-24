using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function("Function1")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation($"C# HTTP trigger function processed a request.{ DateTime.Now.ToString() }");
       
        return new OkObjectResult($"Welcome to Azure Functions!{DateTime.Now.ToString() }");
    }

//    [Function("TimerFunction")]
//    public void Run(
//    [TimerTrigger("%TIMER_SCHEDULE%", RunOnStartup = true)] TimerInfo myTimer,
//    FunctionContext context
//)
//    {
//        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

//        if (myTimer.IsPastDue)
//        {
//            _logger.LogWarning("The timer is running late!");
//        }
//    }
}