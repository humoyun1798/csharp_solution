using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace Scoket
{
   public class Client
    {
        public static void client()
        {
            // 设置服务器IP地址和端口
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8888;

            // 创建TCP/IP Socket
            Socket clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // 连接到服务器
                clientSocket.Connect(new IPEndPoint(ipAddress, port));
                Console.WriteLine("已连接到服务器");

                // 创建一个线程来接收服务器响应
                Thread receiveThread = new Thread(() => ReceiveData(clientSocket));
                receiveThread.Start();

                while (true)
                {
                    // 发送数据到服务器
                    Console.Write("请输入要发送的数据: ");
                    string sendData = Console.ReadLine();
                    byte[] sendBytes = Encoding.UTF8.GetBytes(sendData);
                    clientSocket.Send(sendBytes);
                    Console.WriteLine("已发送数据到服务器");

                    if (sendData.ToLower() == "exit")
                    {
                        // 如果输入 "exit"，则断开连接
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生异常: " + ex.Message);
            }
            finally
            {
                // 关闭Socket
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }

        private static void ReceiveData(Socket clientSocket)
        {
            try
            {
                while (true)
                {
                    // 接收服务器响应数据
                    byte[] buffer = new byte[1024];
                    int bytesReceived = clientSocket.Receive(buffer);
                    if (bytesReceived == 0)
                    {
                        // 服务器断开连接
                        Console.WriteLine("服务器已断开连接");
                        break;
                    }

                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                    Console.WriteLine("接收到服务器响应: " + receivedData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生异常: " + ex.Message);
            }
        }
    }
}
