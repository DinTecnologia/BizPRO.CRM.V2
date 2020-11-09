using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Especificacoes.PessoasFisica;

namespace BizPRO.CRM.V2.Dominio.Validacoes.PessoasFisica
{
    public class ClienteAptoParaCadastroValidation : Validator<PessoaFisica>
    {
        public ClienteAptoParaCadastroValidation(IPessoaFisicaRepositorio repositorio)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoEspecificacao(repositorio);
            base.Add("cpfDuplicado", new Rule<PessoaFisica>(cpfDuplicado, "CPF já cadastrado."));
        }
    }
}