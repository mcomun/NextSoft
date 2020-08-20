using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.DataAccess;

namespace Delfin.Principal
{
   public partial class CAJ017View : Form, ICAJ017View
   {
      #region [ Variables ]
      private String m_mensaje = string.Format("*\t{0}\n*\t{1}\n*\t{2}\n", "No tiene detalles de Contendores", "No se encuentra Pre-Facturada", "No tiene habilitado la opcion de Emitir Aviso de Llegada");
      private String m_ccot_numero;
      private Nullable<Int32> m_entc_codcliente;
      #endregion

      #region [ Propiedades ]
      public CAJ017Presenter Presenter { get; set; }
      #endregion

      #region [ Formulario ]
      public CAJ017View()
      {
         InitializeComponent();
         try
         {
            this.btnGenerar.Click += btnGenerar_Click;
            this.btnSalir.Click += btnSalir_Click;
            txaAyudaHBL.AyudaClick += txaAyudaHBL_AyudaClick;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      #endregion

      #region [ ICAJ017MView ]
      public void LoadView()
      {
         try
         {
            txaENTC_CodCliente.ContainerService = Presenter.ContainerService;
            txaENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }
      #endregion

      #region [ Metodos ]
      private void GenerarAviso()
      {
         try
         {
            if (Presenter.GenararDocAviso(m_ccot_numero, m_entc_codcliente))
            {
               Delfin.Controls.EmailFiles EFiles = new Controls.EmailFiles();
               String _mensaje = EFiles.Avisos(Presenter.DTAviso, m_ccot_numero);
               if (!String.IsNullOrEmpty(_mensaje))
               {
                  if (_mensaje.Substring(0, 1) == "#")
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "OCURRIO UN ERROR EN EL METODO DE AVISOS (Ver Detalles)", _mensaje); }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, _mensaje); }
               }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se ha podido Emitir el Avisa por una(s) de la siguientes razones (detalles)", m_mensaje); }
         }
         catch (Exception ex)
         { throw ex; }
      }
      #endregion

      #region [ Eventos ]
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.Close();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      private void btnGenerar_Click(object sender, EventArgs e)
      {
         try
         {
            this.m_ccot_numero = null;
            this.m_entc_codcliente = null;
            if (!string.IsNullOrEmpty(txtCCOT_Numero.Text.Trim()))
            {
               m_ccot_numero = txtCCOT_Numero.Text.Trim();
               if (txaENTC_CodCliente.Value != null)
               { m_entc_codcliente = txaENTC_CodCliente.Value.ENTC_Codigo; }
               this.GenerarAviso();
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar el número de la Orden de Venta"); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al generar el Documento.", ex); }
      }


      private void txaAyudaHBL_AyudaClick(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _listFilters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@psinEMPR_Codigo", FilterValue = Delfin.Controls.Entorno.ItemEmpresa.EMPR_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int16, FilterSize = 2 });
            _listFilters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@DOOV_HBL", FilterValue = txaAyudaHBL.Text, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Varchar, FilterSize = 50 });

            System.Data.DataTable dtAyuda = new System.Data.DataTable();
            dtAyuda = Presenter.Client.GetDTCabPerfilAsientos("COM_CCOTSS_AyudaHBL", _listFilters);

            if (dtAyuda.Rows.Count == 0)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "No se encontraron coincidencias."); }
            else if (dtAyuda.Rows.Count == 1)
            {
               int CCOT_Numero = int.Parse(dtAyuda.Rows[0]["CCOT_Numero"].ToString());
               int CCOT_Tipo = int.Parse(dtAyuda.Rows[0]["CCOT_Tipo"].ToString());

               txtCCOT_Numero.Text = dtAyuda.Rows[0]["CCOT_NumDoc"].ToString();
               txaENTC_CodCliente.SetValue(int.Parse(dtAyuda.Rows[0]["ENTC_CodCliente"].ToString()));
               txaAyudaHBL.SetValue(dtAyuda.Rows[0]["DOOV_HBL"].ToString(), dtAyuda.Rows[0]["DOOV_HBL"].ToString());
            }
            else
            {
               int i = 0;
               List<Infrastructure.WinForms.Controls.ColumnaAyuda> _columnas = new List<Infrastructure.WinForms.Controls.ColumnaAyuda>();
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CCOT_NumDoc",
                  ColumnCaption = "Numero OV",
                  Alineacion = DataGridViewContentAlignment.MiddleCenter,
                  Width = 100,
                  DataType = typeof(System.String),
                  Format = null
               });
               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "ENTC_RazonSocial",
                  ColumnCaption = "Razon Social",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 250,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "DOOV_HBL",
                  ColumnCaption = "Numero HBL",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 150,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "DOOV_MBL",
                  ColumnCaption = "Numero MBL",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 150,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CCOT_FecEmi",
                  ColumnCaption = "Fecha Emisión",
                  Alineacion = DataGridViewContentAlignment.MiddleLeft,
                  Width = 120,
                  DataType = typeof(System.String),
                  Format = null
               });

               _columnas.Add(new Infrastructure.WinForms.Controls.ColumnaAyuda()
               {
                  Index = i++,
                  ColumnName = "CCOT_Numero",
                  ColumnCaption = "Interno",
                  Alineacion = DataGridViewContentAlignment.MiddleCenter,
                  Width = 120,
                  DataType = typeof(System.String),
                  Format = null
               });

               Infrastructure.WinForms.Controls.Ayuda x_Ayuda = new Infrastructure.WinForms.Controls.Ayuda("Ayuda - Documento Origen"
                                                                                                         , dtAyuda, false, _columnas);

               x_Ayuda.Width = x_Ayuda.Width * 2;
               if (x_Ayuda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                  int CCOT_Numero = int.Parse(x_Ayuda.Respuesta.Rows[0]["CCOT_Numero"].ToString());
                  int CCOT_Tipo = int.Parse(x_Ayuda.Respuesta.Rows[0]["CCOT_Tipo"].ToString());

                  txtCCOT_Numero.Text = x_Ayuda.Respuesta.Rows[0]["CCOT_NumDoc"].ToString();
                  txaENTC_CodCliente.SetValue(int.Parse(x_Ayuda.Respuesta.Rows[0]["ENTC_CodCliente"].ToString()));
                  txaAyudaHBL.SetValue(x_Ayuda.Respuesta.Rows[0]["DOOV_HBL"].ToString(), x_Ayuda.Respuesta.Rows[0]["DOOV_HBL"].ToString());
               }
               else
               {
                  //   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Error en el dialogo de Ayuda de Horarios Disponibles"); 
               }
            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Error en el dialogo de Ayuda de Horarios Disponibles", ex); }
      }

      #endregion
   }
}
