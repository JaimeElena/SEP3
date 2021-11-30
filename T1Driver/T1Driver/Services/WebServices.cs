using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using T1Driver.Models;

namespace T1Driver.Services
{
    public class WebServices : IWebServices
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

        public string Register(string username, string password,int id)
        {
            Request request = new Request()
            {
                Type = "register",
                Body = new User() {password = password, username = username, id = id}
            };

            string backString = RequestReply(request);
            Console.WriteLine(username + password+id);

            return backString;
        }

        public string Login(string username, string password)
        {
            Request request = new Request()
            {
                Type = "login",
                Body = new User() {password = password, username = username}
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

        public Driver GetDriver(string username)
        {
            Request request = new Request()
            {
                Type = "get",
                Body = new Driver() {username = username}
            };
            string backString = RequestReply(request);
            Driver driver = JsonSerializer.Deserialize<Driver>(backString);
            return driver;
        }

        public Driver EditDriver(int id, string username, string password, string firstName, string lastName,
            DateTime birthday, string sex)
        {
            Request request = new Request()
            {
                Type = "edit",
                Body = new Driver() {id = id, username = username, password = password, firstName = firstName, lastName = lastName, birthday = birthday, sex = sex}
            };
            string backString = RequestReply(request);
            Driver driver = JsonSerializer.Deserialize<Driver>(backString);
            return driver;
        }
    }
}