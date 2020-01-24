using ManiaGaming.Interfaces;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;

namespace ManiaGaming.Converters
{
    public class OrderViewModelConverter : IViewModelConverter<Order, OrderDetailViewModel>
    {
        public List<OrderDetailViewModel> ModelsToViewModels(List<Order> models)
        {
            List<OrderDetailViewModel> orderDetailViewModels = new List<OrderDetailViewModel>();

            foreach (Order p in models)
            {
                orderDetailViewModels.Add(ModelToViewModel(p));
            }

            return orderDetailViewModels;
        }

    

        public OrderDetailViewModel ModelToViewModel(Order o)
        {
            OrderDetailViewModel vm = new OrderDetailViewModel()
            {
                Id = o.Id,
                Datum = o.Datum,
                WerknemerID = o.WerknemerID,
                VerzenderID = o.VerzenderID,
                OntvangerID = o.OntvangerID,
                Ontvangen = o.Ontvangen,
                Verzonden = o.Verzonden,
                Filialen = o.Filialen,
                Producten = o.Producten,
                ProductId = o.ProductID,
                Aantal = o.Aantal,
            };

            return vm;
        }

        public List<Order> ViewModelsToModels(List<OrderDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

       
        public Order ViewModelToModel(OrderDetailViewModel vm)
        {
            Order o = new Order()
            {
                Id = vm.Id,
                OntvangerID = vm.OntvangerID,
                ProductID = vm.ProductId,
                WerknemerID = vm.WerknemerID,
                Aantal = vm.Aantal,
                Datum = vm.Datum,
                Ontvangen = vm.Ontvangen,
                Verzonden = vm.Verzonden,
                VerzenderID = vm.VerzenderID,
            };
            return o;
        }
    }
}
