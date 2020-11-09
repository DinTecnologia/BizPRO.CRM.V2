using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface ITerminaisUsuarioAppServico
    {
        TerminaisUsuario Salvar(List<TerminaisUsuario> entidade);
        List<TerminaisUsuario> ObterTerminaisUsuario(string userId);
        void DeletarTerminaisUsuario(string userId);
    }
}
