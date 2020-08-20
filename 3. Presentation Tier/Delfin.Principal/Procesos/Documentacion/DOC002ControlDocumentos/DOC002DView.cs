using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delfin.Principal
{
    public partial class DOC002DView : Form
    {
        #region[Variables]
        int _correlativo = 1;
        #endregion

        #region[Propiedades]
        public DataTable DTFiles { get; set; }
        public DOC002Presenter Presenter { get; set; }
        public BindingSource BSItemsFiles { get; set; }
        public Nullable<Int32> _file_codigo { get; set; }
        public String _file_name { get; set; }
        private bool Closing = false;
        private System.Collections.Hashtable HashFormulario { get; set; }
        #endregion

        #region[Formulario]
        public DOC002DView()
        {
            InitializeComponent();
            try
            {
                this.FormClosing += new FormClosingEventHandler(DView_FormClosing);
                this.FormClosed += DOC002DView_FormClosed;

                BSItemsFiles = new BindingSource();
                BSItemsFiles.CurrentItemChanged += new EventHandler(BSItemsFiles_CurrentItemChanged);
                grdItemsFiles.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(grdItemsFiles_CommandCellClick);
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error inicializando el formulario LView.", ex); }
        }
        public void LoadView()
        {
            try
            {
                FormatDataGridFiles();
                ShowItemsFiles();
            }
            catch (Exception)
            { throw; }
        }
        public void ShowItemsFiles()
        {
            try
            {
                BSItemsFiles.DataSource = DTFiles;
                grdItemsFiles.DataSource = BSItemsFiles;
                navItemsFiles.BindingSource = BSItemsFiles;
                BSItemsFiles.ResetBindings(true);
                if (grdItemsFiles.RowCount > 0)
                {
                    grdItemsFiles.Enabled = true;
                    //Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsFiles);

                }
                else
                {
                    grdItemsFiles.Enabled = false;
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
        }
        private void FormatDataGridFiles()
        {
            try
            {
                Telerik.WinControls.UI.Localization.RadGridLocalizationProvider.CurrentProvider = new Infrastructure.WinForms.Controls.MySpanishRadGridLocalizationProvider();

                this.grdItemsFiles.Columns.Clear();
                this.grdItemsFiles.AllowAddNewRow = false;
                this.grdItemsFiles.AllowDeleteRow = false;
                this.grdItemsFiles.AutoGenerateColumns = false;
                this.grdItemsFiles.AllowColumnReorder = false;
                this.grdItemsFiles.AllowRowResize = false;
                this.grdItemsFiles.AllowRowReorder = false;
                this.grdItemsFiles.AllowColumnHeaderContextMenu = false;
                this.grdItemsFiles.AllowCellContextMenu = false;
                this.grdItemsFiles.AllowMultiColumnSorting = false;
                this.grdItemsFiles.AllowEditRow = false;
                this.grdItemsFiles.ReadOnly = true;
                this.grdItemsFiles.ShowFilteringRow = false;
                this.grdItemsFiles.EnableFiltering = false;
                this.grdItemsFiles.MasterTemplate.EnableFiltering = false;
                this.grdItemsFiles.EnableGrouping = false;
                this.grdItemsFiles.MasterTemplate.EnableGrouping = false;
                this.grdItemsFiles.EnableSorting = false;
                this.grdItemsFiles.MasterTemplate.EnableCustomSorting = false;

                Telerik.WinControls.UI.GridViewCommandColumn commandColumn;
                commandColumn = new Telerik.WinControls.UI.GridViewCommandColumn();
                commandColumn.Name = "Open";
                commandColumn.HeaderText = "Abrir";
                commandColumn.DefaultText = "Abrir";
                commandColumn.UseDefaultText = true;
                this.grdItemsFiles.Columns.Add(commandColumn);
                this.grdItemsFiles.Columns["Open"].AllowSort = false;
                this.grdItemsFiles.Columns["Open"].AllowFiltering = false;
                this.grdItemsFiles.Columns.Add("FILE_Codigo", "Codigo", "FILE_Codigo");
                grdItemsFiles.Columns["FILE_Codigo"].Width = 50;
                this.grdItemsFiles.Columns.Add("FILE_FileName", "Nombre del Documento", "FILE_FileName");
                grdItemsFiles.Columns["FILE_FileName"].Width = 350;
                this.grdItemsFiles.Columns.Add("AUDI_UsrCrea", "Usuario", "AUDI_UsrCrea");
                grdItemsFiles.Columns["AUDI_UsrCrea"].Width = 100;


                //Infrastructure.WinForms.Controls.GridAutoFit.Fit(grdItemsFiles);

            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, Infrastructure.Aspect.Constants.Mensajes.FormatDataGridView, ex); }
        }
        #endregion

        #region[Metodos]
        private void SeleccionarFiles()
        {
            try
            {
                if (Presenter != null)
                {
                    if (BSItemsFiles != null && BSItemsFiles.DataSource != null && BSItemsFiles.Current != null)//&& BSItemsFiles.Current is Entities.Cab_Cotizacion_OV
                    {
                        DataRowView current = (DataRowView)BSItemsFiles.Current;
                        if (current["FILE_Codigo"] != System.DBNull.Value)
                        { _file_codigo = Convert.ToInt32(current["FILE_Codigo"]); }
                        else
                        { _file_codigo = null; }
                        if (current["FILE_FileName"] != System.DBNull.Value)
                        { _file_name = Convert.ToString(current["FILE_FileName"]); }
                        else
                        { _file_name = null; }
                    }
                    else
                    {
                       
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
        }
        private String GenerateFiles()
        {
            try
            {
                String _folder = @"DOCUMENTOS_GENERADOS";
                String pathString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _folder);
                
                System.IO.Directory.CreateDirectory(pathString);
                String _rutaarchivo = Path.Combine(pathString, _file_name);

                string expression = "FILE_Codigo = " + _file_codigo;
                DataRow[] results = DTFiles.Select(expression);
                //String _rutaarchivo = 
                Byte[] bytes = (Byte[])results[0]["FILE_InputStream"];
                MemoryStream stmBLOBData = new MemoryStream(bytes);
                //if (File.Exists("D:\\PQS")) { x_archivoDestino = GetNameFile(x_archivoDestino); }
                using (var destinoFileStream = new FileStream(_rutaarchivo, FileMode.Create))
                {
                    const int capacidadBuffer = 65536;
                    var buffer = new Byte[capacidadBuffer];
                    int bytesPorLectura = stmBLOBData.Read(buffer, 0, capacidadBuffer);
                    while (bytesPorLectura > 0)
                    {
                        destinoFileStream.Write(buffer, 0, bytesPorLectura);
                        bytesPorLectura = stmBLOBData.Read(buffer, 0, capacidadBuffer);
                    }

                }

                return _rutaarchivo;
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al generar el archivo.", ex); return null; }
        }
        private void OpenFile()
        {
            try
            {
                String _ruta = GenerateFiles();
                if (File.Exists((string)_ruta))
                {
                    Process.Start(_ruta);
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al generar el archivo.", ex);}
        }
        #endregion

        #region[Eventos]
        private void grdItemsFiles_CommandCellClick(object sender, EventArgs e)
        {
            try
            {
                if (sender is Telerik.WinControls.UI.GridCommandCellElement)
                {
                    switch ((((Telerik.WinControls.UI.GridCommandCellElement)(sender)).CommandButton).TextElement.Text)
                    {
                        case "Abrir":
                            SeleccionarFiles();
                            OpenFile();
                            break;
                    }
                }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar el boton abrir.", ex); }
        }
        private void BSItemsFiles_CurrentItemChanged(object sender, EventArgs e)
        {
            SeleccionarFiles();
        }
        private void DView_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Closing != true)
                {
                    this.FormClosing -= DView_FormClosing;
                    if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario))
                    {
                        if (Presenter.GuardarCambios() == System.Windows.Forms.DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            this.FormClosing += new FormClosingEventHandler(DView_FormClosing);
                        }
                    }
                }
                else
                { Closing = false; e.Cancel = true; }
            }
            catch (Exception ex)
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cerrar el formulario.", ex); }
        }
        private void DOC002DView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Presenter.IsClosedMView();
        }
        #endregion

        #region [ IFormClose ]
        #endregion

    }
}
