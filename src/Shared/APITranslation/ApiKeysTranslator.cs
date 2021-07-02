using Shipping.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Shared.ApiKeysTranslation
{
    public enum Keys
    {
        ShipmentStatus,
    }


    public static class ApiKeysTranslator
    {


        public static string getTranslatedKeys(string str, Keys Keys)
        {

            if (Keys == Keys.ShipmentStatus)
            {
                switch (str)
                {

                    case "Draft": return "مسوده";
                    case "Delivering": return "قيد الشحن";
                    case "Delivered": return "تم التسليم";
                    case "returned": return "مرتجع";

                    default:
                        return str;
                }
            }

            return str;

        }

    }
}
