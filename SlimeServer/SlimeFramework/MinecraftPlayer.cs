using MCSharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeFramework
{
    public class MinecraftPlayer
    {
        public string Name { get; set; }
        public string UUID { get; set; }
        public MinecraftConnection Connection { get; set; }
    }
}
