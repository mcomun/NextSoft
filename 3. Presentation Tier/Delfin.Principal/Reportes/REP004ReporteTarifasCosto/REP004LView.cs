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
   public partial class REP004LView : UserControl, IREP004LView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public REP004LView(Telerik.WinControls.UI.RadPageViewPage x_tabPageControl)
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

            CONT_Numero.AyudaClick += CONT_Numero_AyudaClick;
            CONT_Numero.AyudaClean += CONT_Numero_AyudaClean;

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
      public REP004Presenter Presenter { get; set; }
      public BindingSource BSItems { get; set; }
      #endregion

      #region [ IREP004LView ]
      public void LoadView()
      {
         try
         {
            ENTC_CodTransportista.ContainerService = Presenter.ContainerService;

            CONS_CodRGM.LoadControl(Presenter.ContainerService, "Tabla de Regimen", "RGM", "< Seleccionar Regimen >", ListSortDirection.Ascending);
            CONS_CodVIA.LoadControl(Presenter.ContainerService, "Tabla de Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);

            TIPO_CodPAIOrigen.LoadControl(Presenter.ContainerService, "Tabla Países Origen", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);
            TIPO_CodPAIDestino.LoadControl(Presenter.ContainerService, "Tabla Países Destino", "PAI", "< Seleccionar País Destino >", ListSortDirection.Ascending);

            Boolean _inicializar = true;
            foreach (Entities.Paquete _pack in Presenter.ListPaquetes)
            {
               PACK_Codigo.AddComboBoxItem(_pack.PACK_Codigo, _pack.PACK_Desc, _inicializar);
               _inicializar = false;
            }
            PACK_Codigo.LoadComboBox("< Seleccionar Embalaje >", ListSortDirection.Ascending);

            //FormatDataGrid();
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

            grdItems.AutoGenerateColumns = false;
            grdItems.AllowAddNewRow = false;
            grdItems.AllowDeleteRow = false;
            grdItems.AllowRowResize = false;
            grdItems.AllowEditRow = true;
            
            grdItems.DataSource = null;
            BSItems.DataSource = null;
            grdItems.Columns.Clear();
            grdItems.BestFitColumns();
            BSItems.ResetBindings(true);

            LoadGroup();

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

                  if ((GroupsNames.ContainsKey(nivel) && GroupsNames[nivel] != columns[nivel]) || !GroupsNames.ContainsKey(nivel))
                  {
                     GroupsNames = new Dictionary<int, string>();
                     Groups = new Dictionary<int, GridViewColumnGroup>();

                     String columngroup = columns[nivel];
                     group = new GridViewColumnGroup(columngroup);

                     if (GroupsNames.ContainsKey(nivel))
                     {
                        GroupsNames[nivel] = columns[nivel];
                        Groups[nivel] = group;

                        Int32 _nivelesuperiores = nivel + 1;
                        while ((GroupsNames.ContainsKey(_nivelesuperiores)))
                        {
                           GroupsNames.Remove(_nivelesuperiores);
                           Groups.Remove(_nivelesuperiores);
                           
                           _nivelesuperiores += 1;
                        }
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

                  grdItems.Columns.Add(column.ColumnName, column.ColumnName, column.ColumnName);
                  
                  view.ColumnGroups.Add(new GridViewColumnGroup(column.ColumnName));
                  view.ColumnGroups[IndexGroup].Rows.Add(new GridViewColumnGroupRow());
                  view.ColumnGroups[IndexGroup].Rows[0].Columns.Add(grdItems.Columns[column.ColumnName]); IndexGroup += 1;
               }

               IndexColumn += 1;
            }

            grdItems.ViewDefinition = view;

            LoadGroupexcel();
         }
         catch (Exception)
         { throw; }
      }
      private void LoadSubGroup(ref GridViewColumnGroup group, DataColumn column, Int32 nivel, Int32 index, Int32 newindex)
      {
         try
         {
            GridViewColumnGroup subgroup = new GridViewColumnGroup();
            String[] columns = column.ColumnName.Split('#');
            if (columns.Length > (nivel + 1))
            {

               if ((GroupsNames.ContainsKey(nivel) && GroupsNames[nivel] != columns[nivel]) || !GroupsNames.ContainsKey(nivel))
               {
                  String columngroup = columns[nivel];
                  subgroup = new GridViewColumnGroup(columngroup);

                  if (GroupsNames.ContainsKey(nivel))
                  {
                     GroupsNames[nivel] = columns[nivel];
                     Groups[nivel] = subgroup;

                     Int32 _nivelesuperiores = nivel + 1;
                     while ((GroupsNames.ContainsKey(_nivelesuperiores)))
                     {
                        GroupsNames.Remove(_nivelesuperiores);
                        Groups.Remove(_nivelesuperiores);

                        _nivelesuperiores += 1;
                     }
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

               if (newindex > 0)
               {
                  Telerik.WinControls.UI.GridViewDecimalColumn _column = new Telerik.WinControls.UI.GridViewDecimalColumn(System.Type.GetType("System.Decimal"), column.ColumnName, column.ColumnName);
                  _column.HeaderText = columns[nivel];
                  //_column.FormatString = "###'###,##0.00";
                  _column.FormatString = "{0:N}";
                  _column.FormatInfo = System.Globalization.CultureInfo.CreateSpecificCulture("es-PE");
                  _column.TextAlignment = ContentAlignment.MiddleRight;
                  grdItems.Columns.Add(_column);

                  group.Rows.Add(new GridViewColumnGroupRow());
                  group.Rows[0].Columns.Add(grdItems.Columns[column.ColumnName]);
                  index += 1;
                  newindex += 1;
               }
               else
               {
                  grdItems.Columns.Add(columnName, columns[nivel], column.ColumnName);

                  group.Rows.Add(new GridViewColumnGroupRow());
                  group.Rows[0].Columns.Add(grdItems.Columns[columnName]);
                  index += 1;
                  newindex += 1;
               }

               
               

            }
         }
         catch (Exception)
         { }
      }

      List<ExportarExcel.Grupos> ListGrupos;
      List<ExportarExcel.Columna> ListColumna;
      private void LoadGroupexcel()
      {
         try
         {
            String[] _columnasNiveles = Presenter.DTReporte.Columns[0].ColumnName.Split('#');
            Int32 _niveles = _columnasNiveles.Length;

            ExportarExcel.ColumnaGrupo _columnagrupo = new ExportarExcel.ColumnaGrupo();
            ExportarExcel.Grupos _grupo;

            ListGrupos = new List<ExportarExcel.Grupos>();
            Int32 Desde = 1;
            Int32 Hasta = 1;
            for (int _nivel = 0; _nivel < _niveles - 1; _nivel++)
            {
               Desde = 1;
               Hasta = 1;

               _grupo = new ExportarExcel.Grupos();
               string _columnNameAnterior = "";
               string _columnName = "";
               string _columnNameNivel = "";
               string _columnNameNivelAnterior = "";
               foreach (DataColumn _column in Presenter.DTReporte.Columns)
               {
                  if (_nivel == 0)
                  {
                     _columnasNiveles = _column.ColumnName.Split('#');
                     _columnName = _columnasNiveles[_nivel];

                     if (String.IsNullOrEmpty(_columnNameAnterior))
                     {
                        _columnNameAnterior = _columnName;

                        _columnagrupo = new ExportarExcel.ColumnaGrupo();
                        _columnagrupo.Valor = _columnName;
                        _columnagrupo.Desde = Desde;
                     }
                     else if (_columnNameAnterior != _columnName)
                     {
                        _columnagrupo.Hasta = Hasta;
                        if (_grupo.ListColumnaGrupos == null) { _grupo.ListColumnaGrupos = new List<ExportarExcel.ColumnaGrupo>(); }
                        _grupo.ListColumnaGrupos.Add(_columnagrupo);


                        _columnNameAnterior = _columnName;
                        Desde = Hasta + 1;
                        Hasta = Desde;

                        _columnagrupo = new ExportarExcel.ColumnaGrupo();
                        _columnagrupo.Valor = _columnName;
                        _columnagrupo.Desde = Desde;
                     }
                     else
                     { Hasta += 1; }
                  }
                  else
                  {
                     _columnasNiveles = _column.ColumnName.Split('#');

                     _columnNameNivel = _columnasNiveles[_nivel - 1];
                     _columnName = _columnasNiveles[_nivel];

                     if (String.IsNullOrEmpty(_columnNameAnterior))
                     {
                        _columnNameAnterior = _columnName;
                        _columnNameNivelAnterior = _columnNameNivel;

                        _columnagrupo = new ExportarExcel.ColumnaGrupo();
                        _columnagrupo.Valor = _columnName;
                        _columnagrupo.Desde = Desde;
                     }
                     else if (_columnNameAnterior != _columnName || _columnNameNivel != _columnNameNivelAnterior)
                     {
                        _columnagrupo.Hasta = Hasta;
                        if (_grupo.ListColumnaGrupos == null) { _grupo.ListColumnaGrupos = new List<ExportarExcel.ColumnaGrupo>(); }
                        _grupo.ListColumnaGrupos.Add(_columnagrupo);

                        _columnNameAnterior = _columnName;
                        _columnNameNivelAnterior = _columnNameNivel;
                        Desde = Hasta + 1;
                        Hasta = Desde;

                        _columnagrupo = new ExportarExcel.ColumnaGrupo();
                        _columnagrupo.Valor = _columnName;
                        _columnagrupo.Desde = Desde;
                     }
                     else
                     { Hasta += 1; }
                  }

                  //Desde = 1;
                  //Hasta = 1;
               }

               _columnagrupo.Hasta = Hasta;
               if (_grupo.ListColumnaGrupos == null) { _grupo.ListColumnaGrupos = new List<ExportarExcel.ColumnaGrupo>(); }
               _grupo.ListColumnaGrupos.Add(_columnagrupo);

               ListGrupos.Add(_grupo);
            }

            ListColumna = new List<ExportarExcel.Columna>();
            foreach (GridViewColumn _column in grdItems.Columns)
            { ListColumna.Add(new ExportarExcel.Columna() { Valor = _column.HeaderText }); }
         }
         catch (Exception)
         { }
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
                  if (CONT_Fecha.NSFecha.HasValue)
                  {
                     String _CONS_TabRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
                     String _CONS_CodRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
                     String _CONS_TabVIA = CONS_CodVIA.ConstantesSelectedItem.CONS_CodTabla;
                     String _CONS_CodVIA = CONS_CodVIA.ConstantesSelectedItem.CONS_CodTipo;
                     DateTime _CONT_Fecha = CONT_Fecha.NSFecha.Value;

                     Nullable<Int32> _PACK_Codigo = PACK_Codigo.ComboIntSelectedValue;
                     Nullable<Int32> _ENTC_CodTransportista = null; if (ENTC_CodTransportista.Value != null && ENTC_CodTransportista.Value.ENTC_Codigo > 0) { _ENTC_CodTransportista = ENTC_CodTransportista.Value.ENTC_Codigo; }

                     Nullable<Int32> _CONT_Codigo = null; if (CONT_Numero.Value != null) { _CONT_Codigo = ((Entities.Contrato)CONT_Numero.Value).CONT_Codigo; }
                     Nullable<Int32> _PUER_CodOrigen = PUER_CodOrigen.ComboIntSelectedValue;
                     Nullable<Int32> _PUER_CodDestino = PUER_CodDestino.ComboIntSelectedValue;

                     Boolean _CONT_Activo = chkCONT_Activo.Checked;

                     Presenter.CargarReporte(_CONS_TabRGM, _CONS_CodRGM, _CONS_TabVIA, _CONS_CodVIA, _CONT_Fecha, _PACK_Codigo, _ENTC_CodTransportista, _CONT_Codigo, _PUER_CodOrigen, _PUER_CodDestino, _CONT_Activo);
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
            CONT_Fecha.NSFecha = null;
            PACK_Codigo.ComboIntSelectedValue = null;
            ENTC_CodTransportista.ClearValue();
            ENTC_CodTransportista.Text = string.Empty;
            CONT_Numero.ClearValue();
            CONT_Numero.Text = string.Empty;
            CONT_Descrip.Text = string.Empty;

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
            ExportarExcel.Titulo _titulo = new ExportarExcel.Titulo() { Valor = Presenter.Title };
            List<ExportarExcel.SubTitulo> _listSubtitulos = new List<ExportarExcel.SubTitulo>();
            _listSubtitulos.Add(new ExportarExcel.SubTitulo() { Etiqueta = "Régimen", Valor = CONS_CodRGM.ConstantesSelectedItem != null ? CONS_CodRGM.ConstantesSelectedItem.CONS_Desc_SPA : "< TODOS >" });
            _listSubtitulos.Add(new ExportarExcel.SubTitulo() { Etiqueta = "Vía", Valor = CONS_CodVIA.ConstantesSelectedItem != null ? CONS_CodVIA.ConstantesSelectedItem.CONS_Desc_SPA : "< TODAS >" });
            _listSubtitulos.Add(new ExportarExcel.SubTitulo() { Etiqueta = "Fecha Fin de Vigencia", Valor = CONT_Fecha.NSFecha.HasValue ? CONT_Fecha.NSFecha.Value.ToString("dd/MM/yyyy") : "" });
            _listSubtitulos.Add(new ExportarExcel.SubTitulo() { Etiqueta = "Embalaje", Valor = PACK_Codigo.ComboSelectedItem != null && PACK_Codigo.ComboSelectedItem.IntCodigo > 0 ? PACK_Codigo.ComboSelectedItem.StrDesc : "< TODOS >" });
            _listSubtitulos.Add(new ExportarExcel.SubTitulo() { Etiqueta = "Linea Transporte", Valor = ENTC_CodTransportista.Value != null ? ENTC_CodTransportista.Value.ENTC_NomCompleto : "< TODOS >" });
            _listSubtitulos.Add(new ExportarExcel.SubTitulo() { Etiqueta = "Contrato", Valor = CONT_Numero.Value != null ? (CONT_Numero.Value as Entities.Contrato).CONT_Numero + " - " + Presenter.ItemContrato.CONT_Descrip : "< TODOS >" });
            _listSubtitulos.Add(new ExportarExcel.SubTitulo() { Etiqueta = "País Origen", Valor = TIPO_CodPAIOrigen.TiposSelectedItem != null ? TIPO_CodPAIOrigen.TiposSelectedItem.TIPO_Desc1 : "< TODOS >" });
            _listSubtitulos.Add(new ExportarExcel.SubTitulo() { Etiqueta = "Puerto Origen", Valor = PUER_CodOrigen.ComboSelectedItem != null ? PUER_CodOrigen.ComboSelectedItem.StrDesc : "< TODOS >" });
            _listSubtitulos.Add(new ExportarExcel.SubTitulo() { Etiqueta = "País Destino", Valor = TIPO_CodPAIDestino.TiposSelectedItem != null ? TIPO_CodPAIDestino.TiposSelectedItem.TIPO_Desc1 : "< TODOS >" });
            _listSubtitulos.Add(new ExportarExcel.SubTitulo() { Etiqueta = "Puerto Destino", Valor = PUER_CodDestino.ComboSelectedItem != null ? PUER_CodDestino.ComboSelectedItem.StrDesc : "< TODOS >" });

            ExportarExcel.Export(_titulo, _listSubtitulos, ListGrupos, ListColumna, Presenter.DTReporte);


            //List<String> Titulos = new List<String>();
            //Titulos.Add("Reporte");
            //Int32 _fila = 2;
            //Infrastructure.WinForms.Controls.ExcelAportes _xls = new Infrastructure.WinForms.Controls.ExcelAportes(1, Titulos, "");
            //Object[] _cabeceras = new Object[1];
            //DataTable _dt = _xls.RadGridViewToDataTable(grdItems, ref _cabeceras, grdItems.FilterDescriptors.Count > 0);
            //if (_dt.Rows.Count > 0)
            //{
            //   List<String> _listTituloFiltro = new List<String>();
            //   _listTituloFiltro.Add("");
            //   _xls.InsertarTitulos(Presenter.Title, 1, ref _fila, 1, _listTituloFiltro, _cabeceras.Length);
            //   _xls.addDataArray(1, _cabeceras, 1, _fila + 2, true, true);
            //   _xls.addDataList(1, _dt, 1, _fila + 3, true, true);
            //}

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

      #region [ Metodos Contrato ]
      private void AyudaContrato(Boolean ActualizarContrato)
      {
         try
         {
            if (CONS_CodRGM.ConstantesSelectedItem != null)
            {
               if (CONS_CodVIA.ConstantesSelectedItem != null)
               {
                  String _CONS_TabRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
                  String _CONS_CodRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
                  String _CONS_TabVIA = CONS_CodVIA.ConstantesSelectedItem.CONS_CodTabla;
                  String _CONS_CodVIA = CONS_CodVIA.ConstantesSelectedItem.CONS_CodTipo;
                  Nullable<Int32> _ENTC_CodTransportista = null; if (ENTC_CodTransportista.Value != null && ENTC_CodTransportista.Value.ENTC_Codigo > 0) { _ENTC_CodTransportista = ENTC_CodTransportista.Value.ENTC_Codigo; }

                  Presenter.AyudaContrato(_CONS_TabRGM, _CONS_CodRGM, _CONS_TabVIA, _CONS_CodVIA, _ENTC_CodTransportista);
               }
               else
               { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar una Vía para poder buscar un Contrato."); }
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un Régimen para poder buscar un Contrato."); }
         }
         catch (Exception)
         { }
      }
      public void ClearItemContrato()
      {
         try
         {
            CONT_Numero.Text = String.Empty;
            CONT_Descrip.Text = String.Empty;
            TIPO_CodPAIOrigen.TiposSelectedValue = null;
            PUER_CodOrigen.ComboIntSelectedValue = null;
            TIPO_CodPAIDestino.TiposSelectedValue = null;
            PUER_CodDestino.ComboIntSelectedValue = null;
         }
         catch (Exception)
         { }
      }
      public void SetItemContrato()
      {
         try
         {
            CONT_Numero.SetValue(Presenter.ItemContrato, Presenter.ItemContrato.CONT_Numero);
            CONT_Descrip.Text = Presenter.ItemContrato.CONT_Descrip;
            TIPO_CodPAIOrigen.TiposSelectedValue = Presenter.ItemContrato.TIPO_CodPaisOrigen;
            if (Presenter.ItemContrato.PUER_CodigoOrigen.HasValue)
            { PUER_CodOrigen.ComboIntSelectedValue = Presenter.ItemContrato.PUER_CodigoOrigen.Value; }
            TIPO_CodPAIDestino.TiposSelectedValue = Presenter.ItemContrato.TIPO_CodPaisDestino;
            if (Presenter.ItemContrato.PUER_CodigoDestino.HasValue)
            { PUER_CodDestino.ComboIntSelectedValue = Presenter.ItemContrato.PUER_CodigoDestino.Value; }
         }
         catch (Exception)
         { }
      }

      private void CONT_Numero_AyudaClick(object sender, EventArgs e)
      { AyudaContrato(false); }
      private void CONT_Numero_AyudaClean(object sender, EventArgs e)
      { ClearItemContrato(); }
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
