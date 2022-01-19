using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.ObjectProviders
{
    public interface IObjectProvider
    {
        public object GetObject();
    }
}
