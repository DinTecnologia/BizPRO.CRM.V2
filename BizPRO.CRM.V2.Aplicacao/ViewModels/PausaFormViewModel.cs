using System;
using System.Web.Mvc;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class PausaFormViewModel
    {
        public string UsuarioId { get; set; }
        public string CanalIds { get; set; }
        public SelectList Motivos { get; set; }
        public int? MotivoId { get; set; }
        public string UsuarioAcaoId { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public List<PausaViewModel> Pausas { get; set; }
        public long? PausaId { get; set; }

        public PausaFormViewModel()
        {
            ValidationResult = new ValidationResult();
            Pausas = new List<PausaViewModel>();
        }
    }


    public class PausaViewModel
    {
        public long Id { get; set; }
        public DateTime IniciadoEm { get; set; }
        public string Motivo { get; set; }
        public string Canal { get; set; }


        public PausaViewModel(long id, DateTime iniciadoEm, string motivo, string canal)
        {
            Id = id;
            IniciadoEm = iniciadoEm;
            Motivo = motivo;
            Canal = canal;
        }
    }
}
