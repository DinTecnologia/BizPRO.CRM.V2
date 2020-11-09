using System;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AtividadeListaViewModel
    {
         public long Id { get; set; }
        public long? FilaId { get; set; }
        public string Fila { get; set; }
        public string Tipo { get; set; }
        public string Referente { get; set; }        
        public string Cliente { get; set; }
        public string Responsavel { get; set; }
        public string Titulo { get; set; }
        public string Status { get; set; }
        public string CriadoEm { get; set; }
        public string PrevisaoExecucao { get; set; }
        public string Sla { get; set; }
        public string Estilolinha { get; set; }
        public bool Finalizada { get; set; }

        public AtividadeListaViewModel()
        {

        }

        public AtividadeListaViewModel(long id, string fila, string tipo, string referente, string cliente,
            string responsavel, string titulo, string status, DateTime criadoEm, DateTime? previsaoExecucao,
            bool possuiSlaAtribuicao, bool possuiSlaFechamento, bool slaAtribuicaoExcedido, bool slaFechamentoExcedido,
            string motivoOcorrencia, bool atividadeFinalizada)
        {
            Id = id;
            Fila = string.IsNullOrEmpty(fila) ? "--" : fila.ToUpper();
            Tipo = string.IsNullOrEmpty(tipo) ? "--" : tipo.ToUpper();
            Cliente = string.IsNullOrEmpty(cliente) ? "--" : cliente.ToUpper();
            Responsavel = string.IsNullOrEmpty(responsavel) ? "--" : responsavel.ToUpper();
            Titulo = string.IsNullOrEmpty(titulo) ? "--" : titulo;
            Status = string.IsNullOrEmpty(status) ? "--" : status;
            CriadoEm = criadoEm.ToString("dd/MM/yyyy HH:mm");
            PrevisaoExecucao = previsaoExecucao.HasValue ? previsaoExecucao.Value.ToString("dd/MM/yyyy HH:mm") : "--";
            Sla = possuiSlaAtribuicao ? possuiSlaFechamento ? "Atribuição <br /> Fechamento" : "Atribuição" : "--";
            Referente = referente.ToLower() == "ocorrência"
                ? string.Format("{0}<b />{1}", referente, motivoOcorrencia)
                : referente;

            if (slaFechamentoExcedido || (slaAtribuicaoExcedido && responsavel == "--"))
                Estilolinha = "Atividade-Atrasada";
            else if (slaAtribuicaoExcedido)
                Estilolinha = "Atividade-Atencao";

            if (Finalizada)
                Estilolinha = "Atividade-Finalizada";

            Finalizada = atividadeFinalizada;
        }
    }
}
