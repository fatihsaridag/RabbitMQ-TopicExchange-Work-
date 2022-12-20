using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace RabbitmqFirstProject.subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
         
            var factory = new ConnectionFactory(); 
            factory.Uri = new Uri("amqps://eznbdupx:Qf4h0Avxf0yEipy5VaR1D7UHRfIL0Gfn@gerbil.rmq.cloudamqp.com/eznbdupx");  
            using var connection = factory.CreateConnection(); 
            var channel = connection.CreateModel();

   


            channel.BasicQos(0, 1, false);                                   
            var consumer = new EventingBasicConsumer(channel);

            var queueName = channel.QueueDeclare().QueueName;
            var routeKey = "*.Error.*";
            channel.QueueBind(queueName, "logs-topic",routeKey);


            channel.BasicConsume(queueName, false,consumer);                  
            Console.WriteLine("Loglar dinleniyor..");                             
            consumer.Received += (object sender, BasicDeliverEventArgs e) => {  
            var message = Encoding.UTF8.GetString(e.Body.ToArray());
            Thread.Sleep(1500);   
            Console.WriteLine("Gelen mesaj : " + message);
            //File.AppendAllText("log-critical.txt", message +"\n");
            channel.BasicAck(e.DeliveryTag, false); 
            };
            Console.ReadLine();
        }
    }
}
