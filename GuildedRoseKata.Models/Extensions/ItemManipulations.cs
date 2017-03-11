namespace GuildedRoseKata.Models.Extensions
{
    public static class ItemManipulations
    {
        public static void DecreaseSellIn(this ItemForSale item)
        {
            item.SellIn--;
        }

        public static void ResetItemQuality(this ItemForSale item)
        {
            item.Quality = ItemForSale.MIN_QUALITY;
        }

        public static void HandleIncrementalQualityIncrease(this ItemForSale item)
        {
            if (item.SellIn < 10)
            {
                AddItemQuality(item);
            }
            if (item.SellIn < 5)
            {
                AddItemQuality(item);
            }
        }

        public static void UpdateDecreasedItemQuality(this ItemForSale item)
        {
            SubtractItemQuality(item);
            if (item.IsPastSellDate)
            {
                SubtractItemQuality(item);
            }

            AssureItemQualityMinMax(item);
        }

        public static void UpdateIncreasedItemQuality(this ItemForSale item)
        {
            AddItemQuality(item);
            if (item.IsPastSellDate)
            {
                AddItemQuality(item);
            }

            AssureItemQualityMinMax(item);
        }


        private static void AssureItemQualityMinMax(this ItemForSale item)
        {
            if (item.Quality > ItemForSale.MAX_QUALITY)
            {
                item.Quality = ItemForSale.MAX_QUALITY;
            }

            if (item.Quality < ItemForSale.MIN_QUALITY)
            {
                item.Quality = ItemForSale.MIN_QUALITY;
            }
        }

        private static void SubtractItemQuality(this ItemForSale item)
        {
            item.Quality--;
            if (item.IsConjured)
            {
                item.Quality--;
            }
        }

        private static void AddItemQuality(this ItemForSale item)
        {
            item.Quality++;
        }
    }
}
