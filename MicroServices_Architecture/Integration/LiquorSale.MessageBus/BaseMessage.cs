namespace LiquorSale.MessageBus
{
    public class BaseMessage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime MessageCreated { get; set; } 
    }
}