namespace configurationtest01
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;

    internal class Program
    {
        static void Main(string[] args)
        {
            ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = factory.CreateLogger("Program");

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
            logger.LogInformation("environment is {Description}.", environment);

            IConfigurationRoot config = new ConfigurationBuilder()
                    .AddJsonFile($"appsettings.{environment}.json", optional: true)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

            logger.LogInformation("Hello World! Logging is {Description}.", config["JAVA_HOME"]);
            logger.LogInformation("Hello World! Logging is {Description}.", config["Logging:LogLevel:Default"]);

            Console.WriteLine("Hello, World!");
        }
    }
}
