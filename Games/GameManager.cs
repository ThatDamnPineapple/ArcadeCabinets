using ArcadeCabinets.Games.Bases;
using Terraria;

namespace ArcadeCabinets.Games {
    internal static class GameManager {

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
            _currentGame.Update();
        }

        public static void DrawGame() {
            _currentGame.Draw(Main.spriteBatch);
        }
    }
}
