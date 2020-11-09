using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class TelefonesTiposAppService :ITelefonesTiposAppService
    {
        private readonly ITelefonesTiposServico _ITelefonesTiposAppService;

        public TelefonesTiposAppService(ITelefonesTiposServico telefonesTiposServico)
        {
            _ITelefonesTiposAppService = telefonesTiposServico;
        }

        public TelefonesTiposViewModel Carregar()
        {
            TelefonesTiposViewModel view = new TelefonesTiposViewModel();
            view.ListaTelefonesTipos= _ITelefonesTiposAppService.ObterTodos();
            return view;
        }
    }
}
