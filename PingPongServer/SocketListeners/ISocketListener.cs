using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.SocketListeners
{
    public interface ISocketListener
    {
        public Socket Accept();

        public void Close();
    }
}
