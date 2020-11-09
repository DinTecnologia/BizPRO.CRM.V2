using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IAtendimentoRepositorio : IRepositorio<Atendimento>
    {
        string GerarNumeroProtocolo(DateTime? data);
        IEnumerable<Atendimento> BuscarPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId, int? quantidade);
        Atendimento BuscarPorProtocolo(string protocolo);
        Atendimento AdicionarAtendimento(Atendimento entidade);

        Atendimento AdicionarAtendimentoCompleto(Atendimento entidade);
    }
}
