using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;
using System.Linq;


namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class CanalServico : Servico<Canal>, ICanalServico
    {
        private readonly ICanalRepositorio _repositorio;

        public CanalServico(ICanalRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Canal> ObterPorNome(string nome)
        {
            return _repositorio.ObterPorNome(nome);
        }

        public Canal ObterCanalTelefone()
        {
            var Retorno = new Canal();
            var Lista = ObterPorNome("TELEFONE");

            if (Lista.Any())
            {
                Retorno = Lista.OrderByDescending(m => m.Id).FirstOrDefault();
            }
            else
                Retorno.ValidationResult.Add(new ValidationError("Canal Telefone não cadastrado."));

            return Retorno;
        }

        public Canal ObterCanalEmail()
        {
            var Retorno = new Canal();
            var Lista = ObterPorNome("EMAIL");

            if (Lista.Any())
            {
                Retorno = Lista.OrderByDescending(m => m.Id).FirstOrDefault();
            }
            else
                Retorno.ValidationResult.Add(new ValidationError("Canal Email não cadastrado."));

            return Retorno;
        }

        public Canal ObterCanalChat()
        {
            var Retorno = new Canal();
            var Lista = ObterPorNome("CHAT");

            if (Lista.Any())
            {
                Retorno = Lista.OrderByDescending(m => m.Id).FirstOrDefault();
            }
            else
                Retorno.ValidationResult.Add(new ValidationError("Canal Chat não cadastrado."));

            return Retorno;
        }

        public Canal ObterCanalMessenger()
        {
            var Retorno = new Canal();
            var Lista = ObterPorNome("MESSENGER");

            if (Lista.Any())
            {
                Retorno = Lista.OrderByDescending(m => m.Id).FirstOrDefault();
            }
            else
                Retorno.ValidationResult.Add(new ValidationError("Canal Messenger não cadastrado."));

            return Retorno;
        }
    }
}
