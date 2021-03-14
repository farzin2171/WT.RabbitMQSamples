using System;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RabbitMQ.Producer
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("producer started");
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://transcode_user:password@localhost/video.transcode.vhost")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            //QueueProducer.Piblish(channel);
            //DirectExchangePublisher.Piblish(channel);
            //TopicExchangePublisher.Piblish(channel);
            //HeaderExchangePublisher.Piblish(channel);
            FanoutExchangePublisher.Piblish(channel);

        }
    }
}
