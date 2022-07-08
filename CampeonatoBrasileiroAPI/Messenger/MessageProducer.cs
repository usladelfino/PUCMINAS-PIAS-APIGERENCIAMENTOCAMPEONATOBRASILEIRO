using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Messenger
{
    public class MessageProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "albatross.rmq.cloudamqp.com", Port = 5672, UserName = "xnxqvhzt", Password = "MgflbWbcULra2Zh_BuXzUXmw55GnOtAr", VirtualHost = "xnxqvhzt" };
            
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("events", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var json = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "", routingKey: "events", body: body);
                }
            }
        }
    }
}
