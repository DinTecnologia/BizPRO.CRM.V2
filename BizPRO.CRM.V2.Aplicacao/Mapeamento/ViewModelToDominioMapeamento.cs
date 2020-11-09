using AutoMapper;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Mapeamento
{
    public class ViewModelToDominioMapeamento : Profile
    {
        protected override void Configure()
        {   
            CreateMap<ClienteFormViewModel, Cliente>();
            CreateMap<ClienteListaViewModel, Cliente>();  
        }
    }
}
