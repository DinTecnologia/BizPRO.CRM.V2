using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL
{
    public interface IRepositorioDal
    {
        Fila GetFila(int id);
    }
}
