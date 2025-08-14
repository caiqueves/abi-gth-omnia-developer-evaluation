using Ambev.DeveloperEvaluation.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;

namespace Ambev.DeveloperEvaluation.Infrastructure.RabbitMQ
{
    public class RabbitMqEventPublisher : IRabbitMqEventPublisher
    {
        private readonly string _queueName = "developerEvalution";

        private readonly IConfiguration _configuration;
        private readonly ConnectionFactory _factory;

        public RabbitMqEventPublisher(IConfiguration configuration)
        {
            _configuration = configuration;
            var url = _configuration.GetValue<string>("RabbitMq:RabbitMqConnection");
            var user = _configuration.GetValue<string>("RabbitMq:RabbitMqUser");
            var pass = _configuration.GetValue<string>("RabbitMq:RabbitMqPass");

            var encodedPass = Uri.EscapeDataString(pass);

            var uri = new Uri($"amqp://{user}:{encodedPass}@{url}");

            _factory = new ConnectionFactory
            {
                Uri = uri,
                AutomaticRecoveryEnabled = true
            };
        }

        public async Task PublishEvent(string eventMessage, string queueName)
        {
            var connection = await _factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();



            await channel.QueueDeclareAsync(queue: _queueName + "_" + queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(eventMessage);


            await channel.BasicPublishAsync(exchange: "",
                                 routingKey: _queueName + "_" + queueName,
                                 body: body);



            Console.WriteLine($"{eventMessage}");
        }
    }
}
