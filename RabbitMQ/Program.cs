using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ
{
    internal class Program
    {
        #region 接收mq

        static void Main(string[] args)
        {
            GetMsg();
        }
        static void GetMsg()
        {
            //创建 RabbitMQ 连接
            var factory = new ConnectionFactory()
            {
                HostName = "127.0.0.1",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
            };
            using (var connection = factory.CreateConnection())

            //创建通道并声明队列
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                //接收消息：
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received message: {0}", message);
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);


                Console.WriteLine("Press [enter] to exit.");
                Console.ReadLine();
            }
        }
        #endregion


        #region 发送消息
        static void SetMsg()
        {
            try
            {
                //创建 RabbitMQ 连接
                var factory = new ConnectionFactory()
                {
                    HostName = "127.0.0.1",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest",
                    VirtualHost = "/",
                };
                using (var connection = factory.CreateConnection())

                //创建通道并声明队列
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    //发布消息
                    string message = "Hello, RabbitMQ!";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine("Sent message: {0}", message);
                }

                Console.WriteLine("Press [enter] to exit.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }

        }
        #endregion
    }
}