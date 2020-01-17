using System;
using System.Collections.Generic;
using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManiaGaming.Controllers
{
    public class OrderController : BaseController
    {
        //repos
        private readonly OrderRepository orderRepository;
        private readonly FiliaalRepository filiaalRepository;
        private readonly ProductRepository productRepository;

        private readonly WerknemerRepository werknemerRepo;
        //GetUserId();
        

        //converters
        private readonly OrderViewModelConverter orderConverter = new OrderViewModelConverter();

        public OrderController(OrderRepository orderRepository, FiliaalRepository filiaalRepository, ProductRepository productRepository, WerknemerRepository werknemerRepo)
        {
            this.werknemerRepo = werknemerRepo;
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
            
            Order order = new Order();
            order = orderConverter.ViewModelToModel(vm);
            order.FiliaalID = 9; // Is niet mogelijk om via de vm te ontvangen
            long ID = GetUserId();
            Werknemer w = werknemerRepo.GetById(ID);
            order.WerknemerID = w.WerknemerId; 
            order.Datum = DateTime.Now;
            orderRepository.Insert(order);
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
                // Het is niet gelukt om de product op ontvangen true  te zetten
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

        [HttpPost]
        public IActionResult FiliaalOrderVerzoek(long id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult FiliaalOrderVerzoek()
        {
            OrderViewModel vm = new OrderViewModel();
            List<Order> TemporaryOrders = new List<Order>();
            List<Order> orders = new List<Order>();
            TemporaryOrders = orderRepository.GetAll();
            int id = werknemerRepo.GetWerknemerID(GetUserId());
            Werknemer w = werknemerRepo.GetById(id);

            foreach (Order o in TemporaryOrders)
            {
                if (o.FiliaalID == w.FiliaalID && o.Ontvangen == false)
                {
                    orders.Add(o);
                }
            }
            vm.Orders = orderConverter.ModelsToViewModels(orders);
        

            return View(vm);
        }

        [HttpGet]
        public IActionResult FiliaalOrderVerzoekDetail(long id)
        {
            OrderDetailViewModel vm = new OrderDetailViewModel();
            Order o = new Order();
            o = orderRepository.GetById(id);
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
            