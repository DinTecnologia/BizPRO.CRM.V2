using System.Collections.Generic;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Data;
using Dapper;
using System.Linq;
using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AtividadeRepositorio : Repositorio<Atividade>, IAtividadeRepositorio
    {
        public AtividadeRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Atividade> ObterEntidadeCompletaPorProcedimento(string procedimento,
            DynamicParameters parametros)
        {
            var retorno = Conn.Query<Atividade, Usuario, Atividade>(procedimento,
                (ret, user) =>
                {
                    ret.Usuario = user;
                    return ret;
                },
                parametros,
                splitOn: "Id,nome",
                commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<Atividade> ObterPorOcorrenciaTipoId(long ocorrenciaTipoId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ocorrenciaTiposID", ocorrenciaTipoId);
            return ObterPorProcedimento("usp_front_sel_atividades", parametros);
        }

        public void AtualizarStatusAtividadePorLigacaoId(long ligacaoID, int statusAtividadeID)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ligacaoID", ligacaoID);
            parametros.Add("@statusAtividadeID", statusAtividadeID);
            ObterPorProcedimento("usp_front_upd_statusAtividadePorLigacaoID", parametros);
        }

        public void AtualizarAtendimentoId(long atividadeID, long atendimentoID)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@atividadeID", atividadeID);
            parametros.Add("@atendimentoID", atendimentoID);
            ObterPorProcedimento("usp_front_upd_AtividadeAtendimento", parametros);
        }

        public void AtualizarStatus(long atividadeID, long statusAtividadeID)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@atividadeID", atividadeID);
            parametros.Add("@statusAtividadeID", statusAtividadeID);
            ObterPorProcedimento("usp_front_upd_AtividadePorAtividadeID", parametros);
        }

        public IEnumerable<Atividade> ObterPorCliente(long? pessoaFisicaID, long? pessoaJuridicaID, int? quantidade)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@pessoaFisicaID", pessoaFisicaID);
            parametros.Add("@pessoaJuridicaID", pessoaJuridicaID);
            parametros.Add("@quantidade", quantidade);

            var retorno =
                Conn
                    .Query
                    <Atividade, Usuario, AtividadeTipo, StatusAtividade,
                        Atividade>("usp_front_sel_atividadesPorCliente",
                        (atividade, usuario, atividadeTipo, statusAtividade) =>
                        {
                            atividade.Usuario = usuario;
                            atividade.StatusAtividade = statusAtividade;
                            atividade.AtividadeTipo = atividadeTipo;
                            return atividade;
                        },
                        parametros,
                        splitOn: "Id,Id,id,id",
                        commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<Atividade> ObterNaoFinalizadasPorOcorrenciaId(long ocorrenciaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ocorrenciaID", ocorrenciaId);
            return ObterPorProcedimento("usp_front_sel_AtividadesNaoFinalizadasPorOcorrenciaId", parametros);
        }

        public Atividade ObterAtividadeCompletaPor(long atividadeId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@atividadeId", atividadeId);

            var retorno =
                Conn
                    .Query
                    <Atividade, StatusAtividade, Ocorrencia, Contrato, Atendimento, PessoaFisica, PessoaJuridica,
                        Atividade>("usp_front_sel_atividade",
                        (atividade, statusAtividade, ocorrencia, contrato, atendimento, pf, pj) =>
                        {
                            atividade.StatusAtividade = statusAtividade;
                            atividade.Ocorrencia = ocorrencia;
                            atividade.Contrato = contrato;
                            atividade.Atendimento = atendimento;
                            atividade.PessoaFisica = pf;
                            atividade.PessoaJuridica = pj;
                            return atividade;
                        },
                        parametros,
                        splitOn: "Id,id,id,id,id,id,id",
                        commandType: CommandType.StoredProcedure);

            return retorno.FirstOrDefault();
        }

        public void AtualizarCliente(long atividadeId, long? pessoaFisicaid, long? pessoaJuridicaId, string userId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@atividadeID", atividadeId);
            if (pessoaFisicaid != null)
                parametros.Add("@pessoaFisicaId", pessoaFisicaid);
            if (pessoaJuridicaId != null)
                parametros.Add("@pessoaJuridicaId", pessoaJuridicaId);
            ObterPorProcedimento("usp_front_upd_Cliente_Atividade", parametros);
        }

        public ValidationResult RedirecionarFila(string atividadesId, string usuarioId, int filaId)
        {
            var retorno = new ValidationResult();

            try
            {
                var Parametros = new DynamicParameters();
                Parametros.Add("@atividadesIds", atividadesId);
                Parametros.Add("@alteradoPorUsuarioId", usuarioId);
                Parametros.Add("@filaId", filaId);
                ExecutarProcedimento("usp_front_upd_RedirecionarAtividades", Parametros);
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Add(new ValidationError(ex.Message));
                return retorno;
            }
        }

        public Atividade AlteraDataPrevisaoAtividade(DateTime data, long atividadeId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@data", data);
            parametros.Add("@id", atividadeId);
            var procedureReturn = ObterPorProcedimento("usp_AlteraDataPrevisaoAtividade", parametros).FirstOrDefault();
            return procedureReturn;
        }
    }
}
