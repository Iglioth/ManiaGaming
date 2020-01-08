using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Controllers
{
    public abstract class BaseController : Controller
    {
        protected virtual long GetUserId()
        {
            
            if (string.IsNullOrEmpty(HttpContext.User.Identities.First().Claims.First().Value))
                return -1;

            if (long.TryParse(HttpContext.User.Identities.First().Claims.First().Value, out long id))
                return id;
            return -1;
        }

       
    }
}
