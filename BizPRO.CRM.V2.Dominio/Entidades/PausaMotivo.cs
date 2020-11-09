using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class PausaMotivo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Tempo { get; set; }
        public string CanalIds { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string AtualizadoPor { get; set; }
        public bool Ativo { get; set; }

        public PausaMotivo()
        {
            CriadoEm = DateTime.Now;
        }
    }
}
