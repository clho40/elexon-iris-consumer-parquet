using Azure.Identity;
using Azure.Messaging.ServiceBus;

namespace ElexonInsightPolling.helpers;

public static class ServiceBusClientHelpers
{
    public static ServiceBusClient GetAuthenticatedServiceBusClient(Settings settings)
    {
        var tokenCredential = new ClientSecretCredential(
            settings.TenantId,
            settings.ClientId,
            settings.Secret);
        Console.WriteLine("Connecting using app registration");
        return new ServiceBusClient(settings.FullyQualifiedNamespace, tokenCredential);
    }
}