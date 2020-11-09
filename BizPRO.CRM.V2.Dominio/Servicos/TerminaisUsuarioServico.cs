using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;


namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TerminaisUsuarioServico : Servico<TerminaisUsuario>, ITerminaisUsuarioServico
    {
        private readonly ITerminaisUsuarioRepositorio _repositorio;
        private DynamicParameters _parametros;

        public TerminaisUsuarioServico(ITerminaisUsuarioRepositorio terminaisUsuarioRepository)
            : base(terminaisUsuarioRepository)
        {
            _repositorio = terminaisUsuarioRepository;
        }

        public TerminaisUsuario Adicionar(TerminaisUsuario entidade)
        {
            _repositorio.Adicionar(entidade);
            return entidade;
        }

        public List<TerminaisUsuario> ObterTerminaisUsuario(string userId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@UserID", userId);
            var listaRetorno = _repositorio.ObterPorProcedimento("usp_sel_TerminaisUsuario", _parametros);
            return listaRetorno.AsList();
        }

        public void DeletarTerminaisUsuario(string userId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@UserID", userId);
            _repositorio.ExecutarProcedimento("usp_del_TerminaisUsuario", _parametros);
        }
    }
}
