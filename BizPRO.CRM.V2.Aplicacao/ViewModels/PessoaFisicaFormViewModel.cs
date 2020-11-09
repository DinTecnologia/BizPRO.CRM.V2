using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Entidades;
using ValidationResult = DomainValidation.Validation.ValidationResult;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class PessoaFisicaFormViewModel
    {
        public long? Id { get; set; }
        public int? TipoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        //[MinLength(4, ErrorMessage = "Mínimo 4 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        //[MinLength(4, ErrorMessage = "Mínimo 4 caracteres")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(14, ErrorMessage = "Máximo 11 caracteres")]
        [MinLength(11, ErrorMessage = "Mínimo 11 caracteres")]
        public string Cpf { get; set; }

        public bool CpfProprio { get; set; }

        public string OutroDocumento { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo 15 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo 3 caracteres")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime, ErrorMessage = "Data informada inválida.")]
        public DateTime? DataNascimento { get; set; }

        public string CriadoPor { get; set; }
        public string CodigoPostal { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public int? CidadesId { get; set; }
        public long? UfId { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public string AlteradoPorUserId { get; set; }
        public string Complemento { get; set; }
        public string NomeEstado { get; set; }
        public IEnumerable<Cidade> ListaCidade { get; set; }
        public IEnumerable<Cidade> ListaUf { get; set; }
        public CidadeViewModel Cidade { get; set; }
        public IEnumerable<TelefoneListaViewModel> ListaTelefone { get; set; }
        public OcorrenciaFormViewModel Ocorrencia { get; set; }
        public IEnumerable<TelefoneListaViewModel> TelefoneLista { get; set; }
        public bool Atender { get; set; }

        public IEnumerable<ContratosIntegracaoViewModel> ListaContratos { get; set; }

        [EmailAddress(ErrorMessage = "O e-mail informado não esta em um formato válido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public DateTime? CriadoEm { get; set; }
        public string NumeroTelefone { get; set; }

        public CampoDinamicoViewModel ViewDinamica { get; set; }
        public long? AtendimentoId { get; set; }
        public bool? AceitaComunicados { get; set; }
        public long? CanalEntidadesCamposValoresId { get; set; }
        public SelectList CanaisEntidadesCamposValores { get; set; }
        public long? TipoEntidadesCamposValoresId { get; set; }
        public SelectList TiposEntidadesCamposValores { get; set; }
        public long? IdentificadorIntegracao { get; set; }

        [ScaffoldColumn(false)]
        public ValidationResult ValidationResult { get; set; }

        public PessoaFisicaFormViewModel()
        {
            ValidationResult = new ValidationResult();
            ListaUf = new List<Cidade>();
            ListaCidade = new List<Cidade>();
            ListaTelefone = new List<TelefoneListaViewModel>();
            ViewDinamica = new CampoDinamicoViewModel();
            ListaContratos = new List<ContratosIntegracaoViewModel>();
        }

        public PessoaFisicaFormViewModel(string nome, string sobrenome, string cpf, bool cpfProprio,
            DateTime? dataNascimento, string criadoPor, ValidationResult validacaoResultado, long? id,
            bool? aceitaComunicados, long? canalEntidadesCamposValoresId, long? tipoEntidadesCamposValoresId)
        {
            ValidationResult = new ValidationResult();

            ValidationResult = validacaoResultado;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            CriadoPor = criadoPor;
            Id = id;
            AceitaComunicados = aceitaComunicados;
            CanalEntidadesCamposValoresId = canalEntidadesCamposValoresId;
            TipoEntidadesCamposValoresId = tipoEntidadesCamposValoresId;
        }

        public PessoaFisicaFormViewModel(IEnumerable<Cidade> listaUf, bool atender,
            CampoDinamicoViewModel viewDinamicaModel, IEnumerable<EntidadeCampoValor> listaCanaisEntidadesCamposValores,
            IEnumerable<EntidadeCampoValor> listaTiposEntidadesCamposValores)
        {
            ValidationResult = new ValidationResult();
            ListaUf = listaUf;
            ListaCidade = new List<Cidade>();
            var Lista = new List<TelefoneListaViewModel>();
            Lista.Add(new TelefoneListaViewModel());
            ListaTelefone = Lista;
            Atender = atender;
            ViewDinamica = viewDinamicaModel;
            CanaisEntidadesCamposValores = new SelectList(listaCanaisEntidadesCamposValores, "id", "valor");
            TiposEntidadesCamposValores = new SelectList(listaTiposEntidadesCamposValores, "id", "valor");
        }

        public PessoaFisicaFormViewModel(long id, string nome, string sobrenome, string cpf, bool cpfProprio,
            DateTime? dataNascimento, IEnumerable<Cidade> listaUf, string nomeEstado, int? cidadeId,
            IEnumerable<Cidade> listaCidade,
            string email, string logradouro, string numero, string bairro, string codigoPostal, string complemento,
            string telefone, CampoDinamicoViewModel viewDinamicaModel)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Id = id;
            ListaUf = listaUf;
            ListaCidade = listaCidade;
            NomeEstado = nomeEstado;
            CidadesId = cidadeId;
            CpfProprio = cpfProprio;
            Email = email;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CodigoPostal = codigoPostal;
            Complemento = complemento;
            NumeroTelefone = telefone;
            ViewDinamica = viewDinamicaModel;
            ValidationResult = new ValidationResult();
        }

        public PessoaFisicaFormViewModel(string nome, string sobrenome, string email, string cpf, bool cpfProprio,
            DateTime? dataNascimento, long? id)
        {
            ValidationResult = new ValidationResult();
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Id = id;
            Email = email;

        }

        public PessoaFisicaFormViewModel(string nome, string cpf, string criadoPor, string logradouro, string numero,
            string bairro, int? cidadesId, string codigoPostal, string email,
            IEnumerable<TelefoneListaViewModel> listaTelefone)
        {
            Nome = nome;
            Cpf = cpf;
            CriadoPor = criadoPor;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CidadesId = cidadesId;
            CodigoPostal = codigoPostal;
            Email = email;
            TelefoneLista = listaTelefone;
            ValidationResult = new ValidationResult();
        }

        public PessoaFisicaFormViewModel(long id, string nome, string sobrenome, string cpf, string logradouro,
            string numero, string bairro, int? cidadesId, string codigoPostal, string email, CidadeViewModel cidade)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CidadesId = cidadesId;
            CodigoPostal = codigoPostal;
            Email = email;
            TelefoneLista = ListaTelefone;
            Cidade = cidade;
            ValidationResult = new ValidationResult();
        }

        public PessoaFisicaFormViewModel(long id, string nome, string sobrenome, string cpf, bool cpfProprio,
            DateTime? dataNascimento, IEnumerable<Cidade> listaUf, string nomeEstado, int? cidadeId,
            IEnumerable<Cidade> listaCidade,
            string email, string logradouro, string numero, string bairro, string codigoPostal, string complemento,
            string telefone, CampoDinamicoViewModel viewDinamicaModel, CidadeViewModel cidade, DateTime? criadoEm,
            DateTime? alteradoEm, IEnumerable<EntidadeCampoValor> listaCanaisEntidadesCamposValores,
            IEnumerable<EntidadeCampoValor> listaTiposEntidadesCamposValores, bool? aceitaComunicados,
            long? canalEntidadesCamposValoresId, long? tipoEntidadesCamposValoresId)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Id = id;
            ListaUf = listaUf;
            ListaCidade = listaCidade;
            NomeEstado = nomeEstado;
            CidadesId = cidadeId;
            CpfProprio = cpfProprio;
            Email = email;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CodigoPostal = codigoPostal;
            Complemento = complemento;
            NumeroTelefone = telefone;
            ViewDinamica = viewDinamicaModel;
            Cidade = cidade;
            CriadoEm = criadoEm;
            AlteradoEm = alteradoEm ?? criadoEm;
            ValidationResult = new ValidationResult();
            CanaisEntidadesCamposValores = new SelectList(listaCanaisEntidadesCamposValores, "id", "valor");
            TiposEntidadesCamposValores = new SelectList(listaTiposEntidadesCamposValores, "id", "valor");
            AceitaComunicados = aceitaComunicados;
            CanalEntidadesCamposValoresId = canalEntidadesCamposValoresId;
            TipoEntidadesCamposValoresId = tipoEntidadesCamposValoresId;
        }
    }
}
