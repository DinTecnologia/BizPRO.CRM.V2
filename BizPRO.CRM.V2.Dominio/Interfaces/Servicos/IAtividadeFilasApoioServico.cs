using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAtividadeFilasApoioServico : IServico<AtividadeFilasApoio>
    {

        IEnumerable<AtividadeFilasApoio> ObterAtividades(string criadoPorId, string responsavelPorId,
           DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
           bool? atrasadoAtribuicao, bool? atrasadoAtendimento, string nomeCliente, string emailCliente, string assuntoAtividade);

        IEnumerable<AtividadeFilasApoio> ObterTotalAtividadesFila(string criadoPorId, string responsavelPorId,
          DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
          bool? atrasadoAtribuicao, bool? atrasadoAtendimento, string nomeCliente, string emailCliente, string assuntoAtividade);

        IEnumerable<AtividadeFilasApoio> ObterAtividadesSupervisao(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool? finalizado, bool? slaAtribuicao,
            bool? slaAtendimento, bool? slaEstourado, string emailAssunto);

        //IEnumerable<AtividadeFilasApoio> ObterAtividades(string criadoPorId, string responsavelPorId,
        //    DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
        //    bool? atrasadoAtribuicao, bool? atrasadoAtendimento);

        //IEnumerable<AtividadeFilasApoio> ObterAtividadesSupervisao(string criadoPorId, string responsavelPorId,
        //    DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool? finalizado, bool? slaAtribuicao,
        //    bool? slaAtendimento, bool? slaEstourado);
    }
}
