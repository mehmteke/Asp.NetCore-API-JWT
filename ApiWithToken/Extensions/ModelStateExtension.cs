using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Extensions
{
    public static class ModelStateExtension
    {
        public static IEnumerable<string> GetErrors(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage + " " + x.Exception).ToList();
        }
    }
}
