using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskWebApp.Helper
{
  
    public class DecimalCodeValidator: ValidationAttribute
    {

            
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    decimal val;
                    var isNumeric = decimal.TryParse(value.ToString(), out val);

                    if (!isNumeric)
                    {
                        string[] memberNames = new string[] { validationContext.MemberName };
                        return new ValidationResult("Must be decimal", memberNames);
                    }
                }

                return ValidationResult.Success;
            }
        




    }
}