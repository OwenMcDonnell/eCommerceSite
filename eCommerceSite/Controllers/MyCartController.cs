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
            cartModel = new MyCartModel(repository);
            rep = repository;
        }
        // GET: /MyCart/
        public ActionResult Index()
        {       
            var cart = cartModel.GetCart(this.HttpContext);
            List<Item> itemObjectList = new List<Item>();
            List<string> newItemsList = cart.CartItems.ItemString.Split(';').ToList();
            foreach (var i in newItemsList)
            {
                if (i == "")
                {
                    break;
                }
                itemObjectList.Add(rep.GetItems().Where(x => x.Name == i).First());
            }
            var viewModel = new MyCartViewModel
            {

                CartItems = itemObjectList,
                ItemTotals = cart.CartItems.ItemCount.Split(';').ToList(),
                CartTotal = cartModel.GetCartTotal(cart)
            };
            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var item = rep.GetItems().Where(i => i.Id == id).SingleOrDefault();
            var cart = cartModel.GetCart(this.HttpContext);
            if (cart.CartItems.ItemString == null)
            {
                rep.AddToCart(item, cart);
            }
            List<string> itemsList = cart.CartItems.ItemString.Split(';').ToList();
            if (itemsList.Contains(item.Name))
            {
                rep.CartCountInc(cart, item);
            }
            else
            {
                rep.AddToCart(item, cart);
                rep.CartCountInc(cart, item);
            }
            //List<Item> itemObjectList = new List<Item>();
            //List<string> newItemsList = cart.CartItems.ItemString.Split(';').ToList();
            //foreach (var i in newItemsList)
            //{
            //    if (i == "")
            //    {
            //        break;
            //    }
            //    itemObjectList.Add(rep.GetItems().Where(x => x.Name == i).First());
            //}
            //var viewModel = new MyCartViewModel
            //{
                
            //    CartItems = itemObjectList,
            //    ItemTotals = cart.CartItems.ItemCount.Split(';').ToList(),
            //    CartTotal = cartModel.GetCartTotal(cart)
            //};

            return RedirectToAction("Index", new { item = item });
        }
    }
}
