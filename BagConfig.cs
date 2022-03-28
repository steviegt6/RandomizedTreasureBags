using System.ComponentModel;
using System.Diagnostics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace RandomizedTreasureBags
{
    [Label("Treasure Bag Config")]
    public class BagConfig : ModConfig
    {
        public static BagConfig Get => ModContent.GetInstance<BagConfig>();

        public override ConfigScope Mode => ConfigScope.ServerSide;

        #region Backing Fields

        private int minimumItems;
        private int maximumItems;
        private int minimumStack;
        private int maximumStack;

        #endregion

        #region Item Count

        [Header("Range Configuration")]
        [Tooltip("The maximum amount of items a treasure bag may drop.")]
        [Label("Maximum Item Count")]
        [DefaultValue(10)]
        [Range(1, 50)]
        [Slider]
        public int MaximumItems
        {
            get => maximumItems;

            set
            {
                if (value < MinimumItems)
                    value = MinimumItems;

                maximumItems = value;
            }
        }
        
        [Label("Minimum Item Count")]
        [Tooltip("The minimum amount of items a treasure bag may drop.")]
        [DefaultValue(5)]
        [Range(1, 50)]
        [Slider]
        public int MinimumItems
        {
            get => minimumItems;

            set
            {
                if (value > MaximumItems)
                    value = MaximumItems;

                minimumItems = value;
            }
        }

        #endregion

        #region Stack

        [Label("Maximum Stack Count")]
        [Tooltip("The maximum stack count an item may have when dropped.")]
        [DefaultValue(50)]
        [Range(1, 50)]
        [Slider]
        public int MaximumStack
        {
            get => maximumStack;

            set
            {
                if (value < MinimumStack)
                    value = MinimumStack;

                maximumStack = value;
            }
        }
        
        [Label("Minimum Stack Count")]
        [Tooltip("The minimum stack count an item may have when dropped.")]
        [DefaultValue(5)]
        [Range(1, 50)]
        [Slider]
        public int MinimumStack
        {
            get => minimumStack;

            set
            {
                if (value > MaximumStack)
                    value = MaximumStack;

                minimumStack = value;
            }
        }

        #endregion

        [Header("Misc. Options")]
        [Label("Drop Dev. Armor")]
        [Tooltip("Allow treasure bags to still drop developer armor sets.")]
        [DefaultValue(true)]
        public bool DropDevArmor { get; set; } = true;

        [Label("Call tModLoader Methods")]
        [Tooltip("Call tModLoader's methods for handling modded content.\nThis may cause regular items to be dropped.")]
        [DefaultValue(false)]
        public bool UseTmlMethods { get; set; } = false;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            message = "NOTICE: When saving, the dummy config might mess up if you modified sliders." +
                      "\nPlease know that even if the sliders reset, your changes were saved!";
            
            return base.AcceptClientChanges(pendingConfig, whoAmI, ref message);
        }
    }
}