using SlimeServer.Configuration;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace SlimeServer.Extensions
{
    public class Utility
    {
        public static Thread Thread(Action start)
        {
            Thread t = new(() => start());
            t.Start();
            return t;
        }

        public static void Put(ApplicationResource resource, string filename)
        {
            if (!System.IO.File.Exists(filename))
                System.IO.File.WriteAllBytes(filename, resource.Data);
        }

        public static void Sleep(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        public static Stream Stream(ApplicationResource resource)
        {
            var ms = new MemoryStream();
            ms.Write(resource.Data);
            ms.Position = 0;
            return ms;
        }

        public static File File(string filename)
        {
            File file = new();
            file.Open(filename);
            return file;
        }

        public static string Content(File file, string defaultValue)
        {
            if(file.Exists)
                return file.ReadText();
            file.WriteText(defaultValue);
            return defaultValue;
        }

        public static string Content(ApplicationResource resource)
        {
            var bytes = resource.Data;
            var str = Encoding.UTF8.GetString(bytes);
            return str;
        }

        public static object Const(SlimeConsts key) => key switch
        {
            SlimeConsts.ProtocolVersion => ConstStore.ProtocolVersion,
            SlimeConsts.VersionName => ConstStore.VerionName,
            _ => throw new Exception("Not found"),
        };
    }
}
