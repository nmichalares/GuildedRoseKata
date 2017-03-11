using GuildedRoseKata.Data;
using GuildedRoseKata.Models;
using GuildedRoseKata.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GuildedRoseKata.Api.Controllers
{
    [Route("api/[controller]")]
    public class DailyOperationController : Controller
    {
        public IGildedRose Service;

        public DailyOperationController()
        {
            Service = new GildedRose();
        }

        public DailyOperationController(IGildedRose service)
        {
            Service = service;
        }

        [HttpPost]
        public void Post()
        {
            var itemsForSale = Service.GetItems();

            foreach (var item in itemsForSale)
            {
                Service.DailyOperation(item);
            }
        }
        
    }
}
