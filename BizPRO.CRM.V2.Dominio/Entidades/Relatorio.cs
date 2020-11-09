using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Relatorio
    {
        public int Id_Cronologia { get; set; }
        public string atendimentoProtocolo { get; set; }
        public DateTime? atendimentoCriadoEm { get; set; }
        public string atendimentoCriadoPor { get; set; }
        public DateTime? atendimentoFinalizadoEm { get; set; }
        public string atendimentoFinalizadoPor { get; set; }
        public string Nome { get; set; }
        public DateTime? Dt_Inicio { get; set; }
        public DateTime? Dt_Termino { get; set; }
        public string Status { get; set; }
        public string Tipo_Atividade { get; set; }
        public string Sentido { get; set; }
        public string DescritivoAbertura { get; set; }
        public int QtdadeFinalizado { get; set; }
        public int QtdadeAberto { get; set; }
        public int TOTAL { get; set; }
        public string nomeExibicao { get; set; }
        public string Referencia { get; set; }
        public string numeroContrato { get; set; }
        public DateTime? criadoEm { get; set; }
        public DateTime? finalizadoEm { get; set; }
        public string NomeCliente { get; set; }
        public string numeroOriginal { get; set; }
        public string responsavel { get; set; }
        public int finalizaAtividade { get; set; }
        public string Documento { get; set; }
        public int id { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public int Total { get; set; }
        public int ativo { get; set; }
        public int receptivo { get; set; }
        public string UsuarioID { get; set; }
        public int StatusID { get; set; }
        public int TotalOcorrencia { get; set; }
        public int TotalLigacao { get; set; }
        public string Departamento { get; set; }
        public string finalizado { get; set; }


        //relatorio contatos detalhado 
        public string DataHora { get; set; }
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public string Cliente { get; set; }
        public string Protocolo { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        //status ja existe nas propriedades acima 
        public string CriadoPor { get; set; }
        public string ResponsavelPor { get; set; }
        //finalizadoEm ja existe nas propriedades acima
        //public int Total { get; set; }
        public int Criada { get; set; }
        public int Tratada { get; set; }
        public IEnumerable<Midia> Midias { get; set; }
        ///Propiedade Relatório "Consolidado de Contatos"     
        public long atividade { get; set; }
        public string canal { get; set; }
        public string midia { get; set; }
        public string status { get; set; }
        public string diaSemana { get; set; }
        public string dia { get; set; }
        public string sentido { get; set; }
        public long contadorSentido { get; set; }
        public int? atividadeTipoID { get; set; }
        public int? statusAtividadeID { get; set; }


        public int? pessoaFisicaID { get; set; }
        public int? pessoaJuridicaID { get; set; }
        public int? potenciaisClientesID { get; set; }
        public int? midiaID { get; set; }
        public string sentidoFiltro { get; set; }


        public string decritivoDeAbertura { get; set; }
        public string tempoTotal { get; set; }
        public int qtdeAtividadesTotal { get; set; }
        public int qtdeAtividadesAberta { get; set; }
        public int qtdeAtividadesFechadas { get; set; }
        public string statusOcorrencia { get; set; }
    }

    public class Report
    {
        public long? ocorrenciaID { get; set; }
        public long? atividadeID { get; set; }
        public int? atividadeTipoID { get; set; }
        public int? pessoaFisicaID { get; set; }
        public int? pessoaJuridicaID { get; set; }
        public int? potenciaisClientesID { get; set; }
        public int? midiaID { get; set; }
        public long? atendimentoID { get; set; }
        public int? statusAtividadeID { get; set; }
        public long? filaID { get; set; }
        public string statusAtividade { get; set; }
        public string statusOcorrencia { get; set; }
        public string decritivoDeAbertura { get; set; }
        public string tempoTotal { get; set; }
        public string cliente { get; set; }
        public DateTime? criadoEm { get; set; }
        public DateTime? finalizadoEm { get; set; }
        public string nomeExibicao { get; set; }
        public string criadoPor { get; set; }
        public string finalizadoPor { get; set; }
        public string descritivoDeAbertura { get; set; }
        public string nomeAtividadeTipo { get; set; }
        public string nomeMidia { get; set; }
        public string titulo { get; set; }
        public string responsavel { get; set; }
        public string protocolo { get; set; }
        public int qtdeOcorrenciasTotal { get; set; }
        public int qtdeOcorrenciasCriadas { get; set; }
        public int qtdeOcorrenciasTratadas { get; set; }
        public int qtdeAtividadesTotal { get; set; }
        public int qtdeAtividadesAberta { get; set; }
        public int qtdeAtividadesFechadas { get; set; }
        public int atividade { get; set; }
        public string diaSemana { get; set; }
        public string dia { get; set; }
        public string sentido { get; set; }
        public int contadorSentido { get; set; }
        public string sentidoFiltro { get; set; }
        public string numeroContrato { get; set; }
        public DateTime? previsaoDeExecucao { get; set; }
        public int fila { get; set; }
        public string nomeFila { get; set; }
        public string descricao { get; set; }
        public string referente { get; set; }
        public string Documento { get; set; }
        public string Referencia { get; set; }
        public DateTime? ResponsavelAtribuidoEm { get; set; }
        public string NomeUraParceiro { get; set; }
        public string NumeroOriginal { get; set; }
        public int QtdeFinalizado { get; set; }
        public int QtdeAberto { get; set; }
        public int Total { get; set; }
        public int CronologiaId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataTermino { get; set; }
        public string Status { get; set; }
        public int FinalizaAtividade { get; set; }
        public string Tipo { get; set; }

        public string Atendimento_Protocolo { get; set; }
        public DateTime Atendimento_Inicio { get; set; }
        public DateTime? Atendimento_Termino { get; set; }
        public string Cliente_Nome { get; set; }
        public string Cliente_Documento { get; set; }
        public string Cliente_Email { get; set; }
        public string Ocorrencia_N1 { get; set; }
        public string Ocorrencia_N2 { get; set; }
        public string Ocorrencia_N3 { get; set; }
        public string Ocorrencia_N4 { get; set; }
        public string Ocorrencia_N6 { get; set; }
        public string Ocorrencia_N5 { get; set; }
        public string Ocorrencia_N7 { get; set; }
        public string Ocorrencia_N8 { get; set; }
        public string Ocorrencia_N9 { get; set; }
        public string Ocorrencia_N10 { get; set; }
        public DateTime Ocorrencia_DataDeCriacao { get; set; }
        public string Ocorrencia_TipoDaOcorrencia { get; set; }
        public string Ocorrencia_PossuiSLA { get; set; }
        public string Ocorrencia_QuebraDeSLA { get; set; }
        public string Ocorrencia_Status { get; set; }
        public bool Ocorrencia_StatusEhFinalizador { get; set; }
        public string Ocorrencia_CriadoPor { get; set; }
        public string Ocorrencia_ResponsavelPor { get; set; }
        public DateTime? Ocorrencia_ResponsavelPorAtribuidoEm { get; set; }
        public string Ocorrencia_AberturaAno { get; set; }
        public string Ocorrencia_AberturaMesExtenso { get; set; }
        public int Ocorrencia_AberturaDia { get; set; }
        public int Ocorrencia_FechamentoAno { get; set; }
        public string Ocorrencia_FechamentoMesExtenso { get; set; }
        public string Ocorrencia_Campanha { get; set; }
        public string Ocorrencias_ProtocoloOcorrencia { get; set; }
        public long Ocorrencia_CodigoBPM { get; set; }
        public string Atendimento_CanalEntrada { get; set; }
        public int Atendimento_CanalEntradaID { get; set; }
        public string Ocorrencia_Produto { get; set; }
        public DateTime? Ocorrencia_DataFinalizacao { get; set; }
        public DateTime? Ocorrencia_PrevisaoFechamento { get; set; }
        public string Atendimento_TipoDaPessoaContato { get; set; }
        public string Atendimento_Origem { get; set; }
        public string Ocorrencia_TipoCliente { get; set; }
        public string Ocorrencia_ResponsavelPor_Departamento { get; set; }
        public string Cliente_UF { get; set; }
        public string Contato_Status { get; set; }
        public string Ocorrencia_Status_Painel { get; set; }
        public string Atendimento_CanalAtendimento { get; set; }
        public int Atendimento_CanalAtendimentoID { get; set; }
        public string Atendimento_Situacao { get; set; }
        public string StatusAtividadeInicioAtendimento { get; set; }
    }
}
