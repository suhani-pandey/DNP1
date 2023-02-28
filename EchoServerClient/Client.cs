﻿// See https://aka.ms/new-console-template for more information

using System.Net.Sockets;
using System.Text;

namespace EchoServerClient
{
    class Client
    {
        
        static void Main(string[] args)
        {
            using TcpClient client = new TcpClient("127.0.0.1", 5000);

            using NetworkStream stream = client.GetStream();
            Console.WriteLine("Client....");

            while (true) {
                Console.WriteLine("INPUT-----");
                string? input = Console.ReadLine();
                byte[] dataToServer = Encoding.ASCII.GetBytes(input);
                stream.Write(dataToServer, 0, dataToServer.Length);
                if (input.ToLower().Equals("exit")) {
                    break;
                }


                byte[] dataFromServer = new byte[1024];
                int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
                string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
                Console.WriteLine(response);
        
            }
   
                                                

    
        }
    }
}
