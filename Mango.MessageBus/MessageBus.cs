using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Security.KeyVault.Secrets;
using Newtonsoft.Json;
using System.Text;

namespace Mango.MessageBus
{
    public class MessageBus : IMessageBus
    {
        public async Task PublishMessage(object message, string topicQueueName)
        {
            // Authenticate and get the secret from Azure Key Vault
            var kvUri = "https://kvdotnetmastery.vault.azure.net/";
            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            KeyVaultSecret secret = await client.GetSecretAsync("AzureServiceBusConnectionString");
            string connectionString = secret.Value;

            // Use ServiceBusClient
            await using var serviceBusClient = new ServiceBusClient(connectionString);
            ServiceBusSender sender = serviceBusClient.CreateSender(topicQueueName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            var finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };

            await sender.SendMessageAsync(finalMessage);
            await serviceBusClient.DisposeAsync();
        }
    }
}
