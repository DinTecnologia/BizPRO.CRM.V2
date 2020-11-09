using System;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using DomainValidation.Validation;
using System.Collections.Generic;
using System.Data;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class PausaRepositorio : Repositorio<Pausa>, IPausaRepositorio
    {
        public PausaRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        protected ValidationResult Pausa(string usuarioId, int? motivoPausaId, string canalIds, string usuarioAcaoId)
        {
            var retorno = new ValidationResult();
            var where = new DynamicParameters();
            where.Add("@UsuarioId", usuarioId);
            where.Add("@CanalIds", canalIds);
            where.Add("@UsuarioAcaoId", usuarioAcaoId);
            if (motivoPausaId.HasValue)
                where.Add("@MotivoPausaId", motivoPausaId);

            try
            {
                ExecutarProcedimento("usp_front_upd_Pausa", where);
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.Add(new ValidationError(ex.Message));
                return retorno;
            }
        }

        public ValidationResult EntrarEmPausa(string usuarioId, int motivoPausaId, string canalIds, string usuarioAcaoId)
        {
            return Pausa(usuarioId, motivoPausaId, canalIds, usuarioAcaoId);
        }

        public ValidationResult SairDaPausa(string usuarioId, string canalIds, string usuarioAcaoId)
        {
            return Pausa(usuarioId, null, canalIds, usuarioAcaoId);
        }

        public IEnumerable<Pausa> ObterPorUsuarioId(string usuarioId, string canalIds)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@CanalIds", canalIds);
            parametros.Add("@UsuarioId", usuarioId);
            return ObterPorProcedimento("usp_front_sel_Pausa", parametros);
        }

        public IEnumerable<Pausa> ListarPausas(string usuarioId, string canalIds)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@CanalIds", canalIds);
            parametros.Add("@UsuarioId", usuarioId);

            var retorno = Conn.Query<Pausa, Canal, PausaMotivo, Pausa>("usp_front_sel_Pausa",
                (ret, canal, motivo) =>
                {
                    ret.Canal = canal;
                    ret.Motivo = motivo;
                    return ret;
                },
                parametros,
                splitOn: "Id,id,id",
                commandType: CommandType.StoredProcedure);

            return retorno;
        }
    }
}
