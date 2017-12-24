using System;
using FFRK.Api.Infra.Options.EnlirETL;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FunctionApp.ETL
{
    public class InjectConfiguration : IExtensionConfigProvider
    {
        #region Class Variables
        private IServiceProvider _serviceProvider;
        #endregion

        public void Initialize(ExtensionConfigContext context)
        {
            var services = new ServiceCollection();

            Startup startup = new Startup();

            startup.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider(true);

            context
                .AddBindingRule<InjectAttribute>()
                .Bind(new InjectBindingProvider(serviceProvider));


            var registry = context.Config.GetService<IExtensionRegistry>();
            var filter = new ScopeCleanupFilter();

            registry.RegisterExtension(typeof(IFunctionInvocationFilter), filter);
            registry.RegisterExtension(typeof(IFunctionExceptionFilter), filter);
        }
    
        //public void Initialize(ExtensionConfigContext context)
        //{
        //    //InitializeConfiguration();

        //    var services = new ServiceCollection();

        //    Startup startup = new Startup();

        //    startup.ConfigureServices(services);

        //    //RegisterServices(services);
        //    _serviceProvider = services.BuildServiceProvider(true);

        //    IOptions<SheetsServiceOptions> options =
        //        _serviceProvider.GetRequiredService<IOptions<SheetsServiceOptions>>();


        //    context
        //        .AddBindingRule<InjectAttribute>()
        //        .BindToInput<dynamic>(i => _serviceProvider.GetRequiredService(i.Type));
        //}

    }
}