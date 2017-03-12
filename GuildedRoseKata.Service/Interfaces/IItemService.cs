using System.Collections.Generic;
using GuildedRoseKata.Models;

namespace GuildedRoseKata.Service.Interfaces
{
    public interface IItemService
    {
        void DailyOperation(ItemForSale item);
        List<ItemForSale> GetItems();
    }
}