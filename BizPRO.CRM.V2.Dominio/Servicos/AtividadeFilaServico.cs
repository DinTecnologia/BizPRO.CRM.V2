using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using DomainValidation.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AtividadeFilaServico : Servico<AtividadeFila>, IAtividadeFilaServico
    {
        private readonly IAtividadeFilaRepositorio _repositorio;
        private readonly IFilaServico _servicoFila;
        private DynamicParameters _parametros = null;

        public AtividadeFilaServico(IAtividadeFilaRepositorio repositorio, IFilaServico servicoFila)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _servicoFila = servicoFila;
        }

        public IEnumerable<AtividadeFila> ObterPorAtividadeId(long? atividadeId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@atividadeID", atividadeId);
            return _repositorio.ObterPorProcedimento("usp_front_sel_AtividadeFilaPorAtividadeID", _parametros);
        }
        public void AtualizaSaiuDaFilaEm(long id)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@id", id);
            _repositorio.ObterPorProcedimento("[usp_front_upd_FilasAtividadeSaiuDaFilaEm]", _parametros);
        }
        public void AtualizaSaiuDaFilaPorAtividadeId(long atividadeId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@atividadeId", atividadeId);
            _repositorio.ObterPorProcedimento("[usp_front_upd_FilasAtividadeSaiuDaFilaPorAtividadeId]", _parametros);
        }
        public ValidationResult AdicionarAtividadeFila(string nomeFila, long atividadeId)
        {
            var retorno = new ValidationResult();
            var fila = _servicoFila.ObterFilasPorNome(nomeFila);
            var valorEncontrado = false;

            if (fila != null)
                if (fila.Any())
                    valorEncontrado = true;

            if (!valorEncontrado)
            {
                retorno.Add(
                    new ValidationError(
                        "Não foi possível vincular a atividade a uma determinada fila: nenhuma fila retornada com o nome:" +
                        nomeFila));
                return retorno;
            }

            var atividadeFila = new AtividadeFila(atividadeId, fila.FirstOrDefault().Id);
            retorno = Adicionar(atividadeFila);
            return retorno;
        }
        public AtividadeFila ObterUltimoVinculoPraAtividade(long atividadeId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@atividadeID", atividadeId);
            return _repositorio.ObterPorProcedimento("usp_front_sel_UltimaFilaAtividade", _parametros).FirstOrDefault();
        }
    }
}
