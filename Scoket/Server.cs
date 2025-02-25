using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace Scoket
{
    public class Server
    {
        public static void server()
        {
            // 设置服务器IP地址和端口
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8888;

            // 创建TCP/IP Socket
            Socket serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // 绑定Socket到本地端点
                serverSocket.Bind(new IPEndPoint(ipAddress, port));

                // 开始监听连接
                serverSocket.Listen(10);
                Console.WriteLine("服务器已启动，等待客户端连接...");

                // 接受客户端连接
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine("客户端已连接");

                // 创建一个线程来处理客户端通信
                Thread clientThread = new Thread(() => HandleClient(clientSocket));
                clientThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生异常: " + ex.Message);
            }
        }

        private static void HandleClient(Socket clientSocket)
        {
            try
            {
                while (true)
                {
                    // 接收客户端发送的数据
                    byte[] buffer = new byte[1024];
                    int bytesReceived = clientSocket.Receive(buffer);
                    if (bytesReceived == 0)
                    {
                        // 客户端断开连接
                        Console.WriteLine("客户端已断开连接");
                        break;
                    }

                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                    Console.WriteLine("接收到客户端数据: " + receivedData);

                    // 发送响应数据到客户端
                    string responseData = "服务器响应: " + receivedData;
                    byte[] responseBytes = Encoding.UTF8.GetBytes(responseData);
                    clientSocket.Send(responseBytes);
                    Console.WriteLine("已发送响应数据到客户端");
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
    }
}
