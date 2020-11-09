﻿using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAspNetRolesMenuServico : IServico<AspNetRolesMenu>
    {
        IEnumerable<AspNetRolesMenu> BuscarPorMenuId(int id);
    }
}
