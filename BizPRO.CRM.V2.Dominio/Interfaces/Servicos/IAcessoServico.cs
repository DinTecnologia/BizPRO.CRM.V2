using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAcessoServico : IServico<Acesso>
    {
        void AtualizarFimDeAcesso(string token);
    }
}
