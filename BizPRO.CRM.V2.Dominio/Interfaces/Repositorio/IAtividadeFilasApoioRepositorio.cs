using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IAtividadeFilasApoioRepositorio : IRepositorio<AtividadeFilasApoio>
    {
        IEnumerable<AtividadeFilasApoio> ObterAtividadesFila(string userId);

        IEnumerable<AtividadeFilasApoio> ObterAtividadesFila(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
            bool? atrasadoAtribuicao, bool? atrasadoAtendimento, string nomeCliente, string emailCliente, string assuntoAtividade);

        IEnumerable<AtividadeFilasApoio> ObterTotalAtividadesFila(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
            bool? atrasadoAtribuicao, bool? atrasadoAtendimento, string nomeCliente, string emailCliente, string assuntoAtividade);


        IEnumerable<AtividadeFilasApoio> ObterAtividadesFilaSupervisao(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool? finalizado, bool? slaAtribuicao,
            bool? slaAtendimento, bool? slaTempoEstourado, string emailAssunto);

        //IEnumerable<AtividadeFilasApoio> ObterAtividadesFila(string userId);

        //IEnumerable<AtividadeFilasApoio> ObterAtividadesFila(string criadoPorId, string responsavelPorId,
        //    DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
        //    bool? atrasadoAtribuicao, bool? atrasadoAtendimento);

        //IEnumerable<AtividadeFilasApoio> ObterAtividadesFilaSupervisao(string criadoPorId, string responsavelPorId,
        //    DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool? finalizado, bool? slaAtribuicao,
        //    bool? slaAtendimento, bool? slaTempoEstourado);
    }
}
