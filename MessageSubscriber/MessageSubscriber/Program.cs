using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace MessageSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "albatross.rmq.cloudamqp.com", Port = 5672, UserName = "xnxqvhzt", Password = "MgflbWbcULra2Zh_BuXzUXmw55GnOtAr", VirtualHost = "xnxqvhzt" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("events", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, eventArgs) =>
                    {
                        var body = eventArgs.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine(message);
                    };

                    channel.BasicConsume(queue: "events", autoAck: true, consumer: consumer);
                    Console.ReadKey();
                }
            }
        }
    }
}
