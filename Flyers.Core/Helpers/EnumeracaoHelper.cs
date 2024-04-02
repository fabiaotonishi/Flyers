using Flyers.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Flyers.Core.Helpers
{
    public static class EnumeracaoHelper
    {
        public static List<EnumeracaoDto> ListaEnumeracao<T>()
        {
            List<EnumeracaoDto> enumeracao = new List<EnumeracaoDto>();
            foreach (var itemTypeEnum in Enum.GetValues(typeof(T)))
            {
                //For each value of this enumeration, add a new EnumValue instance
                enumeracao.Add(new EnumeracaoDto()
                {
                    Id = (int)itemTypeEnum,
                    //Descricao = Enum.GetName(typeof(T), itemTypeEnum)
                    Descricao = itemTypeEnum
                        .GetType().GetMember(itemTypeEnum.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()
                        .Name
                });
            }
            return enumeracao;
        }
    }
}
