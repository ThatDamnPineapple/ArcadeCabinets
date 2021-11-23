using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ArcadeCabinets.Games.Bases {
    // It's called ArcadeGame in order to not conflict or be confused with XNA's Game class.
    internal abstract class ArcadeGame : IDisposable {
        protected RenderTarget2D target;
        protected Rectangle hitbox;
        protected ControllerState controllerState;

        public virtual void Initialize() {
            InitializeRenderTarget();
        }
        // TODO: Handle basic input functionality in virtual Update method
        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void DestroyGame();
        public abstract void InitializeRenderTarget();

        public void Dispose() {
            target.Dispose();
            DestroyGame();
        }
    }
}
