using System.Linq;
using CoreLib;
using CoreLib.Submodules.ModEntity;
using PugMod;
using Unity.Burst;
using UnityEngine;

namespace MoreMinecarts
{
    public class MoreMinecartsMod : IMod
    {
        public const string VERSION = "1.0.1";
        public const string NAME = "More Minecarts";
        private LoadedMod modInfo;

        public void EarlyInit()
        {
            Debug.Log($"[{NAME}]: Mod version: {VERSION}");
            LoadModInfo();
            AdditionalLibraryLoading();
            Debug.Log($"[{NAME}]: Mod loaded successfully");

            CoreLibMod.LoadModules(typeof(EntityModule));

            Debug.Log($"[{NAME}]: Registering CoreLib Entity Modifications");
            EntityModule.RegisterEntityModifications(modInfo.ModId);
            //EntityModule.RegisterPrefabModifications(modInfo.ModId);
            Debug.Log($"[{NAME}]: Done Registering CoreLib Entity Modifications");
        }

        private void LoadModInfo()
        {
            modInfo = GetModInfo(this);
            if (modInfo == null)
            {
                Debug.Log($"[{NAME}]: Failed to load {NAME}: mod metadata not found!");
                return;
            }
        }

        private void AdditionalLibraryLoading()
        {
            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                string directory = API.ModLoader.GetDirectory(modInfo.ModId);
                BurstRuntime.LoadAdditionalLibrary($"{directory}/{NAME.Replace(" ", "")}_burst_generated.dll");
            }
        }

        public static LoadedMod GetModInfo(IMod mod)
        {
            return API.ModLoader.LoadedMods.FirstOrDefault(modInfo => modInfo.Handlers.Contains(mod));
        }


        public void Init()
        {
        }

        public void Shutdown()
        {
        }

        public void ModObjectLoaded(UnityEngine.Object obj)
        {
        }

        public void Update()
        {
        }
    }
}