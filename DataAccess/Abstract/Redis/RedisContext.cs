using StackExchange.Redis;

namespace DataAccess.Abstract.Redis
{
    public class RedisContext
    {
        private ConnectionMultiplexer _ConnectionMultiplexer;
        private string _host;
        private string _port;
        public RedisContext(string host, string port)
        {
            _host = host;
            _port = port;
        }

        public void Connect()
        {
            ConfigurationOptions options = ConfigurationOptions.Parse($"{_host}:{_port}");
            options.Password = "TLXxH9OPdArKLWh56feiYLs8Us79u1Jg";
            _ConnectionMultiplexer = ConnectionMultiplexer.Connect(options);
        }

        public IDatabase GetDb(int db = 1) => _ConnectionMultiplexer.GetDatabase(db);
    }
}
