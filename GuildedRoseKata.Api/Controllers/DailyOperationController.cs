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

        public DailyOperationController()
        {
            _itemsService = new ItemService();
        }

        public DailyOperationController(IItemService service)
        {
            _itemsService = service;
        }

        [HttpPost]
        public void Post()
        {
            var itemsForSale = _itemsService.GetItems();

            foreach (var item in itemsForSale)
            {
                _itemsService.DailyOperation(item);
            }
        }
        
    }
}
