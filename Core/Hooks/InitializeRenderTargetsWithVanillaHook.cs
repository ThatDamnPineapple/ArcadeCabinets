using ArcadeCabinets.Games.Bases;
using ArcadeCabinets.Games;

namespace ArcadeCabinets.Core.Hooks {
    internal static class InitializeRenderTargetsWithVanillaHook {
        public static void Load() {
            On.Terraria.Main.InitTargets += InitTargetsWithVanilla;
        }

        public static void Unload()
        {
            On.Terraria.Main.InitTargets -= InitTargetsWithVanilla;
        }

        private static void InitTargetsWithVanilla(On.Terraria.Main.orig_InitTargets orig, Terraria.Main self) {
            orig(self);
            if(GameManager.CurrentGame != null && GameManager.CurrentGame.ShouldResetTargetWhenVanillaDoes) {
                GameManager.CurrentGame.InitializeRenderTarget();
            }
        }
    }
}
