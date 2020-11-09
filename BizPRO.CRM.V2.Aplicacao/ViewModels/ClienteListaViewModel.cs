using System;
using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ClienteListaViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string TipoCliente { get; set; }
        public bool EntidadeIntegracao { get; set; }
        public long? IdentificadorIntegracao { get; set; }
        public string Documento { get; set; }
        public string RegistroDe { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? DataNascimento { get; set; }

        public string TipoClienteDisplay
        {
            get { return TipoCliente == "PF" ? "Pessoa Física" : "Pessoa Jurídica"; }
        }

        public ClienteListaViewModel()
        {

        }

        public ClienteListaViewModel(long id, string nome, string tipoCliente, string documento,
            DateTime? dataNascimento, long? identificadorIntegracao, bool registroJaIntegrado,
            bool entidadeIntegracao = false)
        {
            Id = id;
            Nome = nome;
            TipoCliente = tipoCliente;
            Documento = documento;
            DataNascimento = dataNascimento;
            IdentificadorIntegracao = identificadorIntegracao;
            EntidadeIntegracao = entidadeIntegracao;
            RegistroDe = registroJaIntegrado ? "C | I" : (entidadeIntegracao ? "I" : "C");
        }
    }
}
