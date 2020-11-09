using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IPausaServico
    {
        ValidationResult Salvar(string usuarioId, int? motivoId, string canalIds,
            string usuarioAcaoId);

        IEnumerable<Pausa> ObterPor(string usuarioId, string canalIds);
    }
}
