using System;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Contrato
    {
        public long Id { get; private set; }
        public string NumeroContrato { get; set; }
        public string CriadoPorUserId { get; set; }
        public string AlteradoPorUserId { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public long? ClientePessoaFisicaId { get; set; }
        public long? ClientePessoaJuridicaId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public decimal? ValorContrato { get; set; }
        public decimal? ValorDesconto { get; set; }
        public string TipoContrato { get; set; }
        public long? ContratoPaiId { get; set; }
        public long StatusEntidadeId { get; set; }
        public string Apelido { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public long? IntegracaoId { get; set; }

        public string NomeCombo
        {
            get
            {
                var retorno = "";

                if (!string.IsNullOrEmpty(Apelido))
                    retorno = Apelido;

                if (!string.IsNullOrEmpty(NumeroContrato))
                    retorno += string.Format(" ({0})", NumeroContrato);

                return retorno;
            }
        }


        public StatusEntidade StatusEntidade { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public Contrato()
        {
            StatusEntidade = new StatusEntidade();
            Produtos = new List<Produto>();
            ValidationResult = new ValidationResult();
        }

        public Contrato(string criadoPorUserId, string numeroContrato, decimal? valorContrato, decimal? valorDesconto,
            long? pessoaFisicaId, long? pessoaJuridicaId, DateTime? dataInicio, DateTime? dataTerminco,
            string tipoContrato, long? contratoPaiId, long statusEntidadeId, string apelido, DateTime? dataEncerramento)
        {
            NumeroContrato = numeroContrato;
            CriadoPorUserId = criadoPorUserId;
            CriadoEm = DateTime.Now;
            ClientePessoaFisicaId = pessoaFisicaId;
            ClientePessoaJuridicaId = pessoaJuridicaId;
            DataInicio = dataInicio;
            DataTermino = dataTerminco;
            ValorContrato = valorContrato;
            ValorDesconto = valorDesconto;
            TipoContrato = tipoContrato;
            ContratoPaiId = contratoPaiId;
            StatusEntidadeId = statusEntidadeId;
            Apelido = apelido;
            DataEncerramento = dataEncerramento;
            ValidationResult = new ValidationResult();
        }
    }
}
