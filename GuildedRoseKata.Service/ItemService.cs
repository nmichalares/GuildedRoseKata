using GuildedRoseKata.Data.Interfaces;
using GuildedRoseKata.Models;
using GuildedRoseKata.Models.Extensions;
using GuildedRoseKata.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GuildedRoseKata.Service
{
    public class ItemService : IItemService
    {
        private IItemData _items;

        public ItemService()
        {
            _items = new Data.ItemData();
        }

        public List<ItemForSale> GetItems()
        {
            return _items.LoadItems().Select(i => new ItemForSale(i.Name, i.SellIn, i.Quality)).ToList();
        }

        public void DailyOperation(ItemForSale item)
        {
            if (item.IsLegendary)
            {
                return;
            }

            item.DecreaseSellIn();

            if (item.CanExpire && item.IsPastSellDate)
            {
                item.ResetItemQuality();
                return;
            }

            if (item.IncreasesIncrementallyBetterTowardsSellIn)
            {
                item.HandleIncrementalQualityIncrease();
            }

            if (item.GetsBetterWithAge)
            {
                item.UpdateIncreasedItemQuality();
            }
            else
            {
                item.UpdateDecreasedItemQuality();
            }
        }
    }
}

