using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MTGCollection.Util
{
    public static class HtmlEnumExtensions
    {
        public static MvcHtmlString EnumToString<T>(this HtmlHelper helper)
        {
            var values = Enum.GetValues(typeof(T)).Cast<int>();
            var enumDictionary = values.ToDictionary(values => Enum.GetName(typeof(T), values));

            return new MvcHtmlString(JsonConvert.SerializeObject(enumDictionary));
        }
    }
}
