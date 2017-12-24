using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionApp.ETL.DISupport
{
    public class InjectBinding : IBinding
    {
        private readonly Type _type;
        private readonly IServiceProvider _serviceProvider;


        public InjectBinding(IServiceProvider serviceProvider, Type type)
        {
            _type = type;
            _serviceProvider = serviceProvider;
        }

        public bool FromAttribute => true;

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context) => Task.FromResult((IValueProvider)new InjectValueProvider(value));

        public async Task<IValueProvider> BindAsync(BindingContext context)
        {
            await Task.Yield();

            var scope = InjectBindingProvider.Scopes.GetOrAdd(context.FunctionInstanceId, (_) => ServiceProviderServiceExtensions.CreateScope(_serviceProvider));
            var value = ServiceProviderServiceExtensions.GetRequiredService(scope.ServiceProvider, _type);

            return await BindAsync(value, context.ValueContext);
        }

        public ParameterDescriptor ToParameterDescriptor() => new ParameterDescriptor();

        private class InjectValueProvider : IValueProvider
        {
            private readonly object _value;

            public InjectValueProvider(object value) => _value = value;

            public Type Type => _value.GetType();

            public Task<object> GetValueAsync() => Task.FromResult<object>(_value);

            public string ToInvokeString() => _value.ToString();
        }
    }
}
