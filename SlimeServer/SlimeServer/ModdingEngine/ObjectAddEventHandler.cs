using SlimeFramework;

namespace SlimeServer.ModdingEngine
{
    public delegate void ObjectAddEventHandler<T>(object sender, T t) where T : SlimeObject;
}