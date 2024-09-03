using Microsoft.IdentityModel.Tokens;
using OrderService.Messaging;

namespace OrderServices.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IAzureServiceBusConsumer ServiceBusConsumer { get; set;}
        public static IApplicationBuilder UseAzureServiceBusConsumer(this IApplicationBuilder builder)
        {
            ServiceBusConsumer = builder.ApplicationServices.GetService<IAzureServiceBusConsumer>();
            var hostApplicationLife = builder.ApplicationServices.GetService<IHostApplicationLifetime>();

            hostApplicationLife.ApplicationStarted.Register(OnStart);
            hostApplicationLife.ApplicationStopped.Register(OnStop);
            return builder;
        }

        private static void OnStart()
        {
            ServiceBusConsumer.Start();
        }

        public static void OnStop()
        {
            ServiceBusConsumer.Stop();
        }
    }
}