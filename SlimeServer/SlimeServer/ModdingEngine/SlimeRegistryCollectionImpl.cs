using SlimeFramework;
using SlimeFramework.Internal;
using System;
using System.Collections.Generic;

namespace SlimeServer.ModdingEngine
{
    public class SlimeRegistryCollectionImpl<T> : SlimeRegistryCollection<T> where T : SlimeObject
    {
        public event ObjectAddEventHandler<T> ObjectAdded;
        public event ObjectRemoveEventHandler<T> ObjectRemoved;

        public Dictionary<RegistryLocation, T> Objects { get; private set; }

        public SlimeRegistryCollectionImpl()
        {
            Objects = new Dictionary<RegistryLocation, T>();
        }

        public override T Get(RegistryLocation location)
        {
            return Objects[location];
        }

        public override void Register(T obj)
        {
            Objects[obj.RegistryName] = obj;
            ObjectAdded?.Invoke(this, obj);
        }

        public override void Unregister(T obj)
        {
            Objects.Remove(obj.RegistryName);
            ObjectRemoved?.Invoke(this, obj);
        }
    }
}
