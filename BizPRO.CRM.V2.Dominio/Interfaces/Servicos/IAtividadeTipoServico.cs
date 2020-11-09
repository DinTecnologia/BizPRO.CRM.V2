using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAtividadeTipoServico : IServico<AtividadeTipo>
    {
        AtividadeTipo BuscarPorNome(string nome);
    }
}
