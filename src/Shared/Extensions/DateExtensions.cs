using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Shipping.Shared.Extensions
{
    public static class DateExtensions
    {
        public static DateTime umAlQuraCalendarMinSupportedDateTime { get; } = (new System.Globalization.UmAlQuraCalendar()).MinSupportedDateTime;
        public static System.Globalization.UmAlQuraCalendar umAlQuraCalendar { get; } = new System.Globalization.UmAlQuraCalendar();



        public static string getumAlQuraDateString(DateTime Value, bool includeG = false, bool includeTime = false)
        {
            if (umAlQuraCalendar.MinSupportedDateTime > Value || Value > umAlQuraCalendar.MaxSupportedDateTime)
            {
                return "";
            }



            var ret = $"{getArabicDayName(Value.DayOfWeek)} {umAlQuraCalendar.GetYear(Value):d4}/{umAlQuraCalendar.GetMonth(Value):d2}/{umAlQuraCalendar.GetDayOfMonth(Value):d2}";
            if (includeG)
            {
                ret = $"{ret} الموافق {Value.ToShortDateString()}";
            }

            if (includeTime)
            {
                ret = $"{ret} {Value.ToShortTimeString()}";
            }



            return ret;
        }
        public static string getFormatToParse(DateTime? Value)
        {
            if (!Value.HasValue || umAlQuraCalendar.MinSupportedDateTime > Value.Value || Value.Value > umAlQuraCalendar.MaxSupportedDateTime)
            {
                return null;
            }



            var ret = $"{Value.Value.Year}-{Value.Value.Month}-{Value.Value.Day}";



            return ret;
        }
        private static string getArabicDayName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Saturday:
                    return "السبت";
                case DayOfWeek.Sunday:
                    return "الأحد";
                case DayOfWeek.Monday:
                    return "الإثنين";
                case DayOfWeek.Tuesday:
                    return "الثلاثاء";
                case DayOfWeek.Wednesday:
                    return "الاربعاء";
                case DayOfWeek.Thursday:
                    return "الخميس";
                case DayOfWeek.Friday:
                    return "الجمعه";



            }
            throw new Exception("uknown day of week");
        }

        public static bool IsValid(this DateTime date)
        {
            return date != default;
        }

        public static string ToShortDateWithValidation(this DateTime date)
        {
            return date.IsValid() ? date.ToShortDateString() : "";
        }

    }
    public static class StatusName
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
       where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
        public static string GetAttributeName(this Enum enumValue)
        {
            return enumValue.GetAttribute<DisplayAttribute>().Name;
        }
    }
}
