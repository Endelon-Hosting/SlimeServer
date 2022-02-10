using SlimeFramework;

namespace SlimeServer.ModdingEngine
{
    public delegate void ObjectRemoveEventHandler<T>(object sender, T t) where T : SlimeObject;
}