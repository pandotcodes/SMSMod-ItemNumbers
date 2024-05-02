using BepInEx;
using HarmonyLib;

namespace ItemNumbers
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded! Applying patch...");
            Harmony harmony = new Harmony("com.orpticon.ItemNumbers");
            harmony.PatchAll();
        }
    }
    public static class ItemNumberPatch
    {
        [HarmonyPatch(typeof(Label))]
        [HarmonyPatch("ProductCount", MethodType.Setter)]
        public static class Label_ProductCount_Patch
        {
            public static void Postfix(Label __instance)
            {
                __instance.m_ProductCount.text = __instance.m_DisplaySlot.ProductID.ToString();
            }
        }
    }
}
