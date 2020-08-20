using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Constants;
using Infrastructure.WinForms.Controls;
using Telerik.WinControls.UI;

namespace Delfin.Principal.Mantenimientos.MAN009Entidad
{
   public partial class MAN009VViewHistorial : Form
   {

      private BindingSource BSItems { get; set; }

      public MAN009VViewHistorial(MAN009DViewLCredito.TLCredito x_TOpcion, ObservableCollection<Entities.EntidadLimiteCredito> listEntidadLimiteCreditos, String x_cadena)
      {
         InitializeComponent();
         try
         {
            panelCaption3.Text = String.Format(panelCaption3.Text, x_cadena);
            this.Text = panelCaption3.Text;

            switch (x_TOpcion)
            {
               case MAN009DViewLCredito.TLCredito.Cliente:
                  FormatDataGridLimiteCreditoCliente();
                  break;
               case MAN009DViewLCredito.TLCredito.Proveedor:
                  FormatDataGridLimiteCreditoProveedor();
                  break;
            }
            

            BSItems = new BindingSource();
            BSItems.DataSource = listEntidadLimiteCreditos;
            grdItemsLimiteCreditoCli.DataSource = BSItems;
            navItems.BindingSource = BSItems;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError("Historial", "Ha ocurrido un error inicializando la vista", ex); }
      }


      private void FormatDataGridLimiteCreditoCliente()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsLimiteCreditoCli.Columns.Clear();
            this.grdItemsLimiteCreditoCli.AllowAddNewRow = false;

            this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_Codigo", "Código", "ENLI_Codigo");
            this.grdItemsLimiteCreditoCli.Columns["ENLI_Codigo"].Width = 50;
            this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_TiposDescripcion", "Tipo", "ENLI_TiposDescripcion");
            this.grdItemsLimiteCreditoCli.Columns["ENLI_TiposDescripcion"].Width = 120;
            this.grdItemsLimiteCreditoCli.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItemsLimiteCreditoCli.Columns["TIPO_MND"].Width = 80;

            //this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_Monto", "Monto", "ENLI_Monto");
            GridViewDecimalColumn ENLI_Monto = new GridViewDecimalColumn();
            ENLI_Monto.Name = "ENLI_Monto";
            ENLI_Monto.HeaderText = "Monto";
            ENLI_Monto.FieldName = "ENLI_Monto";
            ENLI_Monto.DecimalPlaces = 2;
            ENLI_Monto.Maximum = 99999999;
            ENLI_Monto.Minimum = 0;
            ENLI_Monto.ThousandsSeparator = true;
            grdItemsLimiteCreditoCli.MasterTemplate.Columns.Add(ENLI_Monto);
            grdItemsLimiteCreditoCli.Columns["ENLI_Monto"].Width = 90;
            grdItemsLimiteCreditoCli.Columns["ENLI_Monto"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsLimiteCreditoCli.Columns["ENLI_Monto"].ReadOnly = true;

            this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_Fecha", "Fecha Convenio", "ENLI_Fecha");
            this.grdItemsLimiteCreditoCli.Columns["ENLI_Fecha"].Width = 100;
            this.grdItemsLimiteCreditoCli.Columns["ENLI_Fecha"].FormatString = "{0:dd/MM/yyyy}";

            //this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_DiasDuracion", "Dias", "ENLI_DiasDuracion");
            GridViewDecimalColumn ENLI_DiasDuracion = new GridViewDecimalColumn();
            ENLI_DiasDuracion.Name = "ENLI_DiasDuracion";
            ENLI_DiasDuracion.HeaderText = "Dias";
            ENLI_DiasDuracion.FieldName = "ENLI_DiasDuracion";
            ENLI_DiasDuracion.DecimalPlaces = 0;
            ENLI_DiasDuracion.Maximum = 9999;
            ENLI_DiasDuracion.Minimum = 0;
            grdItemsLimiteCreditoCli.MasterTemplate.Columns.Add(ENLI_DiasDuracion);
            grdItemsLimiteCreditoCli.Columns["ENLI_DiasDuracion"].Width = 50;
            grdItemsLimiteCreditoCli.Columns["ENLI_DiasDuracion"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsLimiteCreditoCli.Columns["ENLI_DiasDuracion"].ReadOnly = true;

            //this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_FecInicio", "Fecha Inicio", "ENLI_FecInicio");
            //this.grdItemsLimiteCreditoCli.Columns["ENLI_FecInicio"].Width = 100;
            //this.grdItemsLimiteCreditoCli.Columns["ENLI_FecInicio"].FormatString = "{0:dd/MM/yyyy}";
            //this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_FecVencimiento", "Fecha Vencimiento", "ENLI_FecVencimiento");
            //this.grdItemsLimiteCreditoCli.Columns["ENLI_FecVencimiento"].Width = 100;
            //this.grdItemsLimiteCreditoCli.Columns["ENLI_FecVencimiento"].FormatString = "{0:dd/MM/yyyy}";

            /* Propiedades Finales */
            //grdItemsLimiteCreditoCli.BestFitColumns();

            grdItemsLimiteCreditoCli.ReadOnly = true;
            grdItemsLimiteCreditoCli.ShowFilteringRow = false;
            grdItemsLimiteCreditoCli.EnableFiltering = false;
            grdItemsLimiteCreditoCli.MasterTemplate.EnableFiltering = false;
            grdItemsLimiteCreditoCli.EnableGrouping = false;
            grdItemsLimiteCreditoCli.MasterTemplate.EnableGrouping = false;
            grdItemsLimiteCreditoCli.EnableSorting = false;
            grdItemsLimiteCreditoCli.MasterTemplate.EnableCustomSorting = false;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError("Historial", Mensajes.FormatDataGridView, ex); }
      }

