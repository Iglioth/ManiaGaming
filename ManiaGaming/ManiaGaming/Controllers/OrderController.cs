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
        private readonly OrderRepository orderRepository;
        private readonly FiliaalRepository filiaalRepository;
        private readonly ProductRepository productRepository;

        //converters
        private readonly OrderViewModelConverter orderConverter = new OrderViewModelConverter();

        public OrderController(OrderRepository orderRepository, FiliaalRepository filiaalRepository, ProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.filiaalRepository = filiaalRepository;
            this.productRepository = productRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            OrderViewModel vm = new OrderViewModel();
            List<Order> Orders = new List<Order>();
            List<Order> NietOntvangenOrders = new List<Order>();
            Orders = orderRepository.GetAll();
            foreach(Order o in Orders)
            {
                if(o.Ontvangen == false)
                {
                    NietOntvangenOrders.Add(o);
                }
            }
            vm.Orders = orderConverter.ModelsToViewModels(NietOntvangenOrders);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            OrderDetailViewModel vm = new OrderDetailViewModel();
            Order o = new Order();
            o = orderRepository.GetById(id);
            vm = orderConverter.ModelToViewModel(o);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Aanmaken(OrderDetailViewModel vm, long id)
        {
            Product product = new Product();
            Order order = new Order();
            order = orderConverter.ViewModelToModel(vm);
            orderRepository.Insert(order); // DE INSERT KLOPT VOOR GEEN METER
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Aanmaken(OrderDetailViewModel vm)
        {
            Order o = new Order
            {
                Filialen = filiaalRepository.GetAll()
            };
            List<Product> products = productRepository.GetAll();
            List<Product> filterproducts = new List<Product>();
            foreach (Product p in products)
            {
                //o.producten.RemoveAll(r => r.Tweedehands == true);
                if (!p.Tweedehands)
                {
                    filterproducts.Add(p);
                }
            }

            o.Producten = filterproducts;

            vm = orderConverter.ModelToViewModel(o);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Ontvangen(int id)
        {
            Order order = orderRepository.GetById(id);
            if(orderRepository.Actief(id, order.Ontvangen) == true)
            {
                //Product is ontvangen.Hier de producten toevoegen aan voorraad
                if(productRepository.UpdateVoorraad(order.ProductID,order.Aantal) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //Product die geleverd zijn zijn nog niet toegevoegd aan de voorraad van het product
                }
            }
            else
            {

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Aanpassen(OrderDetailViewModel vm)
        {
            Order o = orderConverter.ViewModelToModel(vm);
            orderRepository.Update(o);

            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public IActionResult Aanpassen(long id)
        {
            OrderDetailViewModel vm = new OrderDetailViewModel();
            Order o = orderRepository.GetById(id);
            vm = orderConverter.ModelToViewModel(o);

            return View(vm); 
        }

    }
}  


//if(vm.Ontvangen == true)
            //{             
            //    Product p = productRepository.GetById(vm.ProductId);
            //    p.Aantal += vm.aantal;
            //    productRepository.Update(p);
                
                
                
            //}
            //else
            //{
                
            //    orderRepository.Insert(order);
            //    return RedirectToAction("Index");
            //}
            