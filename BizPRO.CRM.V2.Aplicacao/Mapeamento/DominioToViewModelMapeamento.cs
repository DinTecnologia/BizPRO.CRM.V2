using AutoMapper;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Mapeamento
{
    public class DominioToViewModelMapeamento : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteListaViewModel>();
        }
    }
}
