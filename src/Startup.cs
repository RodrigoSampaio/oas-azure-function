using AzureFunctions.Extensions.Swashbuckle;
using DemoApp;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System.Reflection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace DemoApp
{
    internal class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddSwashBuckle(Assembly.GetExecutingAssembly());
        }
    }
}
