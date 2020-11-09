using System;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Validacoes.PessoasJuridica;
using BizPRO.CRM.V2.Core.Comum;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class PessoaJuridica
    {
        public long Id { get; private set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime? DataDeConstituicao { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public string EmailPrincipal { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public int? CidadeId { get; set; }
        public string CodigoPostal { get; set; }
        public string AlteradoPorUserId { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public string Complemento { get; set; }
        public long? AtendimentoId { get; set; }
        public bool? AceitaComunicados { get; set; }
        public long? CanalEntidadesCamposValoresId { get; set; }
        public long? TipoEntidadesCamposValoresId { get; set; }
        public string Endereco { get; set; }
        public string NomeEstado { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public bool EntidadeIntegracao { get; set; }
        public long? IdentificadorIntegracao { get; set; }
        public bool RegistroJaIntegrado { get; set; }

        public bool IsValid()
        {
            ValidationResult = new PessoaJuridicaEstaConsistenteValidacao().Validate(this);
            return ValidationResult.IsValid;
        }

        public PessoaJuridica()
        {
            ValidationResult = new ValidationResult();
        }

        public PessoaJuridica(string razaoSocial, string nomeFantasia, string cnpj, string inscricaoEstadual,
            DateTime? dataDeConstituicao, string criadoPor, string emailPrincipal,
            DateTime? criadoEm, string logradouro, string numero, string bairro, int? cidadesID, string complemento,
            string codigoPostal, long? id, bool? aceitaComunicados, long? canalEntidadesCamposValoresId,
            long? tipoEntidadesCamposValoresId, long? atendimentoId)
        {
            CriadoEm = criadoEm ?? DateTime.Now;
            RazaoSocial = string.IsNullOrEmpty(razaoSocial)
                ? razaoSocial
                : TextoApoio.PrimeiraMaiusculaTodasPalavras(razaoSocial.ToLower());
            NomeFantasia = string.IsNullOrEmpty(nomeFantasia)
                ? nomeFantasia
                : TextoApoio.PrimeiraMaiusculaTodasPalavras(nomeFantasia.ToLower());
            InscricaoEstadual = inscricaoEstadual;
            DataDeConstituicao = dataDeConstituicao;
            CriadoPorUserId = criadoPor;
            EmailPrincipal = string.IsNullOrEmpty(emailPrincipal) ? emailPrincipal : emailPrincipal.ToLower();
            Cnpj = cnpj;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CidadeId = cidadesID;
            Complemento = complemento;
            CodigoPostal = codigoPostal;
            if (id.HasValue)
                Id = (long) id;

            AtendimentoId = atendimentoId;
            AceitaComunicados = aceitaComunicados ?? false;
            CanalEntidadesCamposValoresId = canalEntidadesCamposValoresId;
            TipoEntidadesCamposValoresId = tipoEntidadesCamposValoresId;
            ValidationResult = new ValidationResult();
        }
    }
}
