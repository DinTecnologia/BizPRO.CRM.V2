using BizPRO.CRM.V2.Aplicacao;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Contexto;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Core.Email;
using BizPRO.CRM.V2.Core.Events;
using BizPRO.CRM.V2.Core.Handlers;
using BizPRO.CRM.V2.Core.Interfaces;
using BizPRO.CRM.V2.Dominio.Eventos;
using BizPRO.CRM.V2.Dominio.Handlers;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Identity.Configuration;
using BizPRO.CRM.V2.Identity.Context;
using BizPRO.CRM.V2.Identity.Model;
using Camadas.Aplicacao.Interfaces;
using SimpleInjector;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BizPRO.CRM.V2.Dominio.Servicos;
using BizPRO.CRM.V2.Repositorio.ADO;
using BizPRO.CRM.V2.Repositorio.Dapper;
using BizPRO.CRM.V2.Repositorio.Entity;

namespace BizPRO.CRM.V2.IoC
{
    public static class BootStrapper
    {
        public static Container MyContainer { get; set; }

        public static void RegisterServices(Container container)
        {
            MyContainer = container;
            //Registrar as Novas implementações aqui:            

            // Aplicação

            container.Register<IBaseAppServico, BaseAppServico>(Lifestyle.Scoped);
            container.Register<IUsuarioAppServico, UsuarioAppServico>(Lifestyle.Scoped);
            container.Register<IProdutoAppServico, ProdutoAppServico>(Lifestyle.Scoped);
            container.Register<IConfiguracaoAppServico, ConfiguracaoAppServico>(Lifestyle.Scoped);
            container.Register<IAcessoAppServico, AcessoAppServico>(Lifestyle.Scoped);
            container.Register<IReceptivoAppServico, ReceptivoAppServico>(Lifestyle.Scoped);
            container.Register<IAtendimentoAppServico, AtendimentoAppServico>(Lifestyle.Scoped);
            container.Register<IClienteAppServico, ClienteAppServico>(Lifestyle.Scoped);
            container.Register<IPessoaFisicaAppServico, PessoaFisicaAppServico>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaAppServico, PessoaJuridicaAppServico>(Lifestyle.Scoped);
            container.Register<IAbordagemAppServico, AbordagemAppServico>(Lifestyle.Scoped);
            container.Register<IOcorrenciaAppServico, OcorrenciaAppServico>(Lifestyle.Scoped);
            container.Register<ITerminaisUsuarioAppServico, TerminaisUsuarioAppServico>(Lifestyle.Scoped);
            container.Register<ILayoutAppServico, LayoutAppService>(Lifestyle.Scoped);
            container.Register<IAtividadeFilasApoioAppServico, AtividadeFilasApoioAppServico>(Lifestyle.Scoped);
            container.Register<ITarefaAppServico, TarefaAppServico>(Lifestyle.Scoped);
            container.Register<IStatusAtividadeAppServico, StatusAtividadeAppServico>(Lifestyle.Scoped);
            container.Register<IRelatorioAppServico, RelatorioAppServico>(Lifestyle.Scoped);
            container.Register<IMenuAppServico, MenuAppServico>(Lifestyle.Scoped);
            container.Register<IAnotacaoAppServico, AnotacaoAppServico>(Lifestyle.Scoped);
            container.Register<IStatusEntidadeAppServico, StatusEntidadeAppServico>(Lifestyle.Scoped);
            container.Register<IOcorrenciaXstatusEntidadeAppServico, OcorrenciaXstatusEntidadeAppServico>(
                Lifestyle.Scoped);
            container.Register<IContratoAppServico, ContratoAppServico>(Lifestyle.Scoped);
            container.Register<IContatoAppServico, ContatoAppServico>(Lifestyle.Scoped);
            container.Register<IAtividadeApoioAppServico, AtividadeApoioAppServico>(Lifestyle.Scoped);
            container.Register<ITelefoneAppServico, TelefonesAppService>(Lifestyle.Scoped);
            container.Register<ITelefonesTiposAppService, TelefonesTiposAppService>(Lifestyle.Scoped);
            container.Register<IViewDinamicaAppServico, ViewDinamicaAppServico>(Lifestyle.Scoped);
            container.Register<IPotenciaisClienteAppServico, PotenciaisClienteAppServico>(Lifestyle.Scoped);
            container.Register<IListasDePrecosAppServico, ListasDePrecosAppServico>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaTiposContatoAppServico, PessoaJuridicaTiposContatoAppServico>(
                Lifestyle.Scoped);
            container.Register<IPessoaJuridicaContatosAppServico, PessoaJuridicaContatosAppServico>(Lifestyle.Scoped);
            container.Register<IVendasAppServico, VendasAppServico>(Lifestyle.Scoped);
            container.Register<ILocalAppServico, LocalAppServico>(Lifestyle.Scoped);
            container.Register<IAtividadeAppServico, AtividadeAppServico>(Lifestyle.Scoped);
            //container.Register<IAxaLaudoAppServico_, AxaLaudoAppServico_>(Lifestyle.Scoped);
            container.Register<IOcorrenciaTipoAppServico, OcorrenciaTipoAppServico>(Lifestyle.Scoped);
            container.Register<ITimelineAppServico, TimelineAppServico>(Lifestyle.Scoped);
            container.Register<IFilaAppServico, FilaAppService>(Lifestyle.Scoped);
            container.Register<IConfiguracaoContasEmailsAppServico, ConfiguracaoContasEmailsAppServico>(
                Lifestyle.Scoped);
            container.Register<IAtividadeFilaAppServico, AtividadeFilaAppServico>(Lifestyle.Scoped);
            container.Register<IAspNetRolesFilaAppServico, AspNetRolesFilaAppServico>(Lifestyle.Scoped);
            container.Register<IAcoesTokensValidadeAppServico, AcoesTokensValidadeAppServico>(Lifestyle.Scoped);
            container.Register<IContaAppServico, ContaAppServico>(Lifestyle.Scoped);
            container.Register<IReportAppServico, ReportAppServico>(Lifestyle.Scoped);
            container.Register<IEmailAppServico, EmailAppServico>(Lifestyle.Scoped);
            container.Register<ICanalAppServico, CanalAppServico>(Lifestyle.Scoped);
            container.Register<IMidiaAppServico, MidiaAppServico>(Lifestyle.Scoped);
            container.Register<IDashboardAppServico, DashboardAppServico>(Lifestyle.Scoped);
            container.Register<IRoleAdminAppServico, RoleAdminAppServico>(Lifestyle.Scoped);
            container.Register<IChatAppServico, ChatAppServico>(Lifestyle.Scoped);
            container.Register<IArquivosAppServico, ArquivosAppServico>(Lifestyle.Scoped);
            container.Register<ILogAcessoAppServico, LogAcessoAppServico>(Lifestyle.Scoped);
            container.Register<IChatMensagensAppServico, ChatMensagensAppServico>(Lifestyle.Scoped);
            container.Register<IAtividadeHistoricoAppServico, AtividadeHistoricoAppServico>(Lifestyle.Scoped);
            container.Register<IAplicacaoAppServico, AplicacaoAppServico>(Lifestyle.Scoped);
            container.Register<IDepartamentoAppServico, DepartamentoAppServico>(Lifestyle.Scoped);
            container.Register<IEquipeAppServico, EquipeAppServico>(Lifestyle.Scoped);
            container.Register<IArquivoAppServico, ArquivoAppServico>(Lifestyle.Scoped);
            container.Register<IFilaAdminAppServico, FilaAdminAppServico>(Lifestyle.Scoped);
            container.Register<ICampoDinamicoAppServico, CampoDinamicoAppServico>(Lifestyle.Scoped);
            container.Register<IEmailTodosAnexosAppServico, EmailTodosAnexosAppServico>(Lifestyle.Scoped);
            container.Register<IPausaAppServico, PausaAppServico>(Lifestyle.Scoped);
            container.Register<ILigacaoAppServico, LigacaoAppServico>(Lifestyle.Scoped);
            //container.Register<IIntegracaoAppServico, IntegracaoAppServico>(Lifestyle.Scoped);
            container.Register<ITextoAppServico, TextoAppServico>(Lifestyle.Scoped);
            container.Register<IAtividadesFilaRepositorioDal, AtividadesFilaRepositorioDal>(Lifestyle.Scoped);





            // Dominio
            container.Register<IUsuarioServico, UsuarioServico>(Lifestyle.Scoped);
            container.Register<IProdutoServico, ProdutoServico>(Lifestyle.Scoped);
            container.Register<IProdutoTipoServico, ProdutoTipoServico>(Lifestyle.Scoped);
            container.Register<IConfiguracaoServico, ConfiguracaoServico>(Lifestyle.Scoped);
            container.Register<IAcessoServico, AcessoServico>(Lifestyle.Scoped);
            container.Register<IStatusAtividadeServico, StatusAtividadeServico>(Lifestyle.Scoped);
            container.Register<IAtividadeServico, AtividadeServico>(Lifestyle.Scoped);
            container.Register<IAtividadeTipoServico, AtividadeTipoServico>(Lifestyle.Scoped);
            container.Register<ILigacaoServico, LigacaoServico>(Lifestyle.Scoped);
            container.Register<IAtendimentoServico, AtendimentoServico>(Lifestyle.Scoped);
            container.Register<IClienteServico, ClienteServico>(Lifestyle.Scoped);
            container.Register<IPessoaFisicaServico, PessoaFisicaServico>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaServico, PessoaJuridicaServico>(Lifestyle.Scoped);
            container.Register<IOcorrenciaServico, OcorrenciaServico>(Lifestyle.Scoped);
            container.Register<IOcorrenciaTipoServico, OcorrenciaTipoServico>(Lifestyle.Scoped);
            container.Register<IContratoServico, ContratoServico>(Lifestyle.Scoped);
            container.Register<ITerminaisUsuarioServico, TerminaisUsuarioServico>(Lifestyle.Scoped);
            container.Register<IFilaServico, FilaServico>(Lifestyle.Scoped);
            container.Register<IAtividadeFilasApoioServico, AtividadeFilasApoioServico>(Lifestyle.Scoped);
            container.Register<IAnotacaoServico, AnotacaoServico>(Lifestyle.Scoped);
            container.Register<IStatusEntidadeServico, StatusEntidadeServico>(Lifestyle.Scoped);
            container.Register<IAnotacoesApoioServico, AnotacoesApoioServico>(Lifestyle.Scoped);
            container.Register<ITarefaAtividadeOcorrenciaServico, TarefaAtividadeOcorrenciaServico>(Lifestyle.Scoped);
            container.Register<ITarefaServico, TarefaServico>(Lifestyle.Scoped);
            container.Register<ICidadeServico, CidadeServico>(Lifestyle.Scoped);
            container.Register<IOcorrenciaTiposXOcorrenciaServico, OcorrenciaTiposXOcorrenciaServico>(Lifestyle.Scoped);
            container.Register<IMenuServico, MenuServico>(Lifestyle.Scoped);
            container.Register<IFuncionalidadeServico, FuncionalidadeServico>(Lifestyle.Scoped);
            container.Register<IRelatorioServico, RelatorioServico>(Lifestyle.Scoped);
            container.Register<IOcorrenciaXstatusEntidadeApoioServico, OcorrenciaXstatusEntidadeApoioServico>(
                Lifestyle.Scoped);
            container.Register<IAtividadeApoioServico, AtividadeApoioServico>(Lifestyle.Scoped);
            container.Register<ITelefoneServico, TelefoneServico>(Lifestyle.Scoped);
            container.Register<IAtendimentoOcorrenciaServico, AtendimentoOcorrenciaServico>(Lifestyle.Scoped);
            container.Register<IEntidadeServico, EntidadeServico>(Lifestyle.Scoped);
            container.Register<ITelefonesTiposServico, TelefonesTiposServico>(Lifestyle.Scoped);
            container.Register<ICampoDinamicoServico, CampoDinamicoServico>(Lifestyle.Scoped);
            container.Register<ICampoDinamicoOpcaoServico, CampoDinamicoOpcaoServico>(Lifestyle.Scoped);
            container.Register<IEntidadeSecaoCampoDinamicoServico, EntidadeSecaoCampoDinamicoServico>(Lifestyle.Scoped);
            container.Register<ICampoDinamicoPreenchidoServico, CampoDinamicoPreenchidoServico>(Lifestyle.Scoped);
            container.Register<IListasDePrecosServico, ListasDePrecosServico>(Lifestyle.Scoped);
            container.Register<IListaDePrecosProdutosServico, ListaDePrecosProdutosServico>(Lifestyle.Scoped);
            container.Register<IEntidadeSecaoServico, EntidadeSecaoServico>(Lifestyle.Scoped);
            container.Register<IVendasServico, VendasServico>(Lifestyle.Scoped);
            container.Register<IVendasProdutosServico, VendasProdutosServico>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaTiposContatoServico, PessoaJuridicaTiposContatoServico>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaContatoServico, PessoaJuridicaContatoServico>(Lifestyle.Scoped);
            container.Register<IContratoProdutoServico, ContratoProdutoServico>(Lifestyle.Scoped);
            container.Register<IPotenciaisClienteServico, PotenciaisClienteServico>(Lifestyle.Scoped);
            container.Register<ILocalServico, Dominio.Servicos.LocalServico>(Lifestyle.Scoped);
            container.Register<IEnderecoServico, EnderecoServico>(Lifestyle.Scoped);
            container.Register<ILocalTipoServico, LocalTipoServico>(Lifestyle.Scoped);
            container.Register<ILocalTipoAtendimentoServico, LocalTipoAtendimentoServico>(Lifestyle.Scoped);
            //container.Register<IAxaLaudoServico_, AxaLaudoServico_>(Lifestyle.Scoped);
            container.Register<IOcorrenciaLocalTipoAtendimentoServico, OcorrenciaLocalTipoAtendimentoServico>(
                Lifestyle.Scoped);
            container.Register<IMidiaServico, MidiaServico>(Lifestyle.Scoped);
            container.Register<ITimelineApoioServico, TimelineApoioServico>(Lifestyle.Scoped);
            container.Register<IEmailAnexoServico, EmailAnexoServico>(Lifestyle.Scoped);
            container.Register<IEmailServico, EmailServico>(Lifestyle.Scoped);
            container.Register<IAtividadeParteEnvolvidaServico, AtividadeParteEnvolvidaServico>(Lifestyle.Scoped);
            container.Register<IEmailModeloServico, EmailModeloServico>(Lifestyle.Scoped);
            container.Register<ITokenAcessoRapidoServico, TokenAcessoRapidoServico>(Lifestyle.Scoped);
            container.Register<IConfiguracaoContasEmailsServico, ConfiguracaoContasEmailsServico>(Lifestyle.Scoped);
            container.Register<IAtividadeFilaServico, AtividadeFilaServico>(Lifestyle.Scoped);
            container.Register<IAspNetRolesFilaServico, AspNetRolesFilaServico>(Lifestyle.Scoped);
            container.Register<IAtendimentoAtividadeServico, AtendimentoAtividadeServico>(Lifestyle.Scoped);
            container.Register<IAcoesTokensValidadeServico, AcoesTokensValidadeServico>(Lifestyle.Scoped);
            container.Register<IEmailLogServico, EmailLogServico>(Lifestyle.Scoped);
            container.Register<ICanalServico, CanalServico>(Lifestyle.Scoped);
            container.Register<IReportServico, ReportServico>(Lifestyle.Scoped);
            container.Register<IDashboardServico, DashboardServico>(Lifestyle.Scoped);
            container.Register<IRoleClaimServico, RoleClaimServico>(Lifestyle.Scoped);
            container.Register<IAspNetClaimServico, AspNetClaimServico>(Lifestyle.Scoped);
            container.Register<IAspNetMatrizServico, AspNetMatrizServico>(Lifestyle.Scoped);
            container.Register<IChatServico, ChatServico>(Lifestyle.Scoped);
            container.Register<IArquivoServico, ArquivoServico>(Lifestyle.Scoped);
            container.Register<ILogAcessoServico, LogAcessoServico>(Lifestyle.Scoped);
            container.Register<IChatMensagemServico, ChatMensagemServico>(Lifestyle.Scoped);
            container.Register<IAtividadeHistoricoServico, AtividadeHistoricoServico>(Lifestyle.Scoped);
            container.Register<IDepartamentoServico, DepartamentoServico>(Lifestyle.Scoped);
            container.Register<IEquipeServico, EquipeServico>(Lifestyle.Scoped);
            container.Register<IChatUraServico, ChatUraServico>(Lifestyle.Scoped);
            container.Register<IAplicacaoServico, AplicacaoServico>(Lifestyle.Scoped);
            container.Register<IAspNetRolesMenuServico, AspNetRolesMenuServico>(Lifestyle.Scoped);
            container.Register<IEntidadeCampoValorServico, EntidadeCampoValorServico>(Lifestyle.Scoped);
            container.Register<IOcorrenciaAcompanhamentoServico, OcorrenciaAcompanhamentoServico>(Lifestyle.Scoped);
            container.Register<IAnotacaoTipoServico, AnotacaoTipoServico>(Lifestyle.Scoped);
            container.Register<IChatSolicitacaoServico, ChatSolicitacaoServico>(Lifestyle.Scoped);
            container.Register<IPausaServico, PausaServico>(Lifestyle.Scoped);
            container.Register<IPausaMotivoServico, PausaMotivoServico>(Lifestyle.Scoped);
            container.Register<IFeriadoServico, FeriadoServico>(Lifestyle.Scoped);
            container.Register<IPerfilServico, PerfilServico>(Lifestyle.Scoped);
            container.Register<IIntegracaoControleServico, IntegracaoControleServico>(Lifestyle.Scoped);
            container.Register<ITextoServico, TextoServico>(Lifestyle.Scoped);
            container.Register<ITextoCategoriaServico, TextoCategoriaServico>(Lifestyle.Scoped);
            container.Register<ITextoFilaServico, TextoFilaServico>(Lifestyle.Scoped);
            container.Register<ITextoTipoServico, TextoTipoServico>(Lifestyle.Scoped);
            container.Register<ITextoFormatoServico, TextoFormatoServico>(Lifestyle.Scoped);
            container.Register<IRepositorioDal, RepositorioDal>(Lifestyle.Scoped); //Added 21/01/2020 Breno
            container.Register<IFilaRepositorioDal, FilaRepositorioDal>(Lifestyle.Scoped); //Added 21/01/2020 Breno
            container.Register<IAtividadeFilaApoioRepositorioDal, AtividadeFilaApoioRepositorioDal>(Lifestyle
                .Scoped); //Added 22/01/2020 Breno
            container.Register<IUsuarioRepositorioDal, UsuarioRepositorioDal>(Lifestyle
                .Scoped); //Added 24/01/2020 Breno



            // Infra Dados            
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IUnitOfWorkEntity, UnitOfWorkEntity>(Lifestyle.Scoped);
            container.Register<CrudContext>(Lifestyle.Scoped);
            container.Register<IDapperContexto, DapperContexto>(Lifestyle.Scoped);
            container.Register(typeof(IRepositorioEntity<>), typeof(RepositorioEntity<>));
            container.Register<IUsuarioRepositorio, UsuarioRepositorio>(Lifestyle.Scoped);
            container.Register<IProdutoRepositorio, ProdutoRepositorio>(Lifestyle.Scoped);
            container.Register<IProdutoTipoRepositorio, ProdutoTipoRepositorio>(Lifestyle.Scoped);
            container.Register<IConfiguracaoRepositorio, ConfiguracaoRepositorio>(Lifestyle.Scoped);
            container.Register<IAcessoRepositorio, AcessoRepositorio>(Lifestyle.Scoped);
            container.Register<IStatusAtividadeRepositorio, StatusAtividadeRepositorio>(Lifestyle.Scoped);
            container.Register<IAtividadeRepositorio, AtividadeRepositorio>(Lifestyle.Scoped);
            container.Register<IAtividadeTipoRepositorio, AtividadeTipoRepositorio>(Lifestyle.Scoped);
            container.Register<ILigacaoRepositorio, LigacaoRepositorio>(Lifestyle.Scoped);
            container.Register<IAtendimentoRepositorio, AtendimentoRepositorio>(Lifestyle.Scoped);
            container.Register<IClienteRepositorio, ClienteRepositorio>(Lifestyle.Scoped);
            container.Register<IPessoaFisicaRepositorio, PessoaFisicaRepositorio>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaRepositorio, PessoaJuridicaRepositorio>(Lifestyle.Scoped);
            container.Register<IOcorrenciaRepositorio, OcorrenciaRepositorio>(Lifestyle.Scoped);
            container.Register<IOcorrenciaTipoRepositorio, OcorrenciaTipoRepositorio>(Lifestyle.Scoped);
            container.Register<IContratoRepositorio, ContratoRepositorio>(Lifestyle.Scoped);
            container.Register<ITerminaisUsuarioRepositorio, TerminaisUsuarioRepositorio>(Lifestyle.Scoped);
            container.Register<IStatusEntidadeRepositorio, StatusEntidadeRepositorio>(Lifestyle.Scoped);
            container.Register<ICidadeRepositorio, CidadeRepositorio>(Lifestyle.Scoped);
            container.Register<IFilaRepositorio, FilaRepositorio>(Lifestyle.Scoped);
            container.Register<IAtividadeFilasApoioRepositorio, AtividadeFilasApoioRepositorio>(Lifestyle.Scoped);
            container.Register<IAnotacaoRepositorio, AnotacaoRepositorio>(Lifestyle.Scoped);
            container.Register<IAnotacoesApoioRepositorio, AnotacoesApoioRepositorio>(Lifestyle.Scoped);
            container.Register<ITarefaAtividadeOcorrenciaRepositorio, TarefaAtividadeOcorrenciaRepositorio>(
                Lifestyle.Scoped);
            container.Register<ITarefaRepositorio, TarefaRepositorio>(Lifestyle.Scoped);
            container.Register<IOcorrenciaTiposXOcorrenciaRepositorio, OcorrenciaTiposXOcorrenciaRepositorio>(
                Lifestyle.Scoped);
            container.Register<IRelatorioRepositorio, RelatorioRepositorio>(Lifestyle.Scoped);
            container.Register<IOcorrenciaXstatusEntidadeApoioRepositorio, OcorrenciaXstatusEntidadeApoioRepositorio>(
                Lifestyle.Scoped);
            container.Register<IMenuRepositorio, MenuRepositorio>(Lifestyle.Scoped);
            container.Register<IFuncionalidadeRepositorio, FuncionalidadeRepositorio>(Lifestyle.Scoped);
            container.Register<IAtividadeApoioRepositorio, AtividadeApoioRepositorio>(Lifestyle.Scoped);
            container.Register<ITelefoneRepositorio, TelefoneRepositorio>(Lifestyle.Scoped);
            container.Register<IAtendimentoOcorrenciaRepositorio, AtendimentoOcorrenciaRepositorio>(Lifestyle.Scoped);
            container.Register<IEntidadeRepositorio, EntidadeRepositorio>(Lifestyle.Scoped);
            container.Register<ITelefonesTiposRepositorio, TelefonesTiposRepositorio>(Lifestyle.Scoped);
            container.Register<ICampoDinamicoRepositorio, CampoDinamicoRepositorio>(Lifestyle.Scoped);
            container.Register<ICampoDinamicoOpcaoRepositorio, CampoDinamicoOpcaoRepositorio>(Lifestyle.Scoped);
            container.Register<IEntidadeSecaoCampoDinamicoRepositorio, EntidadeSecaoCampoDinamicoRepositorio>(
                Lifestyle.Scoped);
            container.Register<ICampoDinamicoPreenchidoRepositorio, CampoDinamicoPreenchidoRepositorio>(
                Lifestyle.Scoped);
            container.Register<IListasDePrecosRepositorio, ListasDePrecosRepositorio>(Lifestyle.Scoped);
            container.Register<IListaDePrecosProdutoRepositorio, ListaDePrecosProdutoRepositorio>(Lifestyle.Scoped);
            container.Register<IEntidadeSecaoRepositorio, EntidadeSecaoRepositorio>(Lifestyle.Scoped);
            container.Register<IVendasRepositorio, VendasRepositorio>(Lifestyle.Scoped);
            container.Register<IVendasProdutosRepositorio, VendasProdutosRepositorio>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaTiposContatoRepositorio, PessoaJuridicaTiposContatoRepositorio>(
                Lifestyle.Scoped);
            container.Register<IPessoaJuridicaContatoRepositorio, PessoaJuridicaContatoRepositorio>(Lifestyle.Scoped);
            container.Register<IContratoProdutoRepositorio, ContratoProdutoRepositorio>(Lifestyle.Scoped);
            container.Register<IPotenciaisClienteRepositorio, PotenciaisClienteRepositorio>(Lifestyle.Scoped);
            container.Register<ILocalRepositorio, LocalRepositorio>(Lifestyle.Scoped);
            container.Register<IEnderecoRepositorio, EnderecoRepositorio>(Lifestyle.Scoped);
            container.Register<ILocalTipoRepositorio, LocalTipoRepositorio>(Lifestyle.Scoped);
            container.Register<ILocalTipoAtendimentoRepositorio, LocalTipoAtendimentoRepositorio>(Lifestyle.Scoped);
            //container.Register<IAxaLaudoRepositorio_, AxaLaudoRepositorio>(Lifestyle.Scoped);
            container.Register<IOcorrenciaLocalTipoAtendimentoRepositorio, OcorrenciaLocalTipoAtendimentoRepositorio>(
                Lifestyle.Scoped);
            container.Register<IMidiaRepositorio, MidiaRepositorio>(Lifestyle.Scoped);
            container.Register<ITimelineApoioRepositorio, TimelineApoioRepositorio>(Lifestyle.Scoped);
            container.Register<ICamposDinamicosRepositorio, CamposDinamicos>(Lifestyle.Scoped);
            container.Register<IAtividadeParteEnvolvidaRepositorio, AtividadeParteEnvolvidaRepositorio>(
                Lifestyle.Scoped);
            container.Register<IEmailAnexoRepositorio, EmailAnexoRepositorio>(Lifestyle.Scoped);
            container.Register<IEmailRepositorio, EmailRepositorio>(Lifestyle.Scoped);
            container.Register<IEmailRepositorioDal, EmailRepositorioDal>(Lifestyle.Scoped);

            container.Register<IConfiguracaoContasEmailsRepositorio, ConfiguracaoContasEmailsRepositorio>(
                Lifestyle.Scoped);
            container.Register<IEmailModeloRepositorio, EmailModeloRepositorio>(Lifestyle.Scoped);
            container.Register<ITokenAcessoRapidoRepositorio, TokenAcessoRapidoRepositorio>(Lifestyle.Scoped);
            container.Register<IAtividadeFilaRepositorio, AtividadeFilaRepositorio>(Lifestyle.Scoped);
            container.Register<IAcoesTokensValidadeRepositorio, AcoesTokensValidadeRepositorio>(Lifestyle.Scoped);
            container.Register<IAspNetRolesFilaRepositorio, AspNetRolesFilaRepositorio>(Lifestyle.Scoped);
            container.Register<IEmailLogRepositorio, EmailLogRepositorio>(Lifestyle.Scoped);
            container.Register<ICanalRepositorio, CanalRepositorio>(Lifestyle.Scoped);
            container.Register<IReportRepositorio, ReportRepositorio>(Lifestyle.Scoped);
            container.Register<IDashboardRepositorio, DashboardRepositorio>(Lifestyle.Scoped);
            container.Register<IRoleClaimRepositorio, RoleClaimRepositorio>(Lifestyle.Scoped);
            container.Register<IAspNetClaimRepositorio, AspNetClaimRepositorio>(Lifestyle.Scoped);
            container.Register<IAspNetMatrizRepositorio, AspNetMatrizRepositorio>(Lifestyle.Scoped);
            container.Register<IChatRepositorio, ChatRepositorio>(Lifestyle.Scoped);
            container.Register<IArquivoRepositorio, ArquivoRepositorio>(Lifestyle.Scoped);
            container.Register<ILogAcessoRepositorio, LogAcessoRepositorio>(Lifestyle.Scoped);
            container.Register<IChatMensagemRepositorio, ChatMensagensRepositorio>(Lifestyle.Scoped);
            container.Register<IAtividadeHistoricoRepositorio, AtividadeHistoricoRepositorio>(Lifestyle.Scoped);
            container.Register<IDepartamentoRepositorio, DepartamentoRepositorio>(Lifestyle.Scoped);
            container.Register<IEquipeRepositorio, EquipeRepositorio>(Lifestyle.Scoped);
            container.Register<IChatUraRepositorio, ChatUraRepositorio>(Lifestyle.Scoped);
            container.Register<IAplicacaoRepositorio, AplicacaoRepositorio>(Lifestyle.Scoped);
            container.Register<IAspNetRolesMenuRepositorio, AspNetRolesMenuRepositorio>(Lifestyle.Scoped);
            container.Register<IEntidadeCampoValorRepositorio, EntidadeCampoValorRepositorio>(Lifestyle.Scoped);
            container.Register<IOcorrenciaAcompanhamentoRepositorio, OcorrenciaAcompanhamentoRepositorio>(
                Lifestyle.Scoped);
            container.Register<IAtendimentoAtividadeRepositorio, AtendimentoAtividadeRepositorio>(Lifestyle.Scoped);
            container.Register<IAnotacaoTipoRepositorio, AnotacaoTipoRepositorio>(Lifestyle.Scoped);
            container.Register<IChatSolicitacaoRepositorio, ChatSolicitacaoRepositorio>(Lifestyle.Scoped);
            container.Register<IPausaRepositorio, PausaRepositorio>(Lifestyle.Scoped);
            container.Register<IPausaMotivoRepositorio, PausaMotivoRepositorio>(Lifestyle.Scoped);
            container.Register<IRelatorioRepositorioAdo, RelatorioRepositorioAdo>(Lifestyle.Scoped);
            container.Register<IFeriadoRepositorio, FeriadoRepositorio>(Lifestyle.Scoped);
            container.Register<IPerfilRepositorio, PerfilRepositorio>(Lifestyle.Scoped);
            container.Register<IIntegracaoControleRepositorio, IntegracaoControleRepositorio>(Lifestyle.Scoped);
            container.Register<ITextoRepositorio, TextoRepositorio>(Lifestyle.Scoped);
            container.Register<ITextoCategoriaRepositorio, TextoCategoriaRepositorio>(Lifestyle.Scoped);
            container.Register<ITextoFilaRepositorio, TextoFilaRepositorio>(Lifestyle.Scoped);
            container.Register<ITextoTipoRepositorio, TextoTipoRepositorio>(Lifestyle.Scoped);
            container.Register<ITextoFormatoRepositorio, TextoFormatoRepositorio>(Lifestyle.Scoped);
            container.Register<IAtividadeRepositorioDal, AtividadeRepositorioDal>(Lifestyle.Scoped);

            // Handlers
            container.Register<IHandler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);
            container.Register<IHandler<UsuarioCadastradoEvento>, UsuarioCadastradoHandler>(Lifestyle.Scoped);

