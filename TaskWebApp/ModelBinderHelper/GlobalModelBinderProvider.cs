using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskWebApp.ModelBinderHelper
{
    public class GlobalModelBinderProvider : IModelBinderProvider
    {

        private bool IsMultipartContentType(string contentType)
        {
            return !string.IsNullOrEmpty(contentType) && contentType.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) >= 0;
        }
        public IModelBinder GetBinder(Type modelType)
        {
            var contentType = HttpContext.Current.Request.ContentType.ToLower();

            if (!IsMultipartContentType(contentType))
            {
                return null;
            }


          
            return new MVModelBinder();
        }


    }
}