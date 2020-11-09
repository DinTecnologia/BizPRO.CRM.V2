using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class CampoDinamicoBuscaViewModel
    {
        public long? OcorrenciaId { get; set; }
        public string ComponenteId { get; set; }
        public string NomeCliente { get; set; }
        public string Protocolo { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public ICollection<ItemOcorrenciaOriginalViewModel> Items { get; set; }
        public string NomeOcorrenciaOriginal { get; set; }

        public CampoDinamicoBuscaViewModel()
        {
            Items = new List<ItemOcorrenciaOriginalViewModel>();
        }

        public bool PossuiParametroPesquisa()
        {
            var retorno = !string.IsNullOrEmpty(NomeCliente) || !string.IsNullOrEmpty(Protocolo) ||
                          PessoaFisicaId.HasValue || PessoaJuridicaId.HasValue;
            return retorno;
        }
    }

    public class ItemOcorrenciaOriginalViewModel
    {
        public long Id { get; set; }
        public string Protocolo { get; set; }
        public string OcorrenciaTipo { get; set; }
        public string Cliente { get; set; }
        public string Descritivo { get; set; }
        public string CriadoEm { get; set; }
        public string Status { get; set; }
        public string ComponenteId { get; set; }

        public ItemOcorrenciaOriginalViewModel(Ocorrencia entidade, string componenteId)
        {
            Id = entidade.Id;
            OcorrenciaTipo = entidade.OcorrenciaTipo != null ? entidade.OcorrenciaTipo.NomeExibicao ?? "--" : "--";
            Cliente = entidade.PessoaFisica != null ? entidade.PessoaFisica.Nome.ToUpper() : "--";
            Descritivo = entidade.DecritivoDeAbertura;
            CriadoEm = entidade.CriadoEm.ToString("dd/MM/yyyy HH:mm");
            Status = entidade.StatusEntidade != null ? entidade.StatusEntidade.nome.ToUpper() : "--";
            Protocolo = entidade.Atendimento != null ? entidade.Atendimento.Protocolo : "--";
            ComponenteId = componenteId;
        }
    }
}
