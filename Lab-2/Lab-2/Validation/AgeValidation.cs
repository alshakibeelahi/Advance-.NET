using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_2.Validation
{
    public class AgeValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }

    }
}