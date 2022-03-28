using System.ComponentModel;
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
    }
}