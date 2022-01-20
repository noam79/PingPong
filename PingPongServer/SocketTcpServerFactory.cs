using PingPongServer.SocketListeners;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPongServer.SocketClientHandlers;
using log4net;
using PingPongServer.TcpListeners;
using PingPongServer.TcpClientHandlers;

namespace PingPongServer
{
    public class SocketTcpServerFactory
    {
        public TcpServer Create(int port)
        {
            var logger = LogManager.GetLogger(nameof(Program));

            var listener = new DefaultTcpClientListener(
                port, 
                logger
                );

            var clientHandler = new PingPongTcpClientHandler(logger);

            return new TcpServer(listener, clientHandler, logger);
        }
    }
}
