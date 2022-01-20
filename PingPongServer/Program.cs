using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPongServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new SocketTcpServerFactory();
            var server = factory.Create(12445);

            Task.Run(() => server.Start());

            Thread.Sleep(3000);

            server.Stop();
        }
    }
}
