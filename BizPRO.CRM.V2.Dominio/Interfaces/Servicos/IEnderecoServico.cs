using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;


namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IEnderecoServico
    {
        IEnumerable<Endereco> ObterEnderecosProduto(long? ocorrenciaId, long? pessoaFisicaId, long? pessoaJuridicaId);
    }
}
