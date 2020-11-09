namespace BizPRO.CRM.V2.Aplicacao.Entidades
{
    public class AspNetRolesFilaApp
    {
        public long Id { get; set; }
        public int FilasId { get; set; }
        public string AspNetRolesId { get; set; }

        public AspNetRolesFilaApp()
        {

        }

        public AspNetRolesFilaApp(long id, int filasId, string aspNetRolesId)
        {
            Id = id;
            FilasId = filasId;
            AspNetRolesId = aspNetRolesId;
        }

        public AspNetRolesFilaApp(int filasId, string aspNetRolesId)
        {
            FilasId = filasId;
            AspNetRolesId = aspNetRolesId;
        }
    }
}
