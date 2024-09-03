using System.Text;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using OrderService.Messages;
using OrderServices.Models;
using OrderServices.Repository;

namespace OrderService.Messaging
{    
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer 
    {
        private readonly string serviceBusConnectionString;
        private readonly string subscriptionCheckoutName;
        private readonly string checkoutMessageTopic;
        private ServiceBusProcessor checkoutProcessor;
        private readonly IConfiguration _configuration;
        private readonly OrderRepository _orderRepository;

        public AzureServiceBusConsumer(OrderRepository orderRepository, IConfiguration configuration)
        {
            _orderRepository = orderRepository;
            serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            subscriptionCheckoutName = _configuration.GetValue<string>("liquorSalesOrderSubscription");
            checkoutMessageTopic = _configuration.GetValue<string>("checkoutmessagetopic");

            var client = new ServiceBusClient(serviceBusConnectionString);

            checkoutProcessor = client.CreateProcessor(checkoutMessageTopic, subscriptionCheckoutName);
        }

        public async Task Start()
        {
            checkoutProcessor.ProcessMessageAsync += OnCheckoutMessageReceived;
            checkoutProcessor.ProcessErrorAsync += ErrorHandler;
            await checkoutProcessor.StartProcessingAsync();
        }

        public async Task Stop()
        {
            await checkoutProcessor.StopProcessingAsync();
             await checkoutProcessor.DisposeAsync();
        }

        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private async Task OnCheckoutMessageReceived(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(body);
            OrderHeader orderHeader = new()
            {
                UserId = checkoutHeaderDto.UserId,
                FirstName = checkoutHeaderDto.FirstName,
                LastName = checkoutHeaderDto.LastName,
                OrderDetails = new List<OrderDetails>(),
                CardNumber = checkoutHeaderDto.CardNumber,
                CouponCode = checkoutHeaderDto.CouponCode,
                CVV = checkoutHeaderDto.CVV,
                DiscountTotal = checkoutHeaderDto.DiscountTotal,
                Email = checkoutHeaderDto.Email,
                ExpiryMonthYear = checkoutHeaderDto.ExpiryMonthYear,
                OrderTime = DateTime.Now,
                OrderTotal = checkoutHeaderDto.OrderTotal,
                PaymentStatus = false,
                Phone = checkoutHeaderDto.Phone,
                PickUpDateTime = checkoutHeaderDto.PickUpDateTime

            };
                foreach (var detailList in checkoutHeaderDto.CartDetailsDtos)
                {
                    OrderDetails orderDetails = new()
                    {
                        ProductsId = detailList.ProductsId,
                        ProductName = detailList.ProductsDto.ProductName,
                        Price = detailList.ProductsDto.Price,
                        Count = detailList.Count,
                    };
                    orderHeader.CartTotalItems += detailList.Count;
                    orderHeader.OrderDetails.Add(orderDetails);

                    await _orderRepository.AddOrder(orderHeader);
                } 


        }
    }
}