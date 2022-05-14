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
			IEntitySource source = self.GetSource_OpenItem(type);
			const string bossBag = "bossBag";

			if (cfg.UseTmlMethods && !ItemLoader.PreOpenVanillaBag(bossBag, self, type))
				return;
			
			if (cfg.UseTmlMethods)
				ItemLoader.OpenVanillaBag(bossBag, self, type);

			int itemAmount = Main.rand.Next(cfg.MinimumItems, cfg.MaximumItems + 1);

			for (int i = 0; i < itemAmount; i++)
			{
				int newType = Main.rand.Next(ItemID.DirtBlock, ItemLoader.ItemCount);
				int newStack = Main.rand.Next(cfg.MinimumStack, cfg.MaximumStack);
				Item sample = ContentSamples.ItemsByType[newType];

				if (newStack > sample.maxStack && cfg.RestrictStacKSize)
					newStack = sample.maxStack;
				
				self.QuickSpawnItem(source, newType, newStack);
			}

			int irrelevant = 0;
			if (cfg.UseTmlMethods)
				ItemLoader.OpenBossBag(type, self, ref irrelevant);

			if (cfg.DropDevArmor && ItemID.Sets.BossBag[type] && (!ItemID.Sets.PreHardmodeLikeBossBag[type] || Main.tenthAnniversaryWorld))
				self.TryGettingDevArmor(source);
			
			// if (cfg.UseTmlMethods)
			NPCLoader.blockLoot.Clear();
		}
	}
}