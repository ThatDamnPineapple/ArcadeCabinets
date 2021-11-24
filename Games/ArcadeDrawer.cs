using ArcadeCabinets.Games.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace ArcadeCabinets.Games 
{
    internal static class ArcadeDrawer
    {
        public static Vector2 Position;

        public static Vector2 Size;

        public static Rectangle Hitbox => new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GameManager.CurrentGame.Target, Position, new Rectangle(0, 0, (int)Size.X, (int)Size.Y), Color.White);
        }
    }
}
