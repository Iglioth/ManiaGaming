using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManiaGaming.Controllers
{
    public class OrderController : Controller
    {
        //repos
        private readonly OrderRepository repo;


        //converters
        private readonly OrderViewModelConverter orderConverter = new OrderViewModelConverter();


        [HttpGet]
        public IActionResult Index()
        {
            OrderViewModel vm = new OrderViewModel();
            List<Order> Orders = new List<Order>();
            Orders = repo.GetAll();
            return View(vm);
        }


        
    }
}