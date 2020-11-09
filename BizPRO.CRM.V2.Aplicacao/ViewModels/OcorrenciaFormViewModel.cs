using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BizPRO.CRM.V2.Dominio.Entidades;
using ValidationResult = DomainValidation.Validation.ValidationResult;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class OcorrenciaFormViewModel
    {
        [Key]
        public long? OcorrenciaID { get; set; }

        [Required(ErrorMessage = "Selecione o Tipo Ocorrência")]
        public long? ocorrenciasTiposID { get; set; }

        [MaxLength(4000, ErrorMessage = "Máximo 4000 caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo 10 caracteres")]
        [Required(ErrorMessage = "Preencha o campo Descritivo")]
        [Display(Name = "Descritivo")]
        public string decritivoDeAbertura { get; set; }

        [ScaffoldColumn(false)]
        public DateTime criadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? atualizadoEm { get; set; }

        [ScaffoldColumn(false)]
        public string criadoPorUserID { get; set; }

        [ScaffoldColumn(false)]
        public long? pessoaFisicaID { get; set; }

        [ScaffoldColumn(false)]
        public long? pessoaJuridicaID { get; set; }

        [Display(Name = "Contrato")]
        public long? contratoID { get; set; }

        [ScaffoldColumn(false)]
        public long? statusEntidadeID { get; set; }

        [ScaffoldColumn(false)]
        public long? atendimentoID { get; set; }

        [ScaffoldColumn(false)]
        public string nomeResponsavel { get; set; }

        public bool Vincularlocal { get; set; }
        public StatusEntidade StatusEntidade { get; set; }
        public IEnumerable<OcorrenciaListaItemViewModel> ListaOcorrenciaCliente { get; set; }
        public IEnumerable<Contrato> ListaContrato { get; set; }
        public IEnumerable<OcorrenciaTipo> ListaOcorrenciaTipo { get; set; }
        public ClientePerfilViewModel Cliente { get; set; }
        public OcorrenciaTiposXOcorrencia OcorrenciaTiposXOcorrencia { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }

        [ScaffoldColumn(false)]
        public ValidationResult ValidationResult { get; set; }

        public IEnumerable<OcorrenciaTipoDdlViewModel> DDLsOcorrenciaTipo { get; set; }
        public OcorrenciaEnderecoProdutoViewModel EnderecoProduto { get; set; }
        public string atualizadoPorAspNetUserID { get; set; }
        public IEnumerable<OcorrenciaTipoViewModel> ListarOcorrenciaTipo { get; set; }
        public CampoDinamicoViewModel ViewDinamica { get; set; }
        public LocalViewModel Local { get; set; }
        public bool LocalAtualizado { get; set; }
        public string NumeroProtocolo { get; set; }
        public bool LocalExcluido { get; set; }
        public string NomeExibicaoOcorrenciaTipo { get; set; }
        //public bool PodeEditar { get; set; }
        public string Responsavel { get; set; }
        public string UsuarioFinalizador { get; set; }
        public bool UsuarioResponsavel { get; set; }
        public bool OcorrenciaFinalizada { get; set; }
        // Essa propiedade será utilizada quando criarmos a estrutura de vínculo por Departamento.
        public bool OcorrenciaMesmoDepartamento { get; set; }
        public bool AtrasadoAtendimento { get; set; }
        public DateTime? Previsao { get; set; }

        public bool MostrarCampoChave1 { get; set; }
        public bool PermitirEdicaoCampoChave1 { get; set; }
        public string CampoChave1 { get; set; }
        public string NomeCampoChave1 { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public bool CarregadaEmIframe { get; set; }


        public OcorrenciaFormViewModel()
        {
            ValidationResult = new ValidationResult();
            ListaOcorrenciaTipo = new List<OcorrenciaTipo>();
            ListaContrato = new List<Contrato>();
            StatusEntidade = new StatusEntidade();
            ViewDinamica = new CampoDinamicoViewModel();
            StatusEntidade = new StatusEntidade();
            Responsavel = "--";
            MostrarCampoChave1 = !string.IsNullOrEmpty(NomeCampoChave1);
        }

        public OcorrenciaFormViewModel(IEnumerable<OcorrenciaTipo> listaOcorrenciaTipo,
            IEnumerable<Contrato> listaContrato, long? pessoaFisicaId, long? pessoaJuridicaId,
            StatusEntidade statusEntidade, long? atendimentoId,
            IEnumerable<OcorrenciaTipoDdlViewModel> ddLsOcorrenciaTipo, string nomeReponsavel,
            CampoDinamicoViewModel viewDinamicaModel, DateTime? previsao, string campoChave1, string nomeCampoChave1,
            bool permitirEdicaoCampoChave1, long? contratoId)
        {
            ListaOcorrenciaTipo = listaOcorrenciaTipo;
            ListaContrato = listaContrato;
            ValidationResult = new ValidationResult();
            pessoaFisicaID = pessoaFisicaId;
            pessoaJuridicaID = pessoaJuridicaId;
            StatusEntidade = statusEntidade;
            atendimentoID = atendimentoId;
            DDLsOcorrenciaTipo = ddLsOcorrenciaTipo;
            criadoEm = DateTime.Now;
            StatusEntidade = new StatusEntidade();
            StatusEntidade.nome = "Nova";
            ViewDinamica = viewDinamicaModel;
            OcorrenciaTiposXOcorrencia = new OcorrenciaTiposXOcorrencia();
            Responsavel = "--";
            Previsao = previsao;
            NomeCampoChave1 = nomeCampoChave1;
            CampoChave1 = campoChave1;
            MostrarCampoChave1 = !string.IsNullOrEmpty(NomeCampoChave1);
            PermitirEdicaoCampoChave1 = permitirEdicaoCampoChave1;
            contratoID = contratoId;
        }

        public OcorrenciaFormViewModel(IEnumerable<OcorrenciaTipo> listaOcorrenciaTipo,
            IEnumerable<Contrato> listaContrato, Ocorrencia ocorrencia, IEnumerable<Anotacao> listaAnotacao,
            StatusEntidade statusEntidade, long? atendimentoId,
            IEnumerable<OcorrenciaTipoDdlViewModel> ddLsOcorrenciaTipo, string nomeReponsavel, bool vincularLocal,
            CampoDinamicoViewModel viewDinamicaModel, bool podeEditar, DateTime? previsao, string campoChave1,
            string nomeCampoChave1, bool permitirEdicaoCampoChave1, string usuarioFinalizador)
        {
            ListaOcorrenciaTipo = listaOcorrenciaTipo;
            ListaContrato = listaContrato;
            ValidationResult = new ValidationResult();
            pessoaFisicaID = ocorrencia.PessoaFisicaId;
            pessoaJuridicaID = ocorrencia.PessoaJuridicaId;
            decritivoDeAbertura = ocorrencia.DecritivoDeAbertura;
            ocorrenciasTiposID = ocorrencia.OcorrenciasTiposId;
            contratoID = ocorrencia.ContratoId;
            statusEntidadeID = ocorrencia.StatusEntidadesId;
            OcorrenciaID = ocorrencia.Id;
            StatusEntidade = statusEntidade;
            DDLsOcorrenciaTipo = ddLsOcorrenciaTipo;
            nomeResponsavel = nomeReponsavel;
            criadoEm = ocorrencia.CriadoEm;
            Vincularlocal = vincularLocal;
            atualizadoEm = ocorrencia.AtualizadoEm;
            ViewDinamica = viewDinamicaModel;
            OcorrenciaTiposXOcorrencia = new OcorrenciaTiposXOcorrencia();
            NomeExibicaoOcorrenciaTipo = ocorrencia.OcorrenciaTipo.ToString();
            atendimentoID = atendimentoId;
            UsuarioResponsavel = podeEditar;
            Responsavel = "--";
            Previsao = previsao;
            FinalizadoEm =  ocorrencia.FinalizadoEm;
            UsuarioFinalizador = usuarioFinalizador;

            if (statusEntidade != null)
                OcorrenciaFinalizada = statusEntidade.finalizador;

            if (ocorrencia.Responsavel != null)
                if (!string.IsNullOrEmpty(ocorrencia.Responsavel.Nome))
                    Responsavel = ocorrencia.Responsavel.Nome;

            

            NomeCampoChave1 = nomeCampoChave1;
            CampoChave1 = campoChave1;
            MostrarCampoChave1 = !string.IsNullOrEmpty(NomeCampoChave1);
            PermitirEdicaoCampoChave1 = permitirEdicaoCampoChave1;
        }
    }

    public class OcorrenciaDetalheViewModel
    {
        public long? ocorrenciaID { get; set; }
        public string nomeOcorrenciaTipo { get; set; }
        public string criadoEm { get; set; }
        public string finalizadoEm { get; set; }
        public string criadoPor { get; set; }
        public string finalizadoPor { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public OcorrenciaDetalheViewModel()
        {
            ValidationResult = new ValidationResult();
            nomeOcorrenciaTipo = "Não Identificado";
        }

        public void Popular(DateTime criadoEm, string criadoPor, DateTime? finalizadoEm, string finalizadoPor,
            string nomeOcorrenciaTipo, long? ocorrenciaID)
        {
            this.nomeOcorrenciaTipo = string.IsNullOrEmpty(nomeOcorrenciaTipo) ? "Não Classificado" : nomeOcorrenciaTipo;
            this.criadoPor = string.IsNullOrEmpty(criadoPor) ? "Não Identificado" : criadoPor;
            this.finalizadoPor = string.IsNullOrEmpty(finalizadoPor) ? "" : finalizadoPor;
            this.finalizadoEm = finalizadoEm.HasValue ? finalizadoEm.Value.ToString("dd/MM/yyyy HH:mm") : "";
            this.criadoEm = criadoEm != null ? criadoEm.ToString("dd/MM/yyyy HH:mm") : "";
            this.ocorrenciaID = ocorrenciaID;
        }
    }
}
