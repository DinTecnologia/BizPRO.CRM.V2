using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AtividadeFilasApoioServico : Servico<AtividadeFilasApoio>, IAtividadeFilasApoioServico
    {
        private readonly IAtividadeFilasApoioRepositorio _respositorio;

        public AtividadeFilasApoioServico(IAtividadeFilasApoioRepositorio respositorio)
            : base(respositorio)
        {
            _respositorio = respositorio;
        }

        public IEnumerable<AtividadeFilasApoio> ObterAtividades(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
            bool? atrasadoAtribuicao, bool? atrasadoAtendimento)
        {
            return _respositorio.ObterAtividadesFila(criadoPorId, responsavelPorId, dataInicio, dataFim, status, filaId,
                finalizado, atrasadoAtribuicao, atrasadoAtendimento, null, null, null);
        }

        public IEnumerable<AtividadeFilasApoio> ObterAtividades(string criadoPorId, string responsavelPorId, DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado, bool? atrasadoAtribuicao, bool? atrasadoAtendimento, string nomeCliente, string emailCliente, string assuntoAtividade)
        {
            return _respositorio.ObterAtividadesFila(criadoPorId, responsavelPorId, dataInicio, dataFim, status, filaId,
                finalizado, atrasadoAtribuicao, atrasadoAtendimento, nomeCliente, emailCliente, assuntoAtividade);
        }

        public IEnumerable<AtividadeFilasApoio> ObterTotalAtividadesFila(string criadoPorId, string responsavelPorId, DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado, bool? atrasadoAtribuicao, bool? atrasadoAtendimento, string nomeCliente, string emailCliente, string assuntoAtividade)
        {
            return _respositorio.ObterTotalAtividadesFila(criadoPorId, responsavelPorId, dataInicio, dataFim, status, filaId,
                finalizado, atrasadoAtribuicao, atrasadoAtendimento, nomeCliente, emailCliente, assuntoAtividade);
        }

        public IEnumerable<AtividadeFilasApoio> ObterAtividadesSupervisao(string criadoPorId, string responsavelPorId,
            DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool? finalizado, bool? slaAtribuicao,
            bool? slaAtendimento, bool? slaEstourado, string emailAssunto)
        {
            return _respositorio.ObterAtividadesFilaSupervisao(criadoPorId, responsavelPorId, dataInicio, dataFim,
                status, filaId, finalizado, slaAtribuicao, slaAtendimento, slaEstourado, emailAssunto);
        }
    }

    //public class AtividadeFilasApoioServico : Servico<AtividadeFilasApoio>, IAtividadeFilasApoioServico
    //{
    //    private readonly IAtividadeFilasApoioRepositorio _respositorio;

    //    public AtividadeFilasApoioServico(IAtividadeFilasApoioRepositorio respositorio)
    //        : base(respositorio)
    //    {
    //        _respositorio = respositorio;
    //    }

    //    public IEnumerable<AtividadeFilasApoio> ObterAtividades(string criadoPorId, string responsavelPorId,
    //        DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool finalizado,
    //        bool? atrasadoAtribuicao, bool? atrasadoAtendimento)
    //    {
    //        return _respositorio.ObterAtividadesFila(criadoPorId, responsavelPorId, dataInicio, dataFim, status, filaId,
    //            finalizado, atrasadoAtribuicao, atrasadoAtendimento);
    //    }

    //    public IEnumerable<AtividadeFilasApoio> ObterAtividadesSupervisao(string criadoPorId, string responsavelPorId,
    //        DateTime? dataInicio, DateTime? dataFim, string status, int? filaId, bool? finalizado, bool? slaAtribuicao,
    //        bool? slaAtendimento, bool? slaEstourado)
    //    {
    //        return _respositorio.ObterAtividadesFilaSupervisao(criadoPorId, responsavelPorId, dataInicio, dataFim,
    //            status, filaId, finalizado, slaAtribuicao, slaAtendimento, slaEstourado);
    //    }
    //}
}
