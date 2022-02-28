using Logging.Net;
using MCSharp.Network;
using SlimeServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using static SlimeServer.Extensions.Utility;

namespace SlimeServer.MinecraftServerHost
{
    public class BasicNetworkServer : IStartableStopable
    {
        private Thread _listenerThr;
        private Thread _block;
        private TcpListener _listener;
        private List<MinecraftConnection> _connections = new List<MinecraftConnection>();

        public void Start()
        {
            _listenerThr = Thread(NetworkMain);
            _block = Thread(() => Sleep(-1));
        }

        public void Stop()
        {
            _listenerThr.Interrupt();
            _block.Interrupt();
        }

        internal void NetworkMain()
        {
            _listener = new TcpListener(IPAddress.Any, 25565);

            _listener.Start();

            _listener.BeginAcceptTcpClient(OnConnected, null);
        }


        internal void OnConnected(IAsyncResult ar)
        {
            TcpClient cl = _listener.EndAcceptTcpClient(ar);

            var connection = new MinecraftConnection(cl, MCSharp.Enums.MinecraftFlow.ClientToServer);

            PaketRegistry writer = new PaketRegistry();
            PaketRegistry.RegisterClientPakets(writer);

            PaketRegistry reader = new PaketRegistry();
            PaketRegistry.RegisterServerPakets(reader);

            connection.WriterRegistry = writer;
            connection.ReaderRegistry = reader;

            connection.Handler = new MinecraftPacketHandler()
            {
                Connection = connection
            };

            connection.Start();

            _connections.Add(connection);

            _listener.BeginAcceptTcpClient(OnConnected, null);
        }
    }
}
