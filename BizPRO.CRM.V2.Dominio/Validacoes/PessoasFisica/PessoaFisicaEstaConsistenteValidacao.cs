using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Especificacoes.PessoasFisica;

namespace BizPRO.CRM.V2.Dominio.Validacoes.PessoasFisica
{
    public class PessoaFisicaEstaConsistenteValidacao : Validator<PessoaFisica>
    {
        public PessoaFisicaEstaConsistenteValidacao()
        {
            var CPFCliente = new ClienteDeveTerCpfValidoSpecification();
            base.Add("CPFCliente", new Rule<PessoaFisica>(CPFCliente, "Cliente informou um CPF inválido."));
        }
    }
}
