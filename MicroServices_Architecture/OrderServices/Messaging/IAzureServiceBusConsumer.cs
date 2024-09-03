namespace OrderService.Messaging
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();

    }
}