using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Z_Hunger.Models
{
    public class Signup
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Organization { get; set; }
        [Required]
        public string OrgAddress { get; set; }
        [Required]
        public string ConPassword { get; set; }
    }
}