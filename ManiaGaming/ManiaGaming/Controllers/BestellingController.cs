using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ManiaGaming.Controllers
{
    public class BestellingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}