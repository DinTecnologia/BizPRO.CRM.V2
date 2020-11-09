using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Tarefa
    {
        public long Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string CriadoPorUserId { get; private set; }
        public string ResponsavelPorUserId { get; private set; }
        public string Descricao { get; private set; }
        public long AtividadeId { get; private set; }
        public IEnumerable<Anotacao> Anotacoes { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            //Preciso validar algumas informações aqui
            return true;
        }

        public Tarefa()
        {
            Anotacoes = new List<Anotacao>();
            ValidationResult = new ValidationResult();
        }

        public Tarefa(string criadoPorUserId, string descricao, long atividadeId)
        {
            CriadoPorUserId = criadoPorUserId;
            Descricao = descricao;
            AtividadeId = atividadeId;
            CriadoEm = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        public Tarefa(long id, string criadoPorUserId, long atividadeId)
        {
            Id = id;
            CriadoPorUserId = criadoPorUserId;
            AtividadeId = atividadeId;
        }
    }
}
