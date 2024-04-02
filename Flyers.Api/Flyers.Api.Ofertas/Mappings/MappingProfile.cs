using AutoMapper;
using Flyers.Api.Ofertas.Models;
using Flyers.Core.Entities;
using Flyers.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Api.Ofertas.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<OfertaEntity, OfertaResponse>()
            //    .ReverseMap();
            CreateMap<OfertaEntity, Oferta>()
                .ForMember(dest => 
                    dest.Descricao, map => 
                    map.MapFrom(orig => orig.Descricao.RemoveTagHTML(orig.Descricao)))
                .ForMember(dest => 
                    dest.Imagem, map => 
                    map.MapFrom(orig => 
                        ImagemHelper.ImagemBase64(orig.Imagem.Tipo, orig.Imagem.Dados)))
                .ReverseMap();
        }
    }
}
