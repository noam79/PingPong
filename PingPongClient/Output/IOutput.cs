using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.Output
{
    public interface IOutput
    {
        public void Write(string message);
    }
}
