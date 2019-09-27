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
        public OrderDetailViewModel ModelToViewModel(Order o)
        {
            OrderDetailViewModel vm = new OrderDetailViewModel()
            {
                Orderid = o.OrderId,
                Datum = o.Datum
            };

            return vm;
        }

        public Order ViewModelToModel(OrderDetailViewModel vm)
        {
            Order o = new Order()
            {
                OrderId = vm.Orderid,
                Datum = vm.Datum
            };
            return o;
        }
    }
}
