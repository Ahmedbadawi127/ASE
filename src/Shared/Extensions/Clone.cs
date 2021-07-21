using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Shared.Extensions
{
    public static class Clone
    {
        public static T DeepClone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static string SerializeObject<T>(this T source)
        {
            return JsonConvert.SerializeObject(source);
        }

        public static T DeserializeObject<T>(this string source)
        {
            return JsonConvert.DeserializeObject<T>(source);
        }
    }
}
