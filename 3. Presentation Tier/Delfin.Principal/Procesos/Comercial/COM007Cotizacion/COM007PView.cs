using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class COM007PView : Form
   {
      private Int32 ENTC_CodCliente;
      private Nullable<Int32> ENTC_CodTransportista;
      private Nullable<Int32> ENTC_CodAgente;
      private Nullable<Int32> ENTC_CodShipper;
      private Nullable<Int32> ENTC_CodConsignee;
      public COM007PView(IUnityContainer ContainerService,  Int32 x_ENTC_CodCliente, Nullable<Int32> x_ENTC_CodTransportista, Nullable<Int32> x_ENTC_CodAgente, Nullable<Int32> x_ENTC_CodShipper,Nullable<Int32> x_ENTC_CodConsignee)
      {
         InitializeComponent();

         try
         {
            ENTC_Codigo.ContainerService = ContainerService;

            ENTC_CodCliente = x_ENTC_CodCliente;
            ENTC_CodTransportista = x_ENTC_CodTransportista;
            ENTC_CodAgente = x_ENTC_CodAgente;
            ENTC_CodShipper = x_ENTC_CodShipper;
            ENTC_CodConsignee = x_ENTC_CodConsignee; ;

            TIPE_Codigo.SelectedIndexChanged += TIPE_Codigo_SelectedIndexChanged;

            TIPE_Codigo.AddComboBoxItem(1, "CLIENTES", true);
            TIPE_Codigo.AddComboBoxItem(2, "PROVEEDORES");
            TIPE_Codigo.AddComboBoxItem(5, "TRANSPORTISTA");
            TIPE_Codigo.AddComboBoxItem(6, "AGENTES");
            TIPE_Codigo.AddComboBoxItem(7, "BROKERS");
            TIPE_Codigo.AddComboBoxItem(10, "SHIPPER");
            //TIPE_Codigo.AddComboBoxItem(1, "CONSIGNEE");

            TIPE_Codigo.LoadComboBox("", ListSortDirection.Ascending);
         }
         catch (Exception)
         { }
      }
      private void TIPE_Codigo_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if (TIPE_Codigo.ComboIntSelectedValue.HasValue)
            {
               switch (TIPE_Codigo.ComboIntSelectedValue)
               {
                  case 1:
                     ENTC_Codigo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
                     ENTC_Codigo.SetValue(ENTC_CodCliente);
                     break;
                  case 2:
                     ENTC_Codigo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Proveedor;
                     break;
                  case 5:
                     ENTC_Codigo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
                     if (ENTC_CodTransportista.HasValue)
                     { ENTC_Codigo.SetValue(ENTC_CodTransportista.Value); }
                     break;
                  case 6:
                     ENTC_Codigo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
                     if (ENTC_CodAgente.HasValue)
                     { ENTC_Codigo.SetValue(ENTC_CodAgente.Value); }
                     break;
                  case 7:
                     ENTC_Codigo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Broker;
                     break;
                  case 10:
                     ENTC_Codigo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Shipper;
                     if (ENTC_CodShipper.HasValue)
                     { ENTC_Codigo.SetValue(ENTC_CodShipper.Value); }
                     break;
                  //case 12:
                  //   ENTC_Codigo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
                  //   if (ENTC_CodConsignee.HasValue)
                  //   { ENTC_Codigo.SetValue(ENTC_CodConsignee.Value); }
                  //   break;
                  default:
                     ENTC_Codigo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
                     break;
               }
            }
            else
            { ENTC_Codigo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente; }
         }
         catch (Exception)
         { }
      }
      public Entities.Entidad Proveedor { get { return ENTC_Codigo.Value; } }
      public Nullable<Int32> TipoEntidad { get { return TIPE_Codigo.ComboIntSelectedValue; } }

      private void btnAceptar_Click(object sender, EventArgs e)
      {
         if (ENTC_Codigo.Value != null)
         { this.DialogResult = System.Windows.Forms.DialogResult.OK; }
         else
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion("Seleccionar Proveedor", "Debe seleccionar una Entidad."); }
      }
   }
}
