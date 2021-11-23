using ArcadeCabinets.Core.Hooks;

namespace ArcadeCabinets {
    internal static class Utils {
        internal static void EnableInput() =>
            PreventNormalInputHook.shouldPreventInput = true;

        internal static void DisableInput() =>
            PreventNormalInputHook.shouldPreventInput = false;
    }
}
