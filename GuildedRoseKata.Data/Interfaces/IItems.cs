using System.Collections.Generic;
using GuildedRoseKata.Models;

namespace GuildedRoseKata.Data.Interfaces
{
    public interface IItems
    {
        List<Item> LoadItems();
    }
}