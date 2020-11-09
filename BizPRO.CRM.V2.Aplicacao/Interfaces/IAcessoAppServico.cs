using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IAcessoAppServico : IAppServico<Acesso>
    {   
        void SairCrm(string token);        
    }
}