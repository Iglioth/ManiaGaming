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

        public OrderController(OrderRepository orderRepository)
        {
            this.repo = orderRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            OrderViewModel vm = new OrderViewModel();
            List<Order> Orders = new List<Order>();
            Orders = repo.GetAll();
            vm.Orders = orderConverter.ModelsToViewModels(Orders);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            OrderDetailViewModel vm = new OrderDetailViewModel();
            Order o = new Order();
            o = repo.GetById(id);
            vm = orderConverter.ModelToViewModel(o);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create(OrderDetailViewModel vm)
        {
            Order o = new Order();
            o = orderConverter.ViewModelToModel(vm);
            repo.Insert(o);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Ontvangen(int id)
        {
            Order order = repo.GetById(id);
            if(repo.Actief(id, order.Ontvangen) == false)
            {
                //Show that there has been an error
            }
            else
            {

            }
            return RedirectToAction("Index");
        }

        
    }
}