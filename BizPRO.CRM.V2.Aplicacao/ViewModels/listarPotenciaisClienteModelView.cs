using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class listarPotenciaisClienteViewModel
    {

        public long id { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public string documento { get; set; }
        public string contato { get; set; }
        public string contatoDocumento { get; set; }
        public string email { get; set; }
        public string contatoEmail { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public int? CidadesID { get; set; }
        public string responsavelPorAspNetUserID { get; set; }
        public DateTime responsavelDesde { get; set; }
        public string criadoPorAspNetUserID { get; set; }
        public DateTime criadoEm { get; set; }
        public string alteradoPorAspNetUserID { get; set; }
        public DateTime? alteradoEm { get; set; }
        public IEnumerable<CidadeViewModel> ListaCidade { get; set; }
        public IEnumerable<CidadeViewModel> ListaUF { get; set; }
        public IEnumerable<TelefoneListaViewModel> TelefoneLista { get; set; }

        public listarPotenciaisClienteViewModel(long id, string nome, string documento, DateTime criadoEm, string tipo, string email )
        {
            this.id = id;
            this.nome = nome;
            this.documento = documento;
            this.criadoEm = criadoEm;
            this.tipo = tipo;
            this.email = email;
        }
    }
}
