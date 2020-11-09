using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Web.Mvc;
using System;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class TextoAppServico : AppServicoDapper, ITextoAppServico
    {
        private readonly ITextoServico _textoServico;
        private readonly ITextoCategoriaServico _textoCategoriaServico;
        private readonly IFilaServico _filaServico;
        private readonly ITextoFilaServico _textoFilaServico;
        private readonly IEntidadeCampoValorServico _entidadeCampoValorServico;
        private readonly ICanalServico _canalServico;
        private readonly ITextoTipoServico _textoTipoServico;
        private readonly ITextoFormatoServico _textoFormatoServico;

        public TextoAppServico(ITextoServico textoServico, ITextoCategoriaServico textoCategoriaServico, IFilaServico filaServico, ITextoFilaServico textoFilaServico, IEntidadeCampoValorServico entidadeCampoValorServico, ICanalServico canalServico, ITextoTipoServico textoTipoServico, ITextoFormatoServico textoFormatoServico)
        {
            _textoServico = textoServico;
            _textoCategoriaServico = textoCategoriaServico;
            _filaServico = filaServico;
            _textoFilaServico = textoFilaServico;
            _entidadeCampoValorServico = entidadeCampoValorServico;
            _canalServico = canalServico;
            _textoTipoServico = textoTipoServico;
            _textoFormatoServico = textoFormatoServico;
        }

        private static List<TreeNode> CarregarSubCategoria(List<TreeNode> headerTree, TextoCategoria categoria, List<TextoCategoria> categorias, List<Texto> textos, long? categoriaPaiId)
        {
            var retorno = new List<TreeNode>();

            if (categoria != null)
            {
                var novaCategoria = new TreeNode
                {
                    CategoriaNome = categoria.Nome,
                    CategoriaId = categoria.Id,
                    Itens = CarregarSubCategoria(headerTree, null, categorias, textos, categoria.Id),
                    EhPasta = true
                };

                retorno.Add(novaCategoria);

                //var textosFilho = textos.Where(x => x.CategoriaId == categoria.Id);

                //foreach (var texto in textosFilho)
                //{
                //    retorno.Add(new TreeNode
                //    {
                //        TextoId = texto.Id,
                //        Nome = texto.Nome,
                //        Descricao = texto.Descricao,
                //        EhPasta = false,
                //        TipoId = texto.TipoId
                //    });
                //}

                return retorno;
            }
            else
            {
                retorno.AddRange(
                    categorias.Where(x => x.TextoCategoriaPaiId.Equals(categoriaPaiId)).Select(item => new TreeNode
                    {
                        CategoriaNome = item.Nome,
                        CategoriaId = item.Id,
                        Itens = CarregarSubCategoria(headerTree, null, categorias, textos, item.Id),
                        EhPasta = true
                    }).ToList());


                var textosFilho = textos.Where(x => x.CategoriaId == categoriaPaiId);

                foreach (var texto in textosFilho)
                {
                    retorno.Add(new TreeNode
                    {
                        TextoId = texto.Id,
                        Nome = texto.Nome,
                        Descricao = texto.Descricao,
                        EhPasta = false,
                        TipoId = texto.TipoId
                    });
                }
            }

            return retorno;
        }
        private static List<TreeNode> FillRecursive(List<Texto> textos, long? categoriaPaiId = null)
        {
            return textos.Where(x => x.CategoriaPaiId.Equals(categoriaPaiId)).Select(item => new TreeNode
            {
                CategoriaNome = item.Categoria,
                CategoriaId = item.CategoriaId,
                Itens = FillRecursive(textos, item.CategoriaId)
            }).ToList();
        }

        public List<TextoCategoriaViewModel> ObterCategorias(int? filaId)
        {
            var retorno = new List<TextoCategoriaViewModel>();
            var categorias = _textoCategoriaServico.ObterPorFilaId(filaId);

            if (categorias.Any())
            {
                foreach (var categoria in categorias)
                {
                    retorno.Add(new TextoCategoriaViewModel
                    {
                        CategoriaId = categoria.Id,
                        CategoriaNome = categoria.Nome,
                        CategoriaPaiId = categoria.TextoCategoriaPaiId
                    });
                }
            }

            return retorno;
        }

        List<TreeNode> ITextoAppServico.ObterPorFila(int? filaId)
        {
            var categorias = _textoCategoriaServico.ObterPorFilaId(filaId);
            var textos = _textoServico.ObterPorFilaId(filaId);
            var categoriasN1 = new List<TextoCategoriaViewModel>();
            List<TreeNode> headerTree = new List<TreeNode>();

            foreach (var categoriaN1 in categorias.Where(x => x.TextoCategoriaPaiId == null))
            {
                headerTree.AddRange(CarregarSubCategoria(headerTree, categoriaN1, categorias.ToList(), textos.ToList(), null));
            }

            return headerTree;
        }        


        public TextoViewModel Novo(string usuarioId)
        {
            var model = new TextoViewModel();
            model.Canais = new SelectList(_canalServico.ObterTodos().ToList().OrderBy(o => o.Nome), "Id", "Nome");
            model.Filas = new SelectList(_filaServico.ObterTodos().Where(w => w.Ativo == true).ToList().OrderBy(o => o.Nome), "Id", "Nome");
            model.Categorias = new SelectList(_textoCategoriaServico.ObterTodos().Where(w => w.Ativo == true && w.TextoCategoriaPaiId == null).ToList(), "Id", "Nome");
            model.Formatos = new SelectList(_textoFormatoServico.ObterTodos().Where(w => w.Ativo == true).ToList().OrderBy(o => o.Nome), "Id", "Nome");
            model.Tipos = new SelectList(_textoTipoServico.ObterTodos().ToList().OrderBy(o => o.Nome), "Id", "Nome");
            return model;
        }

        List<TextoCategoriaItemViewModel> ITextoAppServico.ObterCategorias(int? textoCategoriaPaiId)
        {
            var retorno = new List<TextoCategoriaItemViewModel>();
            var listaCategoria = _textoCategoriaServico.ObterTodos();

            if (textoCategoriaPaiId.HasValue)
                listaCategoria = listaCategoria.Where(x => x.TextoCategoriaPaiId == textoCategoriaPaiId);

            foreach (var categoria in listaCategoria)
            {
                retorno.Add(new TextoCategoriaItemViewModel
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                    EhUltimoNivel = categoria.EhUltimoNivel
                });
            }

            return retorno;
        }

        public SelectList ObterStatusTexto(int? statusTextoId)
        {
            throw new NotImplementedException();
        }

        public TextoViewModel Adicionar(TextoViewModel model)
        {
            var texto = new Texto
            {
                FormatoId = model.FormatoId,
                CategoriaId = model.CategoriaId,
                TipoId = model.TipoId,
                Nome = model.Nome,
                Descricao = model.Descricao.Replace("|","/"),
                CriadoEm = DateTime.Now,
                CriadoPor = model.CriadoPor,
                Ativo = true
            };

            var resultado = _textoServico.Adicionar(texto);

            if (!resultado.IsValid)
            {
                model.ValidationResult = resultado;
                return model;
            }

            var textoFila = new TextoFila
            {
                FilaId = (int)model.FilaId,
                TextoId = texto.Id,
                CriadoEm = DateTime.Now,
                CriadoPor = model.CriadoPor,
                Ativo = true
            };

            _textoFilaServico.Adicionar(textoFila);


            //foreach (var filas in model.FilasSelecionadas)
            //{
            //    var textoFila = new TextoFila
            //    {
            //        FilaId = Convert.ToInt32(filas),
            //        TextoId = texto.Id,
            //        CriadoEm = DateTime.Now,
            //        CriadoPor = model.CriadoPor,
            //        Ativo = true
            //    };

            //    _textoFilaServico.Adicionar(textoFila);
            //}

            return model;
        }

        public IEnumerable<TextoListaViewModel> BuscarTexto(TextoFiltroViewModel model)
        {
            var lista = _textoServico.FiltrarPor(model.FilaId, model.CanalId, model.TipoId, model.FormatoId);
            var retorno = new List<TextoListaViewModel>();

            foreach (var itemTexto in lista)
            {
                retorno.Add(new TextoListaViewModel
                {
                    Id = itemTexto.Id,
                    Nome = itemTexto.Nome,
                    Resumo = itemTexto.Descricao,
                    CriadoPor = itemTexto.CriadoPorObj != null ? itemTexto.CriadoPorObj.Nome : "--",
                    CriadoEm = itemTexto.CriadoEm.ToString("dd/MM/yy HH:mm"),
                    Status = itemTexto.Ativo ? "Ativo" : "Inativo",
                    Categoria = itemTexto.CategoriaObj != null ? itemTexto.CategoriaObj.Nome : "--"
                });
            }

            return retorno;
        }

        public TextoFiltroViewModel Carregar()
        {
            var retorno = new TextoFiltroViewModel();
            retorno.Filas = new SelectList(_filaServico.ObterTodos().Where(w => w.Ativo == true).ToList().OrderBy(o => o.Nome), "Id", "Nome");
            retorno.Canais = new SelectList(_canalServico.ObterTodos().ToList().OrderBy(o => o.Nome), "Id", "Nome");
            retorno.Tipos = new SelectList(_textoTipoServico.ObterTodos().ToList().OrderBy(o => o.Nome), "Id", "Nome");
            retorno.Formatos = new SelectList(_textoFormatoServico.ObterTodos().Where(w => w.Ativo == true).ToList().OrderBy(o => o.Nome), "Id", "Nome");

            return retorno;
        }

        public TextoViewModel Editar(long id)
        {
            var texto = _textoServico.ObterPorId(id);
            var textoFilas = _textoFilaServico.ObterPorTextoId(id);
            var filas = _filaServico.ObterTodos().Where(w => w.Ativo == true).ToList().OrderBy(o => o.Nome);
            var canais = _canalServico.ObterTodos().OrderBy(o => o.Nome);
            List<SelectListItem> Filas = new List<SelectListItem>();            
            var textoFila = textoFilas.FirstOrDefault();
            var fila = new Fila();

            if (textoFila != null)
            {
                fila = filas.FirstOrDefault(x => x.Id == textoFila.FilaId);
            }
            else
            {
                textoFila = new TextoFila();                
            }
            

            foreach (var filaItem in filas)
            {
                Filas.Add(new SelectListItem
                {
                    Selected = filaItem.Id == textoFila.FilaId,
                    Text = filaItem.Nome,
                    Value = filaItem.Id.ToString()
                });
            }

            //foreach (var fila in filas)
            //{
            //    Filas.Add(new SelectListItem
            //    {
            //        Selected = textoFilas.Count(x => x.FilaId == fila.Id) > 0,
            //        Text = fila.Nome,
            //        Value = fila.Id.ToString()
            //    });
            //}

            var formatos = _textoFormatoServico.ObterTodos().Where(w => w.Ativo == true).ToList().OrderBy(o => o.Nome);
            var tipos = _textoTipoServico.ObterTodos().ToList().OrderBy(o => o.Nome);
            List<SelectListItem> Formatos = new List<SelectListItem>();
            List<SelectListItem> Tipos = new List<SelectListItem>();
            List<SelectListItem> Canais = new List<SelectListItem>();

            foreach (var formato in formatos)
            {
                Formatos.Add(new SelectListItem
                {
                    Selected = formato.Id == texto.FormatoId,
                    Text = formato.Nome,
                    Value = formato.Id.ToString()
                });
            }

            foreach (var tipo in tipos)
            {
                Tipos.Add(new SelectListItem
                {
                    Selected = tipo.Id == texto.TipoId,
                    Text = tipo.Nome,
                    Value = tipo.Id.ToString()
                });
            }

            foreach (var canal in canais)
            {
                Canais.Add(new SelectListItem
                {
                    Selected = canal.Id == fila.CanalId,
                    Text = canal.Nome,
                    Value = canal.Id.ToString()
                });
            }


            var model = new TextoViewModel
            {
                Id = texto.Id,
                Canais = Canais,
                Filas = Filas,
                Categorias = new SelectList(_textoCategoriaServico.ObterTodos().Where(w => w.Ativo == true && w.TextoCategoriaPaiId == null).ToList(), "Id", "Nome"),
                Nome = texto.Nome,
                Descricao = texto.Descricao,
                CategoriaId = texto.CategoriaId,
                TipoId = texto.TipoId,
                Ativo = texto.Ativo,
                FormatoId = texto.FormatoId,
                Formatos = Formatos,
                Tipos = Tipos,
                DdlsCategoria = ObterCategoriasDdlViewModel(texto.CategoriaId)
            };

            return model;
        }

        public TextoViewModel Atualizar(TextoViewModel model)
        {
            var textoDB = _textoServico.ObterPorId((long)model.Id);

            textoDB.Nome = model.Nome;
            textoDB.Descricao = model.Descricao.Replace("|", "/");
            textoDB.CategoriaId = model.CategoriaId;
            textoDB.FormatoId = model.FormatoId;
            textoDB.TipoId = model.TipoId;
            textoDB.AtualizadoEm = DateTime.Now;
            textoDB.AtualizadoPor = model.AtualizadoPor;
            textoDB.Ativo = model.Ativo;
            var resultado = _textoServico.Atualizar(textoDB);

            if (!resultado.IsValid)
            {
                model.ValidationResult = resultado;
                return model;
            }

            _textoFilaServico.DeletarTodosAtivo((long)model.Id, model.AtualizadoPor);

            var textoFila = new TextoFila
            {
                FilaId = (int)model.FilaId,
                TextoId = (long)model.Id,
                CriadoEm = DateTime.Now,
                CriadoPor = model.AtualizadoPor,
                Ativo = true
            };

            _textoFilaServico.Adicionar(textoFila);

            //foreach (var filas in model.FilasSelecionadas)
            //{
            //    var textoFila = new TextoFila
            //    {
            //        FilaId = Convert.ToInt32(filas),
            //        TextoId = (long)model.Id,
            //        CriadoEm = DateTime.Now,
            //        CriadoPor = model.AtualizadoPor,
            //        Ativo = true
            //    };

            //    _textoFilaServico.Adicionar(textoFila);
            //}

            return model;

        }

        public IEnumerable<CategoriaDdlViewModel> ObterCategoriasDdlViewModel(long categoriId)
        {
            var retorno = new List<CategoriaDdlViewModel>();
            var categorias = _textoCategoriaServico.ObterTodos();
            var categoriaTexto = categorias.FirstOrDefault(x => x.Id == categoriId);
            var contador = 1;

            foreach (var categoriaEstruturaId in categoriaTexto.EstruturaDeIds.Split('|'))
            {
                long id;
                long.TryParse(categoriaEstruturaId, out id);

                if (id > 0)
                {
                    var opcoes = new List<TextoCategoria>();

                    if (contador == 1)
                    {
                        opcoes = categorias.Where(w => w.TextoCategoriaPaiId == null).ToList();
                    }
                    else
                    {
                        var categoriaNivel = categorias.FirstOrDefault(w => w.Id == id);
                        opcoes = categorias.Where(w => w.TextoCategoriaPaiId == categoriaNivel.TextoCategoriaPaiId).ToList();
                    }

                    retorno.Add(new CategoriaDdlViewModel
                    {
                        Opcoes = new SelectList(opcoes, "Id", "Nome", categoriaEstruturaId),
                        Contador = contador,
                        ValorSelecionado = categoriaEstruturaId
                    });
                }
                contador++;
            }

            return retorno;

        }
    }
}
