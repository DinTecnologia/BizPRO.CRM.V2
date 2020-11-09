using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class PessoaJuridicaContatoServico : Servico<PessoaJuridicaContato>, IPessoaJuridicaContatoServico
    {
        private readonly IPessoaJuridicaContatoRepositorio _repositorio;
        private DynamicParameters _parametros = null;

        public PessoaJuridicaContatoServico(IPessoaJuridicaContatoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public PessoaJuridicaContato InserirContato(long pessoaFisicaId, long pessoaJuridicaId, string userId)
        {
            _parametros = new DynamicParameters();

            _parametros.Add("@pessoaFisicaID", pessoaFisicaId);
            _parametros.Add("@pessoaJuridicaID", pessoaJuridicaId);
            _parametros.Add("@criadoPorUserID", userId);

            var retorno =
                _repositorio.ObterPorProcedimento("usp_front_ins_PessoaJuridicaContato", _parametros).FirstOrDefault();

            return retorno;
        }


        public IEnumerable<PessoaJuridicaContato> ListarContatos(long? pessoaJuridicaId, long? pessoaFisicaId)
        {

            _parametros = new DynamicParameters();

            _parametros.Add("@pessoaJuridicaID", pessoaJuridicaId);
            _parametros.Add("@pessoaFisicaID", pessoaFisicaId);

            var listaRetorno = _repositorio.ObterEntidadeCompletaPorProcedimento("usp_front_sel_PessoaJuridicaContato",
                _parametros);

            return listaRetorno.AsList();
        }


        public PessoaJuridicaContato AtualizarContato(long pessoaJuridicaTipoContatoId, long pessoaJuridicaContatoId,
            string userId)
        {
            _parametros = new DynamicParameters();

            _parametros.Add("@pessoaJuridicaTipoContatoID", pessoaJuridicaTipoContatoId);
            _parametros.Add("@pessoaJuridicaContatoID", pessoaJuridicaContatoId);
            _parametros.Add("@userID", userId);

            var listaRetorno =
                _repositorio.ObterPorProcedimento("usp_front_upd_PessoaJuridicaContato", _parametros).FirstOrDefault();

            return listaRetorno;
        }


        public PessoaJuridicaContato DeletarContato(long pessoaJuridicaContatoId, string userId)
        {
            _parametros = new DynamicParameters();

            _parametros.Add("@pessoaJuridicaContatoID", pessoaJuridicaContatoId);
            _parametros.Add("@userID", userId);

            var listaRetorno =
                _repositorio.ObterPorProcedimento("usp_front_usp_PessoaJuridicaContatoInativar", _parametros)
                    .FirstOrDefault();

            return listaRetorno;
        }
    }
}
