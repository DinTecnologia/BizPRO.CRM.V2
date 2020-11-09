using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IPotenciaisClienteServico : IServico<PotenciaisCliente>
    {
        PotenciaisCliente AdicionarPotenciaisCliente(PotenciaisCliente entidade);
        IEnumerable<PotenciaisCliente> PesquisarPotenciaisCliente(string nome, string documento, string protocolo);
        PotenciaisCliente EditarPotenciaisCliente(PotenciaisCliente entidade);
        PotenciaisCliente AtualizarConverterCliente(PotenciaisCliente entidade);
    }
}
