using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Z_Hunger.EF.Model
{
    public class Employee : Person
    {
        [Required]
        public string Status { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Address { get; set; }
        public ICollection<Collection> Collections { get; set; }
        public Employee()
        {
            Collections = new List<Collection>();
        }
    }
}