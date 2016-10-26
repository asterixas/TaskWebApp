using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using TaskWebApp.Models;

namespace TaskWebApp.ModelBinderHelper
{
   public abstract class  FileEngineParser
    {
       public abstract List<TaxViewModel> ParseFile(string fileName, Stream inpuStream);
     
      
    }
}
