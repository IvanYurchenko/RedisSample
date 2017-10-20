using System;
using StackExchange.Redis;

namespace RedisSample.Redis
{
    public class RedisConnectorHelper
    {
        static RedisConnectorHelper()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect("localhost,allowAdmin=true"));
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        public static ConnectionMultiplexer Connection => lazyConnection.Value;
    }
}