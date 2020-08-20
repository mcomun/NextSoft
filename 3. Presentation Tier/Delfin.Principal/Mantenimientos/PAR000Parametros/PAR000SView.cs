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
    public partial class PAR000SView : Form
    {
        #region [ Variables ]
        String m_para_valor;

        #endregion

        #region [ Constructores ]
        public PAR000SView(IUnityContainer x_container, String x_para_valor, char x_separador = '-')
        {
            InitializeComponent();

            this.ContainerService = x_container;
            Client = ContainerService.Resolve<IDelfinServices>();

            FormatDataGrid();
            SERVADICIONAL.LoadControl(ContainerService);
            SERVADICIONAL.TipoAyudaServicio = Delfin.Controls.AyudaServicio.TipoAyuda.Nombre;

            m_para_valor = x_para_valor;
            BSItems = new BindingSource();

            BSItems.DataSource = ItemsServicios;
            grdItems.DataSource = BSItems;

            LoadParameter(x_separador);

            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnAgregar.Click += btnAgregar_Click;
            grdItems.CommandCellClick += grdItems_CommandCellClick;
        }
        #endregion

        #region [ Propiedades ]
        public IUnityContainer ContainerService { get; set; }
        public IDelfinServices Client { get; set; }

        public String PARA_Valor { get { return m_para_valor; } }
        private ObservableCollection<Entities.Servicio> m_itemsServicios;

        public ObservableCollection<Entities.Servicio> ItemsServicios
        {
            get
            {
                if (m_itemsServicios == null) { m_itemsServicios = new ObservableCollection<Entities.Servicio>(); }
                return m_itemsServicios;
            }
            set { m_itemsServicios = value; }
        }
        public BindingSource BSItems { get; set; }
        #endregion

        #region [ Metodos ]
        private void LoadParameter(char x_separador)
        {
            try
            {
                if (!String.IsNullOrEmpty(PARA_Valor) && PARA_Valor.Contains(x_separador))
                {
                    var _valores = PARA_Valor.Split(x_separador);
                    for (int i = 0; i < _valores.Length; i++)
                    {
                        Int32 _serv_codigo;
                        if (Int32.TryParse(_valores[i], out _serv_codigo))
                        { AgregarServicio(_serv_codigo); }
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void GetParameter()
        {
            try
            {
                m_para_valor = String.Empty;

                foreach (Entities.Servicio _itemServicio in ItemsServicios)
                { m_para_valor += _itemServicio.SERV_Codigo.ToString() + "-"; }
            }
            catch (Exception)
            { }
        }
        private void AgregarServicio(Int32 x_serv_codigo)
        {
            try
            {
                if (m_itemsServicios.FirstOrDefault(serv => serv.SERV_Codigo == x_serv_codigo) == null)
                {
                    var _servicio = Client.GetOneServicio(x_serv_codigo);
                    ItemsServicios.Add(_servicio);
                }
                else
                { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(this.Text, "Ya se encuentra el servicios agregado."); }
                BSItems.ResetBindings(true);
            }
            catch (Exception)
            { throw; }
        }
        private void FormatDataGrid()
        {
            try
            {
                Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();
                this.grdItems.Columns.Clear();
                this.grdItems.AllowAddNewRow = false;


                Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
                commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
                commandColumn.Name = "Delete";
                commandColumn.HeaderText = "Eliminar";
                commandColumn.DefaultText = "Eliminar";
                commandColumn.UseDefaultText = true;
                this.grdItems.Columns.Add(commandColumn);
                this.grdItems.Columns["Delete"].AllowSort = false;
                this.grdItems.Columns["Delete"].AllowFiltering = false;

                //
                this.grdItems.Columns.Add("CONS_DescRGM", "Regimen", "CONS_DescRGM");
                this.grdItems.Columns.Add("CONS_DescVIA", "Via", "CONS_DescVIA");
                this.grdItems.Columns.Add("CONS_DescLNG", "Linea de Negocio", "CONS_DescLNG");

                this.grdItems.Columns.Add("SERV_NombreCorto", "Nombre Corto", "SERV_NombreCorto");
                //
                this.grdItems.Columns.Add("SERV_Nombre_SPA", "Nombre Español", "SERV_Nombre_SPA");
                this.grdItems.Columns.Add("SERV_Nombre_ENG", "Nombre Ingles", "SERV_Nombre_ENG");
                //
                this.grdItems.Columns.Add("SERV_Glosa", "Glosa", "SERV_Glosa");
                //this.grdItems.Columns.Add("CONS_DescLNG", "Línea de Negocio", "CONS_DescLNG");
                this.grdItems.Columns.Add("SERV_TipoMov", "Movimiento", "SERV_TipoMov");
                //
                this.grdItems.Columns.Add("SERV_CuenIngreso", "Cuenta de Venta", "SERV_CuenIngreso");
                this.grdItems.Columns.Add("SERV_CuenCosto", "Cuenta de Gasto", "SERV_CuenCosto");
                //this.grdItems.Columns.Add("SERV_CueVta", "Cuenta de Venta", "SERV_CueVta");
                //this.grdItems.Columns.Add("SERV_CueGas", "Cuenta de Gasto", "SERV_CueGas");
                this.grdItems.Columns.Add("SERV_CuenPuente", "Cuenta Puente", "SERV_CuenPuente");
                //this.grdItems.Columns.Add("SERV_Agrup1", "Agrupación 1", "SERV_Agrup1");
                //this.grdItems.Columns.Add("SERV_Agrup2", "Agrupación 2", "SERV_Agrup2");

                //this.grdItems.Columns.Add("SERV_AfeIgv", "Afecto I.G.V:", "SERV_AfeIgv");
                Telerik.WinControls.UI.GridViewCheckBoxColumn checkboxColum;
                checkboxColum = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
                checkboxColum.Name = "SERV_AfeIgv";
                checkboxColum.HeaderText = "Afecto I.G.V";
                checkboxColum.FieldName = "SERV_AfeIgv";
                grdItems.Columns.Add(checkboxColum);
                grdItems.Columns["SERV_AfeIgv"].Width = 90;

                //this.grdItems.Columns.Add("SERV_AfeDet", "Afecto Detracción", "SERV_AfeDet");
                checkboxColum = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
                checkboxColum.Name = "SERV_AfeDet";
                checkboxColum.HeaderText = "Afecto Detracción";
                checkboxColum.FieldName = "SERV_AfeDet";
                grdItems.Columns.Add(checkboxColum);
                grdItems.Columns["SERV_AfeDet"].Width = 90;

                this.grdItems.Columns.Add("SERV_PorDet", "Procentaje Deterioro", "SERV_PorDet");
                this.grdItems.Columns.Add("TIPO_DescDET", "Tipo de Detracción", "TIPO_DescDET");
                //
                this.grdItems.Columns.Add("CONS_DescBAS", "Base de Cálculo", "CONS_DescBAS");
                this.grdItems.Columns.Add("TIPO_DescMND", "Moneda", "TIPO_DescMND");
                //
                this.grdItems.Columns.Add("SERV_Valor", "Valor de Servicio", "SERV_Valor");
                this.grdItems.Columns.Add("SERV_CobMin", "Cobro Mínimno", "SERV_CobMin");
                //this.grdItems.Columns.Add("SERV_FrecFac", "FrecFac", "SERV_FrecFac");
                this.grdItems.Columns.Add("SERV_DefinidoPor", "Definido Por", "SERV_DefinidoPor");
                this.grdItems.Columns.Add("SERV_Observaciones", "Observaciones", "SERV_Observaciones");
                this.grdItems.Columns.Add("SERV_Codigo", "Interno", "SERV_Codigo");
                this.grdItems.Columns.Add("Documentos", "Documentos", "Documentos");

                grdItems.BestFitColumns();

                Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItems);

                this.grdItems.EnableFiltering = false;
                this.grdItems.MasterTemplate.EnableFiltering = false;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(this.Text, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
        }
        #endregion

        #region [ Eventos ]
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GetParameter();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (SERVADICIONAL.SelectedServicio != null)
            { AgregarServicio(SERVADICIONAL.SelectedServicio.SERV_Codigo); SERVADICIONAL.ClearValue(); }
        }

        private void grdItems_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                if (sender is Telerik.WinControls.UI.GridCommandCellElement)
                {
                    switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
                    {
                        case "Eliminar":
                            if (BSItems != null && BSItems.Current != null && BSItems.Current is Entities.Servicio)
                            { BSItems.RemoveCurrent(); }
                            break;
                    }
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(this.Text, "Ha ocurrido un error al eliminar el registro.", ex); }
        }
        #endregion
    }
}