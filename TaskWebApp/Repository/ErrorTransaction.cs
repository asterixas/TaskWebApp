using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TaskWebApp.Repository
{
    public class ErrorTransaction
    {
        [Key]
        public int ID { get; set; }
        public string Message { get; set; }
        public string DocumentName { get; set; }
    }
}
