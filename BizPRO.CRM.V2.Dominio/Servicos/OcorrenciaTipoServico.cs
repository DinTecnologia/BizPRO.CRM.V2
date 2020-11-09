using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using System.Linq;
using System;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class OcorrenciaTipoServico : IOcorrenciaTipoServico
    {
        private readonly IOcorrenciaTipoRepositorio _repositorio;

        public OcorrenciaTipoServico(IOcorrenciaTipoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<OcorrenciaTipo> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public IEnumerable<OcorrenciaTipo> ObterPor(long ocorrenciasTipoPaiId)
        {
            return _repositorio.ObterPor(ocorrenciasTipoPaiId);
        }

        public IEnumerable<OcorrenciaTipo> ObterOcorrenciasPai()
        {
            return _repositorio.ObterOcorrenciasPai();
        }

        public OcorrenciaTipo ObterPorId(long id)
        {
            return _repositorio.ObterPorId(id);
        }

        public OcorrenciaTipo SalvarOcorrenciaTipo(OcorrenciaTipo entidade)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@criadoEm", entidade.CriadoEm);
            parametros.Add("@criadoPorUserID", entidade.CriadoPorUserId);
            parametros.Add("@nome", entidade.Nome);
            parametros.Add("@ocorrenciasTiposPaiID", entidade.OcorrenciasTiposPaiId);
            parametros.Add("@ativo", entidade.Ativo);
            parametros.Add("@vincularLocal", entidade.VincularLocal);
            parametros.Add("@tempoPrevistoAtendimento", entidade.TempoPrevistoAtendimento);
            return _repositorio.ObterPorProcedimento("usp_front_ins_ocorrenciaTipos", parametros).FirstOrDefault();
        }

        public OcorrenciaTipo EditarOcorrenciaTipo(OcorrenciaTipo entidade)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nome", entidade.Nome);
            parametros.Add("@ocorrenciasTiposPaiID", entidade.OcorrenciasTiposPaiId);
            parametros.Add("@ativo", entidade.Ativo);
            parametros.Add("@vincularLocal", entidade.VincularLocal);
            parametros.Add("@id", entidade.Id);
            parametros.Add("@tempoPrevistoAtendimento", entidade.TempoPrevistoAtendimento);
            return _repositorio.ObterPorProcedimento("usp_front_upd_ocorrenciaTipos", parametros).FirstOrDefault();
        }

        public IEnumerable<OcorrenciaTipo> ListarOcorrenciaTipoOcorrencia(string userId)
        {
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(userId))
                parametros.Add("@UserID", userId);

            return _repositorio.ObterPorProcedimento("usp_front_sel_OcorrenciaTipoOcorrencia", parametros);

        }

        public DateTime? CalcularSla(long id)
        {
            var entidade = ObterPorId(id);

            if (entidade == null) return null;
            if (entidade.TempoPrevistoAtendimento > 0)
                return DateTime.Now.AddMinutes(entidade.TempoPrevistoAtendimento);

            return null;
        }

        public void AdicionarOcorrenciaTipoDoArquivoCliente(string nivel1, string nivel2, string nivel3,
            string nivel4, string nivel5, string nivel6, string nivel7, string nivel8, string nivel9, string nivel10,
            string status, bool gerarAtividade, string fila, int sla, int qtdNiveis)
        {
            var parametros = new DynamicParameters();

            parametros.Add("@nivel1", string.IsNullOrEmpty(nivel1) ? null : nivel1.ToUpper().Trim());
            parametros.Add("@nivel2", string.IsNullOrEmpty(nivel2) ? null : nivel2.ToUpper().Trim());
            parametros.Add("@nivel3", string.IsNullOrEmpty(nivel3) ? null : nivel3.ToUpper().Trim());
            parametros.Add("@nivel4", string.IsNullOrEmpty(nivel4) ? null : nivel4.ToUpper().Trim());
            parametros.Add("@nivel5", string.IsNullOrEmpty(nivel5) ? null : nivel5.ToUpper().Trim());
            parametros.Add("@nivel6", string.IsNullOrEmpty(nivel6) ? null : nivel6.ToUpper().Trim());
            parametros.Add("@nivel7", string.IsNullOrEmpty(nivel7) ? null : nivel7.ToUpper().Trim());
            parametros.Add("@nivel8", string.IsNullOrEmpty(nivel8) ? null : nivel8.ToUpper().Trim());
            parametros.Add("@nivel9", string.IsNullOrEmpty(nivel9) ? null : nivel9.ToUpper().Trim());
            parametros.Add("@nivel10", string.IsNullOrEmpty(nivel10) ? null : nivel10.ToUpper().Trim());

            parametros.Add("@status", status);
            parametros.Add("@gerarAtividade", gerarAtividade);

            if (gerarAtividade)
                parametros.Add("@fila", fila);

            parametros.Add("@sla", sla);
            parametros.Add("@qtdNiveis", qtdNiveis);
            _repositorio.ExecutarProcedimento("usp_batch_ImportarOcorrenciaTipo", parametros);
        }


        public OcorrenciaTipo ObterPorOcorrenciaId(long id)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@OcorrenciaId", id);

            return _repositorio.ObterPorProcedimento("usp_front_sel_OcorrenciaTipoPorOcorrenciaId", parametros).FirstOrDefault();
        }

        public DateTime? CalcularDataSla(int ocorrenciaTipoId, DateTime? dataInicio)
        {
            var retorno = _repositorio.ObterPrevisaoInicial(ocorrenciaTipoId, dataInicio).FirstOrDefault();

            return retorno == null ? (DateTime?)null : retorno.PrevisaoInicial;
        }
    }
}