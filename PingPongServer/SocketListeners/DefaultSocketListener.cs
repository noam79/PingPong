using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.SocketListeners
{
    public class DefaultSocketListener : ISocketListener
    {
        private Socket _listener;

        public DefaultSocketListener(int port, int maxClients)
        {
            _listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(new IPEndPoint(IPAddress.Any, port));
            _listener.Listen(maxClients);
        }

        public Socket Accept()
        {
            return _listener.Accept();
        }

        public void Close()
        {
            _listener.Close();
        }
    }
}
