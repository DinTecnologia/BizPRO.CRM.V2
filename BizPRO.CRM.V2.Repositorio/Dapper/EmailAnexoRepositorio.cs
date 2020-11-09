using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using Dapper;
using System;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class EmailAnexoRepositorio : Repositorio<EmailAnexo>, IEmailAnexoRepositorio
    {
        public EmailAnexoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<EmailAnexo> ObterAnexos(long atividadeId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@atividadeId", atividadeId);
            return ObterPorProcedimento("usp_front_sel_EmailAnexo", parametros);
        }

        public IEnumerable<EmailAnexo> ObterDiretoriosEmailAnexo(DateTime? data)
        {
            var parametros = new DynamicParameters();
            if (data.HasValue)
                parametros.Add("@Data", data);
            return ObterPorProcedimento("usp_batch_DiretoriosEmailAnexo", parametros);
        }

    }
}
