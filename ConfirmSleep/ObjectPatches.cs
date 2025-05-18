using ConfirmSleep;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using static StardewValley.GameLocation;

namespace ConfirmSleep
{
    internal class ObjectPatches
    {
        // initialized by ModEntry.cs
        public static ModEntry ModInstance;
        
        public static bool Game1_showEndOfNightStuff_Prefix()
        {
            // if needed, force player to see a shipped-items list (which they must then confirm before day ends)
            // Spring 1 Year 1: DaysPlayed = 1 at start of day, 2 at end of day
            if (Game1.player.displayedShippedItems.Count == 0 && Game1.stats.DaysPlayed > 1)
            {
                ModInstance.Monitor.Log("[Confirm Sleep] Shipped-items list is empty", LogLevel.Trace);
                var obj = ItemRegistry.Create("JohnPeters.NoTea");
                ModInstance.Monitor.Log("[Confirm Sleep] Created placeholder item", LogLevel.Trace);
                Game1.player.displayedShippedItems.Add(obj);
                ModInstance.Monitor.Log("[Confirm Sleep] Added placeholder item to shipped-items list", LogLevel.Debug);
            }

            // allow base game function to run normally
            return true;
        }
    }
}
