using AutoMapper;
using TechChallengeFIAP.DTOs;
using TechChallengeFIAP.Models;

namespace TechChallengeFIAP.Api.Mappings
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<CreatePedidoModel, CreatePedidoDTO>();
        }
    }
}
