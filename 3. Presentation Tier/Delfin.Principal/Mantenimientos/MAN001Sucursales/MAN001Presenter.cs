using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;
using Delfin.ServiceContracts;
using Delfin.ServiceProxy;
using Delfin.Entities;
using Infrastructure.Client.Services.Session;
using System.Collections.ObjectModel;

namespace Delfin.Principal
{
    public class MAN001Presenter
    {
        #region [ Variables ]
        private ObservableCollection<Empresa> m_items_Empresa = new ObservableCollection<Empresa>();
        private Empresa m_item_Empresa = new Empresa();    
        public String Title = "Mantenimiento de Empresas";
        public String CUS = "MAN001";
        #endregion

        #region [ Contrusctor ]
        public MAN001Presenter(IUnityContainer x_container, IMAN001LView x_lview, IMAN001MView x_mview)
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
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
        }
        #endregion

        #region [ Propiedades ]
        public ObservableCollection<Empresa> ItemsEmpresas {
            get { return m_items_Empresa; }
            set { m_items_Empresa = value; }
        }
        public Empresa ItemEmpresa { 
            
            get {return m_item_Empresa; }
            set { m_item_Empresa = value; }
        }
        public IUnityContainer ContainerService { get; set; }
        public ISessionService Session { get; set; }
        public IDelfinServices Client { get; set; }

        public IMAN001LView LView { get; set; }
        public IMAN001MView MView { get; set; }

        public Sucursales Item { get; set; }
        public ObservableCollection<Sucursales> Items { get; set; }
        #endregion

        #region [ Metodos ]
        public void getEmpresas()
        {
            ItemsEmpresas = Client.GetAllEmpresa();

        }


        public void Actualizar()
        {
            try
            {
                Item = null;
                Items = null;

                Items = Client.GetAllSucursales();

                LView.ShowItems();
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error actualizando.", ex); }
        }

        public void Nuevo()
        {
            try
            {
                MView.ClearItem();
                this.Item = new Sucursales();
                this.Item.AUDI_UsrCrea = Session.UserName;
                this.Item.AUDI_FecCrea = Session.Fecha;
                this.Item.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;
                MView.SetItem();

                ((MAN001MView)MView).ShowDialog();
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

                    ((MAN001MView)MView).ShowDialog();
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
                        if (Client.SaveSucursales(Item))
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
                    if (Client.SaveSucursales(Item))
                    {
                        Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Title, "Se ha guardado satisfactoriamente");
                        Actualizar();
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
