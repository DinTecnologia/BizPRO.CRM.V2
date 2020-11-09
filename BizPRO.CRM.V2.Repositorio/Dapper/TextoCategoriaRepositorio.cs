using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class TextoCategoriaRepositorio : Repositorio<TextoCategoria>, ITextoCategoriaRepositorio
    {
        public TextoCategoriaRepositorio(IDapperContexto context) : base(context)
        {

        }

        public IEnumerable<TextoCategoria> ObterPorFilaId(int? filaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@FilaId", filaId);
            return ObterPorProcedimento("usp_front_sel_TextoCategorias", parametros);
        }
    }
}
