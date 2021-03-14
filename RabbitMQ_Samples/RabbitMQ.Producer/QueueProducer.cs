using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace RabbitMQ.Producer
{
    public static class QueueProducer
    {
        public static void Piblish(IModel channel)
        {
            channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"Hello {count}" };
                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

                //For now we dont use exchanges 
                channel.BasicPublish("", "demo-queue", null, body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
