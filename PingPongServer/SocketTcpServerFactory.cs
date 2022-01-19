﻿using PingPongServer.SocketListeners;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPongServer.SocketClientHandlers;

namespace PingPongServer
{
    public class SocketTcpServerFactory
    {
        public TcpServer Create(int port)
        {
            var listener = new DefaultSocketListener(
                port, 
                int.Parse(ConfigurationManager.AppSettings["maxClients"]));

            var clientHandler = new PingPongSocketHandler();

            return new TcpServer(listener, clientHandler);
        }
    }
}