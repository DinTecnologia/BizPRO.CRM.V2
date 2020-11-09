using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using System;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IOcorrenciaTipoServico
    {
        OcorrenciaTipo ObterPorId(long id);
        IEnumerable<OcorrenciaTipo> ObterTodos();
        IEnumerable<OcorrenciaTipo> ObterOcorrenciasPai();
        IEnumerable<OcorrenciaTipo> ObterPor(long ocorrenciasTipoPaiId);
        OcorrenciaTipo SalvarOcorrenciaTipo(OcorrenciaTipo entidade);
        OcorrenciaTipo EditarOcorrenciaTipo(OcorrenciaTipo entidade);
        IEnumerable<OcorrenciaTipo> ListarOcorrenciaTipoOcorrencia(string userId);
        DateTime? CalcularSla(long id);
        void AdicionarOcorrenciaTipoDoArquivoCliente(string nivel1, string nivel2, string nivel3,
            string nivel4, string nivel5, string nivel6, string nivel7, string nivel8, string nivel9, string nivel10,
            string status, bool gerarAtividade, string fila, int sla, int qtdNiveis);
        OcorrenciaTipo ObterPorOcorrenciaId(long id);
        DateTime? CalcularDataSla(int ocorrenciaTipoId, DateTime? dataInicio);
    }
}