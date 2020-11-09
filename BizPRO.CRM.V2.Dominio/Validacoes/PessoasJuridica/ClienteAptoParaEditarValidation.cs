using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Especificacoes.PessoasFisica;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Validacoes.PessoasJuridica
{
    class ClienteAptoParaEditarValidation: Validator<PessoaJuridica>
    {
        public ClienteAptoParaEditarValidation(IPessoaJuridicaRepositorio repositorio)
        {
            var cnpjDuplicado = new ClienteDevePossuirCNPJUnicoPorIDEspecificacao(repositorio);
            base.Add("cnpjDuplicado", new Rule<PessoaJuridica>(cnpjDuplicado, "CNPJ já cadastrado."));
        }
    }
}
