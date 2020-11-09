﻿using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class TextoMapper : ClassMapper<Texto>
    {
        public TextoMapper()
        {
            Table("Textos");
            Map(m => m.Id).Column("Id").Key(KeyType.Identity);
            Map(m => m.FormatoId).Column("FormatoId");
            Map(m => m.CategoriaId).Column("CategoriaId");
            Map(m => m.TipoId).Column("TipoId");
            Map(m => m.Nome).Column("Nome");
            Map(m => m.Descricao).Column("Descricao");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.CriadoPor).Column("CriadoPor");
            Map(m => m.AtualizadoEm).Column("AtualizadoEm");
            Map(m => m.AtualizadoPor).Column("AtualizadoPor");
            Map(m => m.Ativo).Column("Ativo");
        }
    }
}
