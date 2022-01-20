using log4net;
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
        private ILog _logger;

        public DefaultSocketListener(int port, int maxClients, ILog logger)
        {
            _logger = logger;

            _listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            try
            {
                _listener.Bind(new IPEndPoint(IPAddress.Any, port));
            }
            catch (Exception e)
            {
                _logger?.Error(e);
                throw;
            }

            _listener.Listen(maxClients);
        }

        public Socket Accept()
        {
            _logger?.Info("Accepting Connections..");
            return _listener.Accept();
        }

        public void Close()
        {
            _logger?.Info("Closing Listener");
            _listener.Close();
        }
    }
}
