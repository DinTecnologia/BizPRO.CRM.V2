using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class StatusEntidadeAlterarViewModel
    {
        public long? StatusEntidadeId { get; set; }
        public long? OcorrenciaId { get; set; }
        public StatusEntidade StatusEntidade { get; set; }
        public IEnumerable<StatusEntidade> ListaStatusEntidade { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public StatusEntidadeAlterarViewModel()
        {
            ValidationResult = new ValidationResult();
        }
        public StatusEntidadeAlterarViewModel(StatusEntidade statusEntidade, IEnumerable<StatusEntidade> listaStatusEntidade, long? ocorrenciId)
        {
            if (statusEntidade != null)
            {
                StatusEntidadeId = statusEntidade.id;
                StatusEntidade = statusEntidade;
            }
            ListaStatusEntidade = listaStatusEntidade;
            OcorrenciaId = ocorrenciId;
            ValidationResult = new ValidationResult();
        }
    }
}
