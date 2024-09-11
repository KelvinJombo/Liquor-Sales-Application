using System.Text;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;

namespace LiquorSale.MessageBus
{
    public class AzureServiceBusMessageBus : IMessageBus
    {

        private string connectionString = "Endpoint=sb://liquorsales.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=7t3usJ6tooj30PRi5ccrTwbS6DNGPxbmp2oVdiO3cI=";

        public async Task PublishMessage(BaseMessage message, string topicName)
        {
             ISenderClient senderClient = new TopicClient(connectionString, topicName);

             var jsonMessage = JsonConvert.SerializeObject(message);
             var finalMessage = new Message(Encoding.UTF8.GetBytes(jsonMessage))
             {
                CorrelationId = Guid.NewGuid().ToString()
             };
               await senderClient.SendAsync(finalMessage);

                await senderClient.CloseAsync();
        }
    }
}