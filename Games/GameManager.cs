using ArcadeCabinets.Games.Bases;
using Terraria;

namespace ArcadeCabinets.Games {
    internal static class GameManager {

        public static bool TerrariaMusicDisabled = false;
        public static bool AnyCurrentGame => CurrentGame != null || CurrentGame.Disposed;
        static ArcadeGame _currentGame;
        public static ArcadeGame CurrentGame {
            get {
                return _currentGame;
            }
            set {
                _currentGame.Dispose();
                _currentGame = value;
                _currentGame.Initialize();
            }
        } 

        public static void UpdateGame() {
            // TODO: Should disable music? If not, we need to come up with a struct to save music volume and set music volume to 0 while this happens.
            if (TerrariaMusicDisabled)
                Main.musicFade[Main.curMusic] = 0f;

            _currentGame.UpdateGame();
        }

        public static void DrawGame() {
            var prevTargets = Main.instance.GraphicsDevice.GetRenderTargets();
            Main.instance.GraphicsDevice.SetRenderTarget(_currentGame.Target);
            _currentGame.Draw(Main.spriteBatch);
            Main.instance.GraphicsDevice.SetRenderTargets(prevTargets);
        }
    }
}
