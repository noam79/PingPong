using PingPongServer.SocketClientHandlers;
using PingPongServer.SocketListeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer
{
    public class TcpServer
    {
        private ISocketListener _listener;
        private ISocketClientHandler _clientHandler;

        private bool _run;

        public TcpServer(ISocketListener listener, ISocketClientHandler clientHandler)
        {
            _listener = listener;
            _clientHandler = clientHandler;
        }

        public void Start()
        {
            _run = true;

            while (_run)
            {
                var clientSocket = _listener.Accept();
                Task.Run(() =>
                    _clientHandler.HandleClient(clientSocket)
                    );
            }
        }

        public void Stop()
        {
            _run = false;
            _listener.Close();
            _clientHandler.Close();
        }
    }
}
