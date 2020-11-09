﻿using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ICidadeRepositorio : IRepositorio<Cidade>
    {
        IEnumerable<Cidade> ObterCidadesSemAcento(string cidade);
    }
}
