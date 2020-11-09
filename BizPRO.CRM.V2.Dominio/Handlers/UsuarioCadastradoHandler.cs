using System.Collections.Generic;
using BizPRO.CRM.V2.Core.Email;
using BizPRO.CRM.V2.Core.Interfaces;
using BizPRO.CRM.V2.Dominio.Eventos;

namespace BizPRO.CRM.V2.Dominio.Handlers
{
    public class UsuarioCadastradoHandler : IHandler<UsuarioCadastradoEvento>
    {
        private List<UsuarioCadastradoEvento> _notifications;
        private readonly IEnvioEmail _envioEmail;

        public UsuarioCadastradoHandler(IEnvioEmail envioEmail)
        {
            _envioEmail = envioEmail;
        }

        public void Handle(UsuarioCadastradoEvento args)
        {
            //// Envia Email!
            //_envioEmail.EnviarAsync(args.Usuario.nome,
            //    args.Usuario.Email.Endereco,
            //    args.EmailTitle,
            //    args.EmailBody);
        }

        public IEnumerable<UsuarioCadastradoEvento> Notify()
        {
            return GetValues();
        }

        public bool HasNotifications()
        {
            return GetValues().Count > 0;
        }

        public List<UsuarioCadastradoEvento> GetValues()
        {
            return _notifications;
        }

        public void Dispose()
        {
            _notifications = new List<UsuarioCadastradoEvento>();
        }
    }
}
