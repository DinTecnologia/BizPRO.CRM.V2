using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ITerminaisUsuarioServico : IServico<TerminaisUsuario>
    {
        TerminaisUsuario Adicionar(TerminaisUsuario entidade);
        List<TerminaisUsuario> ObterTerminaisUsuario(string userId);
        void DeletarTerminaisUsuario(string userId);
    }
}
