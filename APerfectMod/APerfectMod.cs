using BepInEx;
using UnityEngine;

namespace APerfectMod
{
    [BepInPlugin("com.puszkapotato.aperfectmod", "A Perfect Mod", "1.0.0")]
    public class APerfectMod : BaseUnityPlugin
    {
        void Awake()
        {
            // This method is called when the game initializes
            Logger.LogInfo("A Perfect Mod Loaded!");
        }
    }
}
