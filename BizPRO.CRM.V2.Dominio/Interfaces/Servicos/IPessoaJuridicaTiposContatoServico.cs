﻿using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IPessoaJuridicaTiposContatoServico : IServico<PessoaJuridicaTiposContato>
    {
        List<PessoaJuridicaTiposContato> Listar();
    }
}
