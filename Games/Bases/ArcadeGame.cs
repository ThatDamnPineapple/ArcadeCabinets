using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ArcadeCabinets.Interfaces;
using Terraria;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ArcadeCabinets.Games.Bases {
    // It's called ArcadeGame in order to not conflict or be confused with XNA's Game class.
    public abstract class ArcadeGame : IDisposable {
        public RenderTarget2D Target;
        public bool ShouldResetTargetWhenVanillaDoes = false;
        public bool Disposed = false;

        protected Rectangle hitbox;
        protected ControllerState controllerState;
        protected Color backgroundColor;
        protected List<IGameObject> objects = new List<IGameObject>();

        public virtual void Initialize() {
            InitializeRenderTarget();
        }
        protected abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void DestroyGame();
        public abstract void InitializeRenderTarget();

        public void Dispose() {
            Target.Dispose();
            DestroyGame();
            Disposed = true;
        }
        public void UpdateGame() {
            controllerState.Update();
            Update();
        }
        public void DrawBackground(SpriteBatch spriteBatch) => spriteBatch.Draw(Main.magicPixel, hitbox, null, backgroundColor, 0f, Vector2.Zero, SpriteEffects.None, 0f);

        protected void UpdateObjects() {
            foreach (IGameObject i in objects)
                i.Update();
        }
    }
}
