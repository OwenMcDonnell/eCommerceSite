using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCommerceSite.Data
{
    public class Review
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Stars { get; set; }
        public DateTime Created { get; set; }

        public int ItemId { get; set; }


    }
}
