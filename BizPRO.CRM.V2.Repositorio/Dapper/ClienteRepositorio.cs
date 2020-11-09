using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using Dapper;
using System;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Cliente> ObterClientesPorNumeroProtocolo(string numeroProtocolo)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@numeroProtocolo", numeroProtocolo);

            return ObterPorProcedimento("usp_front_sel_PesquisarClientePorNumeroProtocolo", parametros);
        }

        public IEnumerable<Cliente> ObterClientesPorDadosCliente(string nome, string documento, string telefone,
            string email)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nome", string.IsNullOrEmpty(nome) ? null : nome);
            parametros.Add("@documento", string.IsNullOrEmpty(documento) ? null : documento);
            parametros.Add("@telefone", string.IsNullOrEmpty(telefone) ? null : telefone);
            parametros.Add("@email", string.IsNullOrEmpty(email) ? null : email);
            return ObterPorProcedimento("usp_front_sel_PesquisarCliente", parametros);
        }

        public IEnumerable<Cliente> ObterClientesBusca(string nome, string documento, string telefone, string email,
            string protocolo, string susep, bool registroComTodosCamposFornecidos)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nome", string.IsNullOrEmpty(nome) ? null : nome);
            parametros.Add("@documento", string.IsNullOrEmpty(documento) ? null : documento);
            parametros.Add("@telefone", string.IsNullOrEmpty(telefone) ? null : telefone);
            parametros.Add("@email", string.IsNullOrEmpty(email) ? null : email);
            parametros.Add("@protocolo", string.IsNullOrEmpty(protocolo) ? null : protocolo);
            parametros.Add("@susep", string.IsNullOrEmpty(susep) ? null : susep);
            parametros.Add("@RegistroComTodosCamposFornecidos", registroComTodosCamposFornecidos);
            return ObterPorProcedimento("usp_front_sel_ClienteBuscaGenerica", parametros);
        }
    }
}
