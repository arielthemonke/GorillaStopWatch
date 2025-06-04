using System;
using System.IO;
using System.Reflection;
using BepInEx;
using GorillaStats;
using UnityEngine;
using UnityEngine.InputSystem;

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
            GorillaStatsAPI.RegisterPage(new Page());
        }
        
        // remove later
        void Update()
        {
            if (ControllerInputPoller.instance.leftControllerPrimaryButton)
            {
                NotifLib.instance.SendNotification("message yay", 2f);
            }
        }
        
    }
}
