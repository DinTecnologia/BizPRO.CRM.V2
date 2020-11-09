using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class CanalAppServico : ICanalAppServico
    {
        private readonly ICanalServico _canalServico;

        public CanalAppServico(ICanalServico canalServico)
        {
            _canalServico = canalServico;
        }

        public IEnumerable<CanalViewModel> ListarCanais()
        {
            var retorno = _canalServico.ObterTodos();
            var canais = new List<CanalViewModel>();

            foreach (var item in retorno)
            {
                canais.Add(new CanalViewModel(item.Id, item.Nome));
            }
            return canais;
        }

        public long ObterCanalPorNome(string nome)
        {
            var canal = _canalServico.ObterPorNome(nome);
            if (!canal.Any()) return 0;
            var firstOrDefault = canal.FirstOrDefault();
            return firstOrDefault != null ? firstOrDefault.Id : 0;
        }
    }
}
