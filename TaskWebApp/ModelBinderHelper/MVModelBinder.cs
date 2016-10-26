using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TaskWebApp.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskWebApp.ModelBinderHelper
{
   public class MVModelBinder : IModelBinder
    {

       public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
       {
           try
           {
               
               var modelType = bindingContext.ModelType;
               if (bindingContext.ModelName.IndexOf("page") != -1)
                   return bindingContext.Model;
               FileEngineParser fileEngineParser = null;
               ITaxModelValidator tmValidator = null;
               HttpPostedFileBase postedFile = controllerContext.HttpContext.Request.Files[0];
               List<TaxViewModel> taxViewModelList = new List<TaxViewModel>();
               string filePath = HttpContext.Current.Server.MapPath("~/ExampleFiles/") + Path.GetFileName(postedFile.FileName);
               if (postedFile.ContentType=="application/vnd.ms-excel")

               {
                
                   var inputStream = controllerContext.HttpContext.Request.InputStream;
                   fileEngineParser = new CSVFileEngineParser();
                   taxViewModelList= fileEngineParser.ParseFile(filePath, inputStream);
                   tmValidator = new VMModelValidator();
                   tmValidator.Validate(bindingContext, taxViewModelList);
                   
                   
                   return taxViewModelList;

               }
               return null;
           }
           catch (Exception ex)
           {
               bindingContext.ModelState.AddModelError("", "The file could not be opened");
               return null;
           }

       }




    }
}
