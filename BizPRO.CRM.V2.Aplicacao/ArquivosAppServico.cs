using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ArquivosAppServico : AppServicoDapper, IArquivosAppServico
    {
        private readonly IArquivoServico _arquivosServico;

        public ArquivosAppServico(IArquivoServico arquivosServico)
        {
            _arquivosServico = arquivosServico;
        }

        public ArquivoViewModel ObterArquivo(long id)
        {
            var arquivos = new ArquivoViewModel();
            var lstArquivos = _arquivosServico.ObterPorId(id);
            if (lstArquivos == null) return null;
            arquivos.Id = lstArquivos.Id;
            arquivos.Nome = lstArquivos.Nome;
            arquivos.Caminho = lstArquivos.Caminho;
            arquivos.CriadoEm = lstArquivos.CriadoEm;
            arquivos.Extensao = lstArquivos.Extensao;
            arquivos.Tamanho = lstArquivos.Tamanho;
            return arquivos;
        }
    }
}
