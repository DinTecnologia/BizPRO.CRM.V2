using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class LayoutAppService : ILayoutAppServico
    {
        private readonly IFilaServico _filaServico;

        public LayoutAppService(IFilaServico filaServico)
        {
            _filaServico = filaServico;
        }

        public ViewModels.LayoutViewModel ObterDados()
        {
            var obj = new ViewModels.LayoutViewModel {MenuFila = _filaServico.ObterTodos()};
            return obj;
        }
    }
}
