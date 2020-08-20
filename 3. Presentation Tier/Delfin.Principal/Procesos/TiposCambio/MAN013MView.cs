using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Delfin.Entities;
using Delfin.Principal.Properties;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.Constants;
using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Client.FormClose;
using Infrastructure.WinFormsControls;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using TiposEntidad = Delfin.Controls.TiposEntidad;
using  System.Data;
using System.Diagnostics;
using ImportarExcel = Delfin.Controls.ImportarExcel;

namespace Delfin.Principal
{
    public partial class MAN013MView : Form, IMAN013MView
   {
      public MAN013MView()
      {
         InitializeComponent();
         try
         {
            btnGuardar.Click += BtnGuardar_Click;
         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError(Presenter.Title, Mensajes.ConstructorView, ex); }
      }
      #region [ Propiedades ]
      public MAN013Presenter Presenter { get; set; }
      public BindingSource BSItemsDetalle { get; set; }

      private Hashtable HashFormulario { get; set; }
      #endregion

      #region [Metodos]

      public void SetFecha(DateTime x_fecha)
      {
         try
         {
            dtpTIPC_Fecha.NSFecha = x_fecha;
         }
         catch (Exception)
         { throw; }
      }

      public void ClearItem()
      {
         txtTIPC_Compra.Text = "0.0000";
         txtTIPC_Venta.Text = "0.0000";
         txnTIPC_DolEuro.Text = "0.000000";
         if (dtpTIPC_Fecha.NSDateTimePicke.Value.Year.ToString() + dtpTIPC_Fecha.NSDateTimePicke.Value.Month.ToString() + dtpTIPC_Fecha.NSDateTimePicke.Value.Day.ToString() != DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString())
            dtpTIPC_Fecha.NSDateTimePicke.Value = DateTime.Now;  
      }

      public void SetItem()
      {
         String _Fecha = Presenter.ItemTiposCambio.TIPC_Fecha;
         DateTime Fecha = Convert.ToDateTime(_Fecha.Substring(0, 4) + "-" + _Fecha.Substring(4, 2) + "-" + _Fecha.Substring(6, 2));
         this.dtpTIPC_Fecha.mdtChangeDate -= this.dtpTIPC_Fecha_mdtChangeDate;
         dtpTIPC_Fecha.NSFecha = Fecha;
         this.dtpTIPC_Fecha.mdtChangeDate += this.dtpTIPC_Fecha_mdtChangeDate;
         txtTIPC_Venta.Text = Presenter.ItemTiposCambio.TIPC_Venta.ToString();
         txtTIPC_Compra.Text = Presenter.ItemTiposCambio.TIPC_Compra.ToString();
         if (Presenter.ItemTiposCambio.TIPC_DolEuro.HasValue) { txnTIPC_DolEuro.Value = Presenter.ItemTiposCambio.TIPC_DolEuro.Value; }
      }

      public void GetItem()
      {
         Presenter.ItemTiposCambio.TIPC_Compra = Convert.ToDecimal (  txtTIPC_Compra.Text);
         Presenter.ItemTiposCambio.TIPC_Venta = Convert.ToDecimal(txtTIPC_Venta.Text);
         Presenter.ItemTiposCambio.TIPC_Fecha = dtpTIPC_Fecha.NSDateTimePicke.Value.Year.ToString() + dtpTIPC_Fecha.NSDateTimePicke.Value.Month.ToString().PadLeft(2,'0')  + dtpTIPC_Fecha.NSDateTimePicke.Value.Day.ToString().PadLeft(2,'0') ;
         Presenter.ItemTiposCambio.TIPC_DolEuro = txnTIPC_DolEuro.Value;
      }


      void BtnGuardar_Click(object sender, EventArgs e)
      {
          Guardar();
      }

      void Guardar()
      {
         try
         {
            if (!Presenter.Guardar()) return;
            errorProvider1.Dispose();
            Close();
         }
         catch (Exception)
         { }
      }

      #endregion

      private void dtpTIPC_Fecha_mdtChangeDate(object sender, EventArgs e)
      {
         Presenter.ValidaExistente(dtpTIPC_Fecha.NSDateTimePicke.Value.Year.ToString() + dtpTIPC_Fecha.NSDateTimePicke.Value.Month.ToString().PadLeft(2,'0')  + dtpTIPC_Fecha.NSDateTimePicke.Value.Day.ToString().PadLeft(2,'0')) ;  
      }
   }
}
