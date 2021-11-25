
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
	public abstract class ArcadeItem : ModItem
	{

		public int TileType { get; }

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 34;
			item.value = 150;

			item.maxStack = 99;

			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 10;
			item.useAnimation = 15;

			item.useTurn = true;
			item.autoReuse = true;
			item.consumable = true;

			item.createTile = TileType;
		}
	}
	public abstract class ArcadeTile : ModTile
	{

		public int ItemType { get; }


		protected ArcadeGame game;
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			animationFrameHeight = 54;
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table | AnchorType.SolidTile | AnchorType.SolidWithTop, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.StyleWrapLimit = 2; //not really necessary but allows me to add more subtypes of chairs below the example chair texture
			TileObjectData.newTile.StyleMultiplier = 2; //same as above
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight; //allows me to place example chairs facing the same way as the player
			TileObjectData.addAlternate(1); //facing right will use the second texture style
			TileObjectData.addTile(Type);
			dustType = -1;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Arcade Cabinet");
			AddMapEntry(new Microsoft.Xna.Framework.Color(200, 200, 200), name);
		}
		public override void RightClick(int i, int j)
		{
			float minLength = 9999;
			Player nearestPlayer = Main.player[Main.myPlayer];
			foreach(Player player in Main.player)
			{
				Vector2 dist = player.Center - new Vector2(i * 16, j * 16);
				if (dist.Length() < minLength)
				{
					nearestPlayer = player;
					minLength = dist.Length();
				}
			}
			if (Main.player[Main.myPlayer] == nearestPlayer)
            {
				GameManager.CurrentGame = game;
            }
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 64, 48, ItemType);
		}
	}
}