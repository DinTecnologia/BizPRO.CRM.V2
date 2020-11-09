using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class FuncionalidadeServico : Servico<Funcionalidade>, IFuncionalidadeServico
    {
        private readonly IFuncionalidadeRepositorio _repositorio;

        public FuncionalidadeServico(IFuncionalidadeRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public Funcionalidade ObterTelaInicial(string usuarioId)
        {
            var funcionalidade = _repositorio.ObterTelaInicial(usuarioId);

            if (funcionalidade != null)
                if (funcionalidade.ActionName.Length > 0 && funcionalidade.ControllerName.Length > 0)
                    return funcionalidade;

            funcionalidade = new Funcionalidade()
            {
                ActionName = "MinhasFilas",
                ControllerName = "AtividadesFila"
            };

            return funcionalidade;
        }
    }
}
