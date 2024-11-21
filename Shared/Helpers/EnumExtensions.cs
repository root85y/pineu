using System.ComponentModel;
using System.Reflection;

namespace Shared.Helpers {
    public static class EnumExtensions {
        public static string GetDescription(this Enum value) {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static T Parse<T>(string value) where T : Enum {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
