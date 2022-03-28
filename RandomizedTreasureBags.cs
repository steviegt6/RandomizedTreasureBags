using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace RandomizedTreasureBags
{
	public class RandomizedTreasureBags : Mod
	{
		public override void Load()
		{
			base.Load();
			
			On.Terraria.Player.OpenBossBag += PlayerOnOpenBossBag;
		}

		public override void Unload()
		{
			base.Unload();

			On.Terraria.Player.OpenBossBag -= PlayerOnOpenBossBag;
		}
		
		private static void PlayerOnOpenBossBag(
			On.Terraria.Player.orig_OpenBossBag orig,
			Player self,
			int type
		)
		{
			BagConfig cfg = BagConfig.Get;
			IEntitySource source = self.GetItemSource_OpenItem(type);

			int itemAmount = Main.rand.Next(cfg.MinimumItems, cfg.MaximumItems + 1);

			for (int i = 0; i < itemAmount; i++)
				self.QuickSpawnItem(
					source,
					Main.rand.Next(ItemID.DirtBlock, ItemLoader.ItemCount),
					Main.rand.Next(cfg.MinimumStack, cfg.MaximumStack)
				);
			
			if (cfg.DropDevArmor)
				self.TryGettingDevArmor(source);
		}
	}
}