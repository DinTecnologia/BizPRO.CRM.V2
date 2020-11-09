using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IAtendimentoAppServico
    {
        IEnumerable<AtendimentoViewModel> ObterAtendimentosPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            int? quantidade);

        AtendimentoViewModel SalvarAtendimento(AtendimentoViewModel model, long atividadeId);
        Atendimento GerarAtendimento(string criadoPor);
        void FinalizarAtendimento(AtendimentoViewModel model);
        AtendimentoViewModel ObterPorId(long id);
        void AtualizarMidia(long atendimentoId, int midiaId);
        AtendimentoFormViewModel Novo(AtendimentoFormViewModel model);
        AtendimentoFormViewModel Atualizar(AtendimentoFormViewModel model);
    }
}
