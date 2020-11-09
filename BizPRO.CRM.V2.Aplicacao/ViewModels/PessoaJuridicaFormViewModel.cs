using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Entidades;
using ValidationResult = DomainValidation.Validation.ValidationResult;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class PessoaJuridicaFormViewModel
    {
        public long? Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome Fantasia")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(18, ErrorMessage = "Máximo 18 caracteres")]
        [MinLength(18, ErrorMessage = "Mínimo 18 caracteres")]
        public string Cnpj { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime, ErrorMessage = "Data informada inválida.")]
        public DateTime? DataDeConstituicao { get; set; }

        [Display(Name = "Email")]
        public string EmailPrincipal { get; set; }

        public string CriadoPor { get; set; }
        public DateTime? CriadoEm { get; set; }

        [Display(Name = "CEP")]
        public string CodigoPostal { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        public int? CidadesId { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public string AlteradoPorUserId { get; set; }
        public string NomeEstado { get; set; }
        public IEnumerable<Cidade> ListaCidade { get; set; }
        public IEnumerable<Cidade> ListaUf { get; set; }
        public string Complemento { get; set; }
        public string NumeroTelefone { get; set; }
        public OcorrenciaFormViewModel Ocorrencia { get; set; }
        public IEnumerable<PessoaJuridica> ListarPessoaJuridicas { get; set; }
        public bool Atender { get; set; }
        public long? UfId { get; set; }
        public IEnumerable<TelefoneListaViewModel> TelefoneLista { get; set; }
        public CidadeViewModel Cidade { get; set; }
        public long? AtendimentoId { get; set; }
        public CampoDinamicoViewModel ViewDinamica { get; set; }
        public bool? AceitaComunicados { get; set; }
        public long? CanalEntidadesCamposValoresId { get; set; }
        public SelectList CanaisEntidadesCamposValores { get; set; }
        public long? TipoEntidadesCamposValoresId { get; set; }
        public SelectList TiposEntidadesCamposValores { get; set; }
        public long? IdentificadorIntegracao { get; set; }
        public IEnumerable<TelefoneListaViewModel> ListaTelefone { get; set; }


        [ScaffoldColumn(false)]
        public ValidationResult ValidationResult { get; set; }

        public PessoaJuridicaFormViewModel()
        {
            ValidationResult = new ValidationResult();
            ListaUf = new List<Cidade>();
            ListaCidade = new List<Cidade>();
            ViewDinamica = new CampoDinamicoViewModel();
            ListaTelefone = new List<TelefoneListaViewModel>();
        }

        public PessoaJuridicaFormViewModel(string razaoSocial, string nomeFantasia, string cnpj,
            string inscricaoEstadual, DateTime? datadeConstituicao, string criadoPor, string emailPrincipal,
            ValidationResult validacaoResultado, long pessoaJuridicaId, bool? aceitaComunicados,
            long? canalEntidadesCamposValoresId, long? tipoEntidadesCamposValoresId)
        {
            ValidationResult = new ValidationResult();
            ValidationResult = validacaoResultado;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            DataDeConstituicao = datadeConstituicao;
            CriadoPor = criadoPor;
            EmailPrincipal = emailPrincipal;
            Id = pessoaJuridicaId;
            AceitaComunicados = aceitaComunicados;
            CanalEntidadesCamposValoresId = canalEntidadesCamposValoresId;
            TipoEntidadesCamposValoresId = tipoEntidadesCamposValoresId;
        }

        public PessoaJuridicaFormViewModel(IEnumerable<Cidade> listaUf, bool atender,
            CampoDinamicoViewModel viewDinamicaModel, IEnumerable<EntidadeCampoValor> listaCanaisEntidadesCamposValores,
            IEnumerable<EntidadeCampoValor> listaTiposEntidadesCamposValores)
        {
            ValidationResult = new ValidationResult();
            ListaUf = listaUf;
            ListaCidade = new List<Cidade>();
            Atender = atender;
            ViewDinamica = viewDinamicaModel;
            CanaisEntidadesCamposValores = new SelectList(listaCanaisEntidadesCamposValores, "id", "valor");
            TiposEntidadesCamposValores = new SelectList(listaTiposEntidadesCamposValores, "id", "valor");
        }

        public PessoaJuridicaFormViewModel(long id, string razaoSocial, string nomeFantasia, string inscricaoEstadual,
            string cnpj, DateTime? dataDeConstituicao, IEnumerable<Cidade> listaUf, string nomeEstado, int? cidadeId,
            IEnumerable<Cidade> listaCidade,
            string email, string logradouro, string numero, string bairro, string codigoPostal, string complemento,
            string telefone, CampoDinamicoViewModel viewDinamicaModel, CidadeViewModel Cidade, DateTime? criadoEm,
            DateTime? alteradoEm, IEnumerable<EntidadeCampoValor> listaCanaisEntidadesCamposValores,
            IEnumerable<EntidadeCampoValor> listaTiposEntidadesCamposValores, bool? aceitaComunicados,
            long? canalEntidadesCamposValoresId, long? tipoEntidadesCamposValoresId)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            InscricaoEstadual = inscricaoEstadual;
            Cnpj = cnpj;
            DataDeConstituicao = dataDeConstituicao;
            Id = id;
            ListaUf = listaUf;
            ListaCidade = listaCidade;
            NomeEstado = nomeEstado;
            CidadesId = cidadeId;
            EmailPrincipal = email;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CodigoPostal = codigoPostal;
            Complemento = complemento;
            NomeFantasia = nomeFantasia;
            NumeroTelefone = telefone;
            this.Cidade = Cidade;
            CriadoEm = criadoEm;
            AlteradoEm = alteradoEm ?? criadoEm;
            ViewDinamica = viewDinamicaModel;
            CanaisEntidadesCamposValores = new SelectList(listaCanaisEntidadesCamposValores, "id", "valor");
            TiposEntidadesCamposValores = new SelectList(listaTiposEntidadesCamposValores, "id", "valor");
            ValidationResult = new ValidationResult();
            AceitaComunicados = aceitaComunicados;
            CanalEntidadesCamposValoresId = canalEntidadesCamposValoresId;
            TipoEntidadesCamposValoresId = tipoEntidadesCamposValoresId;
        }

        public PessoaJuridicaFormViewModel(string razaoSocial, string nomeFantasia, string cnpj,
            DateTime? dataDeConstituicao, string inscricaoEstadual, long id)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            InscricaoEstadual = inscricaoEstadual;
            Cnpj = cnpj;
            DataDeConstituicao = dataDeConstituicao;
            NomeFantasia = nomeFantasia;
            ValidationResult = new ValidationResult();
        }

        public PessoaJuridicaFormViewModel(string razaoSocial, string cnpj, string criadoPor, string logradouro,
            string numero, string bairro, int? cidadesId, string codigoPostal, string email,
            IEnumerable<TelefoneListaViewModel> listaTelefone)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = razaoSocial;
            Cnpj = cnpj;
            CriadoPor = criadoPor;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CidadesId = cidadesId;
            CodigoPostal = codigoPostal;
            EmailPrincipal = email;
            TelefoneLista = listaTelefone;
            ValidationResult = new ValidationResult();
        }
    }
}
