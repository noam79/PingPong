using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.ServerContact
{
    public class SocketContact<T> : IServerContact<T>
    {
        private Socket _socket;

        public SocketContact()
        {
            _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string ip, int port)
        {
            _socket.Connect(ip, port);
        }

        public T Recieve(int maxMessageSize)
        {
            var message = new byte[maxMessageSize];
            var messageLength = _socket.Receive(message);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(
                Encoding.ASCII.GetString(message, 0, messageLength));
        }

        public void Send(object obj)
        {
            _socket.Send(Encoding.ASCII.GetBytes(obj.ToString()));
        }

        public void Dispose()
        {
            _socket.Close();
        }
    }
}
