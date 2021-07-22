using System;
using Microsoft.Extensions.Logging;
namespace logging
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("logging application");
   
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                 builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                .AddConsole()
                .AddEventLog();
            });

        ILogger logger = loggerFactory.CreateLogger<Program>();
        logger.LogInformation("Example log message");

        // using events
        // log event id
        // each log can add event id as addition parameter
        int eventid = 100;
        logger.LogWarning(MyLogEvents.GetItemNotFound, "Get({Id}) NOT FOUND", eventid); 
        // event id is defined in application and unique id to classify the logs

        //using template message
        string apples = 1;
        string pears = 2;
        string bananas = 3;
        _logger.LogInformation("Parameters: {pears}, {bananas}, {apples}", apples, pears, bananas);
        // notes placeholders will be replaced based on order so message will be 
        // Parameters: 1, 2, 3


        // log level
        // Trace = 0, Debug = 1, Information = 2, Warning = 3, Error = 4, Critical = 5, and None = 6.

        // log providers 
        // console, debug, Event source, EventLog, AzureAppServicesFile, AzureAppServicesBlob,ApplicationInsights

        // log level can be set using environment variables 
        // setx Logging__LogLevel__Microsoft.Hosting.Lifetime=Trace /M

        //To specify the category as class name 
        //  inject  ILogger<PrivacyModel> logfactory directory
        // to spcify arbitory category
        //  inject ILoggerFactory logfactory
        //   _logger = logfactory.CreateLogger("MyCategory");

        //  using (_logger.BeginScope("using block message"))
        // {
            // used to group the logs
        // }

        }

    }

}
