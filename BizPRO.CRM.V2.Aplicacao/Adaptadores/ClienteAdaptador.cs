using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Adaptadores
{
    public class ClienteAdaptador
    {
        public static ClienteBuscaViewModel ParaAplicacaoViewModel(string nome, string documento, string telefone,
            IEnumerable<Cliente> listaCliente)
        {
            var viewModel = new ClienteBuscaViewModel(nome, documento, telefone, listaCliente);
            return viewModel;
        }
    }
}
