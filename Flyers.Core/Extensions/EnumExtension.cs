using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Flyers.Core.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// Extensão para retornar o Display Name 
        /// </summary>
        public static string GetEnumDisplay(this Enum enumTipo)
        {
            return enumTipo.GetType().GetMember(enumTipo.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
    }
}
