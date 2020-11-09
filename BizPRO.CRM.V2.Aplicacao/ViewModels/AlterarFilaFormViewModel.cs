using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AlterarFilaFormViewModel
    {
        public string AtividadesId { get; set; }
        public long? UltimaFilaId { get; set; }
        public string UltimaFilaNome { get; set; }
        public long? NovaFilaId { get; set; }
        public SelectList Filas { get; set; }
        public string AlteradoPorUsuarioId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public AlterarFilaFormViewModel()
        {
            Filas = new SelectList(new List<Fila>(), "id", "nome");
            ValidationResult = new ValidationResult();
        }

        public AlterarFilaFormViewModel(string atividadeId, Fila ultimaFila, SelectList filas)
        {
            AtividadesId = atividadeId;
            UltimaFilaNome = "--";
            Filas = filas;
            ValidationResult = new ValidationResult();

            if (ultimaFila == null) return;
            if (ultimaFila.Id <= 0) return;
            UltimaFilaId = ultimaFila.Id;
            UltimaFilaNome = ultimaFila.Nome;
        }
    }
}
