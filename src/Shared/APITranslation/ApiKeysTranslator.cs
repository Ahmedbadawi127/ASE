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
                Enum.TryParse(str, out ShipmentStatus myStatus);

                switch (myStatus)
                {
                    case ShipmentStatus.Undefined: return "غير معرف";
                    case ShipmentStatus.Draft: return "مسوده";
                    case ShipmentStatus.Approved: return "قيد الشحن";
                    case ShipmentStatus.Delivered: return "تم التسليم";
                    case ShipmentStatus.returned: return "مرتجع";

                    default:
                        return str;
                }
            }

            return str;

        }

    }
}
