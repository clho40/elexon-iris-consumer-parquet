namespace ElexonInsightPolling;

public sealed class Settings
{
    public string TenantId = "1a235385-5d29-40e1-96fd-bc5ec2706361";
    public string? ServiceBusNamespace { get; set; }
    public string? ClientId { get; set; }
    public string? Secret { get; set; }
    public string FullyQualifiedNamespace => $"{ServiceBusNamespace}.servicebus.windows.net";
    public string? QueueName { get; set; }
    public string? RelativeFileDownloadDirectory { get; set; }
    public string? StorageAccountConnectionString { get; set; }
    public string? DatalakeContainerName { get; set; }

    public bool IsAppRegistrationProvided()
    {
        return !string.IsNullOrWhiteSpace(ClientId) && !string.IsNullOrWhiteSpace(Secret);
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(QueueName))
        {
            throw new SystemException($"Invalid configuration value: {nameof(QueueName)} is required");
        }

        if (string.IsNullOrWhiteSpace(ServiceBusNamespace))
        {
            throw new SystemException($"Invalid configuration value: {nameof(ServiceBusNamespace)} is required");
        }

        if (string.IsNullOrWhiteSpace(ClientId) != string.IsNullOrWhiteSpace(Secret))
        {
            throw new SystemException(
                $"Invalid configuration value(s): If one of" +
                $"{nameof(ClientId)} and " +
                $"{nameof(Secret)} are provided, both are required");
        }
    }
}