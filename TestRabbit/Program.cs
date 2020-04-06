using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace TestRabbit
{
    /// <summary>
    /// https://www.rabbitmq.com/dotnet-api-guide.html
    /// </summary>
    class Program
    {
        static string connection = "amqp://gaemdyle:1-gnUUM4-NZKNHsDLxFIrqQrTCAp8uSs@moose.rmq.cloudamqp.com/gaemdyle";
        static string queueName = "colaorigen";
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(connection);

            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();

            var consumer = new EventingBasicConsumer(channel);

            var mainProcess = new MainProccess(new ConvertBasic(),new PublishDefault(), new ValidateDefault());


            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body;
                var data = Encoding.UTF8.GetString(body, 0, body.Length);

                mainProcess.Run(data);

                // ... process the message
                channel.BasicAck(ea.DeliveryTag, false);
            };

            String consumerTag = channel.BasicConsume(queueName, false, consumer);
        }

     
    }
}
