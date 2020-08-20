using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Infrastructure.Client.Services.Session;
using Delfin.ServiceContracts;

namespace Delfin.Principal
{
    public partial class CAJ017Presenter
    {
        #region [ Variables ]
        public String Title = "Avisos de Llegada";
        public String CUS = "CAJ017";
        #endregion 

        #region [ Propiedades ]
        public IUnityContainer ContainerService { get; set; }
        public ISessionService Session { get; set; }
        public IDelfinServices Client { get; set; }
        public ICAJ017View MView { get; set; }
        public System.Data.DataTable DTAviso { get; set; }
        #endregion 

        #region [ Constructor ]
        public CAJ017Presenter(IUnityContainer x_container, ICAJ017View x_mview)
        {
            try
            {
                this.ContainerService = x_container;
                Session = this.ContainerService.Resolve<ISessionService>();
                this.MView = x_mview;
            }
            catch (Exception)
            {throw;}
        }
        public void Load()
        {
            try
            {
                Client = ContainerService.Resolve<IDelfinServices>();
                MView.LoadView();
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Title, "Ha ocurrido un error inicializando la vista.", ex); }
        }
        #endregion

        #region [ Metodos ]
        public bool GenararDocAviso(String x_CCOT_Numero, Nullable<Int32> x_ENTC_CodCliente)
        {
            try
            {
                DTAviso = new System.Data.DataTable();
                DTAviso = Client.GetAllAvisosByNaveViaje(null,null, x_CCOT_Numero, x_ENTC_CodCliente);
                if (DTAviso != null && DTAviso.Rows.Count > 0)
                { return true; }
                else
                { return false; }
            }
            catch (Exception ex)
            {throw ex;}
        }
        #endregion
    }
}
