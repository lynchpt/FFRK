using System;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionApp.ETL.DISupport
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
    }
}