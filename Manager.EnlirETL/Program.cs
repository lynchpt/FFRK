using System;
using System.IO;
using FFRK.Api.Infra.Options.EnlirETL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.SystemConsole.Themes;

namespace Manager.EnlirETL
{
    public class Program
    {
        #region Class Variables
        private static IConfiguration _configuration;
        private static IServiceCollection _serviceCollection;
        private static IServiceProvider _services;
        #endregion

        #region Constants

        private const string EnvironmentIndicatingEnvironmentVariable = "ASPNETCORE_ENVIRONMENT";
        private const string LocalEnvironmentKey = "local";
        private const string ConfigFileName = "config";
        private const string ConfigFileExtension = "json";
        #endregion

        #region Main Entry Point
        static void Main(string[] args)
        {
            //this must be first because other methods have dependencies on it.
            LoadConfiguration();

            ConfigureServiceCollection();

            ConfigureLogger();

            ConfigureServices();

            IApplication application = _services.GetService<IApplication>();

            application.Run();
        } 
        #endregion


        #region Private Configuration Methods
        private static void LoadConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable(EnvironmentIndicatingEnvironmentVariable);


            if (environmentName == LocalEnvironmentKey)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"{ConfigFileName}.{environmentName}.{ConfigFileExtension}", optional: true);

                _configuration = builder.Build();
            }
            else
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"{ConfigFileName}.{ConfigFileExtension}", optional: true);

                _configuration = builder.Build();
            }


        }

        private static void ConfigureServiceCollection()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddOptions();

            _serviceCollection = serviceCollection;
        }

        private static void ConfigureLogger()
        {
            string rollingFileLogPath = _configuration.GetSection($"{nameof(LoggingOptions)}:{nameof(LoggingOptions.LogFilePath)}").Value;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(rollingFileLogPath).MinimumLevel.Information()
                .WriteTo.Console(theme: SystemConsoleTheme.Literate).MinimumLevel.Information()
                .WriteTo.Debug().MinimumLevel.Debug()
                .CreateLogger();

            _serviceCollection.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
        }

        private static void ConfigureServices()
        {

            _serviceCollection.Configure<ApplicationOptions>(_configuration.GetSection(nameof(ApplicationOptions)));
            _serviceCollection.Configure<LoggingOptions>(_configuration.GetSection(nameof(LoggingOptions)));


            _serviceCollection.AddSingleton<IServiceCollection>(_serviceCollection);
            _serviceCollection.AddSingleton<IConfiguration>(_configuration);
            _serviceCollection.AddScoped<IApplication, Application>();

            _services = _serviceCollection.BuildServiceProvider();

        } 
        #endregion
    }
}
