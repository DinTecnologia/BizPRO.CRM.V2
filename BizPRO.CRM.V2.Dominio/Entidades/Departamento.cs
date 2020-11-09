using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
    }
}
