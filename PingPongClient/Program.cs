using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ClientFactory();
            var client = factory.Create();

            client.Communicate("127.0.0.10", 12345);
        }
    }
}
