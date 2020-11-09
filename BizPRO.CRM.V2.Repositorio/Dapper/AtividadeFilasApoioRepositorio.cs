using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Contexto.Interfaces;
using System.Collections.Generic;
using Dapper;
using System;
using System.Linq;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AtividadeFilasApoioRepositorio : Repositorio<AtividadeFilasApoio>, IAtividadeFilasApoioRepositorio
    {
        public AtividadeFilasApoioRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<AtividadeFilasApoio> ObterAtividadesFila(string userId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@userID", userId);
            return ObterPorProcedimento("usp_front_sel_AtividadeFila", parametros);
        }

        public IEnumerable<AtividadeFilasApoio> ObterAtividadesFila(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
            bool? atrasadoAtribuicao, bool? atrasadoAtendimento)
        {
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(criadoPorId))
                parametros.Add("@criadoPorID", criadoPorId);

            if (!string.IsNullOrEmpty(responsavelPorId))
                parametros.Add("@responsavelPorID", responsavelPorId);

            if (dataInicio != DateTime.MinValue && dataInicio.HasValue)
                parametros.Add("@dataInicio", dataInicio);

            if (dataFim != DateTime.MinValue && dataFim.HasValue)
                parametros.Add("@dataFim", dataFim);

            if (!string.IsNullOrEmpty(status))
                parametros.Add("@status", status);

            if (filaId.HasValue)
                parametros.Add("@filaID", filaId);

            if (atrasadoAtendimento != null)
                parametros.Add("@atrasadoAtendimento", atrasadoAtendimento);

            if (atrasadoAtribuicao != null)
                parametros.Add("@atrasadoAtribuicao", atrasadoAtribuicao);

            parametros.Add("@finalizado", finalizado);

            return ObterPorProcedimento("usp_front_sel_AtividadeFila", parametros);
        }

        public IEnumerable<AtividadeFilasApoio> ObterAtividadesFila(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
            bool? atrasadoAtribuicao, bool? atrasadoAtendimento, string nomeCliente, string emailCliente,
            string assuntoAtividade)
        {
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(criadoPorId))
                parametros.Add("@criadoPorID", criadoPorId);

            if (!string.IsNullOrEmpty(responsavelPorId))
                parametros.Add("@responsavelPorID", responsavelPorId);

            if (dataInicio != DateTime.MinValue && dataInicio.HasValue)
                parametros.Add("@dataInicio", dataInicio);

            if (dataFim != DateTime.MinValue && dataFim.HasValue)
                parametros.Add("@dataFim", dataFim);

            if (!string.IsNullOrEmpty(status))
                parametros.Add("@status", status);

            if (filaId.HasValue)
                parametros.Add("@filaID", filaId);

            if (atrasadoAtendimento != null)
                parametros.Add("@atrasadoAtendimento", atrasadoAtendimento);

            if (atrasadoAtribuicao != null)
                parametros.Add("@atrasadoAtribuicao", atrasadoAtribuicao);

            parametros.Add("@finalizado", finalizado);


            if (!string.IsNullOrEmpty(nomeCliente))
                parametros.Add("@nomeCliente", nomeCliente);

            if (!string.IsNullOrEmpty(emailCliente))
                parametros.Add("@emailCliente", emailCliente);

            if (!string.IsNullOrEmpty(assuntoAtividade))
                parametros.Add("@assuntoAtividade", assuntoAtividade);

            return ObterPorProcedimento("usp_front_sel_AtividadeFila", parametros);
        }

        public IEnumerable<AtividadeFilasApoio> ObterTotalAtividadesFila(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
            bool? atrasadoAtribuicao, bool? atrasadoAtendimento, string nomeCliente, string emailCliente,
            string assuntoAtividade)
        {
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(criadoPorId))
                parametros.Add("@criadoPorID", criadoPorId);

            if (!string.IsNullOrEmpty(responsavelPorId))
                parametros.Add("@responsavelPorID", responsavelPorId);

            if (dataInicio != DateTime.MinValue && dataInicio.HasValue)
                parametros.Add("@dataInicio", dataInicio);

            if (dataFim != DateTime.MinValue && dataFim.HasValue)
                parametros.Add("@dataFim", dataFim);

            if (!string.IsNullOrEmpty(status))
                parametros.Add("@status", status);

            if (filaId.HasValue)
                parametros.Add("@filaID", filaId);

            if (atrasadoAtendimento != null)
                parametros.Add("@atrasadoAtendimento", atrasadoAtendimento);

            if (atrasadoAtribuicao != null)
                parametros.Add("@atrasadoAtribuicao", atrasadoAtribuicao);

            parametros.Add("@finalizado", finalizado);


            if (!string.IsNullOrEmpty(nomeCliente))
                parametros.Add("@nomeCliente", nomeCliente);

            if (!string.IsNullOrEmpty(emailCliente))
                parametros.Add("@emailCliente", emailCliente);

            if (!string.IsNullOrEmpty(assuntoAtividade))
                parametros.Add("@assuntoAtividade", assuntoAtividade);

            return ObterPorProcedimento("usp_front_sel_TotalAtividadeFila", parametros);
        }


        public IEnumerable<AtividadeFilasApoio> ObterAtividadesFilaSupervisao(string criadoPorId,
            string responsavelPorId, DateTime? dataInicio, DateTime? dataFim, string status, int? filaId,
            bool? finalizado, bool? slaAtribuicao, bool? slaAtendimento, bool? slaTempoEstourado, string emailAssunto)
        {
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(criadoPorId))
                parametros.Add("@criadoPorID", criadoPorId);

            if (!string.IsNullOrEmpty(responsavelPorId))
                parametros.Add("@responsavelPorID", responsavelPorId);

            if (dataInicio != DateTime.MinValue && dataInicio.HasValue)
                parametros.Add("@dataInicio", dataInicio);

            if (dataFim != DateTime.MinValue && dataFim.HasValue)
                parametros.Add("@dataFim", dataFim);

            if (!string.IsNullOrEmpty(status))
                parametros.Add("@status", status);

            if (filaId.HasValue)
                parametros.Add("@filaID", filaId);

            if (finalizado.HasValue)
                parametros.Add("@finalizado", finalizado);

            if (slaAtribuicao.HasValue)
                parametros.Add("@slaAtribuicao", slaAtribuicao);

            if (slaAtendimento.HasValue)
                parametros.Add("@slaAtendimento", slaAtendimento);

            if (slaTempoEstourado.HasValue)
                parametros.Add("@slaTempoEstourado", slaTempoEstourado);

            if (!string.IsNullOrEmpty(emailAssunto))
                parametros.Add("@emailAssunto", emailAssunto);

            return ObterPorProcedimento("usp_front_sel_AtividadesFila_Supervisao", parametros);
        }
    }

    //public class AtividadeFilasApoioRepositorio : Repositorio<AtividadeFilasApoio>, IAtividadeFilasApoioRepositorio
    //{
    //    public AtividadeFilasApoioRepositorio(IDapperContexto context)
    //        : base(context)
    //    {

    //    }

    //    public IEnumerable<AtividadeFilasApoio> ObterAtividadesFila(string userId)
    //    {
    //        var parametros = new DynamicParameters();
    //        parametros.Add("@userID", userId);
    //        return ObterPorProcedimento("usp_front_sel_AtividadeFila", parametros);
    //    }

    //    public IEnumerable<AtividadeFilasApoio> ObterAtividadesFila(string criadoPorId, string responsavelPorId,
    //        DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
    //        bool? atrasadoAtribuicao, bool? atrasadoAtendimento)
    //    {
    //        var parametros = new DynamicParameters();

    //        if (!string.IsNullOrEmpty(criadoPorId))
    //            parametros.Add("@criadoPorID", criadoPorId);

    //        if (!string.IsNullOrEmpty(responsavelPorId))
    //            parametros.Add("@responsavelPorID", responsavelPorId);

    //        if (dataInicio != DateTime.MinValue && dataInicio.HasValue)
    //            parametros.Add("@dataInicio", dataInicio);

    //        if (dataFim != DateTime.MinValue && dataFim.HasValue)
    //            parametros.Add("@dataFim", dataFim);

    //        if (!string.IsNullOrEmpty(status))
    //            parametros.Add("@status", status);

    //        if (filaId.HasValue)
    //            parametros.Add("@filaID", filaId);

    //        if (atrasadoAtendimento != null)
    //            parametros.Add("@atrasadoAtendimento", atrasadoAtendimento);

    //        if (atrasadoAtribuicao != null)
    //            parametros.Add("@atrasadoAtribuicao", atrasadoAtribuicao);

    //        parametros.Add("@finalizado", finalizado);

    //        return ObterPorProcedimento("usp_front_sel_AtividadeFila", parametros);
    //    }

    //    public IEnumerable<AtividadeFilasApoio> ObterAtividadesFilaSupervisao(string criadoPorId,
    //        string responsavelPorId, DateTime? dataInicio, DateTime? dataFim, string status, int? filaId,
    //        bool? finalizado, bool? slaAtribuicao, bool? slaAtendimento, bool? slaTempoEstourado)
    //    {
    //        var parametros = new DynamicParameters();

    //        if (!string.IsNullOrEmpty(criadoPorId))
    //            parametros.Add("@criadoPorID", criadoPorId);

    //        if (!string.IsNullOrEmpty(responsavelPorId))
    //            parametros.Add("@responsavelPorID", responsavelPorId);

    //        if (dataInicio != DateTime.MinValue && dataInicio.HasValue)
    //            parametros.Add("@dataInicio", dataInicio);

    //        if (dataFim != DateTime.MinValue && dataFim.HasValue)
    //            parametros.Add("@dataFim", dataFim);

    //        if (!string.IsNullOrEmpty(status))
    //            parametros.Add("@status", status);

    //        if (filaId.HasValue)
    //            parametros.Add("@filaID", filaId);

    //        if (finalizado.HasValue)
    //            parametros.Add("@finalizado", finalizado);

    //        if (slaAtribuicao.HasValue)
    //            parametros.Add("@slaAtribuicao", slaAtribuicao);

    //        if (slaAtendimento.HasValue)
    //            parametros.Add("@slaAtendimento", slaAtendimento);

    //        if (slaTempoEstourado.HasValue)
    //            parametros.Add("@slaTempoEstourado", slaTempoEstourado);

    //        return ObterPorProcedimento("usp_front_sel_AtividadesFila_Supervisao", parametros);
    //    }
    //}
}
