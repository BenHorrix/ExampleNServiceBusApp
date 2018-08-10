using System;
using System.Threading.Tasks;
using NServiceBus;

namespace Common
{
    public static class ServiceBusConfigurationHelper
    {
        public static async Task<IEndpointInstance> ConfigureEndpoint(string endpointName)
        {
            var endpointConfiguration = new EndpointConfiguration(endpointName);
            endpointConfiguration.EnableInstallers();

            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString("host=localhost:15672");

            return await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
        }
    }
}
