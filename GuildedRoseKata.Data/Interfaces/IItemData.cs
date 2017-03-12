using System.Collections.Generic;
using GuildedRoseKata.Models;

namespace GuildedRoseKata.Data.Interfaces
{
    public interface IItemData
    {
        List<Item> LoadItems();
    }
}