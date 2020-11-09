using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IPotenciaisClienteAppServico
    {
        PotenciaisClienteViewModel Carregar();
        List<CidadeViewModel> ObterCidadesPorUf(string uf);
        PotenciaisClienteViewModel Adicionar(PotenciaisClienteViewModel model, string usuarioId);
        IEnumerable<listarPotenciaisClienteViewModel> Pesquisar(string nome, string documento, string protocolo);
        PotenciaisClienteViewModel BuscarCliente(long id);
        PotenciaisClienteViewModel Editar(PotenciaisClienteViewModel modelusuarioId, string usuarioId);
        PotenciaisClienteViewModel ConverterEmCliente(PotenciaisClienteViewModel model);
        PotenciaisClienteViewModel ObterPorPotencialClienteId(long? id);
    }
}
