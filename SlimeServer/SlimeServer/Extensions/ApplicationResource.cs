namespace SlimeServer.Extensions
{
    public class ApplicationResource
    {
        public static ApplicationResource dimcodec { get; set; } = new ApplicationResource(ResourceFiles.dimcodec);
        public static ApplicationResource server { get; set; } = new ApplicationResource(ResourceFiles.server);

        public ApplicationResource(byte[] data)
        {
            Data = data;
        }

        public byte[] Data { get; }
    }
}