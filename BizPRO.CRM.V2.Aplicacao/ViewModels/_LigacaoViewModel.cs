using System.Collections.Generic;
using DomainValidation.Validation;
using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class _LigacaoViewModel
    {
        public long AtendimentoId { get; set; }
        public long LigacaoId { get; set; }
        public long AtividadeId { get; set; }
        public string InformacaoUra { get; set; }
        public string NumeroTelefone { get; set; }
        public string Protocolo { get; set; }
        public string NumeroIdentificado { get; set; }
        public string Tipo { get; set; }
        public long? MidiaId { get; set; }
        public bool AtendimentoFinalizado { get; set; }
        public string DataPrevisao { get; set; }
        public int? FilaId { get; set; }
        public string FilaNome { get; set; }
        public SelectList Midias { get; set; }
        public IEnumerable<StatusAtividade> StatusAtividades { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public string StatusNome { get; set; }
        public long? OcorrenciaId { get; set; }
        public string Sentido { get; set; }
        public string Numero { get; set; }
        public string DetalheContato { get; set; }
        public bool? Receptiva { get; set; }
        public long? PessoaFisicaIdTratativa { get; set; }
        public long? PessoaJuridicaIdTratativa { get; set; }

        public _LigacaoViewModel()
        {
            ValidationResult = new ValidationResult();
        }

        public _LigacaoViewModel(Ligacao ligacao, IEnumerable<Midia> midias, IEnumerable<StatusAtividade> statusAtividades)
        {
            Midias = new SelectList(midias, "id", "nome");
            StatusAtividades = statusAtividades;
            LigacaoId = ligacao.Id;
            NumeroTelefone = ligacao.NumeroOriginal;
            Sentido = ligacao.Receptiva == null ? "--" : (ligacao.Receptiva.Value ? "Receptivo" : "Ativo");
            Receptiva = ligacao.Receptiva;
            FilaNome = "Sem fila atribuída";
            if (ligacao.Receptiva.HasValue)
            {
                Numero = ligacao.Receptiva.Value
                    ? ligacao.NumeroOriginal
                    : (ligacao.Telefone != null ? ligacao.Telefone.ToString() : "--");
            }

            if (string.IsNullOrEmpty(Numero))
                Numero = "Não Informado";

            if(ligacao.Fila != null)
            {
                FilaNome = ligacao.Fila.Nome;
                FilaId = ligacao.Fila.Id;
            }

            if (ligacao.Atividade != null)
            {
                AtendimentoFinalizado = ligacao.Atividade.FinalizadoEm.HasValue;
                DataPrevisao = ligacao.Atividade.PrevisaoDeExecucao.HasValue
                    ? ligacao.Atividade.PrevisaoDeExecucao.ToString()
                    : "--";
                DetalheContato = ligacao.Atividade.Descricao;

                if (ligacao.Atividade.Ocorrencia != null)
                {
                    OcorrenciaId = ligacao.Atividade.Ocorrencia.Id;
                }

                if (ligacao.Atividade.Atendimento != null)
                {
                    AtendimentoId = ligacao.Atividade.Atendimento.Id;
                    Protocolo = ligacao.Atividade.Atendimento.Protocolo;
                    MidiaId = ligacao.Atividade.Atendimento.MidiasId ?? ligacao.Atividade.MidiasId;
                }

                PessoaFisicaIdTratativa = ligacao.Atividade.PessoasFisicasId;
                PessoaJuridicaIdTratativa = ligacao.Atividade.PessoasJuridicasId;

                if (ligacao.Atividade.StatusAtividade != null)
                {
                    StatusNome = ligacao.Atividade.StatusAtividade.FinalizaAtividade
                        ? ligacao.Atividade.StatusAtividade.Descricao
                        : null;
                }
            }
        }
    }
}
