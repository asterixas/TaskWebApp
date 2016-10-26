using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskWebApp.Repository
{
    public class TaxTransaction
    {
         [Key]
        public int ID { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CurrencyCode { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string DocumentName { get; set; }

    }
}