using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface ILocalAppServico
    {
        IEnumerable<Cidade> ObterCidadesPorUf(string uf);

        LocalOcorrenciaViewModel Carregar(long? ocorrenciaId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? contratoId);

        AdicionarEnderecoProdutoViewModel NovoEnderecoProduto();
        LocalOcorrenciaViewModel AdicionarEnderecoProduto(AdicionarEnderecoProdutoViewModel model);
        EnderecoProdutoViewModel Pesquisar(EnderecoProdutoViewModel model);
        LocalOcorrenciaViewModel ObterLocalTiposAtendimento(long localId, string enderecoProduto, string nomeSegmento);

        LocalOcorrenciaViewModel CarregarSelecionarLocal(int? segmentoId, double latitude, double longitude,
            string enderecoProduto);

        LocalViewModel CarregarPerfil(long localId, long localAtendimentoId, string nomeTipoAtendimento,
            string enderecoProduto, long? segmentoId);

        LocalOcorrenciaViewModel ObterEnderecoEntidadeSelecionada(EnderecoProdutoViewModel model);
    }
}
