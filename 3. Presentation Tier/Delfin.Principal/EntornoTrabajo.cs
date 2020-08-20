using Delfin.ServiceContracts;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
   public partial class EntornoTrabajo : Form
   {
      #region [ Variables ]
      
      #endregion

      #region [ Constructor ]
      public EntornoTrabajo(IUnityContainer x_container)
      {
         InitializeComponent();

         try
         {
            //Client = new Delfin.ServiceProxy.DelfinServicesProxyProxy();
            Client = x_container.Resolve<IDelfinServices>();

            cmbEmpresa.SelectedIndexChanged += cmbEmpresa_SelectedIndexChanged;
            cmbSucursal.SelectedIndexChanged += cmbSucursal_SelectedIndexChanged;
            CargarEmpresas();
            cmbSucursal.SelectedIndex = 1;
            cmbSucursal.Enabled = true;
         }
         catch (Exception)
         { throw; }
      }
      #endregion
      
      #region [ Propiedades ]
      private Delfin.ServiceContracts.IDelfinServices Client { get; set; }
      public Entities.Empresa ItemEmpresa { get; set; }
      public Entities.Sucursales ItemSucursal { get; set; }
      #endregion

      #region [ Metodos ]
      private void CargarEmpresas()
      {
         try
         {
            ObservableCollection<Entities.Empresa> items = Client.GetAllEmpresa();
            items.Insert(0, new Entities.Empresa() { EMPR_Codigo = -1, EMPR_RazonSocial = "< Seleccionar Empresa >" });

            cmbEmpresa.ValueMember = "EMPR_Codigo";
            cmbEmpresa.DisplayMember = "EMPR_RazonSocial";
            cmbEmpresa.DataSource = items;
            cmbEmpresa.SelectedIndex = 1;
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(this.Text, "Ha ocurrido un error cargando las empresas.", ex); }
      }
      private void CargarSucursales()
      {
         try
         {
            if (ItemEmpresa != null)
            {
               ObservableCollection<Entities.Sucursales> items = Client.GetAllSucursales();
               items.Insert(0, new Entities.Sucursales() { EMPR_Codigo = ItemEmpresa.EMPR_Codigo, SUCR_Codigo = -1, SUCR_Desc = "< Seleccionar Sucursal >" });

               cmbSucursal.ValueMember = "SUCR_Codigo";
               cmbSucursal.DisplayMember = "SUCR_Desc";
               cmbSucursal.DataSource = items;
               cmbSucursal.SelectedIndex = 0;

               cmbSucursal.Enabled = true;
            }
            else
            {
               cmbSucursal.ValueMember = "SUCR_Codigo";
               cmbSucursal.DisplayMember = "SUCR_Desc";
               cmbSucursal.DataSource = null;
               cmbSucursal.SelectedIndex = -1;
               cmbSucursal.Enabled = false;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(this.Text, "Ha ocurrido un erro cargando las sucursales", ex); }
      }

      private void SeleccionarEmpresa()
      {
         try
         {
            if (cmbEmpresa.SelectedItem != null && cmbEmpresa.SelectedItem is Entities.Empresa && ((Entities.Empresa)cmbEmpresa.SelectedItem).EMPR_Codigo > 0)
            { ItemEmpresa = ((Entities.Empresa)cmbEmpresa.SelectedItem); }
            else
            { ItemEmpresa = null; }

            CargarSucursales();
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(this.Text, "Ha ocurrido un error seleccionado la empresa.", ex); }
      }
      private void SeleccionarSucursal()
      {
         try
         {
            if (cmbSucursal.SelectedItem != null && cmbSucursal.SelectedItem is Entities.Sucursales && ((Entities.Sucursales)cmbSucursal.SelectedItem).SUCR_Codigo > 0)
            { ItemSucursal = ((Entities.Sucursales)cmbSucursal.SelectedItem); }
            else
            { ItemSucursal = null; }
         }
         catch (Exception ex)
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeError(this.Text, "Ha ocurrido un error seleccionado la empresa.", ex); }
      }
      #endregion

      #region [ Eventos ]
      private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
      { SeleccionarEmpresa(); }
      private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
      { SeleccionarSucursal(); }
      
      private void btnAceptar_Click(object sender, EventArgs e)
      {
         if (ItemEmpresa != null)
         {
            if (ItemSucursal != null)
            { this.DialogResult = System.Windows.Forms.DialogResult.OK; }
            else
            { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeInformacion(Text, "Debe Seleccionar Sucursal."); }
         }
         else
         { Infrastructure.WinFormsControls.Dialogos.MostrarMensajeInformacion(Text, "Debe Seleccionar Empresa."); }
      }
      #endregion

      
   }
}
