using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AtividadesHistorico
    {
        public long Id { get; set; }
        public long AtividadeId { get; set; }
        public string ResponsavelPorAnteriorUserId { get; set; }
        public string ResponsavelPorAtualUserId { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime CridoProUserId { get; set; }
    }
}
