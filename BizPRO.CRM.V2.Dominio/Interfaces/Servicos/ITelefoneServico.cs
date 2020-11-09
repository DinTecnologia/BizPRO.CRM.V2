using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ITelefoneServico : IServico<Telefone>
    {
         List<Telefone> ObterTelefonePessoaFisica(long pessoaFisicaId);
         List<Telefone> ObterTelefonePessoaJuridica(long pessoaJuridicaId);
         List<Telefone> ObterTelefoneCliente(long? pessoaFisicaId, long? pessoaJuridicaId, long? potenciaisCliente);
         Telefone AtualizarTelefone(long id , bool ativo);
         Telefone SalvarTelefone(Telefone telefone);
    }
}
