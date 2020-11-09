using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{    
    public interface IAtividadeTipoRepositorio : IRepositorio<AtividadeTipo>
    {
        AtividadeTipo BuscarPorNome(string nome);
    }
}
