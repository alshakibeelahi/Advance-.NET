using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace My_Snippets.CustomVal
{
    public class AgeVal : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime input = Convert.ToDateTime(value);
            string dat = input.Date.ToString("yyyy-MM-dd");
            int yr=int.Parse(dat.Substring(0,4));
            int curr=int.Parse(DateTime.Now.Year.ToString());
            if ((curr-yr)>=18)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Age must be greater than 18 years old");
        }
    }
}