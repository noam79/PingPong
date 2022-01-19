using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.ServerContact
{
    public class SocketContact : IServerContact
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

        public object Recieve(int maxMessageSize)
        {
            var message = new byte[maxMessageSize];
            var messageLength = _socket.Receive(message);

            return Encoding.ASCII.GetString(message, 0, messageLength);
        }

        public void Send(object obj)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
