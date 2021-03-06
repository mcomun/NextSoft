﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;

namespace Delfin.Comercial
{
    public class MAN010Presenter
    {
        #region [ Variables ]
        public String Title = "Mantenimiento de Naves";
        public String CUS = "MAN010";
        #endregion

        #region [ Contrusctor ]
        public MAN010Presenter(IUnityContainer x_container, IMAN010LView x_lview, IMAN010MView x_mview)
        {
            try
            {
                this.ContainerService = x_container;
                Session = this.ContainerService.Resolve<ISessionService>();
                this.LView = x_lview;
                this.MView = x_mview;
            }
            catch (Exception)
            { throw; }
        }
        public void Load()
        {
            try
            {
                Client = ContainerService.Resolve<IDelfinServices>();

                LView.LoadView();
                MView.LoadView();
                ItemTransportista=new Entidad() ;


            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
        }
        #endregion

        #region [ Propiedades ]
        public IUnityContainer ContainerService { get; set; }
        public ISessionService Session { get; set; }
        public IDelfinServices Client { get; set; }

        public IMAN010LView LView { get; set; }
        public IMAN010MView MView { get; set; }

        
        public Nave  Item { get; set; }
        public Entidad ItemTransportista { get; set; }
        public ObservableCollection<Nave> Items { get; set; }
        public Constantes ItemVIA { get; set; }
        #endregion

        #region [ Metodos ]
        public void Actualizar(bool x_BaseDatos = true)
        {
            try
            {
                if (x_BaseDatos)
                {
                    Item = null;
                    Items = null;


                    //if (ItemTransportista != null)
                    //{ 
                       Items = Client.GetAllNave(null); 
                    //}
                    //else
                    //{ Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un transportista."); }
                }
                else
                {
                    if (this.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added)
                    {
                        if (Items == null) { Items = new ObservableCollection<Nave>(); }
                        Items.Add(Item);
                    }
                    else if (this.Item.Instance == Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified)
                    {
                        Items.Contains(Item);
                    }
                }
                LView.ShowItems();

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
        }


        public void Nuevo()
        {
           try
           {
              //if (ItemTransportista  != null)
              //{
              MView.ClearItem();
              this.Item = new Nave();
              //this.Item.NAVE_Codigo = Item.NAVE_Codigo;
              //this.Item.NAVE_Nombre = Item.NAVE_Nombre;

              //this.Item.ENTC_CodTransportista = ItemTransportista.ENTC_Codigo;
              this.Item.AUDI_UsrCrea = Session.UserName;
              this.Item.AUDI_FecCrea = Session.Fecha;
              this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
              MView.SetItem();

              //}
              //else
              //{ Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un Transportista."); }

              ((MAN010MView)MView).ShowDialog();
           }
           catch (Exception ex)
           { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.NewPresenter, ex); }
        }
        public void Editar()
        {
            try
            {
                if (Item != null)
                {
                    MView.ClearItem();
                    this.Item.AUDI_UsrMod = Session.UserName;
                    this.Item.AUDI_FecMod = Session.Fecha;
                    this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                    MView.SetItem();

                    ((MAN010MView)MView).ShowDialog();
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.EditPresenter, ex); }
        }
        public void Eliminar()
        {
            try
            {
                if (Item != null)
                {
                    System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.PreguntaEliminar, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
                    if (_result == System.Windows.Forms.DialogResult.Yes)
                    {
                        Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Deleted;
                        if (Client.SaveNave (Item))
                        {
                            Actualizar();
                            Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha eliminado el item.");
                        }
                        else
                        { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item."); }
                    }
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Debe seleccionar un elemento de la grilla"); }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.DeletePresenter, ex); }
        }
        public bool Guardar()
        {
            try
            {
                MView.GetItem();
                if (Item.Validar())
                {
                    if (Client.SaveNave(Item))
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                        Actualizar( );
                        return true;
                    }
                    else
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al guardar el item.");
                        return false;
                    }
                   
                }
                else
                {
                    MView.ShowValidation();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
                return false;
            }
        }
        public System.Windows.Forms.DialogResult GuardarCambios()
        {
            try
            {
                if (this.Item != null)
                {
                    System.Windows.Forms.DialogResult _result = Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Title, Infrastructure.Aspect.Constants.Mensajes.SaveChangesPreguntaPresenter, Infrastructure.WinForms.Controls.Dialogos.LabelBoton.Si_No);
                    if (_result == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Guardar())
                        { return System.Windows.Forms.DialogResult.Yes; }
                        else
                        { return System.Windows.Forms.DialogResult.Cancel; }
                    }
                    else
                    { return _result; }
                }
                else
                {
                    Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Title, "Ha ocurrido un error al cerrar el formulario.");
                    return System.Windows.Forms.DialogResult.Cancel;
                }
            }
            catch (Exception ex)
            {
                Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, Infrastructure.Aspect.Constants.Mensajes.SavePresenter, ex);
                return System.Windows.Forms.DialogResult.Cancel;
            }
        }
        #endregion
    }
}
