
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.Enums;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using ArcadeCabinets.Games.Bases;
using ArcadeCabinets.Games;
namespace ArcadeCabinets.Content
{
	public class SnakeItem : ArcadeItem
	{

		public int TileType => ModContent.TileType<SnakeTile>();
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snake");

		}
	}
	public class SnakeTile : ArcadeTile
	{

		public int ItemType => ModContent.ItemType<SnakeItem>();


		protected ArcadeGame game;

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frameCounter++;
			if (frameCounter >= 10) //replace 10 with duration of frame in ticks
			{
				frameCounter = 0;
				frame++;
				frame %= 2;
			}
		}
	}
}