            // Infra Core
            container.Register<IEnvioEmail, EnvioEmail>(Lifestyle.Singleton);

            // Registrando Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(
                () => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
        }

        public static Container ContainerServicoLeituraEmail()
        {
            var container = new Container();
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Transient);
            container.Register<IUnitOfWorkEntity, UnitOfWorkEntity>(Lifestyle.Transient);
            container.Register<CrudContext>(Lifestyle.Transient);
            container.Register<IDapperContexto, DapperContexto>(Lifestyle.Transient);
            container.Register(typeof(IRepositorioEntity<>), typeof(RepositorioEntity<>));
            //container.Register<IRepositorioDal, RepositorioDal>(Lifestyle.Scoped); //Added 21/01/2020 Breno
            container.Register<IConfiguracaoContasEmailsServico, ConfiguracaoContasEmailsServico>(Lifestyle.Transient);
            container.Register<IConfiguracaoContasEmailsRepositorio, ConfiguracaoContasEmailsRepositorio>(
                Lifestyle.Transient);
            container.Register<IEmailAnexoServico, EmailAnexoServico>(Lifestyle.Transient);
            container.Register<IEmailAnexoRepositorio, EmailAnexoRepositorio>(Lifestyle.Transient);
            container.Register<IEmailServico, EmailServico>(Lifestyle.Transient);
            container.Register<IEmailRepositorio, EmailRepositorio>(Lifestyle.Transient);
            //container.Register<IEmailRepositorioDal, EmailRepositorioDal>(Lifestyle.Scoped);
            container.Register<IAtividadeServico, AtividadeServico>(Lifestyle.Transient);
            container.Register<IAtividadeRepositorio, AtividadeRepositorio>(Lifestyle.Transient);
            container.Register<IStatusAtividadeServico, StatusAtividadeServico>(Lifestyle.Transient);
            container.Register<IStatusAtividadeRepositorio, StatusAtividadeRepositorio>(Lifestyle.Transient);
            container.Register<IEmailLogServico, EmailLogServico>(Lifestyle.Transient);
            container.Register<IEmailLogRepositorio, EmailLogRepositorio>(Lifestyle.Transient);
            container.Register<IAtividadeTipoServico, AtividadeTipoServico>(Lifestyle.Transient);
            container.Register<IAtividadeTipoRepositorio, AtividadeTipoRepositorio>(Lifestyle.Transient);
            container.Register<IAtividadeParteEnvolvidaRepositorio, AtividadeParteEnvolvidaRepositorio>(
                Lifestyle.Transient);
            container.Register<IAtividadeParteEnvolvidaServico, AtividadeParteEnvolvidaServico>(Lifestyle.Transient);
            container.Register<IAtividadeFilaServico, AtividadeFilaServico>(Lifestyle.Transient);
            container.Register<IAtividadeFilaRepositorio, AtividadeFilaRepositorio>(Lifestyle.Transient);
            container.Register<IFilaRepositorio, FilaRepositorio>(Lifestyle.Transient);
            container.Register<IFilaServico, FilaServico>(Lifestyle.Transient);
            container.Register<IConfiguracaoServico, ConfiguracaoServico>(Lifestyle.Transient);
            container.Register<IConfiguracaoRepositorio, ConfiguracaoRepositorio>(Lifestyle.Transient);
            container.Register<ILigacaoServico, LigacaoServico>(Lifestyle.Transient);
            container.Register<ILigacaoRepositorio, LigacaoRepositorio>(Lifestyle.Transient);
            container.Register<IOcorrenciaServico, OcorrenciaServico>(Lifestyle.Transient);
            container.Register<IOcorrenciaRepositorio, OcorrenciaRepositorio>(Lifestyle.Transient);
            container.Register<ICampoDinamicoRepositorio, CampoDinamicoRepositorio>(Lifestyle.Transient);
            container.Register<ICampoDinamicoOpcaoRepositorio, CampoDinamicoOpcaoRepositorio>(Lifestyle.Transient);
            container.Register<ICamposDinamicosRepositorio, CamposDinamicos>(Lifestyle.Transient);
            container.Register<ICampoDinamicoPreenchidoRepositorio, CampoDinamicoPreenchidoRepositorio>(Lifestyle.Transient);

