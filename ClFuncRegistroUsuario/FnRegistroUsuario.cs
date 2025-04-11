using System.Text.Json;
using Application.UseCases.RegistroUsuario;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ClFuncRegistroUsuario
{
    public class FnRegistroUsuario
    {
        private readonly ILogger<FnRegistroUsuario> _logger;

        private readonly ISender _sender;


        public FnRegistroUsuario(ILogger<FnRegistroUsuario> logger, ISender _sender)
        {
            _logger = logger;
            this._sender = _sender;
        }

        [Function("FnRegistroUsuario")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {

            try
            {
                _logger.LogInformation("C# HTTP trigger function processed a request.");

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var data = JsonSerializer.Deserialize<UsuarioRequest>(requestBody);

                if (data is null)
                {
                    return new BadRequestResult();
                }
                var user = await _sender.Send(data);

                _logger.LogInformation("function process with success.");
                return new OkObjectResult(user);

            }
            catch (Exception ex)
            {
                var message = ex.Message ?? ex.InnerException.Message;                
                _logger.LogError("error: "+ message);
            }

            return null;
        }
    }
}
