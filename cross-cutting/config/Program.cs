using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


// todo : https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-5.0
// todo: optionbuilder
// todo: monior options
// todo: snapshot options
// todo: vaidation on annotation options
// todo: call service when creating theoptions
// todo: Implement IValidateOptions
// todo: post configuration
// todo: accessing option during startup

namespace config
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationBuilder builder = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json");
                            //        .AddJsonFile($"appsettings.{environment}.json", true, true);
            IConfiguration config = builder.Build();
            Console.WriteLine("config-> GetSection -> value" + config.GetValue<String>("Logging:Level"));

            LogConfig logConfig = new LogConfig();
            ConfigurationBinder.Bind(config.GetSection("Logging"), logConfig);
            Console.WriteLine("Typed configuration -> " + logConfig.Level);

            // additing to the service provider with Ioptions
              var serviceProvider = new ServiceCollection()
                .Configure<LogConfig>(config.GetSection("Logging"))
                .BuildServiceProvider();
        }
    }

    class LogConfig {
        public string Level {get;set;}
    }

}
