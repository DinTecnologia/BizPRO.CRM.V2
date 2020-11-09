using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IConfiguracaoServico : IServico<Configuracao>
    {
        Configuracao ObterTipoLogin();
        string ObterTitle();
        string ObterTitleMenu();
        IEnumerable<Configuracao> ObterPor(Configuracao entidade);
        Configuracao ObterUrlLoginExternoToken();
        Configuracao ObterPorSigla(string sigla);
        Configuracao BuscarDiretorioEmailAnexos();
        Configuracao SetarUrlTodosAnexosEmail();
        bool VincularOcorrenciaAtendimentoManual();
        bool Adicionar(Configuracao configuracao);
        bool Atualizar(Configuracao configuracao);
        string ObterNomeCampoChave1Ocorrencia();
        string ObterValorPadraoCampoChave1Ocorrencia();
        Configuracao ObterDiretorioArquivosChat();
        Configuracao ObterUrlScreenPopUpChat();
        Configuracao ObterQuantidadeConversaPadrao();
        Configuracao ObterTipoAberturaOcorrencia();
    }
}
