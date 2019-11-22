using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace ManiaGaming.Controllers
{
    public class WinkelwagenController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            //ViewBag.total = cart.Sum(item => Convert.ToInt32(item.Product.Prijs) * item.Quantity);
            return View();
        }
    }
}