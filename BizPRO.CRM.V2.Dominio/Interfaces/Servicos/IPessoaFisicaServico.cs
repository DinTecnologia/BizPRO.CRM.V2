using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IPessoaFisicaServico : IServico<PessoaFisica>
    {
        PessoaFisica Adicionar(PessoaFisica entidade);
        PessoaFisica Editar(PessoaFisica entidade);

        IEnumerable<PessoaFisica> PesquisarPessoaFisica(string nome, string documento, string telefone,
            long? pessoaFisicaId, string protocolo);
    }
}
