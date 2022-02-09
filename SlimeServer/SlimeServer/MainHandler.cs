using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SlimeServer
{
    public delegate T2 MainHandler<in T1, out T2>(T1 t1);
}
