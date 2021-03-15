using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Threading.Tasks;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private const string QueueUri = "rabbitmq://localhost/order-consumer-queue";
        private readonly ILogger<OrderController> _logger;
        private readonly IBusControl _busControl;

        public OrderController(ILogger<OrderController> logger, IBusControl busControl)
        {
            _logger = logger;
            _busControl = busControl;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] long orderId)
        {
            var endpoint = await _busControl.GetSendEndpoint(new Uri(QueueUri));

            await endpoint.Send(new Order { OrderId = orderId });

            _logger.LogInformation($"Message published. OrderId: {orderId}");

            return Ok($"{DateTime.Now:o}");
        }
    }
}
