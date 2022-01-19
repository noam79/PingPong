using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.SocketListeners
{
    public class DefaultSocketListener : ISocketListener
    {
        private Socket _listener;

        public DefaultSocketListener()
        {
            _listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
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
