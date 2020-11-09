namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Perfil
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int? FuncionalidadeId { get; set; }
        public int? Ordem { get; set; }
    }
}
