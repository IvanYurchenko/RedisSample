using System.Web.Helpers;
using Newtonsoft.Json;
using RedisSample.Models;
using StackExchange.Redis;

namespace RedisSample.Redis
{
    public static class RedisManager
    {
        private static bool _fetched = false;
        public static void FetchDataFromDb()
        {
            using (var db = new MyDbContext())
            {
                // Clean up data
                foreach (var endPoint in RedisConnectorHelper.Connection.GetEndPoints(true))
                {
                    var server = RedisConnectorHelper.Connection.GetServer(endPoint);
                    server.FlushAllDatabases();
                }

                // Add data
                var cache = RedisConnectorHelper.Connection.GetDatabase();
                foreach (var foo in db.Foos)
                {
                    cache.StringSet($"Something:{foo.Id}", JsonConvert.SerializeObject(foo));
                }
            }
        }

        public static Foo GetFoo(int id)
        {
            if (!_fetched)
            {
                FetchDataFromDb();
                _fetched = true;
            }

            var cache = RedisConnectorHelper.Connection.GetDatabase();
            RedisValue value = cache.StringGet($"Something:{id}");
            if (value.IsNull) return null;
            return JsonConvert.DeserializeObject<Foo>(value);
        }
    }
}