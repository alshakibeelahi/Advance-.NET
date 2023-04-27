using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Member
    {
        [Key]
        [Required] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        [ForeignKey("Proj")]
        public int PId { get; set; }
        public virtual Project Proj { get; set; }
    }
}
