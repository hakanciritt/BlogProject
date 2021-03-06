using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            if (string.IsNullOrEmpty(enumValue.ToString()))
                throw new ArgumentNullException(nameof(enumValue));

            return enumValue.GetType()
                .GetMember(enumValue.ToString()).First()
                .GetCustomAttribute<DisplayAttribute>().GetName();
        }
    }
}
