using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class TerminaisUsuarioAppServico : ITerminaisUsuarioAppServico
    {
        ITerminaisUsuarioServico _servicoTerminalUsuario;

        public TerminaisUsuarioAppServico(ITerminaisUsuarioServico servicoTerminalUsuario)
        {
            this._servicoTerminalUsuario = servicoTerminalUsuario;
        }

        public TerminaisUsuario Salvar(List<TerminaisUsuario> _obj)
        {
            TerminaisUsuario resultado = null;

            foreach (var entidade in _obj)
            {
                resultado = _servicoTerminalUsuario.Adicionar(entidade);
            }

            return resultado;
        }


        public List<TerminaisUsuario> ObterTerminaisUsuario(string UserID)
        {
            var resultado = _servicoTerminalUsuario.ObterTerminaisUsuario(UserID);

            return resultado;
        }

        public void DeletarTerminaisUsuario(string UserID)
        {
           _servicoTerminalUsuario.DeletarTerminaisUsuario(UserID);
        }

    }
}
