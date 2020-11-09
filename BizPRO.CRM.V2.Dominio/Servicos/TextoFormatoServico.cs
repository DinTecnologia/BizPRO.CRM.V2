using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TextoFormatoServico : Servico<TextoFormato>, ITextoFormatoServico
    {
        private readonly ITextoFormatoRepositorio _repositorio;

        public TextoFormatoServico(ITextoFormatoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

    }
}
