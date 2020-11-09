using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IConfiguracaoAppServico
    {
        Configuracao ObterTipoLogin();
        string ObterTitle();
        string ObterTitleMenu();
        string ObterSenhaPadrao();
        string ObterDiretorioAnexoEmail();
        Configuracao ObterPorSigla(string sigla);
        string ObterScriptEntidade(string nomeLogico);
        List<ConfiguracoesViewModel> ObterConfiguracoes();
        bool Adicionar(ConfiguracoesViewModel model);
        ConfiguracoesViewModel ObterPorId(ConfiguracoesViewModel model);
        bool Atualizar(ConfiguracoesViewModel model);
        bool Delete(long id);
        IEnumerable<Cidade> ObterCidadesPorUf(string uf);
        IEnumerable<Equipe> ObterPorDepartamentoId(int DepartamentoId);
        MenuNewViewModel ObterMenu(string usuarioId, string url);
        string ObterDiretorioUploadChat();
        IEnumerable<Perfil> ObterPerfis(string usuarioId);
    }
}
