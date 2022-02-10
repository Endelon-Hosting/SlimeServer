using System;

namespace SlimeFramework
{
    public class SlimeRegistry
    {
        internal static Internal.SlimeRegistry Instance { get; set; }
        public static void Register<T>(T obj) where T : SlimeObject =>  Instance.Register(obj);
    }
}
