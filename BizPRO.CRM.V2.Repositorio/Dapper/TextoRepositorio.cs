using System.Collections.Generic;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Data;
using System.Linq;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class TextoRepositorio : Repositorio<Texto>, ITextoRepositorio
    {
        public TextoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Texto> FiltrarTexto(int? filaId, int? canalId, int? tipoId, int? formatoId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@FilaId", filaId);
            parametros.Add("@CanalId", canalId);
            parametros.Add("@TipoId", tipoId);
            parametros.Add("@FormatoId", formatoId);
            //return ObterPorProcedimento("usp_front_sel_Textos_Filtro", parametros);

            var retorno =
             Conn
                  .Query
                  <Texto, TextoCategoria, Usuario, Texto>(
                      "usp_front_sel_Textos_Filtro",
                      (ret, categoria, usuario) =>
                      {
                          ret.CategoriaObj = categoria;
                          ret.CriadoPorObj = usuario;
                          return ret;
                      },
                      parametros,
                      splitOn: "Id,Id,Id",
                      commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<Texto> ObterPorFilaId(int? filaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@FilaId", filaId ?? filaId);
            return ObterPorProcedimento("usp_front_sel_Textos", parametros);
        }
    }
}
