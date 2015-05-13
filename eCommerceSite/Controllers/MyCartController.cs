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
            var cartModel = cart.GetCartItems(this.HttpContext);
            return View();
        }
        
        public ActionResult AddToCart(int id)
        {
            //var cart = new MyCartModel();
            //cart.AddToCart(item, this.HttpContext);
            var cart = MyCartModel.GetCart(this.HttpContext);
            Item item = _rep.GetItems().Where(i => i.Id == id).ToList().FirstOrDefault();
            cart.AddToCart(item, this.HttpContext);

            return RedirectToAction("Index");
        }

    }
}
