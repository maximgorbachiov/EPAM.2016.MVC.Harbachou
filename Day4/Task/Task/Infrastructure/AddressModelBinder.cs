using System.Web.Mvc;
using Task.Models;

namespace Task.Infrastructure
{
    public class AddressModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext modelBindingExecutionContext, ModelBindingContext bindingContext)
        {
            var model = bindingContext.Model as Address ?? new Address();

            model.Line1 = GetValue(bindingContext, "Line1");
            model.Line2 = GetValue(bindingContext, "Line2");
            model.City = GetValue(bindingContext, "City");
            model.Country = GetValue(bindingContext, "Country");
            model.PostalCode = GetValue(bindingContext, "PostalCode");

            if ((model.PostalCode != "<Not Specified>") && (model.City != "<Not Specified>") &&
                    (model.Line1 != "<Not Specified>"))
            {
                model.AddressSummary = model.PostalCode + " " + model.City + ", " + model.Line1;
            }
            else
            {
                model.AddressSummary = "No personal address";
            }

            return model;
        }

        private string GetValue(ModelBindingContext context, string name)
        {
            string modelName = context.ModelName == ""
                ? ""
                : "HomeAddress.";

            name = modelName + name;

            ValueProviderResult result = context.ValueProvider.GetValue(name);

            if (result == null || result.AttemptedValue.Contains("PO BOX"))
            {
                return "<Not Specified>";
            }

            switch (name)
            {
                case "HomeAddress.Line2":
                    if (result.AttemptedValue == "")
                    {
                        return "<Not Specified>";
                    }
                    break;
                case "HomeAddress.PostalCode":
                    if (result.AttemptedValue.Length < 6)
                    {
                        return "<Not Specified>";
                    }
                    break;
            }

            return result.AttemptedValue;
        }
    }
}