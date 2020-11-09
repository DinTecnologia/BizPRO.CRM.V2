using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IAplicacaoAppServico
    {
        bool RedirecionarAplicao(string host, string protocolo);
        Funcionalidade ObterFuncionalidadeTelaPrincipal(string usuarioId);
        string ObterUrlAplicacaoPadrao();
    }
}
