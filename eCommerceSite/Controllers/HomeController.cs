using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerceSite.Models;
using eCommerceSite.Services;
using eCommerceSite.Data;

namespace eCommerceSite.Controllers
{
    public class HomeController : Controller
    {
        private IMailService mail;
        private IeCommerceRepository rep;
        public HomeController(IMailService mailService, IeCommerceRepository repository)
        {
            
            mail = mailService;
            rep = repository;
        }

        public ActionResult Index()
        {

            var items = rep.GetItems();
            return View(items);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment from: {1}{0}Email:{2}{0}subject:{3}{0} Comment:{4}{0}",
                Environment.NewLine, model.name, model.email, model.subject, model.message);

            if (mail.SendMail("companyemail@company.com", "customer@customer.com", "website contact", msg))
            {
                ViewBag.MailSent = true;
            }
            return View();
        }
        public ActionResult MyCart()
        {
            
            return View();
        }
        public ActionResult Item(int id) 
        {
            ViewData["Reviews"] = rep.GetReviewsByItem(id).ToList();
            ViewData["ReviewsCount"] = rep.GetReviewsByItem(id).ToList().Count;

            var item = rep.GetItems().Where(i => i.Id == id).First();
            return View(item);
        }
        public ActionResult Services()
        {
            return View();
        }
        public FileContentResult ImageRender(int id)
        {
            byte[] ImgArray = rep.GetItems().Where(i => i.Id == id).First().Thumbnail;
            return new FileContentResult(ImgArray, "image/jpeg");
        }
    }
}
