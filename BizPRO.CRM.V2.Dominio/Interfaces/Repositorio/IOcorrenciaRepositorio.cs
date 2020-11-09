using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IOcorrenciaRepositorio : IRepositorio<Ocorrencia>
    {
        IEnumerable<Ocorrencia> ObterOcorrenciasLocalPorUserId(string userId);

        IEnumerable<Ocorrencia> ObterOcorrenciasPorProtocolo(string protocolo);

        IEnumerable<Ocorrencia> ObterOcorrenciasLocalPorObjetos(string userId, string protocolo, string cliente,
            long? ocorrenciaTipoId, string documento);

        IEnumerable<Ocorrencia> ObterOcorrenciasLojista(string userId, string protocolo, string documento);

        IEnumerable<Ocorrencia> BuscarOcorrenciasCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId);

        IEnumerable<Ocorrencia> ObterOcorrenciasOriginal(string cliente, string protocolo, long? pessoaJuridicaId,
            long? pessoaFisicaId, long? ocorrenciaId);

        bool OcorrenciaFinalizada(long ocorrenciaId);

        IEnumerable<Ocorrencia> ObterOcorrenciasCorrecao();

        ValidationResult AtualizarMotivoOcorrencia(long ocorrenciaId, long ocorrenciaTipoId, string usuarioId);

        ValidationResult AtualizarContratoOcorrencia(long ocorrenciaId, long contratoId, string usuarioId);
    }
}
