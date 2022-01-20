using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.TcpClientHandlers
{
    public class PingPongTcpClientHandler : ITcpClientHandler
    {
        private bool _run;
        private ILog _logger;


        public PingPongTcpClientHandler(ILog logger)
        {
            _logger = logger;
        }

        public void HandleClient(TcpClient client)
        {
            _run = true;

            var stream = client.GetStream();
            var buffer = new byte[2048];
            string data;
            int bytesReceived;

            while (_run)
            {
                try
                {
                    bytesReceived = stream.Read(buffer, 0, buffer.Length);
                }
                catch (Exception)
                {
                    _logger.Info("Client Closed Connection");
                    break;
                }
                data = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                _logger?.Info($"Received Message, Echoing: \"{data}\"");

                var message = Encoding.ASCII.GetBytes(data);
                stream.Write(message, 0, message.Length);
            }
        }

        public void Close()
        {
            _run = false;
        }
    }
}
