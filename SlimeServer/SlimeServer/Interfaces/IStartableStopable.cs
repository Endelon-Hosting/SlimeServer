using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeServer.Interfaces
{
    public interface IStartableStopable
    {
        public void Start();
        public void Stop();
    }
}
