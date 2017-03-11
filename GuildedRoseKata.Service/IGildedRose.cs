using System.Collections.Generic;
using GuildedRoseKata.Models;

namespace GuildedRoseKata.Service
{
    public interface IGildedRose
    {
        void DailyOperation(ItemForSale item);
        List<ItemForSale> GetItems();
    }
}