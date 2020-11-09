using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Telefone
    {
        public long Id { get; private set; }
        public long? ClientePessoaJuridicaId { get; set; }
        public long? ClientePessoaFisicaId { get; set; }
        public bool Ativo { get; set; }
        public string TipoTelefone { get; set; }
        public int Ordem { get; set; }
        public int Ddi { get; set; }
        public int Ddd { get; set; }
        public long Numero { get; set; }
        public bool Principal { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public bool EhMovel { get; set; }
        public int? TelefonesTiposId { get; set; }
        public long? PotenciaisClientesId { get; set; }

        public override string ToString()
        {
            return string.Format("({0}) {1}", Ddd, Numero);
        }

        public ValidationResult ValidationResult { get; private set; }

        public Telefone()
        {
            ValidationResult = new ValidationResult();
        }

        public Telefone(string numeroTelefone, string criadoPorUserId, long? pessoaFisicaId, long? pessoaJuridicaId)
        {
            long NumeroTelefone;

            long.TryParse(numeroTelefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""),
                out NumeroTelefone);
            Ddd = Convert.ToInt32(NumeroTelefone.ToString().Substring(0, 2));
            Numero = Convert.ToInt64(NumeroTelefone.ToString().Substring(2, NumeroTelefone.ToString().Length - 2));
            ;
            CriadoEm = DateTime.Now;
            CriadoPorUserId = criadoPorUserId;
            ClientePessoaFisicaId = pessoaFisicaId;
            ClientePessoaJuridicaId = pessoaJuridicaId;
            Ativo = true;
            Principal = false;
        }

        public Telefone(int? ddd, long? numero, string criadoPorUserId, long? pessoaFisicaId, long? pessoaJuridicaId,
            int? tipo, long? potenciaisClientesId)
        {
            Ddd = (int) ddd;
            Numero = (long) numero;
            CriadoEm = DateTime.Now;
            CriadoPorUserId = criadoPorUserId;
            ClientePessoaFisicaId = pessoaFisicaId;
            ClientePessoaJuridicaId = pessoaJuridicaId;
            Ativo = true;
            Principal = false;
            TelefonesTiposId = tipo;
            PotenciaisClientesId = potenciaisClientesId;
        }
    }
}
