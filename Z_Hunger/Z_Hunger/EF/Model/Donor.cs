using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Z_Hunger.EF.Model
{
    public class Donor : Person
    {
        [Required]
        public string Organization { get; set; }
        [Required]
        public string OrgAddress { get; set; }
        public ICollection<CollectRequest> CollectRequests { get; set; }
        public Donor()
        {
            CollectRequests = new List<CollectRequest>();
        }
    }
}