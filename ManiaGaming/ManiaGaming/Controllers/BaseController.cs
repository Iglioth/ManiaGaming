using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
