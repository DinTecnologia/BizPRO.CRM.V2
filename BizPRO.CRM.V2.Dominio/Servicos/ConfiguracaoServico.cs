using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DapperExtensions;
using System.Data;
using Dapper;
using DomainValidation.Validation;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ConfiguracaoServico : Servico<Configuracao>, IConfiguracaoServico
    {
        private readonly IConfiguracaoRepositorio _repositorio;
        private readonly ValidationResult _validationResult;

        public ConfiguracaoServico(IConfiguracaoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _validationResult = new ValidationResult();
        }

        public IEnumerable<Configuracao> ObterTipoLogin()
        {
            return _repositorio.ObterPorSigla("TPOLG");
        }

        public string ObterTitle()
        {
            var title = "..:: BIZPRO CRM ::..";
            var listaConfiguracoes = _repositorio.ObterPorSigla("TITTL");

            if (listaConfiguracoes != null)
                if (listaConfiguracoes.Count() > 0)
                    title = listaConfiguracoes.FirstOrDefault().Valor;

            return title;
        }

        public string ObterTitleMenu()
        {
            var title = "BIZPRO";
            var listaConfiguracoes = _repositorio.ObterPorSigla("TITMN");

            if (listaConfiguracoes != null)
                if (listaConfiguracoes.Any())
                    title = listaConfiguracoes.FirstOrDefault().Valor;

            return title;
        }

        Configuracao IConfiguracaoServico.ObterTipoLogin()
        {
            var retorno = new Configuracao();
            retorno.LoginDefault();

            var listaConfiguracoes = _repositorio.ObterPorSigla("TPOLG");
            if (listaConfiguracoes != null)
                if (listaConfiguracoes.Any())
                    retorno = listaConfiguracoes.OrderByDescending(p => p.CriadoEm).FirstOrDefault();

            return retorno;
        }

        public IEnumerable<Configuracao> ObterPor(Configuracao entidade)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            if (!string.IsNullOrEmpty(entidade.Sigla))
                where.Predicates.Add(Predicates.Field<Configuracao>(f => f.Sigla, Operator.Eq, entidade.Sigla));
            where.Predicates.Add(Predicates.Field<Configuracao>(f => f.Ativo, Operator.Eq, true));
            return _repositorio.ObterPor(where);
        }

        public Configuracao ObterUrlLoginExternoToken()
        {
            var configuracao = new Configuracao();
            configuracao.SetarUrlLoginExternoToken();
            return ObterPor(configuracao).OrderByDescending(o => o.Id).FirstOrDefault();
        }

        public Configuracao ObterPorSigla(string sigla)
        {
            var retorno = new Configuracao();
            var configuracoes = _repositorio.ObterPorSigla(sigla);


            if (configuracoes == null)
            {
                retorno.ValidationResult.Add(new ValidationError("Nenhuma configuração retornada para a sigla:" + sigla));
                return retorno;
            }

            if (!configuracoes.Any())
            {
                retorno.ValidationResult.Add(new ValidationError("Nenhuma configuração retornada para a sigla:" + sigla));
                return retorno;
            }

            retorno = configuracoes.FirstOrDefault();
            return retorno;
        }

        public Configuracao BuscarDiretorioEmailAnexos()
        {
            var configuracao = new Configuracao();
            configuracao.SetarUrlEmailAnexos();
            return ObterPorSigla(configuracao.Sigla);
        }

        public Configuracao ObterDiretorioArquivosChat()
        {
            var configuracao = new Configuracao();
            configuracao.SetarUrlChatAnexos();
            return ObterPorSigla(configuracao.Sigla);
        }

        public Configuracao SetarUrlTodosAnexosEmail()
        {
            var configuracao = new Configuracao();
            configuracao.SetarUrlTodosAnexosEmail();
            return ObterPorSigla(configuracao.Sigla);
        }

        public bool VincularOcorrenciaAtendimentoManual()
        {
            bool retorno = false;
            var configuracao = new Configuracao();
            configuracao.SetarVincularOcorrenciaAtendimentoManual();
            configuracao = ObterPorSigla(configuracao.Sigla);

            if (configuracao != null)
                if (configuracao.Valor == "1")
                    retorno = true;

            return retorno;
        }

        public bool Adicionar(Configuracao configuracao)
        {
            _repositorio.Adicionar(configuracao);
            return configuracao.Id > 0;
        }

        public bool Atualizar(Configuracao configuracao)
        {
            _repositorio.Atualizar(configuracao);
            return configuracao.Id > 0;
        }

        public string ObterNomeCampoChave1Ocorrencia()
        {
            var configuracao = new Configuracao();
            configuracao.SetarNomeOcorrenciaCampoChave1();
            configuracao = ObterPorSigla(configuracao.Sigla);
            return configuracao.ValidationResult.IsValid ? configuracao.Valor : null;
        }

        public string ObterValorPadraoCampoChave1Ocorrencia()
        {
            var configuracao = new Configuracao();
            configuracao.SetarRegraPreenchimentoOcorrenciaCampoChave1();
            configuracao = ObterPorSigla(configuracao.Sigla);
            return configuracao.ValidationResult.IsValid ? RegraCampoChave1(configuracao.Valor) : null;
        }

        protected string RegraCampoChave1(string valor)
        {
            var parte = Guid.NewGuid().ToString().Substring(0, 6);
            valor = valor.Replace("XXXXXX", parte);
            return valor;
        }

        public Configuracao ObterUrlScreenPopUpChat()
        {
            var configuracao = new Configuracao();
            configuracao.SetarUrlScreenPopUpChat();
            return ObterPor(configuracao).OrderByDescending(o => o.Id).FirstOrDefault();
        }

        public Configuracao ObterQuantidadeConversaPadrao()
        {
            var configuracao = new Configuracao();
            configuracao.SetarChatQuantidadeAtendimentoSimultaneo();
            return ObterPor(configuracao).OrderByDescending(o => o.Id).FirstOrDefault();
        }

        public Configuracao ObterTipoAberturaOcorrencia()
        {
            var configuracao = new Configuracao();
            configuracao.SetarTipoAberturaOcorrencia();
            return ObterPorSigla(configuracao.Sigla);
        }
    }
}

