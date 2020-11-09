using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AcoesTokensValidadeServico : Servico<AcoesTokensValidade>, IAcoesTokensValidadeServico
    {
        private readonly IAcoesTokensValidadeRepositorio _repositorio;

        public AcoesTokensValidadeServico(IAcoesTokensValidadeRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public AcoesTokensValidade CarregarPorToken(string token)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@token", token);

            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_sel_AcoesTokensValidadePorToken", parametros);
            return listaRetorno.FirstOrDefault();
        }


        public AcoesTokensValidade AdicionarToken(AcoesTokensValidade acoesTokensValidade)
        {
            var add = _repositorio.Adicionar(acoesTokensValidade);
            return add != null ? ObterAcoesTokensValidadePorId(add) : new AcoesTokensValidade();
        }

        public AcoesTokensValidade ObterAcoesTokensValidadePorId(long id)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@id", id);

            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_sel_AcoesTokensValidadePorId", parametros);
            return listaRetorno.FirstOrDefault();
        }


        public AcoesTokensValidade AtualizarToken(string token)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@token", token);

            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_upd_AcoesTokensValidade", parametros);
            return listaRetorno.FirstOrDefault();
        }
    }
}
