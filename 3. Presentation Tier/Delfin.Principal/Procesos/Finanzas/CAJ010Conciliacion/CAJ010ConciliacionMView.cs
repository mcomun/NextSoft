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

namespace Delfin.Comercial
{
   public partial class CAJ010ConciliacionMView : Form, ICAJ010ConciliacionMView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public CAJ010ConciliacionMView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
            this.FormClosed += CAJ010ConciliacionMView_FormClosed;

            btnGuardar.Click += btnGuardar_Click;
            btnSalir.Click += btnSalir_Click;

            BSItemsFlete = new BindingSource();
            //grdItemsFlete.DataSource = BSItemsFlete;
            //grdItemsFleteEmbarque.DataSource = BSItemsFlete;

            BSItemsServicio = new BindingSource();
            grdItemsServicio.DataSource = BSItemsServicio;



            this.Load += CAJ010ConciliacionMView_Load;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario MView.", ex); }
      }

      private void CAJ010ConciliacionMView_FormClosed(object sender, FormClosedEventArgs e)
      { Presenter.IsClosedMView(); }

      private void CAJ010ConciliacionMView_Load(object sender, EventArgs e)
      {
         tabCab_Cotizacion_OV.TabPages.Clear();

         tabCab_Cotizacion_OV.TabPages.Add(pageGenerales);
         tabCab_Cotizacion_OV.TabPages.Add(pageDetalle);
            //tabCab_Cotizacion_OV.TabPages.Add(pageNovedades);
            //tabCab_Cotizacion_OV.TabPages.Add(pageArchivos);
            //tabCab_Cotizacion_OV.TabPages.Add(pageEventosTareas);
         tabCab_Cotizacion_OV.SelectedTab = pageGenerales;
      }
      #endregion

      #region [ Propiedades ]
      public CAJ010ConciliacionPresenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }

      public BindingSource BSItemsFlete { get; set; }
      public BindingSource BSItemsServicio { get; set; }

      public BindingSource BSItemsNovedades { get; set; }
      public BindingSource BSItemsArchivos { get; set; }
      #endregion

      #region [ ICAJ010ConciliacionMView ]
      public void LoadView()
      {
         try
         {
            //ENTC_CodAgente.ContainerService = Presenter.ContainerService;
            //ENTC_CodBroker.ContainerService = Presenter.ContainerService;
            //ENTC_CodCliente.ContainerService = Presenter.ContainerService;

            FormatGridServicios();

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en el LoadView.", ex); }
      }

      public void ClearItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            #region [ Datos Generales ]
            //CCOT_NumDocCOT.Text = String.Empty;
            //CCOT_Version.Text = String.Empty;
            ////CONS_TabEST

            #endregion

            #region [ Servicios y Tarifa ]
            //CONT_Numero.Text = string.Empty;
            //CONT_Descrip.Text = string.Empty;
            BSItemsServicio.DataSource = null;
            BSItemsServicio.ResetBindings(true);
            #endregion

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ClearItem.", ex); }
      }
      public void GetItem()
      {
         try
         {
            errorProviderCab_Cotizacion_OV.Clear();

            #region [ Datos Generales ]

            //Presenter.Item.CCOT_NumDoc = CCOT_NumDocCOT.Text;

            #endregion

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en GetItem.", ex); }
      }
      public void SetItem()
      {
         try
         {

            //CCOT_NumDocCOT.Text = Presenter.Item.CCOT_NumDoc;
            //CCOT_Version.Text = Presenter.Item.CCOT_Version.ToString();
            //CONS_CodESTCOT.ConstantesSelectedValue = Presenter.Item.CONS_CodEST;

            EnabledItem();
            tabCab_Cotizacion_OV.SelectedTab = pageGenerales;
            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en SetItem.", ex); }
      }
      private void EnabledItem()
      {
         try
         {
            
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en EnabledItem.", ex); }
      }

      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Cab_Cotizacion_OV>.Validate(Presenter.Item, this, errorProviderCab_Cotizacion_OV);

            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Cab_Cotizacion_OV>.SetTabError(tabCab_Cotizacion_OV, errorProviderCab_Cotizacion_OV);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error en ShowValidation.", ex); }
      }
      #endregion

      #region [ Metodos ]

      private void FormatGridServicios()
      {
         try
         {

         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView + " (Grid Servicios)", ex); }
      }
      private void AddFlete()
      {
         try
         {
            Entities.Det_Cotizacion_OV_Flete _flete = new Entities.Det_Cotizacion_OV_Flete();
            Int32 _DCOT_Item = 0;
            if (((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Count > 0)
            { _DCOT_Item = ((ObservableCollection<Entities.Det_Cotizacion_OV_Flete>)BSItemsFlete.DataSource).Max(dcot => dcot.DCOT_Item); }
            _flete.DCOT_Item = _DCOT_Item + 1;
            _flete.AUDI_UsrCrea = Presenter.Session.UserName;
            _flete.AUDI_FecCrea = Presenter.Session.Fecha;
            _flete.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
            BSItemsFlete.Add(_flete);
            BSItemsFlete.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al agregar un flete", ex); }
      }

      #endregion

      #region [ Metodos Documentos ]
     
      #endregion

      #region [ Eventos ]
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            Boolean EsProspecto = false; // = (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? ENTC_CodCliente.Value.ENTC_Prospecto.Value : false;
            if (Presenter.Guardar(EsProspecto, true))
            {
               //this.FormClosing -= MView_FormClosing;
               //errorProviderCab_Cotizacion_OV.Dispose();
               //Presenter.Actualizar();
               //this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }
      private void btnSalir_Click(object sender, EventArgs e)
      {
         try
         {
            Boolean EsProspecto = false; // = (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? ENTC_CodCliente.Value.ENTC_Prospecto.Value : false;

            this.FormClosing -= MView_FormClosing;
            errorProviderCab_Cotizacion_OV.Dispose();
            if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
            {
               if (Presenter.GuardarCambios(EsProspecto) != System.Windows.Forms.DialogResult.Cancel)
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
            Boolean EsProspecto = false; // (ENTC_CodCliente.Value != null && ENTC_CodCliente.Value.ENTC_Prospecto.HasValue) ? ENTC_CodCliente.Value.ENTC_Prospecto.Value : false;

            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
               {
                  if (Presenter.GuardarCambios(EsProspecto) == System.Windows.Forms.DialogResult.Cancel)
                  {
                     e.Cancel = true;
                     this.FormClosing += new FormClosingEventHandler(MView_FormClosing);
                  }
                  else
                  { Presenter.Actualizar(); }
               }
               else
               { Presenter.Actualizar(); }
            }
            else
            { Closing = false; e.Cancel = true; }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
      }
      #endregion
   }
}