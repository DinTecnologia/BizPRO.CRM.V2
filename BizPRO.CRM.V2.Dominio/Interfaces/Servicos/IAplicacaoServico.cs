using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAplicacaoServico
    {
        bool Redirecionar(string host, string protocolo);
        Dominio.Entidades.Aplicacao ObterAplicacao(string nome);
    }
}
