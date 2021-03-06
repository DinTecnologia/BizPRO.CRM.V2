﻿using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IDepartamentoServico : IServico<Departamento>
    {
        IEnumerable<Departamento> ObterDepartamentos();
        Departamento ObterPorId(int id);
        IEnumerable<Departamento> ObterPorUsuario(string usuarioId);
        IEnumerable<Departamento> ObterDepartamentoPorUser(string usuarioId);
    }
}
