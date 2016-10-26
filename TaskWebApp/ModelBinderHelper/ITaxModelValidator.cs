using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TaskWebApp.Models;

namespace TaskWebApp.ModelBinderHelper
{
   public interface ITaxModelValidator
    {
    void  Validate(ModelBindingContext modelbindingContext , List<TaxViewModel> taxviewvModelList);

    }
}
