﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL
{
    public interface IEmailRepositorioDal
    {
        int PossuiNovosEmails(string userId);
    }
}
