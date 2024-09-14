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

            //while (true)
            //{
            //    AckGetMsg();

            //}

            int i = 0;
            while (true)
            {
                i++;
                SetMsg(i);
            }
        }
        static void GetMsg()
        {
            //创建 RabbitMQ 连接
            var factory = new ConnectionFactory()  //1.实例化连接工厂
            {
                HostName = "127.0.0.1",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
            };
            using (var connection = factory.CreateConnection()) //2. 建立连接

            //创建通道并声明队列
            using (var channel = connection.CreateModel())  //3. 创建信道
            {
                channel.QueueDeclare(queue: "hello",  //4. 申明队列
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                //接收消息：
                var consumer = new EventingBasicConsumer(channel);  //5. 构造消费者实例
                consumer.Received += (model, ea) =>  //6. 绑定消息接收后的事件委托
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received message: {0}", message);
                };
                channel.BasicConsume(queue: "hello",  //7. 启动消费者
                                     autoAck: true,
                                     consumer: consumer);


                Console.WriteLine("Press [enter] to exit.");
                Console.ReadLine();
            }
        }


        //有消息确认的 
        static void AckGetMsg()
        {
            //创建 RabbitMQ 连接
            var factory = new ConnectionFactory()  //1.实例化连接工厂
            {
                HostName = "127.0.0.1",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
            };
            using (var connection = factory.CreateConnection()) //2. 建立连接

            //创建通道并声明队列
            using (var channel = connection.CreateModel())  //3. 创建信道
            {
                channel.QueueDeclare(queue: "hello",  //4. 申明队列
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                //接收消息：
                var consumer = new EventingBasicConsumer(channel);  //5. 构造消费者实例
                consumer.Received += (model, ea) =>  //6. 绑定消息接收后的事件委托
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received message: {0}", message);

                    Thread.Sleep(6000);
                    Console.WriteLine(" Done");
                    // 7. 发送消息确认信号（手动消息确认）
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                //8. 启动消费者
                //autoAck:true；自动进行消息确认，当消费端接收到消息后，就自动发送ack信号，不管消息是否正确处理完毕
                //autoAck:false；关闭自动消息确认，通过调用BasicAck方法手动进行消息确认
                channel.BasicConsume(queue: "hello", autoAck: false, consumer: consumer);


                Console.WriteLine("Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        #endregion


        #region 发送消息
        static void SetMsg(int n)
        {
            try
            {
                //创建 RabbitMQ 连接
                var factory = new ConnectionFactory()  //1.实例化连接工厂
                {
                    HostName = "127.0.0.1",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest",
                    VirtualHost = "/",
                };
                using (var connection = factory.CreateConnection())//2. 建立连接

                //创建通道并声明队列
                using (var channel = connection.CreateModel()) //3. 创建信道
                {
                    channel.QueueDeclare(queue: "hello",//4. 申明队列
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    ////将消息标记为持久性
                    ////将消息标记为持久性 - 将IBasicProperties.SetPersistent设置为true   持久化之后就算大部分数据重启电脑之后也还在队列，存在磁盘里了
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;



                    //发布消息
                    //5. 构建byte消息数据包
                    string message = $"Hello{n}, RabbitMQ!";
                    var body = Encoding.UTF8.GetBytes(message);
                    //6. 发送数据包 (指定basicProperties)
                    channel.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         //basicProperties: null,
                                         basicProperties: properties,
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