using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;


namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class EntidadeSecaoServico : IEntidadeSecaoServico
    {
        private readonly IEntidadeSecaoRepositorio _repositorio;

        public EntidadeSecaoServico(IEntidadeSecaoRepositorio repositorio)
        {
            _repositorio = repositorio;
            new ValidationResult();
        }

        public EntidadeSecao ObterPor(string siglaEntidade, string nomeAba, string nomeSecao)
        {
            var entidade = _repositorio.ObterPor(siglaEntidade, nomeAba, nomeSecao);

            if (entidade != null) return entidade;

            var erro = new ValidationError("Não foram encontrados nenhuma EntidadeSeccao com os dados informados.");
            var validationResult = new ValidationResult();
            validationResult.Add(erro);
            entidade = new EntidadeSecao() {ValidationResult = validationResult};
            return entidade;
        }
    }
}
