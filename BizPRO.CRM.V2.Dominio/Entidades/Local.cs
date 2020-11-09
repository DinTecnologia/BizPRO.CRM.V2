using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Local
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string nomeContato { get; set; }
        public int locaisTiposID { get; set; }
        public string criadoPorUserID { get; set; }
        public DateTime criadoEm { get; set; }
        public string alteradoPorUserID { get; set; }
        public DateTime? alteradoEm { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public int cidadesID { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public string telefone01 { get; set; }
        public string telefone02 { get; set; }
        public string telefone03 { get; set; }
        public string email01 { get; set; }
        public string email02 { get; set; }
        public string webSite { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        public LocalTipo LocalTipo { get; set; }
        public OcorrenciaLocalTipoAtendimento LocalOcorrencia { get; set; }
        public string Detalhe { get; set; }

        public string estado { get; set; }
        public string cidade { get; set; }
        public double? distancia { get; set; }

        public Local()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
