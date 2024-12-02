using Ambev.DeveloperEvaluation.Domain.Services;
using RabbitMQ.Client;
using System.Text;

namespace Ambev.DeveloperEvaluation.Infrastructure.RabbitMQ
{
    public class RabbitMqEventPublisher : IEventPublisher
    {
        private readonly string _hostname = "localhost"; 
        private readonly string _queueName = "developerEvalution"; 
        private readonly string _username = "guest"; 
        private readonly string _password = "guest"; 

        public RabbitMqEventPublisher()
        {
            
        }

        public void PublishEvent(string eventMessage, string queueName)
        {

            var factory = new ConnectionFactory() { 
                HostName = _hostname,
                UserName = _username,  
                Password = _password   

            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                channel.QueueDeclare(queue: _queueName+"_"+queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(eventMessage);


                channel.BasicPublish(exchange: "",
                                     routingKey: _queueName + "_" + queueName,
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($"{eventMessage}");
            }
        }


    }
}
