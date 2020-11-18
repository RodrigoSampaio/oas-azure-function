using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoApp
{
    public static class SwaggerFunctions
    {
        [SwaggerIgnore]
        [FunctionName("SwaggerFile")]
        public static Task<HttpResponseMessage> SwaggerFile(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "doc/yaml")]
            HttpRequestMessage req,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient,
            ExecutionContext context)
        {
            var oas = Path.Combine(context.FunctionAppDirectory, "oas.yaml");
            var stream = new FileStream(oas, FileMode.Open);
            var httpResponseMessage = new HttpResponseMessage()
            {
                Content = new StreamContent(stream)
            };
            return Task.FromResult(httpResponseMessage);
        }

        [SwaggerIgnore]
        [FunctionName("SwaggerUi")]
        public static Task<HttpResponseMessage> SwaggerUi(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "doc")]
            HttpRequestMessage req,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerUIResponse(req, "doc/yaml "));
        }
    }
}
