using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class PotenciaisClienteViewModel
    {
        public long? id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo 4 caracteres")]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        public string tipo { get; set; }
        //[Required(ErrorMessage = "Preencha o campo Documento")]
        //[MaxLength(18, ErrorMessage = "Máximo 18 caracteres")]
        //[MinLength(11, ErrorMessage = "Mínimo 11 caracteres")]
        public string documento { get; set; }
        [Required(ErrorMessage = "Preencha o campo Contato")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo 4 caracteres")]
        public string contato { get; set; }
        public string contatoDocumento { get; set; }
        [EmailAddress(ErrorMessage = "O e-mail informado não esta em um formato válido.")]
        [Display(Name = "E-mail")]
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
        public CidadeViewModel CidadeViewModel { get; set; }
        public string estado { get; set; }
        //public ViewDinamicaViewModel ViewDinamica { get; set; }
        public CampoDinamicoViewModel ViewDinamica { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public DateTime? convertidoEmClienteEm { get; set; }
        public string convertidoEmClientePorAspNetUserID { get; set; }
        public long? convertidoEmClientePessoasFisicasID { get; set; }
        public long? convertidoEmClientePessoasJuridicasID { get; set; }

        public PotenciaisClienteViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            this.ListaUF = new List<CidadeViewModel>();
            this.ListaCidade = new List<CidadeViewModel>();
            this.TelefoneLista = new List<TelefoneListaViewModel>();
        }



        public PotenciaisClienteViewModel
        (
              long id
            , string nome
            , string documento
            , string contato
            , string contatoDocumento
            , string email
            , string logradouro
            , string numero
            , string bairro
            , int? CidadesID
            , string criadoPorAspNetUserID
            , string tipo
            , string cep
            , string contatoEmail
            , DateTime criadoEm
            , DateTime? alteradoEm
            , List<CidadeViewModel> listaUF
            , List<CidadeViewModel> ListaCidade
            , CidadeViewModel CidadeViewModel
            , List<TelefoneListaViewModel> TelefoneLista
            , string estado
            , CampoDinamicoViewModel ViewDinamica 
        )
        {
            this.id = id;
            this.nome = nome;
            this.documento = documento;
            this.contato = contato;
            this.contatoDocumento = contatoDocumento;
            this.email = email;
            this.logradouro = logradouro;
            this.numero = numero;
            this.bairro = bairro;
            this.CidadesID = CidadesID;
            this.criadoPorAspNetUserID = criadoPorAspNetUserID;
            this.tipo = tipo;
            this.cep = cep;
            this.contatoEmail = contatoEmail;
            this.criadoEm = criadoEm;
            this.alteradoEm = alteradoEm;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            this.ListaUF = listaUF;
            this.ListaCidade = ListaCidade;
            if (CidadeViewModel.id != 0)
                this.CidadeViewModel = CidadeViewModel;
            this.TelefoneLista = TelefoneLista;
            this.ViewDinamica = ViewDinamica;

        }
    }
}
