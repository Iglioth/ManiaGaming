using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ManiaGaming.Models.Data;
using ManiaGaming.Controllers;
using System.Data;
using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;
using Microsoft.Extensions.Configuration;

namespace ManiaGaming.Context.MSSQLContext
{
    public class MSSQLOrderContext : BaseMSSQLContext, IOrderContext
    {
        public MSSQLOrderContext(IConfiguration config) : base(config)
        {
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Order obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
