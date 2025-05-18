using HarmonyLib;
using StardewModdingAPI;

namespace ConfirmSleep
{
    public class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            ObjectPatches.ModInstance = this;

            var harmony = new Harmony(this.ModManifest.UniqueID);
            harmony.Patch(
                original: AccessTools.Method(typeof(StardewValley.Game1), nameof(StardewValley.Game1.showEndOfNightStuff)),
                prefix: new HarmonyMethod(typeof(ObjectPatches), nameof(ObjectPatches.Game1_showEndOfNightStuff_Prefix))
            );
        }
    }
}
