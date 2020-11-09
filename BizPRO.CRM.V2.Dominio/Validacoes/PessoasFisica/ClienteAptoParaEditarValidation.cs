using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Especificacoes.PessoasFisica;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Validacoes.PessoasFisica
{
    class ClienteAptoParaEditarValidation: Validator<PessoaFisica>
    {
        public ClienteAptoParaEditarValidation(IPessoaFisicaRepositorio repositorio)
        {
            //var cpfDuplicado = new ClienteDevePossuirCPFUnicoPorIDEspecificacao(repositorio);
            //base.Add("cpfDuplicado", new Rule<PessoaFisica>(cpfDuplicado, "CPF já cadastrado."));
        }
    }
}
