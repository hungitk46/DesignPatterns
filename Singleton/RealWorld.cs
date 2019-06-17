using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class RealWorld
    {
        public void Run()
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Same instance?

            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests
            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.NextServer.Name;
                Console.WriteLine("Dispatch Request to: " + server);
            }
        }
    }
    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    sealed class LoadBalancer
    {
        private static LoadBalancer _instance = new LoadBalancer();
        private List<Server> _servers;
        private readonly Random _random = new Random();

        // Constructor (protected)
        protected LoadBalancer()
        {
            // Load list of available servers
            _servers = new List<Server>
                    {
                     new Server{ Name = "ServerI", IP = "120.14.220.18" },
                     new Server{ Name = "ServerII", IP = "120.14.220.19" },
                     new Server{ Name = "ServerIII", IP = "120.14.220.20" },
                     new Server{ Name = "ServerIV", IP = "120.14.220.21" },
                     new Server{ Name = "ServerV", IP = "120.14.220.22" },
                    };
        }

        public static LoadBalancer GetLoadBalancer()
        {
            return _instance;
        }

        // Simple, but effective random load balancer
        public Server NextServer
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }
    /// <summary>
    /// Represents a server machine
    /// </summary>
    public class Server
    {
        // Gets or sets server name
        public string Name { get; set; }

        // Gets or sets server IP address
        public string IP { get; set; }
    }
}
