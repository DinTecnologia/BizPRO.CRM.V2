using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ConfiguracaoAppServico : IConfiguracaoAppServico
    {
        private readonly IConfiguracaoServico _servicoConfiguracao;
        private readonly IEntidadeServico _servicoEntidade;
        private readonly ICidadeServico _servicoCidade;
        private readonly IPerfilServico _servicoPerfil;
        private readonly IEquipeServico _equipeServico;

        public ConfiguracaoAppServico(IConfiguracaoServico servicoConfiguracao, IEntidadeServico servicoEntidade,
            ICidadeServico servicoCidade, IPerfilServico servicoPerfil, IEquipeServico equipeServico)
        {
            _servicoConfiguracao = servicoConfiguracao;
            _servicoEntidade = servicoEntidade;
            _servicoCidade = servicoCidade;
            _servicoPerfil = servicoPerfil;
            _equipeServico = equipeServico;
        }

        public Configuracao ObterTipoLogin()
        {
            return _servicoConfiguracao.ObterTipoLogin();
        }

        public string ObterTitle()
        {
            return _servicoConfiguracao.ObterTitle();
        }

        public string ObterTitleMenu()
        {
            return _servicoConfiguracao.ObterTitleMenu();
        }

        public string ObterSenhaPadrao()
        {
            var config = _servicoConfiguracao.ObterPorSigla("SEPAD");

            if (config != null)
                return _servicoConfiguracao.ObterPorSigla("SEPAD").Valor;
            else
                return "";
        }

        public string ObterDiretorioAnexoEmail()
        {
            var configuracao = new Configuracao();
            configuracao.SetarUrlEmailAnexos();

            var retorno = _servicoConfiguracao.ObterPorSigla(configuracao.Sigla);

            return retorno != null ? retorno.Valor : "Endereço de Diretório de Anexo não cadastrado";
        }

        public string ObterDiretorioUploadChat()
        {
            var configuracao = new Configuracao();
            configuracao.SetarUrlChatAnexos();
            var retorno = _servicoConfiguracao.ObterPorSigla(configuracao.Sigla);
            return retorno != null ? retorno.Valor : null;
        }

        public Configuracao ObterPorSigla(string sigla)
        {
            return _servicoConfiguracao.ObterPorSigla(sigla);
        }

        public string ObterScriptEntidade(string nomeLogico)
        {
            return _servicoEntidade.ObterScriptEntidade(nomeLogico);
        }

        public List<ConfiguracoesViewModel> ObterConfiguracoes()
        {
            var e = new List<ConfiguracoesViewModel>();

            var retorno = _servicoConfiguracao.ObterPor(new Configuracao());
            foreach (var x in retorno)
            {
                var eAux = new ConfiguracoesViewModel
                {
                    id = x.Id,
                    alteradoPorUserID = x.AlteradoPorUserId,
                    descricao = x.Descricao,
                    sigla = x.Sigla,
                    valor = x.Valor,
                    criadoPorUserID = x.CriadoPorUserId,
                    ativo = x.Ativo
                };

                if (x.AlteradoEm != null) eAux.alteradoEm = x.AlteradoEm.Value;
                e.Add(eAux);
            }
            return e;
        }

        public bool Adicionar(ConfiguracoesViewModel model)
        {
            var config = new Configuracao(model.sigla, model.descricao, model.valor, model.ativo, model.criadoPorUserID);
            var retorno = _servicoConfiguracao.Adicionar(config);
            return retorno;
        }

        public ConfiguracoesViewModel ObterPorId(ConfiguracoesViewModel model)
        {
            var config = new ConfiguracoesViewModel();
            var retornoConfig = _servicoConfiguracao.ObterPorId(model.id);
            if (retornoConfig == null) return config;
            config.id = retornoConfig.Id;
            config.alteradoEm = retornoConfig.AlteradoEm;
            config.alteradoPorUserID = retornoConfig.AlteradoPorUserId;
            config.ativo = retornoConfig.Ativo;
            config.criadoEm = retornoConfig.CriadoEm;
            config.criadoPorUserID = retornoConfig.CriadoPorUserId;
            config.descricao = retornoConfig.Descricao;
            config.sigla = retornoConfig.Sigla;
            config.valor = retornoConfig.Valor;
            config.ValidationResult = retornoConfig.ValidationResult;
            return config;
        }

        public bool Delete(long id)
        {
            var retornoConfig = _servicoConfiguracao.ObterPorId(id);
            if (retornoConfig == null) return false;
            _servicoConfiguracao.Deletar(retornoConfig);
            return true;
        }

        public bool Atualizar(ConfiguracoesViewModel model)
        {
            var config = new Configuracao(model.id, model.sigla, model.descricao, model.valor, model.ativo,
                model.alteradoPorUserID, model.criadoPorUserID, model.criadoEm);
            var retorno = _servicoConfiguracao.Atualizar(config);
            return retorno;
        }

        public IEnumerable<Cidade> ObterCidadesPorUf(string uf)
        {
            return _servicoCidade.ObterCidadesPorEstado(uf);
        }

        public IEnumerable<Equipe> ObterPorDepartamentoId(int DepartamentoId)
        {
            return _equipeServico.ObterPorDepartamentoId(DepartamentoId);
        }

        public MenuNewViewModel ObterMenu(string usuarioId, string url)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Perfil> ObterPerfis(string usuarioId)
        {
            return _servicoPerfil.ObterPerfis(usuarioId);
        }
    }
}
