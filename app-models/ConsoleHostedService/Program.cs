using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace confg1
{
    class Program
    {
        static async Task  Main(string[] args)
        {
            await Host
            .CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(configHost => {})
            .ConfigureAppConfiguration((hostContext, configApp) => {})
            .ConfigureServices((hostContext, services) => {

                 services.AddHostedService<ConsoleHostedService>();
            })
            .ConfigureLogging((hostContext, configLogging) => {})
            .UseConsoleLifetime()
            .RunConsoleAsync();
            //.Build();



            // using (var scope = host.Services.CreateScope())
            // {
            //        Console.WriteLine("Hello World!");

            //        //  var myAppService = scope.ServiceProvider.GetService(typeof(IMyAppServiceToRun)) as IMyAppServiceToRun; //Use IHost DI container to obtain instance of service to run & resolve all dependencies
            //        // await myAppService.StartAsync(CancellationToken.None); // Execute your task here
            // }


             //    await host.RunConsoleAsync();

            //  await host.RunAsync();
            
        }

    } 
}
