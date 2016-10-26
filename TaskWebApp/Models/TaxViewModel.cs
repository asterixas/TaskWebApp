using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskWebApp.Helper;
using TaskWebApp.ModelBinderHelper;

namespace TaskWebApp.Models
{
    public class TaxViewModel
    {
     
        
        public TaxViewModel()
        {
            CurrencyCode = string.Empty;
            Description = string.Empty;
            Account = string.Empty;
            DocumentName = string.Empty;

        }
        
        
        
        
        [Required]
        public string Account { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [IsoCurrencyCodeValidator]
        public string CurrencyCode { get; set; }
        [Required]
        [DecimalCodeValidator]
        public string Amount { get; set;}

        public State State { get; set; }
        public string DocumentName { get; set; }

        public int ID { get; set; }
    }
}