using System;
using System.Text;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class OcorrenciaTipo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long? OcorrenciasTiposPaiId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public string NomeExibicao { get; set; }
        public bool Ativo { get; set; }
        public string EstruturaDeIDs { get; set; }
        public bool VincularLocal { get; set; }
        public int TempoPrevistoAtendimento { get; set; }
        public bool AtrasadoAtendimento { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public bool TempoPrevistoCorrido { get; set; }
        public string TextoDescricaoPadrao { get; set; }
        public string Fila { get; set; }
        public long IdExcel { get; set; }
        public DateTime? PrevisaoInicial { get; set; }

        public bool EhUltimoNivel { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(NomeExibicao) ? "Não Informado" : NomeExibicao;
        }

        public OcorrenciaTipo()
        {
            ValidationResult = new ValidationResult();
        }

        public OcorrenciaTipo(long id, string nome, long? ocorrenciasTiposPaiId, string criadoPorUserId,
            string nomeExibicao, bool vincularLocal, bool ativo, int tempoPrevistoAtendimento)
        {
            Id = id;
            Nome = nome;
            OcorrenciasTiposPaiId = ocorrenciasTiposPaiId;
            CriadoPorUserId = criadoPorUserId;
            NomeExibicao = nomeExibicao;
            VincularLocal = vincularLocal;
            Ativo = ativo;
            CriadoEm = DateTime.Now;
            TempoPrevistoAtendimento = tempoPrevistoAtendimento;
        }

        public string TempoPrevistoDeAtendimentoPorExtenso(bool periodoUtilSomente = false)
        {
            var retorno = new StringBuilder();

            if (TempoPrevistoAtendimento <= 0)
                return "Não Possui";

            const int horaEmMinutos = 60;
            const int diaEmMinutos = 1440;

            var somandoHoras = TempoPrevistoAtendimento % diaEmMinutos;
            var somandoDias = (TempoPrevistoAtendimento - somandoHoras) / diaEmMinutos;
            var somandoMinutos = somandoHoras % horaEmMinutos;
            somandoHoras = (somandoHoras - somandoMinutos) / horaEmMinutos;

            if (somandoDias > 0)
            {
                retorno.Append(somandoDias + " Dia(s) ");
            }

            if (somandoHoras > 0)
            {
                retorno.Append(somandoHoras + " Hora(s) ");
            }

            if (somandoMinutos > 0)
            {
                retorno.Append(somandoMinutos + " Minuto(s) ");
            }

            if (periodoUtilSomente)
            {
                retorno.Append("\"Dias Úteis\"");
            }

            return retorno.ToString();
        }


        public string TempoPrevistoPorExtenso(DateTime? dataPrevista, bool periodoUtilSomente = false)
        {
            var retorno = new StringBuilder();

            if (!dataPrevista.HasValue)
                return "Não Possui";

            var intervalo = dataPrevista.Value - DateTime.Now;

            if (intervalo.Days > 0)
            {
                retorno.Append(intervalo.Days + " Dia(s) ");
            }

            if (intervalo.Hours > 0)
            {
                retorno.Append(intervalo.Hours + " Hora(s) ");
            }

            if (intervalo.Minutes > 0)
            {
                retorno.Append(intervalo.Minutes + " Minuto(s) ");
            }

            if (periodoUtilSomente)
            {
                retorno.Append("\"Dias Úteis\"");
            }

            return retorno.ToString();

        }

    }
}