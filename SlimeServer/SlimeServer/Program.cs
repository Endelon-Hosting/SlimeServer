using Spectre.Console;
using System;
using System.IO;

namespace SlimeServer
{
    public class Program
    {
        public static MinecraftServer Server { get; private set; }

        public static int Main(string[] args)
        {
            return Crashhandler(Application, args);
        }

        private static int Application(string[] args)
        {
            Server = MinecraftServer.Run(args);
            return 0;
        }

        private static int Crashhandler(MainHandler<string[], int> main, params string[] args)
        {
            try
            {
                return main(args);
            }
            catch (Exception e)
            {
                Logger.Error("Unhandled Exception");
                Logger.Error("Creating new Crashreport");
                AnsiConsole.WriteException(e);
                if (!Directory.Exists("crash-reports"))
                    Directory.CreateDirectory("crash-reports");
                File.WriteAllText($"crash-reports/crash-{DateTime.Now.ToString().Replace(".","-").Replace(":","-").Replace(" ","-")}-{DateTime.Now.Millisecond}.txt", e.ToString());
                Logger.Info("Exception handled");
                Logger.Info("Restarting Server");
                return Crashhandler(main, args);
            }
        }
    }
}
