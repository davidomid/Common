using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Common.Helpers
{
    public class ModelStateDictionaryHelepr
    {
        public static ModelStateDictionaryHelepr Current = new ModelStateDictionaryHelepr();

        public static List<string> GetErrorListFromModelState(ModelStateDictionary modelState)
        {
            List<string> errorList = modelState?.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return errorList;
        }
    }
}