using Dalk.PropertiesSerializer;

namespace SlimeServer.Models
{
    public class EulaModel
    {
        [PropertyName("eula")]
        public bool Eula { get; set; }
    }
}
