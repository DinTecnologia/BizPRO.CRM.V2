using System;
using System.Linq;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;
using Camadas.Aplicacao.Interfaces;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class AtividadeFilasApoioAppServico : IAtividadeFilasApoioAppServico
    {
        private readonly AtividadeFilasApoioViewModel _model = new AtividadeFilasApoioViewModel();
        private readonly IAtividadeFilasApoioServico _servicoAtividadeFilaApoio;
        private readonly IFilaServico _servicoFila;
        private readonly IUsuarioServico _servicoUsuario;
        private readonly IAtividadesFilaRepositorioDal _atividadesFilaRepositorioDal;
        private readonly IAtividadeFilaApoioRepositorioDal _atividadeFilaApoioRepositorioDal;
        private readonly IFilaRepositorioDal _filaRepositorioDal;

        public AtividadeFilasApoioAppServico
        (
            IAtividadeFilasApoioServico servicoAtividadeFilaApoio
            , IFilaServico servicoFila
            , IUsuarioServico servicoUsuario
            , IAtividadesFilaRepositorioDal atividadesFilaRepositorioDal
            , IAtividadeFilaApoioRepositorioDal atividadeFilaApoioRepositorioDal
            , IFilaRepositorioDal filaRepositorioDal
        )
        {
            _servicoAtividadeFilaApoio = servicoAtividadeFilaApoio;
            _servicoFila = servicoFila;
            _servicoUsuario = servicoUsuario;
            _atividadesFilaRepositorioDal = atividadesFilaRepositorioDal;
            _atividadeFilaApoioRepositorioDal = atividadeFilaApoioRepositorioDal;
            _filaRepositorioDal = filaRepositorioDal;
        }

        public AtividadeFilasApoioViewModel ObterDados(int filaId, string userId, bool finalizado)
        {
            _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, userId, null, null, null,
                filaId, finalizado, null, null, null, null, null);
            _model.Fila = _servicoFila.ObterPorId(filaId);
            _model.FilaId = filaId;
            return _model;
        }

        public AtividadeFilasApoioViewModel ObterDadosUsuario(string userId, string dataInicio, string dataFim,
            string status)
        {
            DateTime data;
            DateTime? DataInicio;
            DateTime? DataFim;

            if (DateTime.TryParse(dataInicio, out data))
                DataInicio = data;
            else
                DataInicio = null;

            if (DateTime.TryParse(dataFim, out data))
                DataFim = data;
            else
                DataFim = null;

            _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, userId, DataInicio, DataFim,
                status, null, true, null, null, null, null, null);
            return _model;
        }

        public AtividadeFilasApoioViewModel ObterDadosUsuarioNaoConcluidas(string userId)
        {
            _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, userId, null, null, null,
                null,
                false, null, null, null, null, null);
            return _model;
        }

        public AtividadeFilasApoioViewModel CarregarSupervisao(string userId)
        {
            _model.Responsaveis = new SelectList(_servicoUsuario.ObterResponsaveisAtividades(), "id", "nome");
            _model.Criadores = new SelectList(_servicoUsuario.ObterCriadoresAtividades(), "id", "nome");
            _model.Filas = new SelectList(_servicoFila.ObterTodos(), "id", "nome");
            return _model;
        }

        public AtividadeFilasApoioViewModel ObterDadosSupervisao(string dataInicio, string dataFim, string status,
            string criadoPorId, string responsavelPorId)
        {
            DateTime data;
            DateTime? DataInicio;
            DateTime? DataFim;

            if (DateTime.TryParse(dataInicio, out data))
                DataInicio = data;
            else
                DataInicio = null;

            if (DateTime.TryParse(dataFim, out data))
                DataFim = data;
            else
                DataFim = null;

            _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(criadoPorId, responsavelPorId,
                DataInicio, DataFim, status, null, true, null, null, null, null, null);
            return _model;
        }

        public AtividadeFilasApoioViewModel ObterDadosSupervisao(int? filaId, string dataInicio, string dataFim,
            bool? atrasadoAtribuicao, bool? atrasadadoAtendimento)
        {
            DateTime data;
            DateTime? DataInicio;
            DateTime? DataFim;

            if (DateTime.TryParse(dataInicio, out data))
                DataInicio = data;
            else
                DataInicio = null;

            if (DateTime.TryParse(dataFim, out data))
                DataFim = data;
            else
                DataFim = null;

            _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, null, DataInicio, DataFim,
                null, filaId, true, atrasadoAtribuicao, atrasadadoAtendimento, null, null, null);
            return _model;
        }

        public AtividadeFilasApoioViewModel ObterAtividadesFila(int filaId, bool finalizado)
        {
            _model.AtividadeFilasApoio =
                _servicoAtividadeFilaApoio.ObterAtividades(null, null, null, null, null, filaId, false, null, null,
                        null,
                        null, null)
                    .Where(w => w.ResponsavelUserId == null).ToList();
            _model.Fila = _servicoFila.ObterPorId(filaId);
            _model.FilaId = filaId;
            return _model;
        }

        public AtividadeFilasApoioViewModel ObterMinhasAtividades(int filaId, string userId, bool finalizado)
        {
            _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, userId, null, null, null,
                filaId, finalizado, null, null, null, null, null);
            _model.Fila = _servicoFila.ObterPorId(filaId);
            _model.FilaId = filaId;
            return _model;
        }

        public AtividadeFilasApoioViewModel ObterDadosSupervisao(string dataInicio, string dataFim, string status,
            string criadoPorId, string responsavelPorId, int? filaId, bool? finalizado, string tipoSla,
            bool? slaTempoEstourado, string emailAssunto)
        {
            var model = new AtividadeFilasApoioViewModel();
            bool? slaAtribuicao = null;
            bool? slaAtendimento = null;

            if (!string.IsNullOrEmpty(tipoSla))
            {
                if (tipoSla.ToLower() == "atribuicao")
                    slaAtribuicao = true;

                if (tipoSla.ToLower() == "atendimento")
                    slaAtendimento = true;
            }

            DateTime data;
            DateTime? DataInicio;
            DateTime? DataFim;

            if (DateTime.TryParse(dataInicio, out data))
                DataInicio = data;
            else
                DataInicio = null;

            if (DateTime.TryParse(dataFim, out data))
                DataFim = data;
            else
                DataFim = null;

            model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividadesSupervisao(criadoPorId,
                responsavelPorId, DataInicio, DataFim, status, filaId, finalizado, slaAtribuicao, slaAtendimento,
                slaTempoEstourado, emailAssunto);
            return model;
        }

        public AtividadeFilasApoioViewModel ObterMinhasAtividades(string usuarioId, DateTime? dataInicio,
            DateTime? dataFim, string status)
        {
            _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, usuarioId, dataInicio,
                dataFim,
                status, null, false, null, null, null, null, null);

            return _model;
        }

        public AtividadeFilasApoioViewModel ObterAtividadesFila(int filaId, string nomeCliente, string emailCliente,
            string assuntoAtividade, bool finalizado)
        {
            _model.AtividadeFilasApoio =
                _servicoAtividadeFilaApoio.ObterAtividades(null, null, null, null, null, filaId, false, null, null,
                        nomeCliente, emailCliente, assuntoAtividade)
                    .Where(w => w.ResponsavelUserId == null).ToList();
            _model.Fila = _servicoFila.ObterPorId(filaId);
            _model.FilaId = filaId;
            return _model;
        }

        //ADO.net 20/01/2020
        public AtividadeFilasApoioViewModel ObterAtividadesFilaDal(int filaId, string nomeCliente, string emailCliente,
            string assuntoAtividade, bool finalizado)
        {
            _model.AtividadeFilasApoio =
                _atividadesFilaRepositorioDal.ObterAtividadesFila(null, null, null, null, null, filaId, false, null,
                        null,
                        nomeCliente, emailCliente, assuntoAtividade)
                    .Where(w => w.ResponsavelUserId == null).ToList();
            _model.Fila = _filaRepositorioDal.ObterPorIdDal(filaId);
            _model.FilaId = filaId;
            return _model;
        }

        public AtividadeFilasApoioViewModel ObterTotalAtividadesFila(int filaId, string nomeCliente,
            string emailCliente,
            string assuntoAtividade, bool finalizado)
        {
            _model.Total =
                _servicoAtividadeFilaApoio.ObterTotalAtividadesFila(null, null, null, null, null, filaId, false, null,
                    null, nomeCliente, emailCliente, assuntoAtividade).FirstOrDefault().Total;
            _model.Fila = _servicoFila.ObterPorId(filaId);
            _model.FilaId = filaId;
            return _model;
        }

        public AtividadeFilasApoioViewModel ObterTotalAtividadesFilaDal(int filaId, string nomeCliente,
            string emailCliente,
            string assuntoAtividade, bool finalizado)
        {
            _model.Total =
                _atividadeFilaApoioRepositorioDal.ObterTotalAtividadesFilaDal(null, null, null, null, null, filaId,
                    false, null,
                    null, nomeCliente, emailCliente, assuntoAtividade);
            _model.Fila = _filaRepositorioDal.ObterPorIdDal(filaId);
            _model.FilaId = filaId;
            return _model;
        }

        public AtividadeFilasApoioViewModel ObterTotalAtividadesFilasDal(string filasIds, string nomeCliente,
            string emailCliente,
            string assuntoAtividade, bool finalizado)
        {
            if (string.IsNullOrEmpty(filasIds))
                return _model;

            try
            {
                string[] stringFilasIds = filasIds.Split('-');
                int[] idsFilas = Array.ConvertAll<string, int>(stringFilasIds, int.Parse);

                int contador = 0;
                foreach (var item in idsFilas)
                {
                    contador++;
                    if (contador > 1)
                        _model.TotalFilas += ",";

                    _model.TotalFilas += _atividadeFilaApoioRepositorioDal.ObterTotalAtividadesFilaDal(null, null, null,
                        null, null, item, false, null, null, nomeCliente, emailCliente, assuntoAtividade).ToString();
                }
            }
            catch (Exception)
            {


            }

            return _model;
        }




        //private readonly AtividadeFilasApoioViewModel _model = new AtividadeFilasApoioViewModel();
        //private readonly IAtividadeFilasApoioServico _servicoAtividadeFilaApoio;
        //private readonly IFilaServico _servicoFila;
        //private readonly IUsuarioServico _servicoUsuario;

        //public AtividadeFilasApoioAppServico
        //(
        //    IAtividadeFilasApoioServico servicoAtividadeFilaApoio
        //    , IFilaServico servicoFila
        //    , IUsuarioServico servicoUsuario
        //)
        //{
        //    _servicoAtividadeFilaApoio = servicoAtividadeFilaApoio;
        //    _servicoFila = servicoFila;
        //    _servicoUsuario = servicoUsuario;
        //}

        //public AtividadeFilasApoioViewModel ObterDados(int filaId, string userId, bool finalizado)
        //{
        //    _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, userId, null, null, null,
        //        filaId, finalizado, null, null);
        //    _model.Fila = _servicoFila.ObterPorId(filaId);
        //    _model.FilaId = filaId;
        //    return _model;
        //}

        //public AtividadeFilasApoioViewModel ObterDadosUsuario(string userId, string dataInicio, string dataFim,
        //    string status)
        //{
        //    DateTime data;
        //    DateTime? DataInicio;
        //    DateTime? DataFim;

        //    if (DateTime.TryParse(dataInicio, out data))
        //        DataInicio = data;
        //    else
        //        DataInicio = null;

        //    if (DateTime.TryParse(dataFim, out data))
        //        DataFim = data;
        //    else
        //        DataFim = null;

        //    _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, userId, DataInicio, DataFim,
        //        status, null, true, null, null);
        //    return _model;
        //}

        //public AtividadeFilasApoioViewModel ObterDadosUsuarioNaoConcluidas(string userId)
        //{
        //    _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, userId, null, null, null, null,
        //        false, null, null);
        //    return _model;
        //}

        //public AtividadeFilasApoioViewModel CarregarSupervisao(string userId)
        //{
        //    _model.Responsaveis = new SelectList(_servicoUsuario.ObterResponsaveisAtividades(), "id", "nome");
        //    _model.Criadores = new SelectList(_servicoUsuario.ObterCriadoresAtividades(), "id", "nome");
        //    _model.Filas = new SelectList(_servicoFila.ObterTodos(), "id", "nome");
        //    return _model;
        //}

        //public AtividadeFilasApoioViewModel ObterDadosSupervisao(string dataInicio, string dataFim, string status,
        //    string criadoPorId, string responsavelPorId)
        //{
        //    DateTime data;
        //    DateTime? DataInicio;
        //    DateTime? DataFim;

        //    if (DateTime.TryParse(dataInicio, out data))
        //        DataInicio = data;
        //    else
        //        DataInicio = null;

        //    if (DateTime.TryParse(dataFim, out data))
        //        DataFim = data;
        //    else
        //        DataFim = null;

        //    _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(criadoPorId, responsavelPorId,
        //        DataInicio, DataFim, status, null, true, null, null);
        //    return _model;
        //}

        //public AtividadeFilasApoioViewModel ObterDadosSupervisao(int? filaId, string dataInicio, string dataFim,
        //    bool? atrasadoAtribuicao, bool? atrasadadoAtendimento)
        //{
        //    DateTime data;
        //    DateTime? DataInicio;
        //    DateTime? DataFim;

        //    if (DateTime.TryParse(dataInicio, out data))
        //        DataInicio = data;
        //    else
        //        DataInicio = null;

        //    if (DateTime.TryParse(dataFim, out data))
        //        DataFim = data;
        //    else
        //        DataFim = null;

        //    _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, null, DataInicio, DataFim,
        //        null, filaId, true, atrasadoAtribuicao, atrasadadoAtendimento);
        //    return _model;
        //}

        //public AtividadeFilasApoioViewModel ObterAtividadesFila(int filaId, bool finalizado)
        //{
        //    _model.AtividadeFilasApoio =
        //        _servicoAtividadeFilaApoio.ObterAtividades(null, null, null, null, null, filaId, false, null, null)
        //            .Where(w => w.ResponsavelUserId == null).ToList();
        //    _model.Fila = _servicoFila.ObterPorId(filaId);
        //    _model.FilaId = filaId;
        //    return _model;
        //}

        //public AtividadeFilasApoioViewModel ObterMinhasAtividades(int filaId, string userId, bool finalizado)
        //{
        //    _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, userId, null, null, null,
        //        filaId, finalizado, null, null);
        //    _model.Fila = _servicoFila.ObterPorId(filaId);
        //    _model.FilaId = filaId;
        //    return _model;
        //}

        //public AtividadeFilasApoioViewModel ObterDadosSupervisao(string dataInicio, string dataFim, string status,
        //    string criadoPorId, string responsavelPorId, int? filaId, bool? finalizado, string tipoSla,
        //    bool? slaTempoEstourado)
        //{
        //    var model = new AtividadeFilasApoioViewModel();
        //    bool? slaAtribuicao = null;
        //    bool? slaAtendimento = null;

        //    if (!string.IsNullOrEmpty(tipoSla))
        //    {
        //        if (tipoSla.ToLower() == "atribuicao")
        //            slaAtribuicao = true;

        //        if (tipoSla.ToLower() == "atendimento")
        //            slaAtendimento = true;
        //    }

        //    DateTime data;
        //    DateTime? DataInicio;
        //    DateTime? DataFim;

        //    if (DateTime.TryParse(dataInicio, out data))
        //        DataInicio = data;
        //    else
        //        DataInicio = null;

        //    if (DateTime.TryParse(dataFim, out data))
        //        DataFim = data;
        //    else
        //        DataFim = null;

        //    model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividadesSupervisao(criadoPorId,
        //        responsavelPorId, DataInicio, DataFim, status, filaId, finalizado, slaAtribuicao, slaAtendimento,
        //        slaTempoEstourado);
        //    return model;
        //}

        //public AtividadeFilasApoioViewModel ObterMinhasAtividades(string usuarioId, DateTime? dataInicio,
        //    DateTime? dataFim, string status)
        //{
        //    _model.AtividadeFilasApoio = _servicoAtividadeFilaApoio.ObterAtividades(null, usuarioId, dataInicio, dataFim,
        //        status, null, false, null, null);

        //    return _model;
        //}
    }
}