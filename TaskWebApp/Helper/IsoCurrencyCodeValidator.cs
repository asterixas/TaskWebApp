using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskWebApp.Models;

namespace TaskWebApp.Helper
{
    
    public class IsoCurrencyCodeValidator:ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value,
                      ValidationContext validationContext)
        {
           TaxViewModel tmodel= ((TaxViewModel)validationContext.ObjectInstance);
           var currentcode = tmodel.CurrencyCode;
           if( (from culture in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.InstalledWin32Cultures)
                                                          where culture.Name.Length > 0 && !culture.IsNeutralCulture
                                                          let region = new System.Globalization.RegionInfo(culture.LCID)
                                                          where String.Equals(region.ISOCurrencySymbol, currentcode, StringComparison.InvariantCultureIgnoreCase)
                                                          select region).FirstOrDefault()==null)
           {
               string[] memberNames = new string[] { validationContext.MemberName };
               return new ValidationResult("Currency code is not valid", memberNames);
              
           }

            return ValidationResult.Success;
        }
    }
}