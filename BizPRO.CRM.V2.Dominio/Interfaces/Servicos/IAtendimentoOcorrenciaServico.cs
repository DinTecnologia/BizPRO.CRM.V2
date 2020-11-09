using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;
namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAtendimentoOcorrenciaServico
    {
        void Adicionar(long atendimentoId, long ocorrenciaId);
        bool PossuiVinculo(long atendimentoId, long ocorrenciaId);
        IEnumerable<AtendimentoOcorrencia> ObterOcorrenciasVinculadasAoAtendimento(long atendimentoId);
    }
}
