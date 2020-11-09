using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.IO;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class EmailAnexoServico : Servico<EmailAnexo>, IEmailAnexoServico
    {
        private readonly IEmailAnexoRepositorio _repositorio;

        public EmailAnexoServico(IEmailAnexoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<EmailAnexo> ObterAnexos(long atividadeId)
        {
            return _repositorio.ObterAnexos(atividadeId);
        }

        public bool VerificarAnexos(string diretorio)
        {
            if (File.Exists(diretorio))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public IEnumerable<EmailAnexo> ObterDiretoriosEmailAnexo(DateTime? data)
        {
            return _repositorio.ObterDiretoriosEmailAnexo(data);
        }
    }
}
