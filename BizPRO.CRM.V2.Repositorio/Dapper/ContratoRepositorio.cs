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
    public class ContratoRepositorio : Repositorio<Contrato>, IContratoRepositorio
    {
        public ContratoRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public IEnumerable<Contrato> ObterContratosPorCliente(string procedimento, DynamicParameters parametros)
        {
            var retorno = Conn.Query<Contrato, StatusEntidade, Contrato>(procedimento,
                (ret, proTp) =>
                {
                    ret.StatusEntidade = proTp;
                    return ret;
                },
                parametros,
                splitOn: "Id,id",
                commandType: CommandType.StoredProcedure);

            return retorno;
        }
        
        public Contrato ObterContratoDetalhe(long contratoId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ContratoId", contratoId);

            var retorno = Conn.Query<Contrato, StatusEntidade, Contrato>("usp_front_sel_DetalheContrato",
                        (contrato, statusEntidade) =>
                        {
                            contrato.StatusEntidade = statusEntidade;
                            return contrato;
                        },
                        parametros,
                        splitOn: "Id,id",
                        commandType: CommandType.StoredProcedure);

            return retorno.FirstOrDefault();
        }
    }
}
