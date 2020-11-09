namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface ILogAcessoAppServico
    {
        void AdicionarLogAcesso(string chatid, string id);
        bool SessaoLogAcesso(string userId, bool ativo);
        bool VerificarUsuarioDisponivel();
    }
}