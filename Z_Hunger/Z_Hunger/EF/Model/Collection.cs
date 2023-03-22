using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Z_Hunger.EF.Model
{
    public class Collection
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Collect")]
        public int CRId { get; set; }
        public virtual CollectRequest Collect { get; set; }
        [Required]
        [ForeignKey("Emp")]
        public int EId { get; set; }
        public virtual Employee Emp { get; set; }
    }
}