using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ViewDinamicaAppServico : IViewDinamicaAppServico
    {
        readonly ICampoDinamicoServico _servicoCampoDinamico;
        readonly ICampoDinamicoPreenchidoServico _servicoCampoDinamicoPreenchido;
        readonly IContratoProdutoServico _contratoProdutoServico;

        public ViewDinamicaAppServico(ICampoDinamicoServico servicoCampoDinamico,
            ICampoDinamicoPreenchidoServico servicoCampoDinamicoPreenchido,
            IContratoProdutoServico contratoProdutoServico)
        {
            _servicoCampoDinamico = servicoCampoDinamico;
            _servicoCampoDinamicoPreenchido = servicoCampoDinamicoPreenchido;
            _contratoProdutoServico = contratoProdutoServico;
        }

        public List<ContratoProdutoViewModel> ListaProdutoCamposDinamicos(long contratoId)
        {
            var listaCampos = new List<ResultadoCamposDinamicosViewModel>();
            var listaContratoProduto = new List<ContratoProdutoViewModel>();

            var modal = _servicoCampoDinamico.ObterCamposDinamicosPorEntidade("CTRPRODUT");
            var entidade = _contratoProdutoServico.ListarContratoProduto(contratoId, null);

            foreach (var contratoProdutos in entidade)
            {
                foreach (var item in modal)
                {
                    var listaValores = new List<ResultadoCamposDinamicosViewModel>();

                    var filho = _servicoCampoDinamicoPreenchido.ObterRespostasCamposDinamicosPorEntidade(item.Id,
                        contratoProdutos.Id);

                    if (!filho.Any())
                    {
                        listaValores.Add(new ResultadoCamposDinamicosViewModel(0, ""));
                    }
                    else
                    {
                        foreach (var i in filho)
                        {
                            if (!item.Tipo.Equals("TX"))
                                listaValores.Add(new ResultadoCamposDinamicosViewModel(i.CampoDinamicoOpcao.Id,
                                    i.CampoDinamicoOpcao.Nome));
                            else
                                listaValores.Add(new ResultadoCamposDinamicosViewModel(i.CamposDinamicosId,
                                    i.ValorPreenchido));
                        }
                    }
                    listaCampos.Add(new ResultadoCamposDinamicosViewModel(item.Id, item.Nome, listaValores));
                }

                var contratoProduto =
                    new ContratoProdutoViewModel(
                        new ProdutoViewModel(contratoProdutos.Produto.id, contratoProdutos.Produto.nome,
                            contratoProdutos.Produto.codigo), listaCampos);
                listaContratoProduto.Add(contratoProduto);
            }
            return listaContratoProduto;
        }

        protected List<CampoDinamicoPreenchido> CarregarInformacoesDinamicasControleDinamico(
            ControlViewModel[] controles)
        {
            var listaControleDinamica = new List<CampoDinamicoPreenchido>();

            if (controles == null) return listaControleDinamica;

            foreach (var controle in controles)
            {
                long opcaoId;
                switch (controle.Type)
                {
                    case "textbox":
                    {
                        var txt = (TextBoxViewModel) controle;
                        if (txt.Value != null)
                            listaControleDinamica.Add(new CampoDinamicoPreenchido()
                            {
                                ValorPreenchido = txt.Value,
                                CamposDinamicosId = txt.CampoDinamicoId,
                                EntidadesSecoesCamposDinamicosId = txt.EntidadesSecoesCamposDinamicosId
                            });
                    }
                        break;
                    case "checkbox":
                    {
                        var chk = (CheckBoxViewModel) controle;
                        listaControleDinamica.Add(new CampoDinamicoPreenchido()
                        {
                            ValorPreenchido = chk.Value ? "True" : "False",
                            CamposDinamicosId = chk.CampoDinamicoId,
                            EntidadesSecoesCamposDinamicosId = chk.EntidadesSecoesCamposDinamicosId
                        });
                    }
                        break;
                    case "checkboxlist":
                    {
                        var chk = (CheckBoxListViewModel) controle;

                        if (chk.ListaOpcoes != null)
                        {
                            listaControleDinamica.AddRange(
                                chk.ListaOpcoes.Where(w => w.Selecionado)
                                    .ToList()
                                    .Select(itemCheckBoxListSelecionado => new CampoDinamicoPreenchido()
                                    {
                                        ValorPreenchido = null,
                                        CamposDinamicosId = chk.CampoDinamicoId,
                                        EntidadesSecoesCamposDinamicosId = chk.EntidadesSecoesCamposDinamicosId,
                                        CamposDinamicosOpcoesId = itemCheckBoxListSelecionado.Id
                                    }));
                        }
                    }
                        break;
                    case "ddl":
                        var ddl = (DropDownListViewModel) controle;

                        if (ddl.MultiplaEscolha)
                        {
                            if (ddl.SelectedIds != null)
                            {
                                foreach (var t in ddl.SelectedIds)
                                {
                                    opcaoId = 0;
                                    long.TryParse(t.ToString(), out opcaoId);

                                    if (opcaoId > 0)
                                        listaControleDinamica.Add(new CampoDinamicoPreenchido()
                                        {
                                            ValorPreenchido = null,
                                            CamposDinamicosId = ddl.CampoDinamicoId,
                                            EntidadesSecoesCamposDinamicosId = ddl.EntidadesSecoesCamposDinamicosId,
                                            CamposDinamicosOpcoesId = opcaoId
                                        });
                                }
                            }
                        }
                        else
                        {
                            opcaoId = 0;
                            if (ddl.SelectedIds != null)
                            {
                                for (var i = 0; i < 1; i++)
                                {
                                    long.TryParse(ddl.SelectedIds[i].ToString(), out opcaoId);

                                    if (opcaoId > 0)
                                        listaControleDinamica.Add(new CampoDinamicoPreenchido()
                                        {
                                            ValorPreenchido = null,
                                            CamposDinamicosId = ddl.CampoDinamicoId,
                                            EntidadesSecoesCamposDinamicosId = ddl.EntidadesSecoesCamposDinamicosId,
                                            CamposDinamicosOpcoesId = opcaoId
                                        });
                                }
                            }
                            else
                            {
                                long.TryParse(ddl.Value, out opcaoId);

                                if (opcaoId > 0)
                                    listaControleDinamica.Add(new CampoDinamicoPreenchido()
                                    {
                                        ValorPreenchido = null,
                                        CamposDinamicosId = ddl.CampoDinamicoId,
                                        EntidadesSecoesCamposDinamicosId = ddl.EntidadesSecoesCamposDinamicosId,
                                        CamposDinamicosOpcoesId = opcaoId
                                    });
                            }
                        }
                        break;
                    case "textarea":
                    {
                        var txt = (TextAreaViewModel) controle;
                        if (txt.Value != null)
                            listaControleDinamica.Add(new CampoDinamicoPreenchido()
                            {
                                ValorPreenchido = txt.Value,
                                CamposDinamicosId = txt.CampoDinamicoId,
                                EntidadesSecoesCamposDinamicosId = txt.EntidadesSecoesCamposDinamicosId
                            });
                    }
                        break;
                    case "rdl":
                        var rdl = (RadioButtonListViewModel) controle;

                        opcaoId = 0;
                        var campoDinamicoOpcao = rdl.Values.FirstOrDefault();
                        if (campoDinamicoOpcao != null)
                            long.TryParse(campoDinamicoOpcao.Id.ToString(), out opcaoId);

                        if (opcaoId > 0)
                            listaControleDinamica.Add(new CampoDinamicoPreenchido()
                            {
                                ValorPreenchido = null,
                                CamposDinamicosId = rdl.CampoDinamicoId,
                                EntidadesSecoesCamposDinamicosId = rdl.EntidadesSecoesCamposDinamicosId,
                                CamposDinamicosOpcoesId = opcaoId
                            });
                        break;

                    case "oovm":
                        var ocorrenciaOriginal = (OcorrenciaOriginalViewModel) controle;
                        if (ocorrenciaOriginal.Value != null)
                            listaControleDinamica.Add(new CampoDinamicoPreenchido()
                            {
                                ValorPreenchido = ocorrenciaOriginal.Value,
                                CamposDinamicosId = ocorrenciaOriginal.CampoDinamicoId,
                                EntidadesSecoesCamposDinamicosId = ocorrenciaOriginal.EntidadesSecoesCamposDinamicosId
                            });

                        break;
                }
            }
            return listaControleDinamica;
        }

        public CampoDinamicoViewModel Carregar(string siglaEntidade, string nomeAba, string nomeSecao, long? id,
            bool podeEditar)
        {
            var viewModel = new CampoDinamicoViewModel
            {
                ChaveEntidadeId = id,
                PodeEditar = podeEditar
            };

            var listaCampoDinamico = _servicoCampoDinamico.ObterPor(id, siglaEntidade, nomeAba, nomeSecao);
            var listaSecoes = new List<SecaoViewModel>();

            if (listaCampoDinamico != null)
            {
                if (listaCampoDinamico.Any())
                {
                    viewModel.ChaveEntidadeId = listaCampoDinamico.FirstOrDefault().EntidadeSecao.EntidadesId;
                    var camposDinamicosAgrupadoPorSecao =
                        listaCampoDinamico.GroupBy(u => new {nome = u.EntidadeSecao.Nome, id = u.EntidadeSecao.Id},
                            (Key, group) => new {id = Key.id, nome = Key.nome, CamposDinamicos = group.ToList()});

                    listaSecoes.AddRange(
                        camposDinamicosAgrupadoPorSecao.Select(
                            secao =>
                                new SecaoViewModel(secao.nome, secao.id, secao.CamposDinamicos, podeEditar,
                                    viewModel.ChaveBase)));
                }
            }

            viewModel.Secoes = listaSecoes;
            return viewModel;
        }

        public CampoDinamicoViewModel Editar(long id, string siglaEntidade, string nomeAba, string nomeSecao)
        {
            var viewModel = new CampoDinamicoViewModel {ChaveEntidadeId = id};
            var listaCampoDinamico = _servicoCampoDinamico.ObterPor(id, siglaEntidade, nomeAba, nomeSecao);
            var listaSecoes = new List<SecaoViewModel>();

            if (listaCampoDinamico != null)
            {
                var camposDinamicosAgrupadoPorSecao =
                    listaCampoDinamico.GroupBy(u => new {nome = u.EntidadeSecao.Nome, id = u.EntidadeSecao.Id},
                        (key, group) => new {key.id, key.nome, CamposDinamicos = group.ToList()});

                listaSecoes.AddRange(
                    camposDinamicosAgrupadoPorSecao.Select(
                        secao =>
                            new SecaoViewModel(secao.nome, secao.id, secao.CamposDinamicos, true, viewModel.ChaveBase)));
            }

            viewModel.Secoes = listaSecoes.ToArray();
            return viewModel;
        }

        public CampoDinamicoViewModel Atualizar(CampoDinamicoViewModel viewModel, string usuarioId)
        {
            if (viewModel == null) return viewModel;

            var listaCamposDinamicos = CarregarInformacoesDinamicasControleDinamico(viewModel.Controls);

            if (viewModel.Controls != null)
            {
                //Limpando registros do Passado
                foreach (var campoDinamico in viewModel.Controls)
                {
                    _servicoCampoDinamicoPreenchido.Deletar((long) viewModel.ChaveEntidadeId,
                        campoDinamico.EntidadesSecoesCamposDinamicosId, campoDinamico.CampoDinamicoId, usuarioId);
                }
            }

            foreach (var campoDinamico in listaCamposDinamicos)
            {
                campoDinamico.ChaveEntidade = (long) viewModel.ChaveEntidadeId;
                _servicoCampoDinamicoPreenchido.Adicionar(campoDinamico,usuarioId);
            }

            return viewModel;
        }

        public CampoDinamicoViewModel Adicionar(CampoDinamicoViewModel viewModel, string usuarioId)
        {
            var listaCamposDinamicos = CarregarInformacoesDinamicasControleDinamico(viewModel.Controls);

            foreach (var campoDinamico in listaCamposDinamicos)
            {
                campoDinamico.ChaveEntidade = (long) viewModel.ChaveEntidadeId;
                _servicoCampoDinamicoPreenchido.Adicionar(campoDinamico, usuarioId);
            }

            return null;
        }
    }
}
