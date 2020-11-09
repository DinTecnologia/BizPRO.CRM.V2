using System;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AtividadeFilterViewModel
    {
        public DateTime? CriadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? PrevisaoDeExecucao { get; set; }
        public int? FilaId { get; set; }
        public string CriadoPorId { get; set; }
        public string ResponsavelPorId { get; set; }
        public int? StatusAtividadeId { get; set; }
        public int? SituacaoId { get; set; }
        public int? AtividadeTipoId { get; set; }
        public bool? AtrasadoAtendimento { get; set; }
        public bool? AtrasadoAtribuicao { get; set; }
        public long? OcorrenciaId { get; set; }
        public long? ContratoId { get; set; }
        public long? AtendimentoId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? PotencialClienteId { get; set; }
        public int? CanalId { get; set; }
        public int? MidiaId { get; set; }
        public string Protocolo { get; set; }
        public bool? AtividadeEmFila { get; set; }
        public int? DepartamentoId { get; set; }
    }
}
