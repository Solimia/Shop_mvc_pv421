using System.Text.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Shop_mvc_pv421.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonSerializer.Serialize(value);
        }   

        public static T? Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {

            // if (!tempData.ContainsKey(key)) return null;
            var item = tempData[key];
            return item == null ? null : JsonSerializer.Deserialize<T>((string)item);

        }
    }



}
