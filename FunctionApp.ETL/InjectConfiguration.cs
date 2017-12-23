using System;
using FFRK.Api.Infra.Options.EnlirETL;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FunctionApp.ETL
{
    public class InjectConfiguration : IExtensionConfigProvider
    {
        private IServiceProvider _serviceProvider;
        private IConfiguration _configuration;

        private const string EnvironmentIndicatingEnvironmentVariable = "ASPNETCORE_ENVIRONMENT";
        private const string LocalEnvironmentKey = "local";
        private const string ConfigFileName = "config";
        private const string ConfigFileExtension = "json";

        public void Initialize(ExtensionConfigContext context)
        {
            InitializeConfiguration();

            var services = new ServiceCollection();
            RegisterServices(services);
            _serviceProvider = services.BuildServiceProvider(true);

            IOptions<SheetsServiceOptions> options =
                _serviceProvider.GetRequiredService<IOptions<SheetsServiceOptions>>();

            context
                .AddBindingRule<InjectAttribute>()
                .BindToInput<dynamic>(i => _serviceProvider.GetRequiredService(i.Type));
        }

        private void InitializeConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable(EnvironmentIndicatingEnvironmentVariable);

            string dir = Environment.CurrentDirectory;

            if (environmentName == LocalEnvironmentKey)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile($"{ConfigFileName}.{environmentName}.{ConfigFileExtension}", optional: true);

                _configuration = builder.Build();
            }
            else
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile($"{ConfigFileName}.{ConfigFileExtension}", optional: true);

                _configuration = builder.Build();
            }
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddOptions();

            // services.AddSingleton<IGreeter, Greeter>();
            string section = _configuration.GetSection(nameof(SheetsServiceOptions)).Path;

            services.Configure<SheetsServiceOptions>(_configuration.GetSection(nameof(SheetsServiceOptions)));

        }
    }
}