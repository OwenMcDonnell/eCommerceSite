using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eCommerceSite.Data
{
    public class ItemDetails
    {
        [Key]
        [ForeignKey("Item")]
        public virtual int ItemId { get; set; }
        public decimal Weight { get; set; }
        public string Materials { get; set; }
        public string MadeIn { get; set; }
        public virtual Item Item { get; set; }
        
    }
}