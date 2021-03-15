using MassTransit;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Threading.Tasks;

namespace Consumer
{
    public sealed class OrderConsumer : IConsumer<Order>
    {
        private readonly ILogger<OrderConsumer> _logger;

        public OrderConsumer(ILogger<OrderConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Order> context)
        {
            try
            {
                var order = context.Message;

                _logger.LogInformation($"Order received: {order.OrderId} - {DateTime.Now:o}");

            }
            catch (Exception ex)
            {
                _logger.LogError("Error on try to consume order", ex);
            }

            return Task.CompletedTask;
        }
    }
}
