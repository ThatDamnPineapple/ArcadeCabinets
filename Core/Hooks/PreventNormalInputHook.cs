using Terraria.ModLoader;

namespace ArcadeCabinets.Core.Hooks {
    internal class PreventNormalInputHook {
        internal static bool shouldPreventInput; 

        internal static void Load() {
            On.Terraria.Main.DoUpdate_HandleInput += InputOverride;
        }

        private static void InputOverride(On.Terraria.Main.orig_DoUpdate_HandleInput orig, Terraria.Main self) {
            if (shouldPreventInput)
                return;
            orig(self);
        }
    }
}
