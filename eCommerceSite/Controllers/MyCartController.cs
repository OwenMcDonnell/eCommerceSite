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
        private IeCommerceRepository rep;
        MyCartModel cartModel;
        public MyCartController(IeCommerceRepository repository)
        {
            cartModel = new MyCartModel();
            rep = repository;
        }
        // GET: /MyCart/
        public ActionResult Index()
        {
           
            var cart = cartModel.GetCart(this.HttpContext);
            return View(cart);
        }

        public ActionResult AddToCart(int id)
        {
            var item = rep.GetItems().Where(i => i.Id == id).SingleOrDefault();
            var cart = cartModel.GetCart(this.HttpContext);
            if (cart.ItemsHash.Items.Contains(item))
            {
                rep.CartCountInc(cart, item);
            }
            else
            {
                rep.AddToCart(item, cart.MyCartId);
                //rep.CartCountInc(cart, item);
            }
            
            return View("Index", cart);
        }
    }
}
