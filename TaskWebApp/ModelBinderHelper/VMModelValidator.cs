using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskWebApp.Models;

namespace TaskWebApp.ModelBinderHelper
{
    public class VMModelValidator:ITaxModelValidator
    {
        public void Validate(ModelBindingContext bindingContext , List<TaxViewModel> taxViewModelList)
        {
            int rowNum = 1;
            foreach (var model in taxViewModelList)
            {
                var validationResults = new HashSet<ValidationResult>();

                var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), validationResults, true);
                if (!isValid)
                {
                    foreach (var result in validationResults)
                    {
                        var memberName = result.MemberNames.FirstOrDefault();
                        
                         PropertyDescriptor pd = TypeDescriptor.GetProperties(model).Cast<PropertyDescriptor>().Where(p => p.Name == memberName).FirstOrDefault();
                         var val = pd.GetValue(model);
                         bindingContext.ModelState.AddModelError("", "Row num " + rowNum + " " + result.ErrorMessage+" : Member-" +memberName+" "+val);
                    }
                    model.State = State.Rejected;
                }
                else
                {

                    model.State = State.Approved;
                }
                rowNum++;
            }


        }

    }
}