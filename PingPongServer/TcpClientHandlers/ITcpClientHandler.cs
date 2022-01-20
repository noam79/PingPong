using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.TcpClientHandlers
{
    public interface ITcpClientHandler
    {
        public void HandleClient(TcpClient socket);

        public void Close();
    }
}
