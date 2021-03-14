using System;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Consumer
{
    static class Program
    {
         static void Main(string[] args)
        {
            Console.WriteLine("Consumer started");
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://transcode_user:password@localhost/video.transcode.vhost")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            //QueueConsumer.Consume(channel);
            //DirectExchangeConsumer.Consume(channel);
            //TopicExchangeConsumer.Consume(channel);
            //HeaderExchangeConsumer.Consume(channel);
            FanoutExchangeConsumer.Consume(channel);
            Console.ReadLine();
            
        }
    }
}
