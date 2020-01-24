using System;
using System.Collections.Generic;
using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManiaGaming.Controllers
{
    [Authorize(Roles = "Beheerder, Werknemer")]
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
            List<Order> TemporaryOrders = new List<Order>();
            List<Order> orders = new List<Order>();
            TemporaryOrders = orderRepository.GetAll();
            Werknemer w = werknemerRepo.GetById(GetUserId());

            foreach (Order o in TemporaryOrders)
            {
                if (o.OntvangerID == w.FiliaalID && o.Ontvangen == false && o.Verzonden == true)
                {
                    orders.Add(o);
                }
            }
            vm.Orders = orderConverter.ModelsToViewModels(orders);


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
        public IActionResult Aanmaken(OrderDetailViewModel vm)
        {
            
            Order order = new Order();
            order = orderConverter.ViewModelToModel(vm);
            long ID = GetUserId();
            Werknemer w = werknemerRepo.GetById(ID);
            order.WerknemerID = w.WerknemerId; 
            order.Datum = DateTime.Now;
            order.OntvangerID = w.FiliaalID;
            orderRepository.Insert(order);
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Aanmaken()
        {
            OrderDetailViewModel vm = new OrderDetailViewModel();
            Order o = new Order
            {
                Filialen = filiaalRepository.GetAll()
            };
            List<Product> products = productRepository.GetAll();
            List<Product> filterproducts = new List<Product>();
            Werknemer w = werknemerRepo.GetById(GetUserId());
            foreach (Product p in products)
            {
               
                if (!p.Tweedehands)
                {
                    filterproducts.Add(p);
                }
            }

            o.Producten = filterproducts;
            for(int i = 0; i < o.Filialen.Count; i++)
            { 
                if(o.Filialen[i].Id == w.FiliaalID)
                {
                    o.Filialen.RemoveAt(i);
                }
            }
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

        [HttpGet]
        public IActionResult OrdersVerzenden()
        {
            OrderViewModel vm = new OrderViewModel();
            List<Order> TemporaryOrders = new List<Order>();
            List<Order> orders = new List<Order>();
            TemporaryOrders = orderRepository.GetAll();
            Werknemer w = werknemerRepo.GetById(GetUserId());

            foreach (Order o in TemporaryOrders)
            {
                if (o.VerzenderID == w.FiliaalID && o.Verzonden == false)
                {
                    orders.Add(o);
                }
            }
            vm.Orders = orderConverter.ModelsToViewModels(orders);
        

            return View(vm);
        }

        [HttpGet]
        public IActionResult Verzenden(long id)
        {
            orderRepository.Verzenden(id);

            return RedirectToAction("OrdersVerzenden");
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
            