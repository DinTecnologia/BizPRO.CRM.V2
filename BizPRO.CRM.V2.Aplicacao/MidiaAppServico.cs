using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class MidiaAppServico : IMidiaAppServico
    {
        private readonly IMidiaServico _midiaServico;

        public MidiaAppServico(IMidiaServico midiaServico)
        {
            _midiaServico = midiaServico;
        }

        public IEnumerable<MidiaViewModel> ListarMidias()
        {
            var retorno = _midiaServico.ObterTodos();
            return retorno.Select(item => new MidiaViewModel(item.Id, item.Nome)).ToList();
        }
    }
}
