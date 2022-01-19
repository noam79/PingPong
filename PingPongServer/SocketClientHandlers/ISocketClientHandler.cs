using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.SocketClientHandlers
{
    public interface ISocketClientHandler
    {
        public void HandleClient(Socket socket);

        public void Close();
    }
}
