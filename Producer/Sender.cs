using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factroy = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factroy.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("Basic Test", false, false, false, null);

                string message = "Getting Started with .net core RabbitMq";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "Basic Test", null, body);
                Console.WriteLine("Sent message {0}...", message);
            }

            Console.WriteLine("Press enter to exit the Sender App...");
            Console.ReadLine();

            //var factory = new ConnectionFactory() { HostName = "localhost" };
            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    channel.QueueDeclare(queue: "hello",
            //                         durable: false,
            //                         exclusive: false,
            //                         autoDelete: false,
            //                         arguments: null);

            //    string message = "Hello World!";
            //    var body = Encoding.UTF8.GetBytes(message);

            //    channel.BasicPublish(exchange: "",
            //                         routingKey: "hello",
            //                         basicProperties: null,
            //                         body: body);
            //    Console.WriteLine(" [x] Sent {0}", message);
            //}

            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();
        }
    }
}
