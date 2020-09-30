using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Loreggia.Delivery.Track.Autenticador.Shared.Helper.Enums
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum genericEnum)
        {
            var genericEnumType = genericEnum.GetType();
            var memberInfo = genericEnumType.GetMember(genericEnum.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attribs != null && attribs.Count() > 0)
                {
                    return ((DescriptionAttribute)attribs.ElementAt(0)).Description;
                }
            }
            return genericEnum.ToString();
        }

        public static IEnumerable<EnumQuery> EnumQueryMethod<TEnum>() where TEnum : Enum
        {
            var list = new List<EnumQuery>();
            foreach (TEnum @enum in Enum.GetValues(typeof(TEnum)))
            {
                list.Add(new EnumQuery(@enum, @enum.GetDescription()));
            }
            return list;
        }
    }
}
