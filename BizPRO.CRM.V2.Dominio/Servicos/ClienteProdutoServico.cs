using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ClienteProdutoServico : Servico<ClienteProduto>, IClienteProdutoServico
    {
        private readonly IClienteProdutoRepositorio _repositorio;

        public ClienteProdutoServico(IClienteProdutoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Cliente> PesquisarCliente(string nome, string documento, string telefone)
        {
            //var parametros = new DynamicParameters();
            //parametros.Add("@atividadesValidas", "ligacao");
            //parametros.Add("@statusPadrao", true);
            //return _repositorio.ObterPorProcedimento("usp_front_sel_statusAtividadesPorAtividadeValida", parametros);

            return null;
        }
    }
}
