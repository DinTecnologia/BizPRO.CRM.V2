using AutoMapper;

namespace BizPRO.CRM.V2.Aplicacao.Mapeamento
{
    public class MapeamentoConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DominioToViewModelMapeamento>();
                x.AddProfile<ViewModelToDominioMapeamento>();
            });
        }
    }
}
