using System;
using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Aplicacao.Adaptadores;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class CampoDinamicoViewModel
    {
        public string NomeAba { get; set; }
        public long? ChaveEntidadeId { get; set; }
        public ControlViewModel[] Controls { get; set; }
        public IEnumerable<SecaoViewModel> Secoes { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public bool PodeEditar { get; set; }
        public string ChaveBase { get; set; }

        public CampoDinamicoViewModel()
        {
            ChaveBase = Guid.NewGuid().ToString();
        }
    }

    public class SecaoViewModel
    {
        public string NomeSecao { get; set; }
        public long EntidadeSecaoId { get; set; }
        public ControlViewModel[] Controls { get; set; }

        public SecaoViewModel(string nomeSecao, long entidadeSecaoId, IEnumerable<CampoDinamico> camposDinamicos,
            bool podeEditar, string chaveBase)
        {
            NomeSecao = nomeSecao;
            EntidadeSecaoId = entidadeSecaoId;

            if (camposDinamicos == null) return;

            Controls =
                camposDinamicos.Select(
                        campoDinamico =>
                            CampoDinamicoAdaptador.ParaAplicacaoViewModel(campoDinamico, podeEditar, chaveBase))
                    .ToArray();
        }
    }

    public abstract class ControlViewModel
    {
        public abstract string Type { get; }
        public long CampoDinamicoId { get; set; }
        public bool Visible { get; set; }
        public string Label { get; set; }
        public string Name { get; set; }
        public int EntidadesSecoesCamposDinamicosId { get; set; }
        public bool MultiplaEscolha { get; set; }
        public int Tamanho { get; set; }
        public string Mascara { get; set; }
        public bool PodeEditar { get; set; }
        public string ChaveBase { get; set; }
    }


    public class TextBoxViewModel : ControlViewModel
    {
        public override string Type
        {
            get { return "textbox"; }
        }

        public string Value { get; set; }
    }

    public class TextAreaViewModel : ControlViewModel
    {
        public override string Type
        {
            get { return "textarea"; }
        }

        public string Value { get; set; }
    }

    public class CheckBoxViewModel : ControlViewModel
    {
        public override string Type
        {
            get { return "checkbox"; }
        }

        public bool Value { get; set; }
    }

    public class CheckBoxListViewModel : TextBoxViewModel
    {
        public override string Type
        {
            get { return "checkboxlist"; }
        }

        public List<ItemChekBoxList> ListaOpcoes { get; set; }
    }

    public class ItemChekBoxList
    {
        public long Id { get; set; }
        public bool Selecionado { get; set; }
        public string Nome { get; set; }
    }

    public class DropDownListViewModel : TextBoxViewModel
    {
        public override string Type
        {
            get { return "ddl"; }
        }

        public IEnumerable<CampoDinamicoOpcao> Values { get; set; }
        public long[] SelectedIds { get; set; }
    }

    public class RadioButtonListViewModel : TextBoxViewModel
    {
        public override string Type
        {
            get { return "rdl"; }
        }

        public IEnumerable<CampoDinamicoOpcao> Values { get; set; }
    }

    public class OcorrenciaOriginalViewModel : TextBoxViewModel
    {
        public override string Type
        {
            get { return "oovm"; }
        }

        public string NomeOcorrenciaOriginal { get; set; }
    }

    public class BuscaCorretorViewModel : ControlViewModel
    {
        public override string Type
        {
            get { return "bc"; }
        }

        public string Value { get; set; }
    }
}
