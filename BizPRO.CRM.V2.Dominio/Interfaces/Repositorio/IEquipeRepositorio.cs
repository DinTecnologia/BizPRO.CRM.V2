using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IEquipeRepositorio : IRepositorio<Equipe>
    {
        IEnumerable<Equipe> ObterEquipes();
        IEnumerable<Equipe> ObterPorDepartamentoId(int DepartamentoId);
        Equipe ObterPorId(int id);
        IEnumerable<Equipe> ObterPorUsuario(string usuarioId);
    }
}
