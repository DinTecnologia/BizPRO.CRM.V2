using BizPRO.CRM.V2.Aplicacao.Entidades;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class AspNetRolesFilaAppServico : IAspNetRolesFilaAppServico
    {
        private readonly IAspNetRolesFilaServico _aspNetRolesFilaServico;

        public AspNetRolesFilaAppServico(IAspNetRolesFilaServico aspNetRolesFilaServico)
        {
            _aspNetRolesFilaServico = aspNetRolesFilaServico;
        }

        public IEnumerable<AspNetRolesFilaApp> ObterPorFila(long id)
        {
            var aspNetRolesFilaAppLista = new List<AspNetRolesFilaApp>();
            var retorno = _aspNetRolesFilaServico.ObterPorFila(id);

            foreach (var item in retorno)
            {
                aspNetRolesFilaAppLista.Add(new AspNetRolesFilaApp(item.Id, item.FilasId, item.AspNetRolesId));
            }

            return aspNetRolesFilaAppLista;
        }
    }
}
