using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ArcadeCabinets.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ArcadeCabinets.Games.Bases {
    // It's called ArcadeGame in order to not conflict or be confused with XNA's Game class.
    internal abstract class ArcadeGame : IDisposable {
        public RenderTarget2D Target;

        protected Rectangle hitbox;
        protected ControllerState controllerState;

        protected Color backgroundColor;

        protected List<IGameObject> objects = new List<IGameObject>();

        public virtual void Initialize() {
            InitializeRenderTarget();
        }
        // TODO: Handle basic input functionality in virtual Update method
        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void DestroyGame();
        public abstract void InitializeRenderTarget();

        public void Dispose() {
            Target.Dispose();
            DestroyGame();
        }

        public void UpdateObjects()
        {
            foreach (IGameObject i in objects)
                i.Update();
        }
    }
}
