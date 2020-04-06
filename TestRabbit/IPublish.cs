using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestRabbit
{
    public interface IPublish
    {
        public void Run(string data);
    }
    public class PublishDefault : IPublish
    {
        string connection = "	amqp://gaemdyle:1-gnUUM4-NZKNHsDLxFIrqQrTCAp8uSs@moose.rmq.cloudamqp.com/gaemdyle";
        string queueName = "canaldestino"; 
        public void Run(string data)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(connection);

            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();

            byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(data);
            channel.BasicPublish("demoexchange", "rkalgo", null, messageBodyBytes);

        }
    }
}
