using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

namespace RabbitmqFirstProject.publisher
{
    class Program
    {


        public enum LogNames
        {
            Critical = 1,
            Error = 2,
            Warning = 3,
            Info = 4
        }


        static void Main(string[] args)
        {
            //RabbitMq ya bağlanmamız için connection factory isminde bir nesne örneğği alalım
            var factory = new ConnectionFactory();
            //Uri yımızı belirticez. CloudAmqp deki instancedan urli alıyoruz. Gerçek seneryoda bunları appsetting.json içeçrisinde tutuyoruz.
            factory.Uri = new Uri("amqps://eznbdupx:Qf4h0Avxf0yEipy5VaR1D7UHRfIL0Gfn@gerbil.rmq.cloudamqp.com/eznbdupx");

            //factory üzerinden bir bağlantı açıyoruz.
            using var connection = factory.CreateConnection();
            //Artık bir bağlantımız var ve bu bağlantı  üzerinden kanal oluşturuyoruz onun üzerinden bağlanıcaz.
            var channel = connection.CreateModel(); //Bu kanal üzerinden rabbitMq ile haberleşebiliriz.
            //1.param : Exchange ismi , 2.param : restart atınca uygulama fiziksel olarak kaydedilsin , 3.param : Exchange tipi ? 
            channel.ExchangeDeclare("logs-topic",durable:true, type:ExchangeType.Topic);                                                        
           
 


            Enumerable.Range(1, 50).ToList().ForEach(x =>
             {

                 Random rnd = new Random();
                 LogNames log1 = (LogNames)rnd.Next(1, 5);
                 LogNames log2 = (LogNames)rnd.Next(1, 5);
                 LogNames log3 = (LogNames)rnd.Next(1, 5);

                 var routeKey = $"{log1}.{log2}.{log3}";
                 string message = $"log-type : {log1} - {log2} - {log3}";
                 var messageBody = Encoding.UTF8.GetBytes(message);




                 channel.BasicPublish("logs-topic", routeKey, null, messageBody);  
                 Console.WriteLine($"Log Gönderilmiştir : {message}");
             });

           
               
        }
    }
}
