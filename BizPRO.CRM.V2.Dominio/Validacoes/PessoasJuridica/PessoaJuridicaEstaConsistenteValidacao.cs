using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Especificacoes.PessoasJuridica;

namespace BizPRO.CRM.V2.Dominio.Validacoes.PessoasJuridica
{
    public class PessoaJuridicaEstaConsistenteValidacao : Validator<PessoaJuridica>
    {
        public PessoaJuridicaEstaConsistenteValidacao()
        {
            var CNPJCliente = new ClienteDeveTerCnpjValidoSpecification();
            base.Add("CNPJCliente", new Rule<PessoaJuridica>(CNPJCliente, "CNPJ inválido."));
        }
    }
}
