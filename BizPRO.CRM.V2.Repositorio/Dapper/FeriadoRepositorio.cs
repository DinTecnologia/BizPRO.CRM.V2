using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class FeriadoRepositorio : Repositorio<Feriado>, IFeriadoRepositorio
    {
        public FeriadoRepositorio(IDapperContexto context)
            : base(context)
        {

        }
    }
}