      private void FormatDataGridLimiteCreditoProveedor()
      {
         try
         {
            Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
            this.grdItemsLimiteCreditoCli.Columns.Clear();
            this.grdItemsLimiteCreditoCli.AllowAddNewRow = false;
            
            this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_FecInicio", "Fecha Inicio", "ENLI_FecInicio");
            this.grdItemsLimiteCreditoCli.Columns["ENLI_FecInicio"].Width = 100;
            this.grdItemsLimiteCreditoCli.Columns["ENLI_FecInicio"].FormatString = "{0:dd/MM/yyyy}";
            this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_FecVencimiento", "Fecha Vencimiento", "ENLI_FecVencimiento");
            this.grdItemsLimiteCreditoCli.Columns["ENLI_FecVencimiento"].Width = 100;
            this.grdItemsLimiteCreditoCli.Columns["ENLI_FecVencimiento"].FormatString = "{0:dd/MM/yyyy}";

            this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_Codigo", "Código", "ENLI_Codigo");
            this.grdItemsLimiteCreditoCli.Columns["ENLI_Codigo"].Width = 50;
            this.grdItemsLimiteCreditoCli.Columns.Add("TIPO_MND", "Moneda", "TIPO_MND");
            this.grdItemsLimiteCreditoCli.Columns["TIPO_MND"].Width = 150;

            //this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_Monto", "Monto", "ENLI_Monto");
            GridViewDecimalColumn ENLI_Monto = new GridViewDecimalColumn();
            ENLI_Monto.Name = "ENLI_Monto";
            ENLI_Monto.HeaderText = "Monto";
            ENLI_Monto.FieldName = "ENLI_Monto";
            ENLI_Monto.DecimalPlaces = 2;
            ENLI_Monto.Maximum = 99999999;
            ENLI_Monto.Minimum = 0;
            ENLI_Monto.ThousandsSeparator = true;
            ENLI_Monto.FormatString = "{0:#,###,##0.00}";
            grdItemsLimiteCreditoCli.MasterTemplate.Columns.Add(ENLI_Monto);
            grdItemsLimiteCreditoCli.Columns["ENLI_Monto"].Width = 90;
            grdItemsLimiteCreditoCli.Columns["ENLI_Monto"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsLimiteCreditoCli.Columns["ENLI_Monto"].ReadOnly = true;

            //this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_Fecha", "Fecha Convenio", "ENLI_Fecha");
            //this.grdItemsLimiteCreditoCli.Columns["ENLI_Fecha"].Width = 100;
            //this.grdItemsLimiteCreditoCli.Columns["ENLI_Fecha"].FormatString = "{0:dd/MM/yyyy}";

            //this.grdItemsLimiteCreditoCli.Columns.Add("ENLI_DiasDuracion", "Dias", "ENLI_DiasDuracion");
            GridViewDecimalColumn ENLI_DiasDuracion = new GridViewDecimalColumn();
            ENLI_DiasDuracion.Name = "ENLI_DiasDuracion";
            ENLI_DiasDuracion.HeaderText = "Dias";
            ENLI_DiasDuracion.FieldName = "ENLI_DiasDuracion";
            ENLI_DiasDuracion.DecimalPlaces = 0;
            ENLI_DiasDuracion.Maximum = 9999;
            ENLI_DiasDuracion.Minimum = 0;
            grdItemsLimiteCreditoCli.MasterTemplate.Columns.Add(ENLI_DiasDuracion);
            grdItemsLimiteCreditoCli.Columns["ENLI_DiasDuracion"].Width = 50;
            grdItemsLimiteCreditoCli.Columns["ENLI_DiasDuracion"].TextAlignment = ContentAlignment.MiddleRight;
            grdItemsLimiteCreditoCli.Columns["ENLI_DiasDuracion"].ReadOnly = true;


            /* Propiedades Finales */
            //grdItemsLimiteCreditoCli.BestFitColumns();

            grdItemsLimiteCreditoCli.ReadOnly = true;
            grdItemsLimiteCreditoCli.ShowFilteringRow = false;
            grdItemsLimiteCreditoCli.EnableFiltering = false;
            grdItemsLimiteCreditoCli.MasterTemplate.EnableFiltering = false;
            grdItemsLimiteCreditoCli.EnableGrouping = false;
            grdItemsLimiteCreditoCli.MasterTemplate.EnableGrouping = false;
            grdItemsLimiteCreditoCli.EnableSorting = false;
            grdItemsLimiteCreditoCli.MasterTemplate.EnableCustomSorting = false;

         }
         catch (Exception ex)
         { Dialogos.MostrarMensajeError("Historial", Mensajes.FormatDataGridView, ex); }
      }
   }
}
