using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IEmailAppServico
    {
        bool EmailSenha(string url, string email, string userId);
        EmailViewModel CarregarEmailVisualizacao(long atividadeId);
        IEnumerable<EmailAnexosViewModel> CarregarAnexos(long atividadeId);

        EmailViewModel CarregarNovoEmail(long? atividadeId, string tipo, long? filaId, long? pessoaFisicaId,
            long? pessoaJuridicaId, string usuarioId, long? ocorrenciaId);

        ValidationResult Adicionar(EmailViewModel model, string userId);
        EmailViewModel CarregarTratar(long emailId, string userId);
        void Excluir(long id, string userId);
        int PossuiNovosEmails(string userId);
        Email BuscarProximoEmail(string userId);
        EmailFormViewModel Novo(EmailFormViewModel model);
        EmailFormViewModel AdicionarNew(EmailFormViewModel model);
    }
}
