using System;
using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Dapper;
using DapperExtensions;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class FilaServico : IFilaServico
    {
        private readonly IFilaRepositorio _repositorio;
        private readonly IConfiguracaoContasEmailsServico _configuracaoContasEmailsServico;
        private readonly IRepositorioDal _repositorioDal;

        public FilaServico(IFilaRepositorio repositorio,
            IConfiguracaoContasEmailsServico configuracaoContasEmailsServico, IRepositorioDal repositorioDal)
        {
            _repositorio = repositorio;
            _configuracaoContasEmailsServico = configuracaoContasEmailsServico;
            _repositorioDal = repositorioDal;
        }

        public IEnumerable<Fila> ObterFilasMenu(string userId)
        {
            return _repositorio.ObterFilaMenu(userId);
        }

        public IEnumerable<Fila> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public Fila AtualizarFila(int id, string nome, bool ativo,
            bool aceitaLigacao, bool aceitaEmail, bool aceitaTarefa, bool aceitaChatSms, bool aceitaChatWeb,
            int? contaParaDisparo, string alteradoPorUserId, DateTime? alteradoEm, int tempoEmMinutosParaSlaDeFechamento,
            int tempoEmMinutosParaSlaPrimeiroAtendimento
        )
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ID", id);
            parametros.Add("@NOME", nome);
            parametros.Add("@ATIVO", ativo);
            parametros.Add("@ACEITA_LIGACAO", aceitaLigacao);
            parametros.Add("@ACEITA_EMAIL", aceitaEmail);
            parametros.Add("@ACEITA_TAREFA", aceitaTarefa);
            parametros.Add("@ACEITA_CHATSMS", aceitaChatSms);
            parametros.Add("@ACEITA_CHATWEB", aceitaChatWeb);
            parametros.Add("@ID_CONTA", contaParaDisparo);
            parametros.Add("@ALTERADOPOR", alteradoPorUserId);
            parametros.Add("@ALTERADOEM", alteradoEm);
            parametros.Add("@tempoEmMinutosParaSLADeFechamento", tempoEmMinutosParaSlaDeFechamento);
            parametros.Add("@tempoEmMinutosParaSLAPrimeiroAtendimento", tempoEmMinutosParaSlaPrimeiroAtendimento);

            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_upd_Fila", parametros);
            return listaRetorno.FirstOrDefault();
        }

        public IEnumerable<Fila> ObterFilasPorNome(string nome)
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            where.Predicates.Add(Predicates.Field<Fila>(f => f.Nome, Operator.Eq, nome));
            var retorno = _repositorio.ObterPor(where);

            foreach (var fila in retorno)
            {
                if (fila.ContaParaDisparoDeEmailConfiguracaoContasEmailsId != null)
                    fila.ContaEmailDisparo =
                        _configuracaoContasEmailsServico.ObterPorId(
                            (int)fila.ContaParaDisparoDeEmailConfiguracaoContasEmailsId);
            }

            return retorno;
        }

        public IEnumerable<Fila> ObterFilasDisparoDeEmails()
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            where.Predicates.Add(Predicates.Field<Fila>(f => f.Ativo, Operator.Eq, true));
            where.Predicates.Add(Predicates.Field<Fila>(f => f.AceitaEmails, Operator.Eq, true));
            var retorno = _repositorio.ObterPor(where);

            foreach (var fila in retorno)
            {
                if (fila.ContaParaDisparoDeEmailConfiguracaoContasEmailsId != null)
                    fila.ContaEmailDisparo =
                        _configuracaoContasEmailsServico.ObterPorId(
                            (int)fila.ContaParaDisparoDeEmailConfiguracaoContasEmailsId);
            }
            return retorno;
        }

        public IEnumerable<Fila> ObterFilasLigacao()
        {
            return _repositorio.ObterFilaLigacao();
        }

        public IEnumerable<Fila> ObterFilasFiltroDashboard(string userId)
        {
            return _repositorio.ObterFilasFiltroDashboard(userId);
        }

        public IEnumerable<Fila> ObterFilasPorUsuario(string userId, bool? aceitaLigacao, bool? aceitaEmail,
            bool? aceitaTarefa,
            bool? aceitaChatSms, bool? aceitaChatWeb, bool? aceitaChatMessenger, bool? ativo)
        {
            return _repositorio.ObterFilasPorUsuario(userId,
                aceitaLigacao,
                aceitaEmail,
                aceitaTarefa,
                aceitaChatSms,
                aceitaChatWeb,
                aceitaChatMessenger,
                ativo);
        }

        public Fila Adicionar(Fila entidade)
        {
            if (!entidade.IsValid())
                return entidade;

            _repositorio.Adicionar(entidade);

            return entidade;
        }

        public ValidationResult Atualizar(Fila entidade, string atualizadoPorUserId)
        {
            var fila = _repositorio.ObterPorId(entidade.Id);

            if (fila == null)
            {
                var retorno = new ValidationResult();
                retorno.Add(
                    new ValidationError("Não foi encontrado nenhuma Fila com o Id: " + entidade.Id +
                                        ", por isso não foi possível atualizar"));
                return retorno;
            }

            fila.AtualizarEntidade(entidade, atualizadoPorUserId);

            if (!fila.IsValid())
                return fila.ValidationResult;

            _repositorio.Atualizar(fila);
            return fila.ValidationResult;
        }

        public IEnumerable<Fila> ObterPor(bool? aceitaLigacao, bool? aceitaEmail, bool? aceitaTarefa,
            bool? aceitaChatSms, bool? aceitaChatWeb, int? departamentoId)
        {
            return _repositorio.ObterPor(aceitaLigacao, aceitaEmail, aceitaTarefa, aceitaChatSms, aceitaChatWeb,
                departamentoId);
        }

        public Fila ObterPorId(int id)
        {
            return _repositorio.ObterPorId(id);
        }

        //ADO.net 21/01/2020 Breno
        public Fila GetFila(int id)
        {
            return _repositorioDal.GetFila(id);
        }


        public IEnumerable<Fila> ObterFilasParaAlterar(long atividadeId)
        {
            return _repositorio.ObterFilasParaAlterar(atividadeId);
        }

        public IEnumerable<Fila> ObterVisaoAdmin()
        {
            return _repositorio.ObterVisaoAdmin();
        }

        public IEnumerable<Fila> ObterPorDepartamentoId(int? departamentoId)
        {
            return _repositorio.ObterPorDepartamentoId(departamentoId);
        }

        public IEnumerable<Fila> ObterPor(int? departamentoId, string usuarioId)
        {
            return _repositorio.ObterPor(departamentoId, usuarioId);
        }

        public IEnumerable<Fila> ObterFilaPorCanalId(int? canalId)
        {
            return _repositorio.ObterFilaPorCanalId(canalId).OrderBy(o => o.Nome);
        }
    }
}
