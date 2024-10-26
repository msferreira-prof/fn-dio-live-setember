using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MyExample.Function
{
    public class HttpTriggerExample
    {
        private readonly ILogger<HttpTriggerExample> _logger;

        public HttpTriggerExample(ILogger<HttpTriggerExample> logger)
        {
            _logger = logger;
        }

        [Function("HttpTriggerExample")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            string nome = req.Query["nome"];
            if (string.IsNullOrWhiteSpace(nome)) {
                return new BadRequestObjectResult("Por favor, informe o nome!");
            }



            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult($"Bem-vindo ao Azure Functions on DIO, {nome}!");
        }
    }
}
