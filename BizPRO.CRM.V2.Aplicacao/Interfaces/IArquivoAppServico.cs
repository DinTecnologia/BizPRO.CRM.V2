using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IArquivoAppServico
    {
        ArquivoFormViewModel Novo(long? ocorrenciaId, long? pessoaFisicaId, long? pessoaJuridicaId);
        ArquivoFormViewModel Adicionar(ArquivoFormViewModel model, string criadoPor);

        IEnumerable<ArquivoListaViewModel> ListarArquivos(long? ocorrenciaId, long? pessoaFisicaId,
            long? pessoaJuridicaId);

        ArquivoFormViewModel AbrirArquivo(long id);
    }
}
