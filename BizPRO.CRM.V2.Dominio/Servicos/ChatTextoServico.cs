using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ChatTextoServico : Servico<ChatTexto>, IChatTextoServico
    {
        public ChatTextoServico(IChatTextoRepositorio repositorio)
            : base(repositorio)
        {

        }


    }
}
