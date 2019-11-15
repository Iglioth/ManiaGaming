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
        private readonly FiliaalRepository frepo;
        private readonly ProductRepository prepo;

        //converters
        private readonly OrderViewModelConverter orderConverter = new OrderViewModelConverter();

        public OrderController(OrderRepository orderRepository, FiliaalRepository filiaalRepository, ProductRepository productRepository)
        {
            this.repo = orderRepository;
            this.frepo = filiaalRepository;
            this.prepo = productRepository;
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
        //public IActionResult Detail(int id)
        //{
        //    OrderDetailViewModel vm = new OrderDetailViewModel();
        //    Order o = new Order();
        //    o = repo.GetById(id);
        //    vm = orderConverter.ModelToViewModel(o);
        //    return View(vm);
        //}

        [HttpPost]
        public IActionResult Aanmaken(OrderDetailViewModel vm, long id)
        {
            Order o = new Order();
            o = orderConverter.ViewModelToModel(vm);
            repo.Insert(o);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Aanmaken(OrderDetailViewModel vm)
        {
            Order o = new Order();
            o.Filialen = frepo.GetAll();
            o.producten = prepo.GetAll();
            vm = orderConverter.ModelToViewModel(o);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Ontvangen(int id)
        {
            Order order = repo.GetById(id);
            if(!repo.Actief(id, order.Ontvangen))
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