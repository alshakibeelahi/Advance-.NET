using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Z_Hunger.EF.Model
{
    public class CollectRequest
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string FoodDes { get; set; }
        [Required]
        public DateTime PreTime { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [ForeignKey("Dnr")]
        public int DId { get; set; }
        public virtual Donor Dnr { get; set; }
        public ICollection<Collection> Collections { get; set; }
        public CollectRequest()
        {
            Collections = new List<Collection>();
        }
    }
}