using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class PessoaJuridicaTiposContatoServico : Servico<PessoaJuridicaTiposContato>,
        IPessoaJuridicaTiposContatoServico
    {
        private readonly IPessoaJuridicaTiposContatoRepositorio _repositorio;
        private DynamicParameters _parametros = null;

        public PessoaJuridicaTiposContatoServico(IPessoaJuridicaTiposContatoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public List<PessoaJuridicaTiposContato> Listar()
        {
            _parametros = new DynamicParameters();
            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_sel_PessoaJuridicaTiposContato", _parametros);
            return listaRetorno.AsList();
        }
    }
}
