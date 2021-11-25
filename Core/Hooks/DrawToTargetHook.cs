using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace ArcadeCabinets.Core.Hooks {
    internal class DrawToTargetHook {

        internal static void Load() {
            Main.OnPreDraw += Main_OnPreDraw;
        }

        private static void Main_OnPreDraw(GameTime obj)
        {
            
        }
    }
}
