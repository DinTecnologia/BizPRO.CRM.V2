using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IFilaRepositorio : IRepositorio<Fila>
    {
        IEnumerable<Fila> ObterFilaMenu(string userId);
        IEnumerable<Fila> ObterFilaLigacao();
        IEnumerable<Fila> ObterFilasFiltroDashboard(string userId);

        IEnumerable<Fila> ObterFilasPorUsuario(string userId, bool? aceitaLigacao, bool? aceitaEmail, bool? aceitaTarefa,
            bool? aceitaChatSms, bool? aceitaChatWeb, bool? aceitaChatMessenger, bool? ativo);

        IEnumerable<Fila> ObterFilasParaAlterar(long atividadeId);
        IEnumerable<Fila> ObterVisaoAdmin();
        IEnumerable<Fila> ObterPorDepartamentoId(int? departamentoId);

        IEnumerable<Fila> ObterPor(bool? aceitaLigacao, bool? aceitaEmail, bool? aceitaTarefa, bool? aceitaChatSms,
            bool? aceitaChatWeb, int? departamentoId);

        IEnumerable<Fila> ObterPor(int? departamentoId, string usuarioId);

        IEnumerable<Fila> ObterFilaPorCanalId(int? canalId);
    }
}
