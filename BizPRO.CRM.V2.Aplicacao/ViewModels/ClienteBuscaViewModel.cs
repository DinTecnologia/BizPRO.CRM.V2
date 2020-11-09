using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ClienteBuscaViewModel
    {
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo 4 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo 14 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo 3 caracteres")]
        [Display(Name = "Documento")]
        public string Documento { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo 15 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo 3 caracteres")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo 15 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo 3 caracteres")]
        [Display(Name = "Número Protocolo")]
        public string NumeroProtocolo { get; set; }

        public IEnumerable<ClienteListaViewModel> ListaPesquisaCliente { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public long? AtividadeId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public bool CarregarComPost { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool? ClienteContato { get; set; }
        public long? AtualClienteId { get; set; }
        public string AtualClienteTipo { get; set; }
        public string Susep { get; set; }
        public string CriadoPor { get; set; }

        public ClienteBuscaViewModel()
        {
            List<ClienteListaViewModel> teste = new List<ClienteListaViewModel>();
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

        public ClienteBuscaViewModel(string nome, string documento, string telefone, IEnumerable<Cliente> listaCliente)
        {
            Nome = nome;
            Documento = documento;
            Telefone = telefone;
            var minhaLista = new List<ClienteListaViewModel>();

            if (listaCliente != null)
                minhaLista.AddRange(
                    listaCliente.Select(
                        cliente =>
                            new ClienteListaViewModel(cliente.Id, cliente.Nome, cliente.TipoCliente, cliente.Documento,
                                cliente.DataNascimento, cliente.IdentificadorIntegracao, cliente.RegistroJaIntegradao,
                                cliente.EntidadeIntegracao)));

            ListaPesquisaCliente = minhaLista;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            ClienteContato = null;
        }
    }
}
