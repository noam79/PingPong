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

            while (_run)
            {
                string data = null;
                byte[] buffer = null;

                while (_run)
                {
                    buffer = new byte[1024];
                    int bytesReceived = socket.Receive(buffer);
                    data += Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        _logger?.Info($"Received Message: \"{data}\"");
                        break;
                    }
                }
                _logger?.Info($"Sending Message: \"{data}\"");
                socket.Send(Encoding.ASCII.GetBytes(data));
            }
        }

        public void Close()
        {
            _run = false;
        }
    }
}