            container.Register<ICampoDinamicoServico, CampoDinamicoServico>(Lifestyle.Transient);
            container.Register<ICampoDinamicoOpcaoServico, CampoDinamicoOpcaoServico>(Lifestyle.Transient);
            container.Register<IOcorrenciaTipoServico, OcorrenciaTipoServico>(Lifestyle.Transient);
            container.Register<IOcorrenciaTipoRepositorio, OcorrenciaTipoRepositorio>(Lifestyle.Transient);
            container.Register<IAtendimentoServico, AtendimentoServico>(Lifestyle.Transient);
            container.Register<IAtendimentoRepositorio, AtendimentoRepositorio>(Lifestyle.Transient);
            container.Register<IEntidadeCampoValorServico, EntidadeCampoValorServico>(Lifestyle.Transient);
            container.Register<IEntidadeCampoValorRepositorio, EntidadeCampoValorRepositorio>(Lifestyle.Transient);
            container.Register<ICanalServico, CanalServico>(Lifestyle.Transient);
            container.Register<ICanalRepositorio, CanalRepositorio>(Lifestyle.Transient);

            container.Register<IAtendimentoAtividadeServico, AtendimentoAtividadeServico>(Lifestyle.Transient);
            container.Register<IAtendimentoAtividadeRepositorio, AtendimentoAtividadeRepositorio>(Lifestyle.Transient);

