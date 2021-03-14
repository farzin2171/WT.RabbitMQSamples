using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace RabbitMQ.Producer
{
    public static class TopicExchangePublisher
    {
        public static void Piblish(IModel channel)
        {
            var ttl = new Dictionary<string, object>
            {
                {"x-message-ttl",30000 }
            };
            channel.ExchangeDeclare("demo-topic-exchange", ExchangeType.Topic, arguments: ttl);

            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"Hello {count}" };
                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

                //For now we dont use exchanges 
                channel.BasicPublish("demo-topic-exchange", "account.init", null, body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
