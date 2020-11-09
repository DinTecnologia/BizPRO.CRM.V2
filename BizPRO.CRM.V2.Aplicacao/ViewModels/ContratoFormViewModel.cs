using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ContratoFormViewModel
    {
        public long? Id { get; private set; }

        [Required(ErrorMessage = "Preencha o campo Número Contrato.")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string NumeroContrato { get; set; }

        public string CriadoPorUserId { get; set; }
        public string AlteradoPorUserId { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public long? ClientePessoaFisicaId { get; set; }
        public long? ClientePessoaJuridicaId { get; set; }

        public long? AtendimentoId { get; set; }


        //[Required(ErrorMessage = "Preencha o campo Data Início.")]
        public DateTime? DataInicio { get; set; }

        //[Required(ErrorMessage = "Preencha o campo Data Término.")]
        public DateTime? DataTermino { get; set; }

        //[Required(ErrorMessage = "Preencha o campo Valor Contrato.")]
        [DataType(DataType.Currency)]
        public decimal? ValorContrato { get; set; }

        public decimal? ValorDesconto { get; set; }
        public string TipoContrato { get; set; }
        public long? ContratoPaiId { get; set; }
        public long? StatusEntidadeId { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        public string Apelido { get; set; }

        public DateTime? DataEncerramento { get; set; }

        [Required(ErrorMessage = "Selecione o Produto")]
        public long? ProdutoId { get; set; }

        public SelectList Produtos { get; set; }
        public long? ProdutoTipoId { get; set; }
        public SelectList ProdutoTipos { get; set; }
        public CampoDinamicoViewModel ViewDinamica { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public ContratoFormViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            CriadoEm = DateTime.Now;
        }

        public ContratoFormViewModel(long? pessoaFisicaId, long? pessoaJuridicaId,
            IEnumerable<ProdutoTipo> listaProdutoTipo, CampoDinamicoViewModel viewDinamica,
            IEnumerable<Produto> listaProduto)
        {
            ClientePessoaFisicaId = pessoaFisicaId;
            ClientePessoaJuridicaId = pessoaJuridicaId;
            ProdutoTipos = new SelectList(listaProdutoTipo, "id", "nome");
            Produtos = new SelectList(listaProduto, "id", "NomeLista");
            ViewDinamica = viewDinamica;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            CriadoEm = DateTime.Now;
        }
    }
}
