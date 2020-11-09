using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IFilaServico
    {
        IEnumerable<Fila> ObterVisaoAdmin();
        IEnumerable<Fila> ObterFilasMenu(string useriId);
        IEnumerable<Fila> ObterTodos();
        IEnumerable<Fila> ObterFilasPorNome(string nome);
        IEnumerable<Fila> ObterFilasDisparoDeEmails();
        IEnumerable<Fila> ObterFilasLigacao();
        IEnumerable<Fila> ObterFilasFiltroDashboard(string userId);

        IEnumerable<Fila> ObterFilasPorUsuario(string userId, bool? aceitaLigacao, bool? aceitaEmail, bool? aceitaTarefa,
            bool? aceitaChatSms, bool? aceitaChatWeb, bool? aceitaChatMessenger, bool? ativo);

        IEnumerable<Fila> ObterPor(bool? aceitaLigacao, bool? aceitaEmail, bool? aceitaTarefa, bool? aceitaChatSms,
            bool? aceitaChatWeb, int? departamentoId);

        Fila ObterPorId(int id);
        Fila Adicionar(Fila entidade);
        ValidationResult Atualizar(Fila entidade, string atualizadoPorUserId);
        IEnumerable<Fila> ObterFilasParaAlterar(long atividadeId);
        IEnumerable<Fila> ObterPorDepartamentoId(int? departamentoId);
        IEnumerable<Fila> ObterPor(int? departamentoId, string usuarioId);

        IEnumerable<Fila> ObterFilaPorCanalId(int? canalId);
    }
}
