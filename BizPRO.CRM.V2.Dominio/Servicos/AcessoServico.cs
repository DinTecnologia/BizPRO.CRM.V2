using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AcessoServico : Servico<Acesso>, IAcessoServico
    {
        private readonly IAcessoRepositorio _repositorio;

        public AcessoServico(IAcessoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public void AtualizarFimDeAcesso(string token)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@token", token);
            _repositorio.ObterPorProcedimento("usp_front_upd_acessoFinalizado", parametros);
        }
    }
}
