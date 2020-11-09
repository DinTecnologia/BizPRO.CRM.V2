using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IFuncionalidadeServico : IServico<Funcionalidade>
    {
        Funcionalidade ObterTelaInicial(string usuarioId);
    }
}
