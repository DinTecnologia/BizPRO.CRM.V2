using System;
using BizPRO.CRM.V2.Core.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Eventos
{
    public class UsuarioCadastradoEvento : IDomainEvent
    {
        public DateTime DataOcorrencia { get; private set; }
        public Usuario Usuario { get; private set; }
        public string EmailTitle { get; private set; }
        public string EmailBody { get; private set; }
        public int Versao { get; private set; }

        public UsuarioCadastradoEvento(Usuario usuario, DateTime dateOccured)
        {
            Versao = 1;
            Usuario = usuario;
            DataOcorrencia = DateTime.Now;
            EmailTitle = "Seja bem vindo " + usuario.Nome;
            EmailBody = "Obrigado por se cadastrar.";
        }

        public UsuarioCadastradoEvento(Usuario usuario) : this(usuario, DateTime.Now)
        {
        }
    }
}