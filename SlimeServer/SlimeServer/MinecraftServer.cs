using Dalk.PropertiesSerializer;
using Logging.Net;
using SlimeServer.Configuration;
using SlimeServer.Interfaces;
using SlimeServer.MinecraftServerHost;
using SlimeServer.Models;
using SlimeServer.ModFramework;
using Spectre.Console;
using System;
using System.IO;
using System.Threading;

namespace SlimeServer
{
    public class MinecraftServer : IStartableStopable
    {
        public static MinecraftServer Run(string[] args)
        {
            ConfigLoader.Init();

            var server = new MinecraftServer();
            server.Initialize(args);
            server.Start();

            Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
            {
                e.Cancel = true;

                server.Stop();
            });

            return server;
        }

        public IStartableStopable Gameserver { get; set; }

        public MinecraftServer()
        {
            Gameserver = new BasicNetworkServer();
        }

        ~MinecraftServer()
        {
            Stop();
        }

        public void Stop()
        {
            Logger.Info("Stopping Server");
            Thread.Sleep(5000);

            Gameserver.Stop();
        }

        public void Start()
        {
            Logger.Info("Starting Server");
            CheckEula();
            ModificationManager.Start();

            Gameserver.Start();
        }

        public void Initialize(string[] args)
        {
        }

        private void CheckEula()
        {
            string eulaFile = "eula.txt";
            if (!File.Exists(eulaFile))
                File.WriteAllText(eulaFile, "eula=false");
            var eulaStr = File.ReadAllText(eulaFile);
            var eula = Serializer.Deserialize<EulaModel>(eulaStr);
            if (!eula.Eula)
            {
                var eulaAc = AnsiConsole.Ask<EulaAcceptState>("[bold] Accept Eula? (y/n)[/]");
                if ((int)eulaAc == 100)
                {
                    eula.Eula = true;
                    File.WriteAllText(eulaFile, Serializer.Serialize(eula));
                }
                else if ((int)eulaAc == 200)
                {
                    Logger.Warn("You need to accept the eula to run the server!");
                    CheckEula();
                }
                else
                {
                    Logger.Error("Invalid format");
                    CheckEula();
                }
            }
        }
    }
}