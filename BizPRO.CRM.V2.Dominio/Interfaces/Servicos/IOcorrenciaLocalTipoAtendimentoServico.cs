using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IOcorrenciaLocalTipoAtendimentoServico
    {
        OcorrenciaLocalTipoAtendimento Adicionar(OcorrenciaLocalTipoAtendimento entidade);
        ValidationResult DeletarTodosLocaisDaOcorrencia(long ocorrenciaId);
    }
}
