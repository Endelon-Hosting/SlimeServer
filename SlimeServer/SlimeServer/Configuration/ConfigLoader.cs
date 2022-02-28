using Dalk.PropertiesSerializer;
using static SlimeServer.Extensions.Utility;

namespace SlimeServer.Configuration
{
    public class ConfigLoader
    {
        private static Config _config = null;
        public static Config Config
        {
            get
            {
                if (_config == null)
                    _config = LoadConfig();
                return _config;
            }
            set
            {
                _config = value;
            }
        }

        private static Config LoadConfig()
        {
            return Serializer.Deserialize<Config>(Content(File("server.properties"), Content(Extensions.ApplicationResource.server)));
        }

        public static void Init() => _config = LoadConfig();
    }
}
