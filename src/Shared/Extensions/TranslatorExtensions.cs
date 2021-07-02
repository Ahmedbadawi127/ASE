using Shipping.Shared.ApiKeysTranslation;
using System;

namespace Shipping.Shared.Extensions
{
    public static class TranslatorExtensions
    {
        public static string Translator(this string str, Keys x, Func<string, Keys, string> keySelector)
        {
            return keySelector(str, x);
        }
    }
}