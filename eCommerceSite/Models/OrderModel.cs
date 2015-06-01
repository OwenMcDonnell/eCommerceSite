using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerceSite.Models
{
    public class OrderModel
    {
        [Required(ErrorMessage = "A name is required")]
        public string name { get; set; }
        [Required()]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Credit Card is not valid")] 
        public string ccnumber { get; set; }
        [Required()]
        [Range(01, 12, ErrorMessage = "Expiry month is not valid")]
        public int expm { get; set; }
        [Required()]
        [Range(2014, 2070, ErrorMessage = "Expiry year is not valid")]
        public int expy { get; set; }
        [Required(ErrorMessage = "The CVC # should be 3 digist long")]
        [StringLength(3, MinimumLength=3)]
        public string cvc { get; set; }

    }
}