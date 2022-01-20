using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.TcpListeners
{
    public class DefaultTcpClientListener : ITcpListener
    {
        private TcpListener _listener;
        private ILog _logger;

        public DefaultTcpClientListener(int port, ILog logger)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();

            _logger = logger;
        }

        public TcpClient Accept()
        {
            _logger?.Info("Accepting Clients..");
            return _listener.AcceptTcpClient();
        }

        public void Close()
        {
            _logger.Info("Closing Listener");
            _listener.Stop();
        }
    }
}
