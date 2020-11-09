using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IEmailAnexoServico : IServico<EmailAnexo>
    {
        IEnumerable<EmailAnexo> ObterAnexos(long atividadeId);
        bool VerificarAnexos(string diretorio);
        IEnumerable<EmailAnexo> ObterDiretoriosEmailAnexo(DateTime? data);
    }
}
