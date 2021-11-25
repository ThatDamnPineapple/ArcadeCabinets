using ArcadeCabinets.Core.Hooks;

namespace ArcadeCabinets.Core {
    internal static class HookLoader {
        internal static void Load() {
            PreventNormalInputHook.Load();
            InitializeRenderTargetsWithVanillaHook.Load();
            DrawToTargetHook.Load();
        }
    }
}
