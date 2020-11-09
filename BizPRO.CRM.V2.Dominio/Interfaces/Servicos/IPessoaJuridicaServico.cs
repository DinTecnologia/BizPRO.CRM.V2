using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IPessoaJuridicaServico : IServico<PessoaJuridica>
    {
        PessoaJuridica Adicionar(PessoaJuridica entidade);
        PessoaJuridica Editar(PessoaJuridica entidade);

        IEnumerable<PessoaJuridica> PesquisarPessoaJuridica(string nome, string documento, string telefone,
            long? pessoaJuridicaId, string protocolo);

        IEnumerable<PessoaJuridica> ObterPor(long? tipoId, string letrasBusca);
    }
}
