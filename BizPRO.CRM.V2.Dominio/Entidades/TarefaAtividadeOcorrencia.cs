using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class TarefaAtividadeOcorrencia
    {
        public long tarefaID { get; set; }
        public string descricao { get; set; }
        public long AtividadeID { get; set; }
        public string nomeOcorrenciaTipo { get; set; }
        public string statusAtividadeNome { get; set; }
        public bool finalizaAtividade { get; set; }
        public string titulo { get; set; }
        public string nomeExibicao { get; set; }
        public long? pessoaFisicaID { get; set; }
        public long? pessoaJuridicaID { get; set; }
        public long ocorrenciaID { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public string referente { get; set; }
        public DateTime? criadoEm { get; set; }
        public DateTime? finalizadoEm { get; set; }
        public string responsavel { get; set; }
        public string tempo { get; set; }

        public TarefaAtividadeOcorrencia()
        {
            ValidationResult = new ValidationResult();            
        }

        public string CalcularTempo()
        {
            var ts = (finalizadoEm.HasValue ? finalizadoEm : DateTime.Now).Value.Subtract(criadoEm.Value);
            var periodo = new DateTime(ts.Ticks);
            tempo = string.Format("{0}d {1}h{2}", periodo.Day, periodo.Hour, periodo.Minute);
            return "";
        }
    }
}
