﻿using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class EntidadeSecaoCampoDinamicoRepositorio : Repositorio<EntidadeSecaoCampoDinamico>, IEntidadeSecaoCampoDinamicoRepositorio
    {
        public EntidadeSecaoCampoDinamicoRepositorio(IDapperContexto context)
            : base(context)
        {
        }
    }
}
