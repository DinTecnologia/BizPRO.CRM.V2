using System;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Validacoes.PessoasFisica;
using BizPRO.CRM.V2.Core.Comum;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class PessoaFisica
    {
        public long Id { get; private set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string OutroDocumento { get; set; }
        public bool CpfProprio { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public string CodigoPostal { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public int? CidadeId { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public string AlteradoPorUserId { get; set; }
        public string Complemento { get; set; }
        public string Email { get; set; }
        public long? AtendimentoId { get; set; }
        public bool AceitaComunicados { get; set; }
        public long? CanalEntidadesCamposValoresId { get; set; }
        public long? TipoEntidadesCamposValoresId { get; set; }

        public string NomeEstado { get; set; }
        public Cidade Cidade { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool EntidadeIntegracao { get; set; }
        public long? IdentificadorIntegracao { get; set; }

        public bool ChamarIntegracao { get; set; }
        public bool JaIntegrado { get; set; }

        public string Endereco
        {
            get
            {
                return String.Format("{0}, {1} - {2}, {3} - {4}, {5}", Logradouro, Numero, Bairro,
                    (Cidade != null ? Cidade.Nome : ""), (Cidade != null ? Cidade.Uf : ""), CodigoPostal);
            }
        }

        public bool IsValid()
        {
            ValidationResult = new PessoaFisicaEstaConsistenteValidacao().Validate(this);
            return ValidationResult.IsValid;
        }

        public PessoaFisica()
        {
            ValidationResult = new ValidationResult();
        }

        public PessoaFisica(long? id, string nome, string sobrenome, string cpf, bool cpfProprio,
            DateTime? dataNascimento, string criadoPor, string outroDocumento, string logradouro,
            string numero, string bairro, int? cidadesId, string complemento, string codigoPostal, string email,
            bool? aceitaComunicados, long? canalEntidadesCamposValoresId, long? tipoEntidadesCamposValoresId,
            long? atendimentoId)
        {
            Id = id != null ? (long) id : int.MinValue;
            Nome = string.IsNullOrEmpty(nome) ? nome : TextoApoio.PrimeiraMaiusculaTodasPalavras(nome.ToLower());
            Sobrenome = string.IsNullOrEmpty(sobrenome)
                ? sobrenome
                : TextoApoio.PrimeiraMaiusculaTodasPalavras(sobrenome.ToLower());
            CpfProprio = cpfProprio;
            DataNascimento = dataNascimento;
            CriadoPorUserId = criadoPor;
            CriadoEm = DateTime.Now;
            Cpf = cpf;
            OutroDocumento = outroDocumento;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CidadeId = cidadesId;
            Complemento = complemento;
            CodigoPostal = codigoPostal;
            Email = email;
            AtendimentoId = atendimentoId;
            AceitaComunicados = aceitaComunicados ?? false;
            CanalEntidadesCamposValoresId = canalEntidadesCamposValoresId;
            TipoEntidadesCamposValoresId = tipoEntidadesCamposValoresId;
            ValidationResult = new ValidationResult();
        }

        public PessoaFisica(string nome, string cpf, string criadoPor, string logradouro, string numero, string bairro,
            int? cidadesId, string codigoPostal, string email)
        {
            Nome = nome;
            Cpf = cpf.Replace(".", "").Replace("-", "");
            CriadoPorUserId = criadoPor;
            CriadoEm = DateTime.Now;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CidadeId = cidadesId;
            CodigoPostal = codigoPostal;
            Email = email;
        }
    }
}