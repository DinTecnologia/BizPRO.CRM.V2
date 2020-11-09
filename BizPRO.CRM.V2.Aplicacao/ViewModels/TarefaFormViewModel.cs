using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class TarefaFormViewModel
    {
        public long? TarefaId { get; set; }
        public long? AtividadeId { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? PrevisaoDeExecucao { get; set; }
        public string Descricao { get; set; }
        public long? OcorrenciaId { get; set; }
        public long? ContratoId { get; set; }
        public long? AtendimentoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Título")]
        [MaxLength(2000, ErrorMessage = "Máximo 2000 caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? PotencialClienteId { get; set; }
        public int? CanalId { get; set; }
        public int? MidiaId { get; set; }
        public long? AtividadeDeOrigemId { get; set; }
        public string ResponsavelPorUserId { get; set; }
        public SelectList Filas { get; set; }
        public SelectList OpcoesPraQuem { get; set; }
        public int? FilaId { get; set; }
        public string PraQuemId { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }


        public TarefaFormViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

        public TarefaFormViewModel(IEnumerable<Fila> filas, long? ocorrenciaId, long? atividadeDeOrigemId,
            long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClienteId, long? atendimentoId)
        {
            OcorrenciaId = ocorrenciaId;
            AtividadeDeOrigemId = atividadeDeOrigemId;
            PessoaFisicaId = pessoaFisicaId;
            PessoaJuridicaId = pessoaJuridicaId;
            PotencialClienteId = potencialClienteId;
            AtendimentoId = atendimentoId;
            Filas = new SelectList(filas, "id", "nome");

            var listaOpcoes = new Dictionary<string, string>
            {
                {"A Mim", "mim"},
                {"Fila", "fila"}
            };

            OpcoesPraQuem = new SelectList(listaOpcoes, "Value", "Key");
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }
}
