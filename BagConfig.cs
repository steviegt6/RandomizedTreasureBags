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

        [Header("Range Configuration")]
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
        
        [Label("Maximum Stack Count")]
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
    }
}