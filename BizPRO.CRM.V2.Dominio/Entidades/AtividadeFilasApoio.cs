using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AtividadeFilasApoio
    {
        public string NomeFila { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public string TipoAtividade { get; set; }
        public string NomeOcorrencia { get; set; }
        public int AtividadesTiposId { get; set; }
        public long AtividadeId { get; set; }
        public string Descricao { get; set; }
        public string NomeExibicao { get; set; }
        public DateTime? PrevisaoDeExecucao { get; set; }
        public string Referente { get; set; }
        public string NomeCliente { get; set; }
        public string TempoAtribuicao { get; set; }
        public bool AtrasadoAtribuicao { get; set; }
        public bool PossuiSlaAtribuicao { get; set; }
        public bool AtrasadoFechamento { get; set; }
        public bool PossuiSlaFechamento { get; set; }
        public bool? AtividadeFinalizada { get; set; }
        public string Texto { get; set; }
        public string Remetente { get; set; }
        public string ResponsavelUserId { get; set; }
        public string Titulo { get; set; }
        public string Responsavel { get; set; }
        public long? ClienteId { get; set; }
        public string ClienteTipo { get; set; }
        public long Total { get; set; }

        public string EstiloLinha
        {
            get
            {
                var classe = "";
                if (AtrasadoFechamento || (AtrasadoAtribuicao && NomeUsuario == "--"))
                    classe = "Atividade-Atrasada";
                else if (AtrasadoAtribuicao)
                    classe = "Atividade-Atencao";

                if (!AtividadeFinalizada.HasValue) return classe;
                if (AtividadeFinalizada.Value)
                    classe = "Atividade-Finalizada";

                return classe;
            }
        }

        public string Tela
        {
            get { return TipoAtividade == "Tarefa" ? "Tarefas" : ""; }
        }

    }
}