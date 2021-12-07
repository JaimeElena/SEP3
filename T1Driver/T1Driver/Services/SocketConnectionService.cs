using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using T1Driver.Models;

namespace T1Driver.Services
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
                Type = "driverregister",
                Body = new Driver() {password = password, username = username},
                RequestEntity = "driver"
            };

            string backString = RequestReply(request);
            Console.WriteLine(backString);

            return backString;
        }

        public string Login(string username, string password)
        {
            Request request = new Request()
            {
                Type = "driverlogin",
                Body = new Driver() {password = password, username = username},
                RequestEntity = "driver"
            };

            string backString = RequestReply(request);
            Console.WriteLine(username + password);

            return backString;
        }

        public void Logout(Driver driver)
        {
            Request request = new Request()
            {
                Type = "driverlogout",
                Body = driver,
                RequestEntity = "driver"
            };

            string backString = RequestReply(request);
            socket.Close();
            Console.WriteLine("Logout");
        }

        public Driver GetDriver(string username)
        {
            Request request = new Request()
            {
                Type = "driverget",
                Body = new Driver() {username = username},
                RequestEntity = "driver"
            };
            string backString = RequestReply(request);
            Driver driver = JsonSerializer.Deserialize<Driver>(backString);
            return driver;
        }

        public Driver EditDriver(Driver driver)
        {
            Request request = new Request()
            {
                Type = "driveredit",
                Body = driver,
                RequestEntity = "driver"
            };
            string backString = RequestReply(request);
            Driver apidriver = JsonSerializer.Deserialize<Driver>(backString);
            return apidriver;
        }
    }
}