using GuildedRoseKata.Data;
using GuildedRoseKata.Models;
using GuildedRoseKata.Service;
using GuildedRoseKata.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GuildedRoseKata.Api.Controllers
{
    [Route("api/[controller]")]
    public class DailyOperationController : Controller
    {
        public IItemService _itemsService;

        public DailyOperationController(IItemService itemService)
        {
            _itemsService = itemService;
        }

        [HttpPost]
        public List<ItemForSale> Post()
        {
            var itemsForSale = _itemsService.GetItems();

            foreach (var item in itemsForSale)
            {
                _itemsService.DailyOperation(item);
            }

            return itemsForSale;
        }
        
    }
}
