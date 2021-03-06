﻿using System;
using System.Collections.Generic;

namespace PushX.Servers
{
    public class ServerFactory :IDisposable
    {
        private HashSet<Server> _createdServers = null;
        private string factoryName = null;

        public ServerFactory()
        {
            factoryName = Guid.NewGuid().ToString();
            _createdServers = new HashSet<Server>();
        }

        public ServerFactory(string factoryName)
        {
            this.factoryName = factoryName;
            _createdServers = new HashSet<Server>();
        }

        public Server CreateServer(ServerType serverType)
        {
            switch (serverType)
            {
                case ServerType.PushServer:
                    GCMPushServer server = new GCMPushServer();
                    server._Key = Guid.NewGuid().ToString();
                    _createdServers.Add(server);
                    return server;
            }

            return null;
        }

        public void Dispose()
        {
            _dispose();
        }

        private void _dispose()
        {
            _createdServers.Clear();
        }
    }
}
