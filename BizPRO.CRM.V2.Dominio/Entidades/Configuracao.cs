using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    /// <summary>
    ///  Classe principal para configurações próprias conforme o cliente.
    ///  Siglas:    ULEXT -  URL para login externo via TOKEN
    /// </summary>
    public class Configuracao
    {
        public long Id { get; private set; }
        public string Sigla { get; private set; }
        public string Descricao { get; private set; }
        public string Valor { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string CriadoPorUserId { get; private set; }
        public DateTime? AlteradoEm { get; private set; }
        public string AlteradoPorUserId { get; private set; }
        public bool Ativo { get; private set; }
        public bool PadraoProduto { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public Configuracao()
        {
            ValidationResult = new ValidationResult();
        }

        public Configuracao(string sigla, string descricao, string valor, bool ativo, string userid)
        {
            Sigla = sigla;
            Descricao = descricao;
            Valor = valor;
            Ativo = ativo;
            CriadoEm = DateTime.Now;
            CriadoPorUserId = userid;
        }

        public Configuracao(long id, string sigla, string descricao, string valor, bool ativo, string atualizadopor,
            string userid, DateTime criado)
        {
            Id = id;
            Sigla = sigla;
            Descricao = descricao;
            Valor = valor;
            Ativo = ativo;
            CriadoEm = criado;
            CriadoPorUserId = userid;
            AlteradoEm = DateTime.Now;
            AlteradoPorUserId = atualizadopor;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public void LoginDefault()
        {
            Sigla = "TPOLG";
            Descricao = "Tipo de Login padrão da Ferramenta";
            Valor = "EXEM";
            Ativo = true;
            CriadoEm = DateTime.Now;
        }

        public void SetarUrlLoginExternoToken()
        {
            Sigla = "ULEXT";
        }

        public void SetarListaSolicitacaoLigacaoCorretor()
        {
            Sigla = "NOFIC";
        }

        public void SetarPeriodoExpiracaoSenha()
        {
            Sigla = "PEESE";
        }

        public void SetarUrlEmailAnexos()
        {
            Sigla = "ULEAX";
            //URL do anexo de emails
        }

        public void SetarUrlTodosAnexosEmail()
        {
            Sigla = "TOAEM";
            //URL de todos anexos de um email
        }

        public void SetarUrlChatAnexos()
        {
            Sigla = "CMCHT";
        }

        public void SetarUrlScreenPopUpChat()
        {
            Sigla = "ULSCH";
        }

        public void SetarVincularOcorrenciaAtendimentoManual()
        {
            Sigla = "VOCMN";
        }

        public void SetarRegraPreenchimentoOcorrenciaCampoChave1()
        {
            Sigla = "CC1RP";
            //Ocorrencia Campo Chave 1 Regra Preenchimento
        }

        public void SetarNomeOcorrenciaCampoChave1()
        {
            Sigla = "CC1NM";
            //Ocorrencia Campo Chave 1 Regra Preenchimento
        }

        public void SetarAtendimentoTerceiros()
        {
            Sigla = "PATTE";
            //Permitir Atendimento Contato
        }

        public void SetarChatQuantidadeAtendimentoSimultaneo()
        {
            Sigla = "FLCHT";
        }

        public void SetarTipoAberturaOcorrencia()
        {
            Sigla = "TPAOC";
        }

        public override string ToString()
        {
            return String.Format("Sigla: {0} - Descricao: {1}", Sigla, Descricao);
        }
    }
}
