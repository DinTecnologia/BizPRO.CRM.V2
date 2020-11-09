using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class statusEntidadeViewModal
    {
        public long id { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
        public string entidadesValidas { get; set; }
        public bool padrao { get; set; }
        public bool finalizador { get; set; }
        public  IEnumerable<StatusEntidade> statusEntidade { get; set; }

        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public statusEntidadeViewModal()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

        public statusEntidadeViewModal
        (
              long id
            , string nome
            , bool ativo
            , string entidadesValidas
            , bool padrao
            , bool finalizador
        )
        {
            this.id = id;
            this.nome = nome;
            this.ativo = ativo;
            this.entidadesValidas = entidadesValidas;
            this.padrao = padrao;
            this.finalizador = finalizador;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }
}
