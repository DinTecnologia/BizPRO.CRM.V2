using System;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IAtividadeFilasApoioAppServico
    {
        //AtividadeFilasApoioViewModel ObterDadosUsuario(string userId, string dataInicio, string dataFim, string status);
        //AtividadeFilasApoioViewModel ObterDadosUsuarioNaoConcluidas(string userId);
        //AtividadeFilasApoioViewModel CarregarSupervisao(string userId);

        //AtividadeFilasApoioViewModel ObterDadosSupervisao(string dataInicio, string dataFim, string status,
        //    string criadoPorId, string responsavelPorId, int? filaId, bool? finalizado, string tipoSla,
        //    bool? slaTempoEstourado);

        //AtividadeFilasApoioViewModel ObterDadosSupervisao(int? filaId, string dataInicio, string dataFim,
        //    bool? atrasadoAtribuicao, bool? atrasadadoAtendimento);

        //AtividadeFilasApoioViewModel ObterAtividadesFila(int filaId, bool finalizado);

        //AtividadeFilasApoioViewModel ObterMinhasAtividades(int filaId, string userId, bool finalizado);

        //AtividadeFilasApoioViewModel ObterMinhasAtividades(string usuarioId, DateTime? dataInicio, DateTime? dataFim,
        //    string status);

        AtividadeFilasApoioViewModel ObterDadosUsuario(string userId, string dataInicio, string dataFim, string status);
        AtividadeFilasApoioViewModel ObterDadosUsuarioNaoConcluidas(string userId);
        AtividadeFilasApoioViewModel CarregarSupervisao(string userId);

        AtividadeFilasApoioViewModel ObterDadosSupervisao(string dataInicio, string dataFim, string status,
            string criadoPorId, string responsavelPorId, int? filaId, bool? finalizado, string tipoSla,
            bool? slaTempoEstourado, string emailAssunto);

        AtividadeFilasApoioViewModel ObterDadosSupervisao(int? filaId, string dataInicio, string dataFim,
            bool? atrasadoAtribuicao, bool? atrasadadoAtendimento);

        AtividadeFilasApoioViewModel ObterAtividadesFila(int filaId, bool finalizado);

        AtividadeFilasApoioViewModel ObterAtividadesFila(int filaId, string nomeCliente, string emailCliente,
            string assuntoAtividade, bool finalizado);

        AtividadeFilasApoioViewModel ObterAtividadesFilaDal(int filaId, string nomeCliente, string emailCliente,
            string assuntoAtividade, bool finalizado);



        AtividadeFilasApoioViewModel ObterTotalAtividadesFila(int filaId, string nomeCliente, string emailCliente,
            string assuntoAtividade, bool finalizado);

        AtividadeFilasApoioViewModel ObterTotalAtividadesFilaDal(int filaId, string nomeCliente, string emailCliente,
            string assuntoAtividade, bool finalizado);

            AtividadeFilasApoioViewModel ObterTotalAtividadesFilasDal(string filasIds, string nomeCliente, string emailCliente,
            string assuntoAtividade, bool finalizado);

        AtividadeFilasApoioViewModel ObterMinhasAtividades(int filaId, string userId, bool finalizado);

        AtividadeFilasApoioViewModel ObterMinhasAtividades(string usuarioId, DateTime? dataInicio, DateTime? dataFim,
            string status);
    }
}

