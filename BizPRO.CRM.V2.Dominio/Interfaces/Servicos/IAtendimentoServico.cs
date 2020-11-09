using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAtendimentoServico : IServico<Atendimento>
    {
        string GerarNumeroProtocolo(DateTime? data);

        IEnumerable<Atendimento> ObterAtendimentosPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            int? quantidade);

        Atendimento InserirAtendimento(Atendimento entidade);
        Atendimento BuscarPorProtocolo(string protocolo);
        Atendimento AdicionarNovoAtendimento(int? canalId, string criadoPorId, long? midiaId);
        bool AtualizarClienteSomenteContato(long atendimentoId, bool clienteSomenteContato, long? tipoClienteContatoId);
        IEnumerable<EntidadeCampoValor> ObterTiposClienteContato();
        void AtualizarMidia(long atendimentoId, int midiaId);
        
    }
}
