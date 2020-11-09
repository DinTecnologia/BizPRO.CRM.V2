using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class FilaAppService : IFilaAppServico
    {
        private readonly IFilaServico _filaServico;
        private readonly IAtividadeFilaServico _atividadeFilaServico;
        private readonly IConfiguracaoContasEmailsServico _configuracaoContasEmailServico;
        private readonly IAspNetRolesFilaServico _aspNetRolesFilaServico;
        private readonly IUsuarioServico _usuarioServico;
        private readonly IAtividadeServico _atividadeServico;
        private readonly IFilaRepositorioDal _filaReposiotorioServicoDal;


        public FilaAppService(IFilaServico filaServico, IConfiguracaoContasEmailsServico configuracaoContasEmailServico,
            IAspNetRolesFilaServico aspNetRolesFilaServico, IUsuarioServico usuarioServico,
            IAtividadeServico atividadeServico, IAtividadeFilaServico atividadeFilaServico, IFilaRepositorioDal filaReposiotorioServicoDal)
        {
            _filaServico = filaServico;
            _configuracaoContasEmailServico = configuracaoContasEmailServico;
            _aspNetRolesFilaServico = aspNetRolesFilaServico;
            _usuarioServico = usuarioServico;
            _atividadeServico = atividadeServico;
            _atividadeFilaServico = atividadeFilaServico;
            _filaReposiotorioServicoDal = filaReposiotorioServicoDal;
        }

        public IEnumerable<FilaViewModel> ObterTodos()
        {
            var retorno = new List<FilaViewModel>();
            var filas = _filaServico.ObterTodos();
            var opcoes = _configuracaoContasEmailServico.ObterTodos();

            foreach (var item in filas)
            {
                retorno.Add(new FilaViewModel(item.Id, item.Nome, item.Ativo, item.CriadoPorUserId, item.CriadoEm,
                    item.AceitaLigacoes,
                    item.AceitaEmails, item.AceitaTarefas, item.AceitaChatSms, item.AceitaChatWeb,
                    item.ContaParaDisparoDeEmailConfiguracaoContasEmailsId,
                    item.AlteradoPorUserId, item.AlteradoEm, opcoes, item.DepartamentoId,
                    item.TempoEmSegundosInatividadeContato));
            }

            return retorno;
        }

        public FilaViewModel SalvarFila(FilaViewModel viewModel, string userId)
        {
            var fila = new Fila(viewModel.Id, viewModel.Nome, viewModel.Ativo, userId, viewModel.aceitaLigacoes,
                viewModel.aceitaLigacoes, viewModel.aceitaTarefas, viewModel.aceitaChatSMS, viewModel.aceitaChatWeb,
                viewModel.contaParaDisparoDeEmail_ConfiguracaoContasEmailsID, viewModel.alteradoPorUserID,
                viewModel.alteradoEm, viewModel.tempoEmMinutosParaSLADeFechamento,
                viewModel.tempoEmMinutosParaSLAPrimeiroAtendimento, viewModel.GerarProtocoloLeituraEmail,
                viewModel.EnviarEmailRespostaLeitura, viewModel.EmailModelId, viewModel.DepartamentoId,
                viewModel.TempoEmSegundoInatividadeContato, viewModel.TempoEmSegundoAvisoInatividadeContato);

            if (fila.Id > 0)
                fila.ValidationResult = _filaServico.Atualizar(fila, userId);
            else
                fila = _filaServico.Adicionar(fila);

            _aspNetRolesFilaServico.DeletaRolesFilas(fila.Id);

            foreach (var item in viewModel.roles)
            {
                _aspNetRolesFilaServico.InserirFilas(new AspNetRolesFila(fila.Id, item));
            }

            return new FilaViewModel(fila.Id, fila.Nome);
        }

        public ComboFilaViewModel ComboFilas(bool? ativo, long? filaId)
        {
            var list = new List<FilaViewModel>();
            IEnumerable<Fila> listaFilas;

            listaFilas = ativo == null
                ? _filaServico.ObterTodos()
                : _filaServico.ObterTodos().Where(c => c.Ativo == ativo && c.AceitaLigacoes);

            foreach (var item in listaFilas)
            {
                list.Add(new FilaViewModel(item.Id, item.Nome));
            }

            return new ComboFilaViewModel(list.AsEnumerable(), filaId);
        }

        public FilaViewModel ObterPorId(long? filaId)
        {
            var item = _filaServico.ObterTodos().FirstOrDefault(c => c.Id == filaId);
            var usuario = _usuarioServico.ObterPorUserId(item.AlteradoPorUserId);
            var usuarioCriador = _usuarioServico.ObterPorUserId(item.CriadoPorUserId);

            return new FilaViewModel(item.Id, item.Nome, item.Ativo, item.CriadoPorUserId, item.CriadoEm,
                item.AceitaLigacoes,
                item.AceitaEmails, item.AceitaTarefas, item.AceitaChatSms, item.AceitaChatWeb,
                item.AlteradoPorUserId, item.AlteradoEm, usuario, usuarioCriador, item.TempoEmMinutosParaSlaDeFechamento,
                item.TempoEmMinutosParaSlaPrimeiroAtendimento, item.DepartamentoId,
                item.TempoEmSegundosInatividadeContato);
        }

        public bool UsuarioPossuiFilaEmail(string userId)
        {
            //var filasUsuario = _filaServico.ObterFilasPorUsuario(userId, null, true, null, null, null, null, true);
            //return filasUsuario.Any();

            IEnumerable<Fila> filaUsuario = _filaReposiotorioServicoDal.ObterFilasPorUsuarioDal(userId, null, true, null, null, null, null, true);
            return filaUsuario.Any();

        }

        public long ObterFilasPorNome(string nome)
        {
            var filas = _filaServico.ObterFilasPorNome(nome);
            if (!filas.Any()) return 0;
            var firstOrDefault = filas.FirstOrDefault();
            return firstOrDefault != null ? firstOrDefault.Id : 0;
        }

        public bool UsuarioPossuiFilaChat(string userId)
        {
            var filasUsuario = _filaServico.ObterFilasPorUsuario(userId, null, null, null, null, true, null, true);
            return filasUsuario.Any();
        }

        public bool UsuarioPossuiFilaMessenger(string userId)
        {
            var filasUsuario = _filaServico.ObterFilasPorUsuario(userId, null, true, null, null, null, true, true);
            return filasUsuario.Any();
        }

        public FilaViewModel UsuarioPossuiFilaMessenger(string userId, long idfila)
        {
            var filas = new FilaViewModel();
            var filasUsuario = _filaServico.ObterFilasPorUsuario(userId, null, null, null, null, null, true, true);
            foreach (var x in filasUsuario)
            {
                if (idfila > 0)
                {
                    if (x.Id == idfila)
                    {
                        filas.Id = x.Id;
                        filas.Nome = x.Nome;
                        filas.Ativo = x.Ativo;
                        filas.CriadoPorUserID = x.CriadoPorUserId;
                        filas.aceitaLigacoes = x.AceitaLigacoes;
                        filas.aceitaEmails = x.AceitaEmails;
                        filas.aceitaTarefas = x.AceitaTarefas;
                        filas.aceitaChatSMS = x.AceitaChatSms;
                        filas.aceitaChatWeb = x.AceitaChatWeb;
                        filas.aceitaChatMessenger = x.AceitaChatMessenger;
                        filas.alteradoEm = x.AlteradoEm;
                        filas.alteradoPorUserID = x.AlteradoPorUserId;
                        filas.contaParaDisparoDeEmail_ConfiguracaoContasEmailsID =
                            x.ContaParaDisparoDeEmailConfiguracaoContasEmailsId;
                        filas.tempoEmMinutosParaSLADeFechamento = x.TempoEmMinutosParaSlaDeFechamento;
                        filas.tempoEmMinutosParaSLAPrimeiroAtendimento = x.TempoEmMinutosParaSlaPrimeiroAtendimento;
                    }
                }
                else
                {
                    filas.Id = x.Id;
                    filas.Nome = x.Nome;
                    filas.Ativo = x.Ativo;
                    filas.CriadoPorUserID = x.CriadoPorUserId;
                    filas.aceitaLigacoes = x.AceitaLigacoes;
                    filas.aceitaEmails = x.AceitaEmails;
                    filas.aceitaTarefas = x.AceitaTarefas;
                    filas.aceitaChatSMS = x.AceitaChatSms;
                    filas.aceitaChatWeb = x.AceitaChatWeb;
                    filas.aceitaChatMessenger = x.AceitaChatMessenger;
                    filas.alteradoEm = x.AlteradoEm;
                    filas.alteradoPorUserID = x.AlteradoPorUserId;
                    filas.contaParaDisparoDeEmail_ConfiguracaoContasEmailsID =
                        x.ContaParaDisparoDeEmailConfiguracaoContasEmailsId;
                    filas.tempoEmMinutosParaSLADeFechamento = x.TempoEmMinutosParaSlaDeFechamento;
                    filas.tempoEmMinutosParaSLAPrimeiroAtendimento = x.TempoEmMinutosParaSlaPrimeiroAtendimento;
                }
            }
            return filas;
        }

        public AlterarFilaFormViewModel CarregarAlterarFila(long atividadeId)
        {
            var filas = _filaServico.ObterFilasParaAlterar(atividadeId);
            var ultimaAtividadeFila = _atividadeFilaServico.ObterUltimoVinculoPraAtividade(atividadeId);
            var ultimaFila = new Fila();

            if (ultimaAtividadeFila != null)
                if (ultimaAtividadeFila.FilaId > 0)
                    ultimaFila = _filaServico.ObterPorId(ultimaAtividadeFila.FilaId);

            return new AlterarFilaFormViewModel(atividadeId.ToString(), ultimaFila, new SelectList(filas, "id", "nome"));
        }

        public AlterarFilaFormViewModel RedirecionarFila(AlterarFilaFormViewModel viewModel)
        {
            if (!viewModel.NovaFilaId.HasValue)
            {
                viewModel.ValidationResult.Add(new ValidationError("Fila não Informada"));
                return viewModel;
            }

            viewModel.ValidationResult = _atividadeServico.RedirecionarFila(viewModel.AtividadesId,
                viewModel.AlteradoPorUsuarioId, (int) viewModel.NovaFilaId);
            return viewModel;
        }

        public SelectList ObterPor(FilaFilterViewModel model)
        {
            var filas = _filaServico.ObterPor(model.DepartamentoId, model.UsuarioId);
            return new SelectList(filas, "id", "nome");
        }

        public SelectList ObterFilaPorCanalId(int? canalId)
        {
            var filas = _filaServico.ObterFilaPorCanalId(canalId);
            return new SelectList(filas, "id", "nome");
        }
    }
}
