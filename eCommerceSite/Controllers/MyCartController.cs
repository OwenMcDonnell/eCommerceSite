using eCommerceSite.Data;
using eCommerceSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceSite.Controllers
{
    public class MyCartController : Controller
    {
        private eCommerceRepository _rep;
        // GET: /MyCart/
        public MyCartController()
        {
            _rep = new eCommerceRepository();
        }
        public ActionResult Index()
        {
            var cart = MyCartModel.GetCart(this.HttpContext);
            return View();
        }
        

    }
}
