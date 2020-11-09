using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class AplicacaoAppServico : AppServicoDapper, IAplicacaoAppServico
    {
        private readonly IAplicacaoServico _aplicacaoServico;
        private readonly IFuncionalidadeServico _funcionalidadeServico;

        public AplicacaoAppServico(IAplicacaoServico aplicacaoServico, IFuncionalidadeServico funcionalidadeServico)
        {
            _aplicacaoServico = aplicacaoServico;
            _funcionalidadeServico = funcionalidadeServico;
        }

        public bool RedirecionarAplicao(string host, string protocolo)
        {
            return _aplicacaoServico.Redirecionar(host, protocolo);
        }
        public Funcionalidade ObterFuncionalidadeTelaPrincipal(string usuarioId)
        {
            return _funcionalidadeServico.ObterTelaInicial(usuarioId);
        }
        public string ObterUrlAplicacaoPadrao()
        {
            var aplicacao = _aplicacaoServico.ObterAplicacao("CRM");
            return aplicacao != null ? aplicacao.Url : "";
        }
    }
}
