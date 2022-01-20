using log4net;
using PingPongServer.SocketClientHandlers;
using PingPongServer.SocketListeners;
using PingPongServer.TcpClientHandlers;
using PingPongServer.TcpListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer
{
    public class TcpServer
    {
        private ITcpListener _listener;
        private ITcpClientHandler _clientHandler;
        private bool _run;

        private ILog _logger;

        public TcpServer(ITcpListener listener, ITcpClientHandler clientHandler, ILog logger)
        {
            _listener = listener;
            _clientHandler = clientHandler;
            _logger = logger;
        }

        public void Start()
        {
            _logger?.Info("Starting TcpServer");

            _run = true;

            while (_run)
            {
                var clientSocket = _listener.Accept();
                _logger?.Info("Accepted Client");
                Task.Run(() =>
                    _clientHandler.HandleClient(clientSocket)
                    );
            }
        }

        public void Stop()
        {
            _logger?.Info("Stopping TcpServer");

            _run = false;
            _listener.Close();
            _clientHandler.Close();
        }
    }
}
