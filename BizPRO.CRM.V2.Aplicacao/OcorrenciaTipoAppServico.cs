using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Core.Comum;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class OcorrenciaTipoAppServico : IOcorrenciaTipoAppServico
    {
        private readonly IOcorrenciaTipoServico _ocorrenciaTipoServico;
        private readonly IOcorrenciaAppServico _ocorrenciaAppServico;
        private readonly IStatusEntidadeServico _statusEntidadeServico;
        private readonly IFeriadoServico _feriadoServico;

        public OcorrenciaTipoAppServico(IOcorrenciaTipoServico ocorrenciaTipoServico,
            IOcorrenciaAppServico ocorrenciaAppServico, IStatusEntidadeServico statusEntidadeServico,
            IFeriadoServico feriadoServico)
        {
            _ocorrenciaTipoServico = ocorrenciaTipoServico;
            _ocorrenciaAppServico = ocorrenciaAppServico;
            _statusEntidadeServico = statusEntidadeServico;
            _feriadoServico = feriadoServico;
        }

        public IEnumerable<OcorrenciaTipoViewModel> ListarOcorrenciaTipo(bool? ativo)
        {
            var lista = ativo == null
                ? _ocorrenciaTipoServico.ObterTodos()
                : _ocorrenciaTipoServico.ObterTodos().Where(w => w.Ativo == ativo);

            return
                lista.Select(
                    item =>
                        new OcorrenciaTipoViewModel(item.Id, item.Nome, item.OcorrenciasTiposPaiId, item.CriadoEm,
                            item.NomeExibicao, item.Ativo, item.AtrasadoAtendimento)).ToList();
        }

        public IEnumerable<OcorrenciaTipoViewModel> ListarOcorrenciaTipoOcorrencia(string userId)
        {
            var lista = _ocorrenciaTipoServico.ListarOcorrenciaTipoOcorrencia(userId);

            return
                lista.Select(
                    item =>
                        new OcorrenciaTipoViewModel(item.Id, item.Nome, item.OcorrenciasTiposPaiId, item.CriadoEm,
                            item.NomeExibicao, item.Ativo, item.AtrasadoAtendimento)).ToList();
        }

        public IEnumerable<OcorrenciaTipoViewModel> ListarOcorrenciaTipoPai(bool ativo)
        {
            var listaOcorrenciaTipo = _ocorrenciaTipoServico.ObterOcorrenciasPai().Where(w => w.Ativo == ativo);
            return
                listaOcorrenciaTipo.Select(
                    item =>
                        new OcorrenciaTipoViewModel(item.Id, item.Nome, item.OcorrenciasTiposPaiId, item.CriadoEm,
                            item.NomeExibicao, item.Ativo, item.AtrasadoAtendimento)).ToList();
        }

        public OcorrenciaTipoViewModel SalvarOcorrenciaTipo(OcorrenciaTipoViewModel view)
        {
            var ocorrenciaTipo =
                _ocorrenciaTipoServico.SalvarOcorrenciaTipo(new OcorrenciaTipo(view.id, view.nome,
                    view.OcorrenciasTiposPaiID, view.criadoPorUserID, view.nomeExibicao, view.vincularLocal, view.ativo,
                    view.tempoPrevistoAtendimento));
            return new OcorrenciaTipoViewModel(ocorrenciaTipo.Id, ocorrenciaTipo.Nome,
                ocorrenciaTipo.OcorrenciasTiposPaiId, ocorrenciaTipo.CriadoPorUserId, ocorrenciaTipo.NomeExibicao,
                ocorrenciaTipo.VincularLocal, ocorrenciaTipo.Ativo, ocorrenciaTipo.TempoPrevistoAtendimento,
                ocorrenciaTipo.AtrasadoAtendimento);
        }

        public OcorrenciaTipoViewModel CarregarDadosOcorrenciaTipo(long id)
        {
            var listaOcorreciasTipoDDlViewModel = _ocorrenciaAppServico.CarregarOcorrenciaTipoGravadas(id);
            var ocorrenciaTipo = _ocorrenciaTipoServico.ObterPorId(id);

            var model = new OcorrenciaTipoViewModel
            {
                ListaOcorrenciaTipoDDLViewModel = listaOcorreciasTipoDDlViewModel,
                id = ocorrenciaTipo.Id,
                nome = ocorrenciaTipo.Nome,
                OcorrenciasTiposPaiID = ocorrenciaTipo.OcorrenciasTiposPaiId,
                nomeExibicao = ocorrenciaTipo.NomeExibicao,
                vincularLocal = ocorrenciaTipo.VincularLocal,
                ativo = ocorrenciaTipo.Ativo,
                tempoPrevistoAtendimento = ocorrenciaTipo.TempoPrevistoAtendimento
            };
            return model;
        }

        public OcorrenciaTipoViewModel EditarOcorrenciaTipo(OcorrenciaTipoViewModel view)
        {
            var ocorrenciaTipo =
                _ocorrenciaTipoServico.EditarOcorrenciaTipo(new OcorrenciaTipo(view.id, view.nome,
                    view.OcorrenciasTiposPaiID, view.criadoPorUserID, view.nomeExibicao, view.vincularLocal, view.ativo,
                    view.tempoPrevistoAtendimento));
            return new OcorrenciaTipoViewModel(ocorrenciaTipo.Id, ocorrenciaTipo.Nome,
                ocorrenciaTipo.OcorrenciasTiposPaiId, ocorrenciaTipo.CriadoPorUserId, ocorrenciaTipo.NomeExibicao,
                ocorrenciaTipo.VincularLocal, ocorrenciaTipo.Ativo, ocorrenciaTipo.TempoPrevistoAtendimento,
                ocorrenciaTipo.AtrasadoAtendimento);
        }

        public DateTime? CalcularSla(long ocorrenciaTipoId)
        {
            return _ocorrenciaTipoServico.CalcularSla(ocorrenciaTipoId);
        }

        public OcorrenciaTipoViewModel ObterDadosPorId(long ocorrenciaTipoId)
        {
            var entidade = _ocorrenciaTipoServico.ObterPorId(ocorrenciaTipoId);

            return entidade == null
                ? null
                : new OcorrenciaTipoViewModel(entidade.Id, entidade.Nome, entidade.OcorrenciasTiposPaiId,
                    entidade.CriadoPorUserId, entidade.NomeExibicao, entidade.VincularLocal, entidade.Ativo,
                    entidade.TempoPrevistoAtendimento, entidade.AtrasadoAtendimento);
        }

        public OcorrenciaTipoViewModel MotivoOcorrenciaSelecionado(long ocorrenciaTipoId,
            bool carregarUltimoNivel = true)
        {
            var ocorrenciaTipo = _ocorrenciaTipoServico.ObterPorId(ocorrenciaTipoId);
            DateTime? previsaoInicial = null;
            var ocorrenciaTipoFilhos = _ocorrenciaTipoServico.ObterPor(ocorrenciaTipoId);

            var retorno = new OcorrenciaTipoViewModel
            {
                nomeExibicao = ocorrenciaTipo.NomeExibicao,
                vincularLocal = ocorrenciaTipo.VincularLocal,
                tempoPrevistoAtendimento = ocorrenciaTipo.TempoPrevistoAtendimento,
                TempoPrevistoAtendimentoPorExtenso =
                    ocorrenciaTipo.TempoPrevistoDeAtendimentoPorExtenso(!ocorrenciaTipo.TempoPrevistoCorrido),
                DescricaoPadrao = ocorrenciaTipo.TextoDescricaoPadrao,
                OcorrenciaTipoFilhos = new SelectList(ocorrenciaTipoFilhos, "id", "nome"),
                EhUltimoNivel = ocorrenciaTipo.EhUltimoNivel
            };


            if (ocorrenciaTipo.EhUltimoNivel && carregarUltimoNivel)
            {
                previsaoInicial = _ocorrenciaTipoServico.CalcularDataSla((int) ocorrenciaTipo.Id, null);

                //var feriados = _feriadoServico.ObterTodos().Where(x => x.Uf == null || x.Uf == "SP" || x.Uf == "" || x.Uf == " ");

                //var listaDatasFeriado =
                //    feriados.Select(
                //            feriado =>
                //                new DateTime(feriado.Ano <= 0 ? DateTime.Now.Year : feriado.Ano, feriado.Mes, feriado.Dia))
                //        .ToList();

                //previsaoInicial = Metodos.CalcularSla(ocorrenciaTipo.TempoPrevistoAtendimento, listaDatasFeriado,
                //   !ocorrenciaTipo.TempoPrevistoCorrido);

                retorno.StatusEntidades =
                    new SelectList(_statusEntidadeServico.ObterPorOcorrenciaTipoId(ocorrenciaTipoId), "id", "nome");
                retorno.Previsao = previsaoInicial.HasValue ? previsaoInicial.Value.ToString("dd/MM/yyyy HH:mm") : "";
                retorno.DataPrevisao = previsaoInicial;
                //retorno.TempoPrevistoAtendimentoPorExtenso = ocorrenciaTipo.TempoPrevistoPorExtenso(previsaoInicial, !ocorrenciaTipo.TempoPrevistoCorrido);
            }

            return retorno;
        }

        public MotivoSelecionadoViewModel CarregarMotivoSelecionado(MotivoSelecionadoViewModel model)
        {
            var ocorrenciaTipo = _ocorrenciaTipoServico.ObterPorId(model.Id);

            if (ocorrenciaTipo.EhUltimoNivel)
            {
                var feriados = _feriadoServico.ObterTodos().Where(x => x.Uf == null || x.Uf == "SP");

                var listaDatasFeriado =
                    feriados.Select(
                            feriado =>
                                new DateTime(feriado.Ano <= 0 ? DateTime.Now.Year : feriado.Ano, feriado.Mes,
                                    feriado.Dia))
                        .ToList();

                var previsaoInicial = Metodos.CalcularSla(ocorrenciaTipo.TempoPrevistoAtendimento, listaDatasFeriado,
                    !ocorrenciaTipo.TempoPrevistoCorrido);

                model.Previsao = previsaoInicial.HasValue ? previsaoInicial.Value.ToString("dd/MM/yyyy HH:mm") : null;

                model.StatusPorMotivo = new SelectList(_statusEntidadeServico.ObterPorOcorrenciaTipoId(model.Id), "id",
                    "nome");
                model.Sla = ocorrenciaTipo.TempoPrevistoDeAtendimentoPorExtenso();
            }

            model.Filhos = new SelectList(_ocorrenciaTipoServico.ObterPor(model.Id), "id", "nome");
            model.NomeCompleto = ocorrenciaTipo.NomeExibicao;

            model.VincularLocal = ocorrenciaTipo.VincularLocal;

            return model;
        }
    }
}
