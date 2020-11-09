using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TextoTipoServico : Servico<TextoTipo>, ITextoTipoServico
    {
        private readonly ITextoTipoRepositorio _repositorio;

        public TextoTipoServico(ITextoTipoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
