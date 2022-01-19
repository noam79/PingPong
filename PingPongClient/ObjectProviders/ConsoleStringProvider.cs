using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.ObjectProviders
{
    public class ConsoleStringProvider : IObjectProvider
    {
        public object GetObject()
        {
            return Console.ReadLine();
        }
    }
}
