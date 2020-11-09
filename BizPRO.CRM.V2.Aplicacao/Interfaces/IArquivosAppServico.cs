using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IArquivosAppServico
    {
        ArquivoViewModel ObterArquivo(long id);
    }
}