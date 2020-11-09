using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ClienteServico : Servico<Cliente>, IClienteServico
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteServico(IClienteRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Cliente> Buscar(string nome, string documento, string telefone, string numeroProtocolo,
            string susep)
        {
            return _repositorio.ObterClientesBusca(nome, documento, telefone, null, numeroProtocolo, susep, true);
        }

        public IEnumerable<Cliente> ObterSugestoes(string nome, string documento, string telefone, string email, bool registroComTodosCamposFornecidos)
        {
            if (!string.IsNullOrEmpty(nome) || !string.IsNullOrEmpty(documento) || !string.IsNullOrEmpty(telefone) ||
                !string.IsNullOrEmpty(email))
            {
                return _repositorio.ObterClientesBusca(nome, documento, telefone, email, null, null, registroComTodosCamposFornecidos);
            }

            return new List<Cliente>();
        }
    }
}
