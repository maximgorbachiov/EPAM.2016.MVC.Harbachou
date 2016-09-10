using System;
using System.Globalization;
using System.Web.Mvc;
using Task.Models;

namespace Task.Infrastructure
{
    public class UserModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object data;
            var model = bindingContext.Model as User ?? new User();

            model.FirstName = (string)GetValue(bindingContext, "FirstName");
            model.LastName = (string)GetValue(bindingContext, "LastName");
            model.UserId = int.Parse((string)GetValue(bindingContext, "UserId"));

            data = GetValue(bindingContext, "Role", controllerContext);
            model.Role = ParseResult<Role>(data);

            data = GetValue(bindingContext, "BirthDate");
            model.BirthDate = ParseResult<DateTime>(data);

            model.HomeAddress = (Address)(new AddressModelBinder().BindModel(controllerContext, bindingContext));

            return model;
        }

        private object GetValue(ModelBindingContext context, string name, ControllerContext controllerContext = null)
        {
            ValueProviderResult result = context.ValueProvider.GetValue(name);

            if (result == null)
            {
                return "<Not found>";
            }

            switch (name)
            {
                case "BirthDate":
                    DateTime dt;
                    DateTime.TryParseExact(result.AttemptedValue, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out dt);

                    return dt;

                case "Role":
                    if (result.AttemptedValue == "" || result.AttemptedValue == "Guest")
                    {
                        return Role.Guest;
                    }

                    if (controllerContext != null 
                        && controllerContext.RequestContext.HttpContext.Request.IsLocal 
                        && result.AttemptedValue == "Admin")
                    {
                        return Role.Admin;
                    }

                    return Role.User;
            }

            return result.AttemptedValue;
        }

        private T ParseResult<T>(object data)
        {
            return (data is string) ? default(T) : (T) data;
        }
    }
}