using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.SocketClientHandlers
{
    public class PingPongSocketHandler : ISocketClientHandler
    {
        private bool _run;
        private ILog _logger;

        public PingPongSocketHandler(ILog logger)
        {
            _logger = logger;
        }

        public void HandleClient(Socket socket)
        {
            _run = true;

            string data = null;
            byte[] buffer = new byte[2048];

            while (_run)
            {
                int bytesReceived = socket.Receive(buffer);

                data += Encoding.ASCII.GetString(buffer, 0, bytesReceived);

                _logger?.Info($"Received Message, Echoing: \"{data}\"");
                socket.Send(Encoding.ASCII.GetBytes(data));

                data = string.Empty;
            }
        }

        public void Close()
        {
            _run = false;
        }
    }
}
