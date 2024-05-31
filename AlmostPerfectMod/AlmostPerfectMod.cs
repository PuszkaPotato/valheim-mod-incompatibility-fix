using BepInEx;
using UnityEngine;

namespace AlmostPerfectMod
{
    [BepInPlugin("com.puszkapotato.almostperfectmod", "Almost Perfect Mod", "1.0.0")]

    // Don't run if A Perfect Mod is present
    [BepInIncompatibility("com.puszkapotato.aperfectmod")]
    public class AlmostPerfectMod : BaseUnityPlugin
    {
        void Awake()
        {
            // This method is called when the game initializes
            Logger.LogInfo("Almost Perfect Mod Loaded!");
        }
    }
}