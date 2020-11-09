using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Camadas.Aplicacao.Interfaces
{
    public interface IAtividadesFilaRepositorioDal
    {
        IEnumerable<AtividadeFilasApoio> ObterAtividadesFila(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
            bool? atrasadoAtribuicao, bool? atrasadoAtendimento, string nomeCliente, string emailCliente,
            string assuntoAtividade);


    }
}
