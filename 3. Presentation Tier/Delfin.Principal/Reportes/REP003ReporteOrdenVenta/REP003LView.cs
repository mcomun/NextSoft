using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Infrastructure.Aspect.Collections;
using Telerik.WinControls.UI;
using Infrastructure.WinForms.Controls;

namespace Delfin.Principal
{
   public partial class REP003LView : UserControl, IREP003LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public REP003LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
      {
         InitializeComponent();
         try
         {
            TabPageControl = x_tabPageControl;

            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnDeshacer.Click += new EventHandler(btnDeshacer_Click);
            btnExportar.Click += new EventHandler(btnExportar_Click);

            TIPO_CodPAIOrigen.SelectedIndexChanged += TIPO_CodPAIOrigen_SelectedIndexChanged;
            TIPO_CodPAIDestino.SelectedIndexChanged += TIPO_CodPAIDestino_SelectedIndexChanged;

            TitleView.FormClose += new EventHandler(View_FormClose);

            BSItems = new BindingSource();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al crear la vista.", ex); }
      }

      
      #endregion

      #region [ Propiedades ]
      public Telerik.WinControls.UI.RadPageViewPage TabPageControl { get; set; }
      public Image IconView { get { return TitleView.FormIcon; } set { TitleView.FormIcon = value; } }
      public REP003Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ IREP003LView ]
      public void LoadView()
      {
         try
         {
            ENTC_CodTransportista.ContainerService = Presenter.ContainerService;

            CONS_CodRGM.LoadControl(Presenter.ContainerService, "Tabla de Regimen", "RGM", "< Seleccionar Regimen >", ListSortDirection.Ascending);
            CONS_CodVIA.LoadControl(Presenter.ContainerService, "Tabla de Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);

            TIPO_CodPAIOrigen.LoadControl(Presenter.ContainerService, "Tabla Países Origen", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);
            TIPO_CodPAIDestino.LoadControl(Presenter.ContainerService, "Tabla Países Destino", "PAI", "< Seleccionar País Destino >", ListSortDirection.Ascending);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando la vista.", ex); }
      }
      public void ShowItems()
      {
         try
         {
            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;

            grdItems.AutoGenerateColumns = true;
            grdItems.AllowAddNewRow = false;
            grdItems.AllowDeleteRow = false;
            grdItems.AllowRowResize = false;
            grdItems.AllowEditRow = true;
            
            grdItems.DataSource = null;
            BSItems.DataSource = null;
            grdItems.Columns.Clear();
            grdItems.BestFitColumns();
            BSItems.ResetBindings(true);

            //LoadGroup();

            BSItems.DataSource = Presenter.DTReporte;
            grdItems.DataSource = BSItems;
            BSItems.ResetBindings(true);
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error cargando los items.", ex); }
      }
      #endregion

      #region [ Metodos ]
      Dictionary<Int32, String> GroupsNames;
      Dictionary<Int32, GridViewColumnGroup> Groups;
      private void LoadGroup()
      {
         try
         {
            GroupsNames = new Dictionary<int, string>();
            Groups = new Dictionary<int, GridViewColumnGroup>();

            ColumnGroupsViewDefinition view = new ColumnGroupsViewDefinition();
            Int32 IndexGroup = 0;
            Int32 IndexColumn = 0;
            GridViewColumnGroup group = new GridViewColumnGroup();
            Int32 nivel = 0;
            foreach (DataColumn column in Presenter.DTReporte.Columns)
            {

               if (column.ColumnName.Contains('#'))
               {
                  String[] columns = column.ColumnName.Split('#');

                  if (!GroupsNames.ContainsKey(nivel) || (GroupsNames.ContainsKey(nivel) && GroupsNames[nivel] != columns[nivel]))
                  {
                     GroupsNames = new Dictionary<int, string>();
                     Groups = new Dictionary<int, GridViewColumnGroup>();

                     String columngroup = columns[nivel];
                     group = new GridViewColumnGroup(columngroup);

                     if (GroupsNames.ContainsKey(nivel))
                     {
                        GroupsNames[nivel] = columns[nivel];
                        Groups[nivel] = group;
                     }
                     else
                     {
                        GroupsNames.Add(nivel, columngroup);
                        Groups.Add(nivel, group);
                     }
                     view.ColumnGroups.Add(group);
                  }
                  else
                  {
                     group = Groups[nivel];
                  }
                  LoadSubGroup(ref group, column, nivel + 1, IndexColumn, IndexColumn++);
               }
               else
               {
                  view.ColumnGroups.Add(new GridViewColumnGroup(column.ColumnName));
                  view.ColumnGroups[IndexGroup].Rows.Add(new GridViewColumnGroupRow());
                  view.ColumnGroups[IndexGroup].Rows[0].Columns.Add(grdItems.Columns[column.ColumnName]); IndexGroup += 1;
               }

               IndexColumn += 1;
            }
            
            grdItems.ViewDefinition = view;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los grupos.", ex); }
      }
      private void LoadSubGroup(ref GridViewColumnGroup group, DataColumn column, Int32 nivel, Int32 index, Int32 newindex)
      {
         try
         {
            GridViewColumnGroup subgroup = new GridViewColumnGroup();
            String[] columns = column.ColumnName.Split('#');
            if (columns.Length > (nivel + 1))
            {

               if (!GroupsNames.ContainsKey(nivel) || (GroupsNames.ContainsKey(nivel) && GroupsNames[nivel] != columns[nivel]))
               {
                  String columngroup = columns[nivel];
                  subgroup = new GridViewColumnGroup(columngroup);

                  if (GroupsNames.ContainsKey(nivel))
                  {
                     GroupsNames[nivel] = columns[nivel];
                     Groups[nivel] = subgroup;
                  }
                  else
                  {
                     GroupsNames.Add(nivel, columngroup);
                     Groups.Add(nivel, subgroup);
                  }

                  group.Groups.Add(subgroup);
               }
               else
               { subgroup = Groups[nivel]; }

               LoadSubGroup(ref subgroup, column, (nivel + 1), index, newindex);
            }
            else
            {
               String columnName = "COLUMN" + newindex;
               grdItems.Columns.Add(columnName, columns[nivel], column.ColumnName);
               group.Rows.Add(new GridViewColumnGroupRow());
               group.Rows[0].Columns.Add(grdItems.Columns[columnName]);
               index += 1;
               newindex += 1;

            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los subgrupos.", ex); }
      }

      private void LoadPuertosOrigen()
      {
         try
         {
            Boolean _inicializar = true;
            if (TIPO_CodPAIOrigen.TiposSelectedItem != null)
            {
               ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.TIPO_CodPais == TIPO_CodPAIOrigen.TiposSelectedItem.TIPO_CodTipo && puer.CONS_CodVia == CONS_CodVIA.ConstantesSelectedValue && puer.PUER_Favorito).ToObservableCollection();
               if (_items != null && _items.Count > 0)
               {
                  foreach (Entities.Puerto _puerto in _items)
                  {
                     PUER_CodOrigen.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
                     _inicializar = false;
                  }
                  PUER_CodOrigen.LoadComboBox("< Seleccionar Puerto Origen >", ListSortDirection.Ascending);
                  PUER_CodOrigen.Enabled = true;
               }
               else
               {
                  PUER_CodOrigen.DataSource = null;
                  PUER_CodOrigen.Enabled = false;
               }
            }
            else
            {
               PUER_CodOrigen.DataSource = null;
               PUER_CodOrigen.Enabled = false;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos de origen.", ex); }
      }
      private void LoadPuertosDestino()
      {
         try
         {
            Boolean _inicializar = true;
            if (TIPO_CodPAIDestino.TiposSelectedItem != null)
            {
               ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.TIPO_CodPais == TIPO_CodPAIDestino.TiposSelectedItem.TIPO_CodTipo && puer.CONS_CodVia == CONS_CodVIA.ConstantesSelectedValue && puer.PUER_Favorito).ToObservableCollection();
               if (_items != null && _items.Count > 0)
               {
                  foreach (Entities.Puerto _puerto in _items)
                  {
                     PUER_CodDestino.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
                     _inicializar = false;
                  }
                  PUER_CodDestino.LoadComboBox("< Seleccionar Puerto Destino >", ListSortDirection.Ascending);
                  PUER_CodDestino.Enabled = true;
               }
               else
               {
                  PUER_CodDestino.DataSource = null;
                  PUER_CodDestino.Enabled = false;
               }
            }
            else
            {
               PUER_CodDestino.DataSource = null;
               PUER_CodDestino.Enabled = false;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos de origen.", ex); }
      }

      private void Buscar()
      {
         try
         {
            if (CONS_CodRGM.ConstantesSelectedItem != null)
            {
               if (CONS_CodVIA.ConstantesSelectedItem != null)
               {
                  if (CCOT_FecEmiDesde.NSFecha.HasValue)
                  {
                     if (CCOT_FecEmiHasta.NSFecha.HasValue)
                     {
                        String _CONS_TabRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
                        String _CONS_CodRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
                        String _CONS_TabVIA = CONS_CodVIA.ConstantesSelectedItem.CONS_CodTabla;
                        String _CONS_CodVIA = CONS_CodVIA.ConstantesSelectedItem.CONS_CodTipo;
                        DateTime _CCOT_FecEmiDesde = CCOT_FecEmiDesde.NSFecha.Value;
                        DateTime _CCOT_FecEmiHasta = CCOT_FecEmiHasta.NSFecha.Value;

                        Nullable<Int32> _ENTC_CodTransportista = null; if (ENTC_CodTransportista.Value != null && ENTC_CodTransportista.Value.ENTC_Codigo > 0) { _ENTC_CodTransportista = ENTC_CodTransportista.Value.ENTC_Codigo; }
                        Nullable<Int32> _PUER_CodOrigen = PUER_CodOrigen.ComboIntSelectedValue;
                        Nullable<Int32> _PUER_CodDestino = PUER_CodDestino.ComboIntSelectedValue;

                        Presenter.CargarReporte(_CONS_TabRGM, _CONS_CodRGM, _CONS_TabVIA, _CONS_CodVIA, _CCOT_FecEmiDesde, _CCOT_FecEmiHasta, _ENTC_CodTransportista, _PUER_CodOrigen, _PUER_CodDestino);
                     }
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar la Fecha Fin Vigencia."); }
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar la Vía."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar el Régimen."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al llamar al reporte.", ex); }
      }
      private void Deshacer()
      {
         try
         {
            Presenter.LimpiarReporte();

            CONS_CodRGM.ConstantesSelectedValue = null;
            CONS_CodVIA.ConstantesSelectedValue = null;
            CCOT_FecEmiDesde.NSFecha = null;
            CCOT_FecEmiHasta.NSFecha = null;
            ENTC_CodTransportista.ClearValue();
            ENTC_CodTransportista.Text = string.Empty;
            
            TIPO_CodPAIOrigen.TiposSelectedValue = null;
            TIPO_CodPAIDestino.TiposSelectedValue = null;
            
            BSItems.DataSource = null;
            grdItems.DataSource = BSItems;
            BSItems.ResetBindings(true);

            grdItems.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = false;
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al limpiar al reporte.", ex); }
      }
      private void Exportar()
      {
         try
         {
            List<String> Titulos = new List<String>();
            Titulos.Add("Reporte");
            Int32 _fila = 2;
            Infrastructure.WinForms.Controls.ExcelAportes _xls = new Infrastructure.WinForms.Controls.ExcelAportes(1, Titulos, "");
            Object[] _cabeceras = new Object[1];
            DataTable _dt = _xls.RadGridViewToDataTable(grdItems, ref _cabeceras, grdItems.FilterDescriptors.Count > 0);
            if (_dt.Rows.Count > 0)
            {
               List<String> _listTituloFiltro = new List<String>();
               _listTituloFiltro.Add("");
               _xls.InsertarTitulos(Presenter.Title, 1, ref _fila, 1, _listTituloFiltro, _cabeceras.Length);
               _xls.addDataArray(1, _cabeceras, 1, _fila + 2, true, true);
               _xls.addDataList(1, _dt, 1, _fila + 3, true, true);
            }

            //List<String> Titulos = new List<String>();
            //Titulos.Add("Reporte");
            //Int32 _fila = 1;
            //ExcelAportes _xls = new ExcelAportes(1, Titulos, "");
            //Object[] _cabeceras = new Object[2];
            //Object[] _CamposTotales = new Object[0];
            ////for (int i = 0; i < m_ListaColumnasSumatorias.Count; i++)
            ////{
            ////   _CamposTotales[i] = m_ListaColumnasSumatorias[i];
            ////}
            //Object[] _cabecerasAgrupamiento = new Object[m_ListaColumnasAgrupamiento.Count];
            //Object[] _columnasCombinadas = new Object[m_ListaColumnasAgrupamiento.Count];
            //for (int i = 0; i < m_ListaColumnasAgrupamiento.Count; i++)
            //{
            //   _cabecerasAgrupamiento[i] = m_ListaColumnasAgrupamiento[i];
            //   _columnasCombinadas[i] = 2;
            //}
            //DataTable _dt = _xls.RadGridViewToDataTable(grdItems, ref _cabeceras, this.grdItems.FilterDescriptors.Count > 0);
            //_xls.InsertarTitulos(Presenter.Title, 1, ref _fila, 1, _listTituloFiltro, _cabeceras.Length);
            //_xls.AddDataAgrupamiento(1, _fila + 2, 2, _columnasCombinadas, _cabecerasAgrupamiento, true, true);
            //_xls.addDataArray(1, _cabeceras, 1, _fila + 3, true, true);
            ////Presenter.Reporte.DefaultView.RowFilter=this.bsItems.Filter;
            //if (_dt.Rows.Count > 0)
            //{
            //   _xls.addDataList(1, _dt, 1, _fila + 4, true, true);
            //   _xls.AsignarFormulaACampos(_dt, _CamposTotales, _fila + 4);
            //}
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al exportar.", ex); }
      }
      #endregion

      #region [ Eventos ]
      private void btnBuscar_Click(object sender, EventArgs e)
      { Buscar(); }
      private void btnDeshacer_Click(object sender, EventArgs e)
      { Deshacer(); }
      private void btnExportar_Click(object sender, EventArgs e)
      { Exportar(); }

      private void TIPO_CodPAIOrigen_SelectedIndexChanged(object sender, EventArgs e)
      { LoadPuertosOrigen(); }
      private void TIPO_CodPAIDestino_SelectedIndexChanged(object sender, EventArgs e)
      { LoadPuertosDestino(); }
      #endregion

      #region [ IFormClose ]
      private void View_FormClose(object sender, EventArgs e)
      {
         if (CloseForm != null)
         {
            //BusinessLogic.Colecciones.Inicializar(Presenter.Container);
            CloseForm(null, new Infrastructure.Client.FormClose.FormCloseEventArgs(this.TabPageControl, Presenter.CUS));
         }
      }
      public event Infrastructure.Client.FormClose.FormCloseEventArgs.FormCloseEventHandler CloseForm;
      #endregion
   }
}
