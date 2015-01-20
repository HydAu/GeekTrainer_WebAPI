using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using DemoCommon;

namespace _06cModelBinders.Models
{
    public class DemoVectorModelBinder : IModelBinder 
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            DemoVector vector;

            if (bindingContext.ModelType != typeof (DemoVector))
            {
                return false;
            }

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value == null)
            {
                return false; 
            }

            var text = value.RawValue as string;

            if (DemoVector.TryParse(text, out vector))
            {
                bindingContext.Model = vector;
                return true;
            }

            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Cannot convert value to vector.");
            return false;
        }
    }
}