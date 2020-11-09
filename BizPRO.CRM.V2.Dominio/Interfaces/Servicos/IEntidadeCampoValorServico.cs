using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;


namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IEntidadeCampoValorServico
    {
        IEnumerable<EntidadeCampoValor> ObterPor(string nomeLogicoEntidade, string nomeCampo, bool? ativo,
            bool? valorPadrao);
    }
}
