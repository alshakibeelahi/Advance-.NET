using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Z_Hunger.Models
{
    public class Request
    {
        [Required]
        public string FoodDes { get; set; }
        [Required]
        public DateTime PreTime { get; set; }
    }
}