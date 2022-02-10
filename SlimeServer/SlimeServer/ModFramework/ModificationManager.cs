using SlimeServer.ModdingEngine;
using System;

namespace SlimeServer.ModFramework
{
    public class ModificationManager
    {
        #region static
        public static ModificationManager Instance { get; private set; }

        public static void Start()
        {
            Instance = new();
            Instance.Run();
        }
        #endregion

        public SlimeRegistryImpl SlimeRegistry { get; private set; }

        public ModificationManager()
        {

        }

        private void Run()
        {
            Initialize();
        }

        private void Initialize()
        {
            SlimeRegistry = new SlimeRegistryImpl();
        }
    }
}
