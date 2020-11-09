using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Identity.Model;

namespace BizPRO.CRM.V2.Aplicacao.Adaptadores
{
    public class TerminaisUsuarioAdaptador
    {
        public static TerminaisUsuario ParaDominioModelo(RegisterViewModel registro)
        {
            var terminaisUsuario = new TerminaisUsuario(registro.Terminal,
                registro.Agente,
                registro.UserID,
                registro.UserID,
                registro.UserID
            );
            return terminaisUsuario;
        }

        public static List<TerminaisUsuario> ParaDominioModeloLista(RegisterViewModel registro)
        {
            var listaTerminaisUsuario = new List<TerminaisUsuario>();

            if (registro.TerminaisUsuario == null) return listaTerminaisUsuario;
            listaTerminaisUsuario.AddRange(
                registro.TerminaisUsuario.Select(
                    item =>
                        new TerminaisUsuario(item.numeroTerminal, item.agente, registro.UserID, registro.UserID,
                            registro.UserID)));

            return listaTerminaisUsuario;
        }

        public static List<TerminaisUsuario> ParaDominioModeloLista(EditUserViewModel registro)
        {
            var listaTerminaisUsuario = new List<TerminaisUsuario>();

            if (registro.TerminaisUsuario == null) return listaTerminaisUsuario;
            foreach (var item in registro.TerminaisUsuario)
            {
                var terminaisUsuario = new TerminaisUsuario(item.numeroTerminal,
                    item.agente,
                    registro.UserID,
                    registro.UserID,
                    registro.UserID
                );

                listaTerminaisUsuario.Add(terminaisUsuario);
            }

            return listaTerminaisUsuario;
        }

        public static EditUserViewModel ParaDominioModeloEdite(List<TerminaisUsuario> registro)
        {
            var listaTerminaisUsuario = new List<terminal>();
            foreach (var item in registro)
            {
                var terminal = new terminal() {agente = item.Agente, numeroTerminal = item.NumeroTerminal};
                listaTerminaisUsuario.Add(terminal);

            }
            var terminaisUsuario = new EditUserViewModel() {TerminaisUsuario = listaTerminaisUsuario};
            return terminaisUsuario;
        }
    }
}
