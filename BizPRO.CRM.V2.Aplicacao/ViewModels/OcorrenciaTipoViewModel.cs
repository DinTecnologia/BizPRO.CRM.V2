using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Entidades;
using ValidationResult = DomainValidation.Validation.ValidationResult;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class OcorrenciaTipoViewModel
    {
        public long id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string nome { get; set; }

        public long? OcorrenciasTiposPaiID { get; set; }
        public DateTime criadoEm { get; set; }
        public string criadoPorUserID { get; set; }
        public string nomeExibicao { get; set; }
        public bool ativo { get; set; }
        public string estruturaDeIDs { get; set; }
        public bool vincularLocal { get; set; }
        public string TempoPrevistoAtendimentoPorExtenso { get; set; }
        public string Previsao { get; set; }

        [Required(ErrorMessage = "Preencha o campo SLA")]
        public int tempoPrevistoAtendimento { get; set; }

        public UsuarioRegisterViewModel Usuario { get; set; }
        public IEnumerable<OcorrenciaTipoDdlViewModel> ListaOcorrenciaTipoDDLViewModel { get; set; }

        [ScaffoldColumn(false)]
        public ValidationResult ValidationResult { get; set; }

        public bool atrasadoAtendimento { get; set; }

        public int SlaPadrao
        {
            get
            {
                if (tempoPrevistoAtendimento <= 0) return 0;
                var tp = new TimeSpan(0, tempoPrevistoAtendimento, 0);
                return tp.Days;
            }
        }

        public DateTime? DataPrevisao { get; set; }
        public SelectList StatusEntidades { get; set; }
        public string DescricaoPadrao { get; set; }
        public SelectList OcorrenciaTipoFilhos { get; set; }

        public bool EhUltimoNivel { get; set; }

        public OcorrenciaTipoViewModel(long id, string nome, long? ocorrenciasTiposPaiId, DateTime criadoEm,
            string nomeExibicao, bool ativo, bool atrasadoAtendimento)
        {
            ValidationResult = new ValidationResult();
            this.id = id;
            this.nome = nome;
            OcorrenciasTiposPaiID = ocorrenciasTiposPaiId;
            this.criadoEm = criadoEm;
            this.nomeExibicao = nomeExibicao;
            this.ativo = ativo;
            this.atrasadoAtendimento = atrasadoAtendimento;
        }

        public OcorrenciaTipoViewModel()
        {
            ValidationResult = new ValidationResult();
        }

        public OcorrenciaTipoViewModel(long id, string nome, long? ocorrenciasTiposPaiId, string criadoPorUserId,
            string nomeExibicao, bool vincularLocal, bool ativo, int tempoPrevistoAtendimento, bool atrasadoAtendimento)
        {
            ValidationResult = new ValidationResult();
            this.id = id;
            this.nome = nome;
            OcorrenciasTiposPaiID = ocorrenciasTiposPaiId;
            criadoPorUserID = criadoPorUserId;
            this.nomeExibicao = nomeExibicao;
            this.vincularLocal = vincularLocal;
            this.ativo = ativo;
            this.tempoPrevistoAtendimento = tempoPrevistoAtendimento;
            this.atrasadoAtendimento = atrasadoAtendimento;
            //OcorrenciaTipoFilhos = ocorrenciaTipoFilhos != null
            //    ? new SelectList(ocorrenciaTipoFilhos, "id", "nome")
            //    : new SelectList(new List<OcorrenciaTipo>(), "id", "nome");
        }
    }

    public class MotivoSelecionadoViewModel
    {
        public long Id { get; set; }
        public SelectList StatusPorMotivo { get; set; }
        public SelectList Filhos { get; set; }
        public string NomeCompleto { get; set; }
        public string Sla { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public string Previsao { get; set; }
        public bool VincularLocal { get; set; }
        public string DescricaoPadrao { get; set; }

        public bool EhUltimoNivel { get; set; }

        public MotivoSelecionadoViewModel()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
