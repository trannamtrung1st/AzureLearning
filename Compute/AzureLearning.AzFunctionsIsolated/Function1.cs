using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;

namespace AzureLearning.AzFunctionsIsolated
{
    public class Function1
    {
        private readonly ILogger _logger;
        private string Author { get; }
        private readonly MyService _myService;

        public Function1(
            ILoggerFactory loggerFactory,
            IConfiguration configuration,
            MyService myService)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            Author = configuration["Author"];
            _myService = myService;
        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString($"Welcome to Azure Functions! {Author} {_myService.GetValue()}");

            return response;
        }
    }
}
