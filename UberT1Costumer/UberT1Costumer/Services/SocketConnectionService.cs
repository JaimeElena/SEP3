using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using UberT1Costumer.Models;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace UberT1Costumer.Services
{
    public class SocketConnectionService : ISocketConnectionService
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void Connect()
        {
            Console.WriteLine("Im here");
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndpoint = new IPEndPoint(iPAddress, 5201);
            socket.Connect(iPEndpoint);
            Console.WriteLine("Connection stablished");
        }

        public string RequestReply(Request request)
        {
            Thread.Sleep(1000);
            var jsonRequest = JsonSerializer.Serialize(request);
            Console.WriteLine("Sending: " + jsonRequest);
            byte[] byteStream = Encoding.UTF8.GetBytes(jsonRequest);
            Console.WriteLine(byteStream.Length);
            socket.Send(byteStream);
            string reply = "";
            byte[] byteReply = new byte[1024];
            int byteCount;
            byteCount = socket.Receive(byteReply, byteReply.Length, 0);
            reply = Encoding.UTF8.GetString(byteReply, 0, byteCount);
            Console.WriteLine(reply);
            return reply;
        }

        public string Register(string username, string password)
        {
            Request request = new Request()
            {
                Type = "register",
                Body = new Costumer() {password = password, username = username}
            };

            string backString = RequestReply(request);
            Console.WriteLine(username + password);

            return backString;
        }

        public string Login(string username, string password)
        {
            Request request = new Request()
            {
                Type = "login",
                Body = new Costumer() {password = password, username = username}
            };

            string backString = RequestReply(request);
            Console.WriteLine(username + password);

            return backString;
        }

        public void Logout()
        {
            Request request = new Request()
            {
                Type = "logout"
            };

            string backString = RequestReply(request);
            socket.Close();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Logout");
        }
    }
}
