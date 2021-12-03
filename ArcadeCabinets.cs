using Terraria.ModLoader;
using ArcadeCabinets.Core;

namespace ArcadeCabinets
{
	public class ArcadeCabinets : Mod
	{
		public override void Load() {
			HookLoader.Load();
        }
        public override void Unload()
        {
            HookLoader.Unload();
        }
    }
}