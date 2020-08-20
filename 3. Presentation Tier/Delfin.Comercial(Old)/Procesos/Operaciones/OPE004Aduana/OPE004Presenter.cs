using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Aspect;
using Infrastructure.Aspect.Collections;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;
using System.IO;
using System.Configuration;
using System.Net;
using System.Runtime.Serialization.Json;

namespace Delfin.Comercial
{
    public partial class OPE004Presenter
    {
        #region [ Variables ]

        public String Title = "Emisión Aduana";
        public String CUS = "OPE004";

        #endregion

        #region [ Contrusctor ]

        public OPE004Presenter(IUnityContainer x_container, IOPE004View x_mview)
        {
            try
            {
                this.ContainerService = x_container;
                Session = this.ContainerService.Resolve<ISessionService>();
                this.MView = x_mview;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Load()
        {
            try
            {
                Client = ContainerService.Resolve<IDelfinServices>();
                ListConstantesMOD = Client.GetAllConstantesByConstanteTabla("MOD");
                MView.LoadView();
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex);
            }
        }

        #endregion

        #region [ Parámetros ]
        public Entities.Parametros PARA_RUTA_TELEDESPACHO { get; set; }
        public Entities.Parametros PARA_RUTA_SDA { get; set; }
        public Entities.Parametros PARA_PUERTO_CALLAO { get; set; }
        public Entities.Parametros PARA_EMISION_SDA { get; set; }
        public Entities.Parametros PARA_EMISION_TELEDESPACHO { get; set; }
        public void LoadParameteres()
        {
            try
            {
                var ItemsPARAMETRO = Client.GetAllParametros();
                PARA_RUTA_TELEDESPACHO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "RUTA_TELEDESPACHO");
                PARA_RUTA_SDA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "RUTA_SDA");
                PARA_PUERTO_CALLAO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "PUERTO_CALLAO");
                PARA_EMISION_SDA = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "EMISION_SDA");
                PARA_EMISION_TELEDESPACHO = ItemsPARAMETRO.FirstOrDefault(para => para.PARA_Clave == "EMISION_TELEDESPACHO");
            }
            catch (Exception)
            { }
        }
        #endregion

        #region [ Propiedades ]
        public IUnityContainer ContainerService { get; set; }
        public ISessionService Session { get; set; }
        public IDelfinServices Client { get; set; }
        public IOPE004View MView { get; set; }
        public ObservableCollection<Det_Cotizacion_OV_EventosTareas> ItemsEventosTareas { get; set; }
        public Det_Cotizacion_OV_EventosTareas ItemEventoTarea { get; set; }
        public ObservableCollection<Constantes> ListConstantesMOD { get; set; }
        #endregion

        #region [ Metodos ]

        public void Cargar(Entities.NaveViaje ItemNaveViaje, string Formato)
        {
            try
            {
                Int32 NVIA_Codigo = ItemNaveViaje.NVIA_Codigo;
                System.Data.DataSet dsEmision = Client.GetAllNaveViajeEmisionAduana(NVIA_Codigo, Formato);
                if (VerificaParametros())
                {
                    if (ValidarSDA(ItemNaveViaje, dsEmision.Tables["MSM"]))
                    {
                        String _Ruta = EligeRuta(true, false);
                        if (Directory.Exists(_Ruta))
                        {
                            String _path = String.Empty;
                            if (String.IsNullOrEmpty(ItemNaveViaje.NAVE_Nombre))
                            { _path = _Ruta + "\\" + "CargaNet_Manifiesto_CargaSueltaSDA_" + ItemNaveViaje.NVIA_NroViaje.Trim() + ".txt"; }
                            else
                            { _path = _Ruta + "\\" + "CargaNet_Manifiesto_CargaSueltaSDA_" + ItemNaveViaje.NAVE_Nombre.Trim() + "_" + ItemNaveViaje.NVIA_NroViaje.Trim() + ".txt"; }
                            using (StreamWriter _writer = new StreamWriter(_path))
                            {

                                _writer.WriteLine(dsEmision.Tables["CAB"].Rows[0]["Valor"].ToString());
                                _writer.WriteLine(dsEmision.Tables["MAN"].Rows[0]["Valor"].ToString());

                                foreach (System.Data.DataRow _MBL in dsEmision.Tables["BLM"].Rows)
                                {
                                    _writer.WriteLine(_MBL["Valor"].ToString());

                                    String _filtroMBL = "DOOV_MBL = '" + _MBL["DOOV_MBL"].ToString() + "'";

                                    dsEmision.Tables["BLH"].DefaultView.RowFilter = _filtroMBL;
                                    foreach (System.Data.DataRow _HBL in dsEmision.Tables["BLH"].DefaultView.ToTable().Rows)
                                    {
                                        _writer.WriteLine(_HBL["Valor"].ToString());

                                        String _filtroHBL = "DOOV_HBL = '" + _HBL["DOOV_HBL"].ToString() + "'";
                                        String _filtroHBLDET = "DOOV_HBL = '" + _HBL["DOOV_HBL"].ToString() + "' AND  DOOV_Tipo = '" + _HBL["DOOV_Tipo"].ToString() + "'";
                                        dsEmision.Tables["ENT"].DefaultView.RowFilter = _filtroHBL;
                                        foreach (System.Data.DataRow _ENT in dsEmision.Tables["ENT"].DefaultView.ToTable().Rows)
                                        { _writer.WriteLine(_ENT["Valor"].ToString()); }

                                        dsEmision.Tables["DET"].DefaultView.RowFilter = _filtroHBLDET;
                                        foreach (System.Data.DataRow _DET in dsEmision.Tables["DET"].DefaultView.ToTable().Rows)
                                        { _writer.WriteLine(_DET["Valor"].ToString()); }
                                    }
                                }
                            }
                            System.Diagnostics.ProcessStartInfo _app = new System.Diagnostics.ProcessStartInfo(_path, "");
                            System.Diagnostics.Process.Start(_app);
                            GenerarEventosTareas("Se Generó Archivo para la Emisión de SDA", PARA_EMISION_SDA.PARA_Valor, dsEmision.Tables["OVs"]);
                        }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "La Ruta No Existe en este Ordenador Verifique sus Parametros"); }
                    }
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
        }
        public void CargarTeledespacho(Entities.NaveViaje ItemNaveViaje)
        {
            try
            {
                Int32 NVIA_Codigo = ItemNaveViaje.NVIA_Codigo;
                System.Data.DataSet dsEmision = Client.GetAllNaveViajeEmisionAduanaTeledespacho(NVIA_Codigo);

                if (VerificaParametros())
                {
                    if (ValidarTeledespacho(dsEmision.Tables["MSM"]))
                    {
                        String _Ruta = EligeRuta(false, true);
                        if (Directory.Exists(_Ruta))
                        {
                            String _path = String.Empty;
                            if (String.IsNullOrEmpty(ItemNaveViaje.NAVE_Nombre))
                            { _path = _Ruta + "\\" + "Teledespacho_" + ItemNaveViaje.NVIA_NroViaje.Trim() + ".txt"; }
                            else
                            { _path = _Ruta + "\\" + "Teledespacho_" + ItemNaveViaje.NAVE_Nombre.Trim() + "_" + ItemNaveViaje.NVIA_NroViaje.Trim() + ".txt"; }

                            using (StreamWriter _writer = new StreamWriter(_path))
                            {
                                _writer.WriteLine(dsEmision.Tables["MAN"].Rows[0]["Valor"].ToString());

                                foreach (System.Data.DataRow _MBL in dsEmision.Tables["BLM"].Rows)
                                {
                                    _writer.WriteLine(_MBL["Valor"].ToString());

                                    String _filtroMBL = "DOOV_MBL = '" + _MBL["DOOV_MBL"].ToString() + "'";

                                    dsEmision.Tables["BLH"].DefaultView.RowFilter = _filtroMBL;
                                    foreach (System.Data.DataRow _HBL in dsEmision.Tables["BLH"].DefaultView.ToTable().Rows)
                                    {
                                        _writer.WriteLine(_HBL["Valor"].ToString());

                                        String _filtroHBL = "DOOV_HBL = '" + _HBL["DOOV_HBL"].ToString() + "'";

                                        dsEmision.Tables["ENT"].DefaultView.RowFilter = _filtroHBL;
                                        foreach (System.Data.DataRow _ENT in dsEmision.Tables["ENT"].DefaultView.ToTable().Rows)
                                        { _writer.WriteLine(_ENT["Valor"].ToString()); }

                                        dsEmision.Tables["DET"].DefaultView.RowFilter = _filtroHBL;
                                        foreach (System.Data.DataRow _DET in dsEmision.Tables["DET"].DefaultView.ToTable().Rows)
                                        { _writer.WriteLine(_DET["Valor"].ToString()); }
                                    }
                                }
                            }
                            System.Diagnostics.ProcessStartInfo _app = new System.Diagnostics.ProcessStartInfo(_path, "");
                            System.Diagnostics.Process.Start(_app);
                            GenerarEventosTareas("Se Generó Archivo para la Emisión de Teledespacho", PARA_EMISION_TELEDESPACHO.PARA_Valor, dsEmision.Tables["OVs"]);
                        }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "La Ruta No Existe en este Ordenador Verifique sus Parametros"); }
                    }
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
        }
        public Boolean VerificaParametros()
        {
            Boolean _isCorret = true;
            String _mesaggerError = String.Empty;
            if (PARA_RUTA_SDA == null || PARA_RUTA_TELEDESPACHO == null)
            {
                _isCorret = false;
                _mesaggerError += "* La(s) Ruta(s) para guardar .txt" + Environment.NewLine;
            }
            else if (String.IsNullOrEmpty(PARA_RUTA_SDA.PARA_Valor) || String.IsNullOrEmpty(PARA_RUTA_TELEDESPACHO.PARA_Valor))
            {
                _isCorret = false;
                _mesaggerError += "* La(s) Ruta(s) para guardar .txt" + Environment.NewLine;
            }
            if (_isCorret)
            { return _isCorret; }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Faltan ingresar algunos Parametros ", _mesaggerError); return _isCorret; }
        }
        public String EligeRuta(Boolean x_SDA, Boolean x_Teledespacho)
        {
            String _Ruta = null;
            if (x_SDA)
            { _Ruta = PARA_RUTA_SDA.PARA_Valor; }
            else if (x_Teledespacho)
            { _Ruta = PARA_RUTA_TELEDESPACHO.PARA_Valor; } 
            return _Ruta;
        }
        public Boolean ValidarSDA(Entities.NaveViaje ItemNaveViaje, System.Data.DataTable DTMensaje)
        {
            Boolean _isCorrect = true;
            String m_mensajeError = String.Empty;
            if (String.IsNullOrEmpty(ItemNaveViaje.NVIA_NroManifiesto))
            {
                _isCorrect = false;
                m_mensajeError += "* Debe ingresar el año de manifiesto de la Nave Viaje" + Environment.NewLine;
            }
            else
            {
                if (ItemNaveViaje.NVIA_NroManifiesto.Length < 5)
                {
                    _isCorrect = false;
                    m_mensajeError += "* Debe ingresar el año de manifiesto de la Nave Viaje" + Environment.NewLine;
                }
            }
            if (DTMensaje != null && DTMensaje.Rows.Count > 0) 
            {
                foreach (System.Data.DataRow _MSM in DTMensaje.Rows)
                {
                    _isCorrect = false;
                    m_mensajeError += Convert.ToString(_MSM["MENSAJE"]) + Environment.NewLine;
                }
            }
            if (!_isCorrect)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Faltan ingresar algunos datos", m_mensajeError); }
            return _isCorrect;
        }
        public Boolean ValidarTeledespacho(System.Data.DataTable DTMensaje)
        {
            Boolean _isCorrect = true;
            String m_mensajeError = String.Empty;
            if (DTMensaje != null && DTMensaje.Rows.Count > 0)
            {
                foreach (System.Data.DataRow _MSM in DTMensaje.Rows)
                {
                    _isCorrect = false;
                    m_mensajeError += Convert.ToString(_MSM["MENSAJE"]) + Environment.NewLine;
                }
            }
            if (!_isCorrect)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Faltan ingresar algunos datos", m_mensajeError); }
            return _isCorrect;
        }
        public void GenerarEventosTareas(String Observacion_Evento, String Codigo_Evento, System.Data.DataTable DT_OV)
        {
            try
            {
                ItemsEventosTareas = new ObservableCollection<Det_Cotizacion_OV_EventosTareas>();
                int pos = 1;
                Int32 _CCOT_NumActual = 0;

                if (DT_OV != null && DT_OV.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow drOV in DT_OV.Rows)
                    {
                        if ((Convert.ToInt32(drOV["CCOT_Numero"])) != _CCOT_NumActual)
                        {
                            _CCOT_NumActual = (Convert.ToInt32(drOV["CCOT_Numero"]));

                            ItemEventoTarea = new Det_Cotizacion_OV_EventosTareas();
                            ItemEventoTarea.CCOT_Numero = (Convert.ToInt32(drOV["CCOT_Numero"]));
                            ItemEventoTarea.CCOT_Tipo = (Convert.ToInt16(drOV["CCOT_Tipo"]));
                            ItemEventoTarea.EVEN_Fecha = DateTime.Now;
                            ItemEventoTarea.EVEN_Cumplida = true;
                            ItemEventoTarea.EVEN_Usuario = Session.UserName;
                            ItemEventoTarea.EVEN_Observaciones = Observacion_Evento;
                            ItemEventoTarea.TIPO_TabEVE = "EVE";
                            ItemEventoTarea.TIPO_CodEVE = Codigo_Evento;
                            if (ListConstantesMOD != null && ListConstantesMOD.Count > 0 && ListConstantesMOD.First() != null)
                            {
                                ItemEventoTarea.CONS_TabMOD = ListConstantesMOD.First().CONS_CodTabla;
                                ItemEventoTarea.CONS_CodMOD = ListConstantesMOD.First().CONS_CodTipo;
                            }
                            ItemEventoTarea.EVEN_Manual = false;

                            ItemEventoTarea.AUDI_UsrCrea = Session.UserName;
                            ItemEventoTarea.AUDI_FecCrea = Session.Fecha;

                            ItemEventoTarea.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

                            ItemsEventosTareas.Add(ItemEventoTarea);
                        }
                        else
                        { _CCOT_NumActual = (Convert.ToInt32(drOV["CCOT_Numero"])); }
                        if (DT_OV.Rows.Count == pos)
                        {
                            if ((Client.SaveDet_Cotizacion_OV_EventosTareas(ItemsEventosTareas)))
                            {
                                //Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Se han Generado Eventos");
                            }
                        }
                        pos++;
                    }
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "No hay Ordenes de venta para generar eventos."); }

            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Error al momento de generar Eventos", ex);
            }
        }
        #endregion
    }
}