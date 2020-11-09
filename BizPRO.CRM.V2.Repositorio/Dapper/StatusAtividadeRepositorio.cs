using System.Collections.Generic;
using System.Data;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class StatusAtividadeRepositorio : Repositorio<StatusAtividade>, IStatusAtividadeRepositorio
    {
        public StatusAtividadeRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public IEnumerable<StatusAtividade> ObterStatusAtividades(string descricao, string atividadesValidas)
        {
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(atividadesValidas))
                parametros.Add("@atividadesValidas", atividadesValidas);

            if (!string.IsNullOrEmpty(descricao))
                parametros.Add("@descricao", descricao);

            parametros.Add("@ativo", true);

            return ObterPorProcedimento("usp_front_sel_statusAtividades", parametros);
        }

        public IEnumerable<StatusAtividade> BuscarStatusAtividadesTratativaEmail()
        {
            return ObterPorProcedimento("usp_front_sel_statusAtividades_Email", null);
        }

        public IEnumerable<StatusAtividade> ObterStatusAtividades(string descricao, string atividadesValidas,
            bool? statusPadrao, bool? finalizaAtividade, bool? finalizaAtendimento, bool? ativo,
            string sentidosValidos = null, bool? statusDeSistema = false)
        {
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(atividadesValidas))
                parametros.Add("@atividadesValidas", atividadesValidas);

            if (!string.IsNullOrEmpty(descricao))
                parametros.Add("@descricao", descricao);

            if (statusPadrao.HasValue)
                parametros.Add("@statusPadrao", statusPadrao);

            if (finalizaAtividade.HasValue)
                parametros.Add("@finalizaAtividade", finalizaAtividade);

            if (finalizaAtendimento.HasValue)
                parametros.Add("@finalizaAtendimento", finalizaAtendimento);

            if (ativo.HasValue)
                parametros.Add("@ativo", ativo);

            if (!string.IsNullOrEmpty(sentidosValidos))
                parametros.Add("@sentidosValidos", sentidosValidos);

            if (statusDeSistema.HasValue)
                parametros.Add("@statusDeSistema", statusDeSistema);

            return ObterPorProcedimento("usp_front_sel_statusAtividades", parametros);
        }

        public bool VerificarEntidadeRequeridaAtendimento(long atendimentoId, long statusAtividadeId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@AtendimentoId", atendimentoId);
            parametros.Add("@StatusAtividadeId", statusAtividadeId);
            return
                (bool)
                Conn.ExecuteScalar("usp_sel_VerificarEntidadeRequerida", parametros, null, null,
                    CommandType.StoredProcedure);
        }

        public bool VerificarEntidadeNaoRequeridaAtendimento(long atendimentoId, long statusAtividadeId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@AtendimentoId", atendimentoId);
            parametros.Add("@StatusAtividadeId", statusAtividadeId);
            return
                (bool)
                Conn.ExecuteScalar("usp_sel_VerificarEntidadeNaoRequerida", parametros, null, null,
                    CommandType.StoredProcedure);
        }

        public bool VerificarTempoAtividade(long atividadeId, long statusAtividadeId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@AtividadeId", atividadeId);
            parametros.Add("@StatusAtividadeId", statusAtividadeId);
            return
                (bool)
                Conn.ExecuteScalar("usp_sel_VerificarTempoAtividades", parametros, null, null,
                    CommandType.StoredProcedure);
        }

        public bool VerificarStatusAtividadeRequerida(long atividadeId, long statusAtividadeId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@AtividadeId", atividadeId);
            parametros.Add("@StatusAtividadeId", statusAtividadeId);
            return
                (bool)
                Conn.ExecuteScalar("usp_sel_VerificarStatusAtividadeRequerida", parametros, null, null,
                    CommandType.StoredProcedure);
        }
    }
}