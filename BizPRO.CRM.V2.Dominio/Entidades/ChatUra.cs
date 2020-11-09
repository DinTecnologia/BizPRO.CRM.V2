using System;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ChatUra
    {
        public long Id { get; private set; }
        public long? ChatUraId { get; private set; }
        public long? ProximaUraId { get; private set; }
        public string Descricao { get; private set; }
        public bool Padrao { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string CriadoPorUserId { get; private set; }
        public bool Titulo { get; private set; }
        public int Ordem { get; private set; }
        public List<ChatUra> Opcoes { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public ChatUra(long id, long? chatUraId, long? proximaUraId, string descricao, bool padrao, DateTime criadoEm,
            string criadoPorUserId, bool titulo, int ordem)
        {
            Id = id;
            ChatUraId = chatUraId;
            Descricao = descricao;
            Padrao = padrao;
            CriadoEm = criadoEm;
            CriadoPorUserId = criadoPorUserId;
            Titulo = titulo;
            Ordem = ordem;
            ValidationResult = new ValidationResult();
            Opcoes = new List<ChatUra>();
            ProximaUraId = proximaUraId;
        }
    }
}
