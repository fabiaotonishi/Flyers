using AutoMapper;
using Flyers.Api.Clientes.Models;
using Flyers.Core.Entities;

namespace Flyers.Api.Clientes.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteEntity, Cliente>()
                .ForMember(dest =>
                    dest.Pessoa, map =>
                    map.MapFrom(orig => orig.Pessoa.GetHashCode()))
                .ReverseMap();
        }
    }
}
