using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Especificacoes.PessoasJuridica;

namespace BizPRO.CRM.V2.Dominio.Validacoes.PessoasJuridica
{
    public class ClienteAptoParaCadastroValidation : Validator<PessoaJuridica>
    {
        public ClienteAptoParaCadastroValidation(IPessoaJuridicaRepositorio repositorio)
        {
            var cnpjDuplicado = new ClienteDevePossuirCNPJUnicoEspecificacao(repositorio);
            base.Add("cnpjDuplicado", new Rule<PessoaJuridica>(cnpjDuplicado, "CNPJ já cadastrado."));
        }
    }
}
