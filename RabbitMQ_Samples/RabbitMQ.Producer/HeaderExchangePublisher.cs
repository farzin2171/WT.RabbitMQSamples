using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace RabbitMQ.Producer
{
    public static class HeaderExchangePublisher
    {
        public static void Piblish(IModel channel)
        {
            var ttl = new Dictionary<string, object>
            {
                {"x-message-ttl",30000 }
            };
            channel.ExchangeDeclare("demo-heder-exchange", ExchangeType.Headers, arguments: ttl);

            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"Hello {count}" };
                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

                var properties = channel.CreateBasicProperties();
                properties.Headers = new Dictionary<string, object>
                {
                    {"account","new" }
                };
                
                channel.BasicPublish("demo-header-exchange", string.Empty, properties, body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
