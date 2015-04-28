using eCommerceSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eCommerceSite.Controllers
{
    public class ItemsController : ApiController
    {
        private eCommerceRepository _repo;
        public ItemsController()
        {
            _repo = new eCommerceRepository();
        }

        public IEnumerable<Item> Get()
        {
            var items = _repo.GetItems().ToList();
           
            return items;
        }
    }
}
