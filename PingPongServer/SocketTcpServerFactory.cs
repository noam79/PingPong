using PingPongServer.SocketListeners;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPongServer.SocketClientHandlers;
using log4net;

namespace PingPongServer
{
    public class SocketTcpServerFactory
    {
        public TcpServer Create(int port)
        {
            var logger = LogManager.GetLogger(nameof(Program));

            var listener = new DefaultSocketListener(
                port, 
                int.Parse(ConfigurationManager.AppSettings["maxClients"]),
                logger
                );

            var clientHandler = new PingPongSocketHandler(logger);

            return new TcpServer(listener, clientHandler, logger);
        }
    }
}
