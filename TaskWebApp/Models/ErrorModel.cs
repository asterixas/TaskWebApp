using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskWebApp.Models
{
    public class ErrorModel
    {
        public string Message { get; set; }
        public string DocumentName { get; set; }

        public int ID { get; set; }
    }
}