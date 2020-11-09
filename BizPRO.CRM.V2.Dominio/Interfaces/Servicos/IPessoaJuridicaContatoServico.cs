using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IPessoaJuridicaContatoServico : IServico<PessoaJuridicaContato>
    {
        PessoaJuridicaContato InserirContato(long pessoaFisicaId, long pessoaJuridicaId, string userId);
        IEnumerable<PessoaJuridicaContato> ListarContatos(long? pessoaJuridicaId, long? pessoaFisicaId);

        PessoaJuridicaContato AtualizarContato(long pessoaJuridicaTipoContatoId, long pessoaJuridicaContatoId,
            string userId);

        PessoaJuridicaContato DeletarContato(long pessoaJuridicaContatoId, string userId);
    }
}
