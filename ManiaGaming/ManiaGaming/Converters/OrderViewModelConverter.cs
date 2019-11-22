using ManiaGaming.Interfaces;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Converters
{
    public class OrderViewModelConverter : IViewModelConverter<Order, OrderDetailViewModel>
    {
        public List<OrderDetailViewModel> ModelsToViewModels(List<Order> models)
        {
            List<OrderDetailViewModel> orderDetailViewModels = new List<OrderDetailViewModel>();

            foreach (Order p in models)
            {
                OrderDetailViewModel vm = new OrderDetailViewModel()
                {
                    Id = p.Id,
                    Datum = p.Datum,
                    FiliaalID = p.FiliaalID,
                    Ontvangen = p.Ontvangen,
                    WerknemerID = p.WerknemerID,
                    Filialen = p.Filialen,
                    Aantal = p.Aantal,
                    Producten = p.Producten,
                    ProductId = p.ProductID
                };
                orderDetailViewModels.Add(vm);
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
                FiliaalID = o.FiliaalID,
                Ontvangen = o.Ontvangen,
                Filialen = o.Filialen,
                Producten = o.Producten,
                ProductId = o.ProductID

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
                FiliaalID = vm.FiliaalID,
                WerknemerID = vm.WerknemerID,

                Datum = vm.Datum
            };
            return o;
        }
    }
}
