using System.Collections.Generic;
using System.Web.Mvc;
using Common.Helpers;

namespace Common.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static List<string> GetErrorListFromModelState(this ModelStateDictionary modelState)
        {
            return ModelStateDictionaryHelepr.GetErrorListFromModelState(modelState);
        }
    }
}