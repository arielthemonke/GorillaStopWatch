using System;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;

namespace GorillaStopWatch
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.ProjectName, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void Start()
        {
            GorillaTagger.OnPlayerSpawned(Init);
        }

        void Init()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }
    }
}
