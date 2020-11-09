using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Aplicacao.Adaptadores
{
    public class CampoDinamicoAdaptador
    {
        public static ControlViewModel ParaAplicacaoViewModel(CampoDinamico registro, bool podeEditar, string chaveBase)
        {
            var listaIdsPreenchidos = new List<long>();
            if (registro.ListaCampoDinamicoPreenchido != null)
            {
                if (registro.ListaCampoDinamicoPreenchido.Any())
                {
                    listaIdsPreenchidos.AddRange(from valorPreenchido in registro.ListaCampoDinamicoPreenchido
                        where valorPreenchido.CamposDinamicosOpcoesId != null
                        select (long) valorPreenchido.CamposDinamicosOpcoesId);
                }
            }
            else
                registro.ListaCampoDinamicoPreenchido = new List<CampoDinamicoPreenchido>();



          



            switch (registro.Tipo.ToLower())
            {
                case "tb":
                    return new TextBoxViewModel
                    {
                        Visible = true,
                        Label = registro.Nome,
                        Name = "txtViewDinamica_" + registro.Id,
                        Value =
                            registro.ListaCampoDinamicoPreenchido.Any()
                                ? registro.ListaCampoDinamicoPreenchido.FirstOrDefault().ValorPreenchido
                                : null,
                        CampoDinamicoId = registro.Id,
                        EntidadesSecoesCamposDinamicosId = registro.EntidadeSecaoCampoDinamico.Id,
                        PodeEditar = podeEditar,
                        ChaveBase = chaveBase
                    };
                case "tx":
                    return new TextAreaViewModel
                    {
                        Visible = true,
                        Label = registro.Nome,
                        Name = "txtViewDinamica_" + registro.Id,
                        Value =
                            registro.ListaCampoDinamicoPreenchido.Any()
                                ? registro.ListaCampoDinamicoPreenchido.FirstOrDefault().ValorPreenchido
                                : null,
                        CampoDinamicoId = registro.Id,
                        EntidadesSecoesCamposDinamicosId = registro.EntidadeSecaoCampoDinamico.Id,
                        PodeEditar = podeEditar,
                        ChaveBase = chaveBase
                    };
                case "dl":

                    if (!registro.CarregarOpcoes)
                    {
                        registro.ListaOpcoes = !string.IsNullOrEmpty(listaIdsPreenchidos.FirstOrDefault().ToString())
                            ? registro.ListaOpcoes.Where(x => x.Id == listaIdsPreenchidos.FirstOrDefault())
                            : new List<CampoDinamicoOpcao>();
                    }

                    return new DropDownListViewModel
                    {
                        Visible = true,
                        Label = registro.Nome,
                        Name = "ddlViewDinamica_" + registro.Id,
                        CampoDinamicoId = registro.Id,
                        EntidadesSecoesCamposDinamicosId = registro.EntidadeSecaoCampoDinamico.Id,
                        Values = registro.ListaOpcoes,
                        MultiplaEscolha = registro.MultiplaEscolha,
                        SelectedIds = listaIdsPreenchidos.ToArray(),
                        Value = listaIdsPreenchidos.FirstOrDefault().ToString(),
                        PodeEditar = podeEditar,
                        ChaveBase = chaveBase
                    };


                case "cl":

                    if (registro.MultiplaEscolha)
                    {
                        var listaItemCheckBoxList = new List<ItemChekBoxList>();

                        if (registro.ListaOpcoes != null)
                            foreach (var item in registro.ListaOpcoes)
                            {
                                listaItemCheckBoxList.Add(new ItemChekBoxList()
                                {
                                    Selecionado = false,
                                    Id = item.Id,
                                    Nome = item.Nome
                                });
                            }

                        if (registro.ListaCampoDinamicoPreenchido != null)
                            foreach (var preenchido in registro.ListaCampoDinamicoPreenchido)
                            {
                                foreach (var itemCheckBoxList in listaItemCheckBoxList)
                                {
                                    if (itemCheckBoxList.Id == preenchido.CamposDinamicosOpcoesId)
                                        itemCheckBoxList.Selecionado = true;
                                }
                            }

                        return new CheckBoxListViewModel
                        {
                            Visible = true,
                            Label = registro.Nome,
                            Name = "chkViewDinamica_" + registro.Id,
                            CampoDinamicoId = registro.Id,
                            EntidadesSecoesCamposDinamicosId = registro.EntidadeSecaoCampoDinamico.Id,
                            MultiplaEscolha = registro.MultiplaEscolha,
                            ListaOpcoes = listaItemCheckBoxList,
                            PodeEditar = podeEditar,
                            ChaveBase = chaveBase
                        };
                    }
                    return new CheckBoxViewModel
                    {
                        Visible = true,
                        Label = registro.Nome,
                        Name = "chkViewDinamica_" + registro.Id,
                        CampoDinamicoId = registro.Id,
                        EntidadesSecoesCamposDinamicosId = registro.EntidadeSecaoCampoDinamico.Id,
                        MultiplaEscolha = registro.MultiplaEscolha,
                        Value =
                            registro.ListaCampoDinamicoPreenchido != null
                                ? (registro.ListaCampoDinamicoPreenchido.Any() &&
                                   registro.ListaCampoDinamicoPreenchido.FirstOrDefault()
                                       .ValorPreenchido.ToLower() == "true")
                                : false,
                        PodeEditar = podeEditar,
                        ChaveBase = chaveBase
                    };

                case "rl":
                    return new RadioButtonListViewModel
                    {
                        Visible = true,
                        Label = registro.Nome,
                        Name = "rdlViewDinamica_" + registro.Id,
                        CampoDinamicoId = registro.Id,
                        EntidadesSecoesCamposDinamicosId = registro.EntidadeSecaoCampoDinamico.Id,
                        Values = registro.ListaOpcoes,
                        MultiplaEscolha = registro.MultiplaEscolha,
                        Value =
                            registro.ListaCampoDinamicoPreenchido != null
                                ? (registro.ListaCampoDinamicoPreenchido.Any()
                                    ? registro.ListaCampoDinamicoPreenchido.FirstOrDefault()
                                        .CamposDinamicosOpcoesId.ToString()
                                    : null)
                                : null,
                        PodeEditar = podeEditar,
                        ChaveBase = chaveBase
                    };
                case "oo":
                    return new OcorrenciaOriginalViewModel()
                    {
                        Visible = true,
                        Label = registro.Nome,
                        Name = "ocorrenciaOriginalViewModel_" + registro.Id,
                        Value =
                            registro.ListaCampoDinamicoPreenchido.Any()
                                ? registro.ListaCampoDinamicoPreenchido.FirstOrDefault().ValorPreenchido
                                : null,
                        CampoDinamicoId = registro.Id,
                        EntidadesSecoesCamposDinamicosId = registro.EntidadeSecaoCampoDinamico.Id,
                        PodeEditar = podeEditar,
                        NomeOcorrenciaOriginal = "",
                        ChaveBase = chaveBase
                    };
                default:
                    return new TextBoxViewModel
                    {
                        Visible = true,
                        Label = registro.Nome,
                        Name = "txt" + registro.Id,
                        Value = null,
                        CampoDinamicoId = registro.Id,
                        EntidadesSecoesCamposDinamicosId = registro.EntidadeSecaoCampoDinamico.Id,
                        PodeEditar = podeEditar,
                        ChaveBase = chaveBase
                    };
            }
        }
    }
}
