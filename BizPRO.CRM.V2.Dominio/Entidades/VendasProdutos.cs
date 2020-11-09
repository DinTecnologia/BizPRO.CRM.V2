﻿using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class VendasProdutos
    {
        public long id { get; set; }

        public long ProdutosID { get; set; }

        public int ListasDePrecosID { get; set; }

        public decimal valorSugerido { get; set; }

        public decimal valorVenda { get; set; }

        public long qtd { get; set; }

        public long valorDaLinha { get; set; }

        public long VendasID { get; set; }

        public string criadoPorUserID { get; set; }

        public DateTime criadoEm { get; set; }

        public string alteradoPorUserID { get; set; }

        public DateTime? alteradoEm { get; set; }


    }
}
