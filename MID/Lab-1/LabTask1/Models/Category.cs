using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTask1.Models
{
    public class Category:Product
    {
        public string CName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}