            container.Register<IAtividadeApoioServico, AtividadeApoioServico>(Lifestyle.Transient);
            container.Register<IAtividadeApoioRepositorio, AtividadeApoioRepositorio>(Lifestyle.Transient);


            container.Register<IEmailModeloServico, EmailModeloServico>(Lifestyle.Transient);
            container.Register<IEmailModeloRepositorio, EmailModeloRepositorio>(Lifestyle.Transient);
            container.Register<IUsuarioRepositorio, UsuarioRepositorio>(Lifestyle.Transient);
            container.Register<IUsuarioServico, UsuarioServico>(Lifestyle.Transient);
            container.Register<ITokenAcessoRapidoRepositorio, TokenAcessoRapidoRepositorio>(Lifestyle.Transient);
            container.Register<ITokenAcessoRapidoServico, TokenAcessoRapidoServico>(Lifestyle.Transient);
            container.Register<IEnvioEmail, EnvioEmail>(Lifestyle.Transient);
            container.Register<IStatusEntidadeServico, StatusEntidadeServico>(Lifestyle.Transient);
            container.Register<IStatusEntidadeRepositorio, StatusEntidadeRepositorio>(Lifestyle.Transient);
            
            

            container.Register<IFeriadoServico, FeriadoServico>(Lifestyle.Transient);
            container.Register<IFeriadoRepositorio, FeriadoRepositorio>(Lifestyle.Transient);
            container.Register<IRepositorioDal, RepositorioDal>(Lifestyle.Transient); //Added 21/01/2020 Breno
            container.Register<IFilaRepositorioDal, FilaRepositorioDal>(Lifestyle.Transient);//Added 21/01/2020 Breno
            container.Register<IAtividadeFilaApoioRepositorioDal, AtividadeFilaApoioRepositorioDal>(Lifestyle.Transient);//Added 22/01/2020 Breno
            container.Register<IUsuarioRepositorioDal, UsuarioRepositorioDal>(Lifestyle.Transient);//Added 24/01/2020 Breno
            container.Register<IEmailRepositorioDal, EmailRepositorioDal>(Lifestyle.Transient);//Added 24/01/2020 Breno
            container.Register<IAtividadeRepositorioDal, AtividadeRepositorioDal>(Lifestyle.Transient);//Added 24/01/2020 Breno
            return container;
        }

    }
}
