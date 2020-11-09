using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
   public  class AspNetRolesFilaRepositorio: Repositorio<AspNetRolesFila>, IAspNetRolesFilaRepositorio
    {
       public AspNetRolesFilaRepositorio(IDapperContexto context)
            : base(context)
        {

        }
    }
}
