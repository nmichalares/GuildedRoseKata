namespace GuildedRoseKata.Models
{
    public class ItemForSale : Item
    {
        public const int MAX_QUALITY = 50;
        public const int MIN_QUALITY = 0;

        public ItemForSale(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public bool IsLegendary
        {
            get { return Name == "Sulfuras, Hand of Ragnaros"; }
        }

        public bool CanExpire
        {
            get { return Name == "Backstage passes to a TAFKAL80ETC concert"; }
        }

        public bool IncreasesIncrementallyBetterTowardsSellIn
        {
            get { return Name == "Backstage passes to a TAFKAL80ETC concert"; }
        }

        public bool IsPastSellDate
        {
            get { return SellIn < 0; }
        }

        public bool IsConjured
        {
            get { return Name.Contains("Conjured"); }
        }

        public bool GetsBetterWithAge
        {
            get { return Name == "Aged Brie" || Name == "Backstage passes to a TAFKAL80ETC concert"; }
        }
    }
}
