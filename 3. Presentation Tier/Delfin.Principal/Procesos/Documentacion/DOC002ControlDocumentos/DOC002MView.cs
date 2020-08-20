using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infrastructure.Aspect.Collections;
using Infrastructure.WinForms.Controls;

namespace Delfin.Principal
{
   public partial class DOC002MView : Form, IDOC002MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public DOC002MView()
      {
         InitializeComponent();
         try
         {

            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += DOC002MView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            btnAuditoriaLoadingList.Click += btnAuditoriaLoadingList_Click;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }
      private void DOC002MView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }
      #endregion

      #region [ Propiedades ]
      public DOC002Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      #endregion

      #region [ IDOC002MView ]
      public void LoadView()
      {
         try
         {
            txtLOAD_Codigo.Enabled = false;
            txtPreAlerta.Enabled = false;
            txtLOAD_MBL.CharacterCasing = CharacterCasing.Upper;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }
      public void ClearItem()
      {
         try
         {
            txtLOAD_Codigo.Text = String.Empty;
            txtPreAlerta.Text = String.Empty;
            txtLOAD_HBL.Text = String.Empty;
            txtLOAD_MBL.Text = String.Empty;
            mdtLOAD_FecDevolucion.NSFecha = null;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            //errorProviderCab_Cotizacion_OV.Clear();
            if (Presenter != null && Presenter._Item != null)
            {
               //Presenter._Item.LOAD_Codigo = txtLOAD_Codigo.Text;
               if (txtPreAlerta.Text == "Sin Pre-Alerta")
               {
                  Presenter._Item.LOAD_SegundoOK = false;
                  Presenter._Item.LOAD_MBL = txtLOAD_MBL.Text;
                  Presenter._Item.LOAD_HBL = txtLOAD_HBL.Text;
               }
               else
               {
                  Presenter._Item.LOAD_SegundoOK = true;
                  Presenter._Item.LOAD_FecDevolucion = mdtLOAD_FecDevolucion.NSFecha;
               }



            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error obteniendo el item.", ex); }
      }
      public void SetItem()
      {
         try
         {
            if (Presenter != null && Presenter._Item != null)
            {
               txtLOAD_Codigo.Text = Presenter._Item.LOAD_Codigo.ToString();
               if (Presenter._Item.LOAD_SegundoOK == true)
               {
                  txtPreAlerta.Text = "Con Pre-Alerta";
                  mdtLOAD_FecDevolucion.NSFecha = Presenter._Item.LOAD_FecDevolucion;
               }
               else
               {
                  txtPreAlerta.Text = "Sin Pre-Alerta";
                  txtLOAD_HBL.Text = Presenter._Item.LOAD_HBL;
                  txtLOAD_MBL.Text = Presenter._Item.LOAD_MBL;
               }
               HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex); }
      }
      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.LoadingList>.Validate(Presenter._Item, this, errorProviderOPE_Loading_List);

            //Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.LoadingList>.SetTabError(tabCab_Cotizacion_OV, errorProviderOPE_Loading_List);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }
      #endregion

      #region [ Metodos ]
      public void ShowCampos(Boolean b)
      {
          if (b)
          {
              if (Presenter != null && Presenter._Item != null)
              {
                  if (Presenter._Item.LOAD_SegundoOK == true)
                  {
                      lblLOAD_HBL.Visible = false;
                      lblLOAD_MBL.Visible = false;
                      txtLOAD_HBL.Visible = false;
                      txtLOAD_MBL.Visible = false;
                      lblLOAD_FecDevolucion.Visible = true;
                      mdtLOAD_FecDevolucion.Visible = true;
                      tableControlDocumentos.RowStyles[1].Height = 27;
                      tableControlDocumentos.RowStyles[2].Height = 0;
                  }
                  else
                  {
                      lblLOAD_HBL.Visible = true;
                      lblLOAD_MBL.Visible = true;
                      txtLOAD_HBL.Visible = true;
                      txtLOAD_MBL.Visible = true;
                      lblLOAD_FecDevolucion.Visible = false;
                      mdtLOAD_FecDevolucion.Visible = false;
                      tableControlDocumentos.RowStyles[1].Height = 0;
                      tableControlDocumentos.RowStyles[2].Height = 27;
                  }

              }
          }
      }
      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter._Item.LOAD_SegundoOK == true)
            {
               if (Presenter.Guardar())
               {
                  this.FormClosing -= MView_FormClosing;
                  this.Close();
               }
            }
            else
            {
               if (!String.IsNullOrEmpty(txtLOAD_HBL.Text))
               {
                  if (Presenter.Guardar())
                  {
                     this.FormClosing -= MView_FormClosing;
                     this.Close();
                  }
               }
               else
               { Dialogos.MostrarMensajeInformacion(Presenter.Title, "Ingrese el Número de HBL"); }
            }

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            this.FormClosing -= MView_FormClosing;
            errorProviderOPE_Loading_List.Dispose();
            if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
            {
               if (Presenter.GuardarCambios() != System.Windows.Forms.DialogResult.Cancel)
               { this.Close(); }
               else
               { this.FormClosing += MView_FormClosing; }
            }
            else
            { this.Close(); }
            Closing = true;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               {
                  if (Presenter.GuardarCambios() == System.Windows.Forms.DialogResult.Cancel)
                  {
                     e.Cancel = true;
                     this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  }
               }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      #endregion

      #region [ Auditoria ]
      private void btnAuditoriaLoadingList_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter._load_codigo.HasValue)
            {
               ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
               _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCMBL_Codigo", FilterValue = Presenter._load_codigo.Value, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

               Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_OPE_Cab_MBL, _filters);
               _auditoriaView.Show();
            }
         }
         catch (Exception)
         { }
      }
      #endregion
   }
}