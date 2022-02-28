using fNbt;
using MCSharp.Network;
using MCSharp.Pakets;
using MCSharp.Pakets.Client.Login;
using MCSharp.Pakets.Client.Play;
using MCSharp.Pakets.Client.Status;
using MCSharp.Pakets.Server.Handshake;
using MCSharp.Pakets.Server.Login;
using MCSharp.Pakets.Server.Status;
using SlimeFramework;
using SlimeServer.Extensions;
using System;
using static SlimeServer.Extensions.Utility;

namespace SlimeServer.MinecraftServerHost
{
    internal class MinecraftPacketHandler : IPaketHandler
    {
        public MinecraftConnection Connection { get; set; }

        public void Handshake(IPaket paket)
        {
            if (paket is HandshakePaket p)
            {
                if (p.NextState == 1)
                {
                    Connection.State = MCSharp.Enums.MinecraftState.Status;
                }
                else
                {
                    Connection.State = MCSharp.Enums.MinecraftState.Login;
                }
            }
        }

        public void Login(IPaket paket)
        {
            if (paket is LoginStartPaket l)
            {
                DisconnectPaket dp = new()
                {
                    Message = "{\"text\": \"foo\",\"bold\": \"true\",\"extra\": [{\"text\": \"bar\"},{\"text\": \"baz\",\"bold\": \"false\"},{\"text\": \"qux\",\"bold\": \"true\"}]}"
                };
                Connection.SendPaket(dp);
                return;
                
                SetCompressionPaket scp = new()
                {
                    Threshold = 256
                };

                Connection.SendPaket(scp);

                MinecraftPlayer player = new()
                {
                    Name = l.Username,
                    Connection = Connection
                };
                SlimeFramework.MinecraftServer.Players.Add(player);

                LoginSuccessPaket lsp = new()
                {
                    Uuid = new MCSharp.Utils.Data.UUID("881ac95e-af99-4875-832c-b42d7ea82cb7"),
                    Username = "Masusniper"
                };

                Connection.SendPaket(lsp);

                Sleep(500);

                Connection.State = MCSharp.Enums.MinecraftState.Play;

                NbtFile file = new();
                file.LoadFromStream(Stream(ApplicationResource.dimcodec), NbtCompression.AutoDetect);
                var dimcodec = file.RootTag;

                JoinGamePaket jgp = new JoinGamePaket()
                {
                    EntityId = 1234,
                    IsHardcore = true,
                    Gamemode = 1,
                    PreviousGamemode = 1,
                    WorldCount = 3,
                    WorldNames = new string[]
                    {
                        "minecraft:overworld",
                        "minecraft:nether",
                        "minecraft:the_end"
                    },
                    WorldName = "minecraft:overworld",
                    DimesionCodec = dimcodec,
                    Dimesion = dimcodec,
                    EnableRespawnScreen = true,
                    HashedSeed = 12345678987,
                    IsDebug = false,
                    IsFlat = true,
                    MaxPlayers = 100,
                    ReducedDebugInfo = false,
                    SimulationDistance = 10,
                    ViewDistance = 10
                };

                Connection.SendPaket(jgp);
            }
        }

        public void Play(IPaket paket)
        {

        }

        public void Status(IPaket paket)
        {
            if (paket is StatusRequestPaket)
            {
                Console.WriteLine("Status requested");

                StatusResponsePaket srp = new StatusResponsePaket()
                {
                    Status = "{\"version\": {\"name\": \"1.18.1\",\"protocol\": 757},\"players\": {\"max\": 100,\"online\": 5,\"sample\": [{\"name\": \"thinkofdeath\",\"id\": \"4566e69f-c907-48ee-8d71-d7ba5aa00d20\"}]},\"description\": {\"text\": \"Hello world\"},\"favicon\": \"data:image/png;base64,<data>\"}"
                };

                //Connection.SendPaket(new StatusResponse().SetMaxPlayers(100).SetOnlinePlayers(500).GetPaket());
                Connection.SendPaket(srp);
            }

            if (paket is PingPaket r)
            {
                Console.WriteLine("Ping");
                PongPaket pp = new PongPaket()
                {
                    Payload = r.Payload
                };

                Connection.SendPaket(pp);
            }
        }
    }
}