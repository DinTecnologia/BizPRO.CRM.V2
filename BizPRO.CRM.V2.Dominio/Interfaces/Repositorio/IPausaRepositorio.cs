using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IPausaRepositorio : IRepositorio<Pausa>
    {
        IEnumerable<Pausa> ListarPausas(string usuarioId, string canalIds);

        ValidationResult EntrarEmPausa(string usuarioId, int motivoPausaId, string canalIds,
      string usuarioAcaoId);

        ValidationResult SairDaPausa(string usuarioId, string canalIds, string usuarioAcaoId);
    }
}
