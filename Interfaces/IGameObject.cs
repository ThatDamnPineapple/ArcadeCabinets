﻿using ArcadeCabinets.Games.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace ArcadeCabinets.Interfaces {
    public interface IGameObject
    {
        Vector2 Position { get; set; }

        void Draw(SpriteBatch spriteBatch);

        void Update();
    }
}