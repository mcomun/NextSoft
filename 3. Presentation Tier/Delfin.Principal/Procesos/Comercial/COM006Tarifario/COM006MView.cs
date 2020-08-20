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

namespace Delfin.Principal
{
   public partial class COM006MView : Form, ICOM006MView
   {
      #region [ Variables ]

      #endregion

      #region [ Formulario ]
      public COM006MView()
      {
         InitializeComponent();
         try
         {
            this.FormClosing += new FormClosingEventHandler(MView_FormClosing);

            btnImportar.Click += btnImportar_Click;
            btnCargar.Click += btnCargar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnGuardaryCerrar.Click += btnGuardaryCerrar_Click;
            btnSalir.Click += btnSalir_Click;
            btnCopiar.Click += btnCopiar_Click;

            btnActualizarTarifas.Click += btnActualizarTarifas_Click;
            btnSumarTarifas.Click += btnSumarTarifas_Click;

            //this.grdItems.CellClick += grdItems_CellClick;
            this.grdItems.MouseDoubleClick += grdItems_MouseDoubleClick;
            this.grdItems.CellEditorInitialized += grdItems_CellEditorInitialized;

            TIPO_CodPAI.SelectedIndexChanged += TIPO_CodPAI_SelectedIndexChanged;
            TIPO_CodPAIOrigen.SelectedIndexChanged += TIPO_CodPAIOrigen_SelectedIndexChanged;
            TIPO_CodPAIDestino.SelectedIndexChanged += TIPO_CodPAIDestino_SelectedIndexChanged;
            CONS_CodRGM.SelectedIndexChanged += CONS_CodRGM_SelectedIndexChanged;

            tabEdicionTarifas.SelectedIndex = 0;

            #region [ Auditoria ]
            btnAuditoriaContrato.Click += btnAuditoriaContrato_Click;
            btnAuditoriaTarifario.Click += btnAuditoriaTarifario_Click;
            #endregion
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Propiedades ]
      public COM006Presenter Presenter { get; set; }
      private bool Closing = false;
      private System.Collections.Hashtable HashFormulario { get; set; }
      #endregion

      #region [ ICOM006MView ]
      public void LoadView()
      {
         try
         {
            ENTC_CodCliente.ContainerService = Presenter.ContainerService;
            ENTC_CodTransportista.ContainerService = Presenter.ContainerService;

            tabEdicionTarifas.SelectedTab = pageFiltroTarifas;

            ENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            ENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;

            CONS_CodRGM.LoadControl(Presenter.ContainerService, "Tabla Régimen", "RGM", "< Seleccionar Régimen >", ListSortDirection.Ascending);
            CONS_CodVia.LoadControl(Presenter.ContainerService, "Tabla Vía", "VIA", "< Seleccionar Vía >", ListSortDirection.Ascending);

            TIPO_CodMnd.LoadControl(Presenter.ContainerService, "Tabla Monedas", "MND", "< Seleccionar Moneda >", ListSortDirection.Ascending);
            TIPO_CodPAI.LoadControl(Presenter.ContainerService, "Tabla Países", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);
            TIPO_CodPAIOrigen.LoadControl(Presenter.ContainerService, "Tabla Países", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);
            TIPO_CodPAIDestino.LoadControl(Presenter.ContainerService, "Tabla Países", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);

            Boolean _inicializar = true;
            foreach (Entities.Paquete _paquete in Presenter.ListPaquetes.OrderBy(_paquete => _paquete.TIPO_Num1TAM).ToObservableCollection())
            {
               PACK_Codigo.AddComboBoxItem(_paquete.PACK_Codigo, _paquete.PACK_Desc, _inicializar);
               _inicializar = false;
            }
            PACK_Codigo.LoadComboBox("< Seleccionar Embalaje >");

            _inicializar = true;
            TARI_CampoAplicar.AddComboBoxItem(1, "Campo Costo", _inicializar); _inicializar = false;
            TARI_CampoAplicar.AddComboBoxItem(2, "Campo Profit 1", _inicializar);
            TARI_CampoAplicar.AddComboBoxItem(3, "Campo Profit 2", _inicializar);
            TARI_CampoAplicar.AddComboBoxItem(4, "Campo Profit 3", _inicializar);
            TARI_CampoAplicar.AddComboBoxItem(5, "Campo Profit 4", _inicializar);
            TARI_CampoAplicar.LoadComboBox("< Seleccionar Campo >");

            _inicializar = true;
            foreach (Entities.Paquete _paquete in Presenter.ListPaquetes.OrderBy(_paquete => _paquete.TIPO_Num1TAM).ToObservableCollection())
            {
               PACK_CodigoAplicar.AddComboBoxItem(_paquete.PACK_Codigo, _paquete.PACK_Desc, _inicializar);
               _inicializar = false;
            }
            PACK_CodigoAplicar.LoadComboBox("< Seleccionar Embalaje >");

            PUER_CodOrigen.DataSource = null;
            PUER_CodOrigen.Enabled = false;

            PUER_CodDestino.DataSource = null;
            PUER_CodDestino.Enabled = false;
         }
         catch (Exception)
         { }
      }

      public void ClearItem()
      {
         try
         {
            CONT_Codigo.Text = string.Empty;
            CONT_Numero.Text = string.Empty;
            CONT_Activo.Checked = true;
            CONT_FecEmi.NSFecha = null;
            CONT_Descrip.Text = string.Empty;
            CONT_FecFin.NSFecha = null;
            CONT_FecIni.NSFecha = null;
            ENTC_CodTransportista.ClearValue();
            ENTC_CodTransportista.Text = String.Empty;
            ENTC_CodCliente.ClearValue();
            ENTC_CodCliente.Text = String.Empty;
            CONS_CodRGM.ConstantesSelectedValue = null;
            CONS_CodVia.ConstantesSelectedValue = null;

            TIPO_CodMnd.TiposSelectedValue = null;
            PACK_Codigo.ComboIntSelectedValue = null;
            TIPO_CodPAIOrigen.TiposSelectedValue = null;
            TIPO_CodPAIDestino.TiposSelectedValue = null;

            TARI_CampoAplicar.ComboIntSelectedValue = null;
            PACK_CodigoAplicar.ComboIntSelectedValue = null;
            TARI_Costo.Value = (Decimal)0.00;

            CONT_Archivo.Clear();
            CONT_Archivo.Text = null;

            grdItems.Rows.Clear();
            grdItems.Columns.Clear();
         }
         catch (Exception)
         { }
      }
      public void GetItem(Boolean Tarifario)
      {
         try
         {

            //Presenter.Item.CONT_Codigo = CONT_Codigo.Text;
            Presenter.Item.CONT_Numero = CONT_Numero.Text;
            Presenter.Item.CONT_Activo = CONT_Activo.Checked;
            Presenter.Item.CONT_FecEmi = CONT_FecEmi.NSFecha;
            Presenter.Item.CONT_FecFin = CONT_FecFin.NSFecha;
            Presenter.Item.CONT_FecIni = CONT_FecIni.NSFecha;
            Presenter.Item.CONT_Descrip = CONT_Descrip.Text;
            if (ENTC_CodTransportista.Value != null)
            { Presenter.Item.ENTC_CodTransportista = ENTC_CodTransportista.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodTransportista = null; }

            if (ENTC_CodCliente.Value != null)
            { Presenter.Item.ENTC_CodCliente = ENTC_CodCliente.Value.ENTC_Codigo; }
            else
            { Presenter.Item.ENTC_CodCliente = null; }

            if (CONS_CodRGM.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TapRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodRGM = CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TapRGM = null;
               Presenter.Item.CONS_CodRGM = null;
            }
            if (CONS_CodVia.ConstantesSelectedItem != null)
            {
               Presenter.Item.CONS_TapVia = CONS_CodVia.ConstantesSelectedItem.CONS_CodTabla;
               Presenter.Item.CONS_CodVia = CONS_CodVia.ConstantesSelectedItem.CONS_CodTipo;
            }
            else
            {
               Presenter.Item.CONS_TapVia = null;
               Presenter.Item.CONS_CodVia = null;
            }
            if (TIPO_CodMnd.TiposSelectedItem != null)
            {
               Presenter.Item.TIPO_TabMND = TIPO_CodMnd.TiposSelectedItem.TIPO_CodTabla;
               Presenter.Item.TIPO_CodMND = TIPO_CodMnd.TiposSelectedItem.TIPO_CodTipo;
            }
            else
            {
               Presenter.Item.TIPO_TabMND = null;
               Presenter.Item.TIPO_CodMND = null;
            }

            if (Tarifario)
            {
               Int32 _PUER_Codigo1 = -1;
               Int32 _PACK_Codigo = -1;
               Int32 _TARI_Codigo = -1;
               Decimal _TARI_Costo = (Decimal)0.00;

               for (int _rowIndex = 0; _rowIndex < grdItems.Rows.Count; _rowIndex++)
               {
                  _PUER_Codigo1 = -1;

                  Telerik.WinControls.UI.GridViewCellInfo _puerto = this.grdItems.Rows[_rowIndex].Cells[0];
                  if (_puerto.Tag != null && !String.IsNullOrEmpty(_puerto.Tag.ToString()))
                  { Int32.TryParse(_puerto.Tag.ToString(), out _PUER_Codigo1); }

                  for (int _colIndex = 1; _colIndex < grdItems.Columns.Count; _colIndex++)
                  {
                     _PACK_Codigo = -1;
                     _TARI_Codigo = -1;
                     _TARI_Costo = (Decimal)0.00;

                     Int32.TryParse(this.grdItems.Columns[_colIndex].Name, out _PACK_Codigo);

                     Telerik.WinControls.UI.GridViewCellInfo _tarifa = this.grdItems.Rows[_rowIndex].Cells[_colIndex];
                     if (_tarifa.Value != null && !String.IsNullOrEmpty(_tarifa.Value.ToString()) && Decimal.TryParse(_tarifa.Value.ToString(), out _TARI_Costo))
                     {
                        if (_TARI_Costo > (Decimal)0.00)
                        {
                           if (_tarifa.Tag != null && !String.IsNullOrEmpty(_tarifa.Tag.ToString()))
                           { Int32.TryParse(_tarifa.Tag.ToString(), out _TARI_Codigo); }

                           if (_PUER_Codigo1 > 0 && _PACK_Codigo > 0)
                           {
                              Int32 _PUER_Codigo2 = -1;
                              if (CONS_CodRGM.ConstantesSelectedValue == Delfin.Controls.variables.CONSRGM_Importacion)
                              { _PUER_Codigo2 = PUER_CodDestino.ComboIntSelectedValue.Value; }
                              else
                              { _PUER_Codigo2 = PUER_CodOrigen.ComboIntSelectedValue.Value; }

                              if (_TARI_Codigo <= 0)
                              {
                                 //Presenter.NuevoTarifa(TIPO_CodMnd.TiposSelectedItem, _PUER_Codigo1, _PUER_Codigo2, _pack_codigo, _tari_costo);

                                 Entities.Tarifa _itemTarifa = new Entities.Tarifa();
                                 //_itemTarifa.CONT_Codigo = Presenter.Item.CONT_Codigo;
                                 if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
                                 {
                                    _itemTarifa.PUER_CodOrigen = _PUER_Codigo1;
                                    _itemTarifa.PUER_CodDestino = _PUER_Codigo2;
                                 }
                                 else
                                 {
                                    _itemTarifa.PUER_CodDestino = _PUER_Codigo1;
                                    _itemTarifa.PUER_CodOrigen = _PUER_Codigo2;
                                 }
                                 _itemTarifa.PACK_Codigo = _PACK_Codigo;
                                 _itemTarifa.TARI_Costo = _TARI_Costo;
                                 _itemTarifa.ActualizarPrecios();
                                 _itemTarifa.TIPO_TabMnd = TIPO_CodMnd.TiposSelectedItem.TIPO_CodTabla;
                                 _itemTarifa.TIPO_CodMnd = TIPO_CodMnd.TiposSelectedItem.TIPO_CodTipo;
                                 _itemTarifa.AUDI_UsrCrea = Presenter.Session.UserName;
                                 _itemTarifa.AUDI_FecCrea = Presenter.Session.Fecha;
                                 _itemTarifa.Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Added;

                                 Presenter.Item.ListTarifa.Add(_itemTarifa);

                              }
                              else
                              {
                                 //Presenter.EditarTarifa(TIPO_CodMnd.TiposSelectedItem, _PUER_Codigo1, _PUER_Codigo2, _PACK_Codigo, _TARI_Codigo, _TARI_Costo); 

                                 Entities.Tarifa _itemTarifa = Presenter.Item.ListTarifa.Where(tari => tari.TARI_Codigo == _TARI_Codigo).FirstOrDefault();

                                 if (_itemTarifa != null)
                                 {
                                    Int32 _index = Presenter.Item.ListTarifa.IndexOf(_itemTarifa);

                                    Presenter.Item.ListTarifa[_index].TARI_Costo = _TARI_Costo;
                                    Presenter.Item.ListTarifa[_index].ActualizarPrecios();
                                    Presenter.Item.ListTarifa[_index].AUDI_UsrMod = Presenter.Session.UserName;
                                    Presenter.Item.ListTarifa[_index].AUDI_FecMod = Presenter.Session.Fecha;
                                    Presenter.Item.ListTarifa[_index].Instance = Infrastructure.Aspect.BusinessEntity.InstanceEntity.Modified;
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
         }
         catch (Exception)
         { }
      }
      public void SetItem(Boolean Copiar = false)
      {
         try
         {
            CONT_Codigo.Text = Presenter.Item.CONT_Codigo.ToString();
            CONT_Activo.Checked = Presenter.Item.CONT_Activo;
            CONT_Numero.Text = Presenter.Item.CONT_Numero;
            CONT_FecEmi.NSFecha = Presenter.Item.CONT_FecEmi;
            CONT_Descrip.Text = Presenter.Item.CONT_Descrip;
            CONT_FecIni.NSFecha = Presenter.Item.CONT_FecIni;
            CONT_FecFin.NSFecha = Presenter.Item.CONT_FecFin;

            if (Presenter.Item.ENTC_CodTransportista.HasValue)
            { ENTC_CodTransportista.SetValue(Presenter.Item.ENTC_CodTransportista.Value); }
            if (Presenter.Item.ENTC_CodCliente.HasValue)
            { ENTC_CodCliente.SetValue(Presenter.Item.ENTC_CodCliente.Value); }

            CONS_CodRGM.ConstantesSelectedValue = Presenter.Item.CONS_CodRGM;
            CONS_CodVia.ConstantesSelectedValue = Presenter.Item.CONS_CodVia;


            TIPO_CodMnd.TiposSelectedValue = Presenter.Item.TIPO_CodMND;
            if (!Copiar)
            {
               if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
               {
                  TIPO_CodPAIDestino.TiposSelectedValue = Presenter.Item.TIPO_CodPaisDestino;
                  PUER_CodDestino.ComboIntSelectedValue = Presenter.Item.PUER_CodigoDestino;

                  TIPO_CodPAIOrigen.TiposSelectedValue = Presenter.Item.TIPO_CodPaisOrigen;
               }
               else
               {
                  TIPO_CodPAIOrigen.TiposSelectedValue = Presenter.Item.TIPO_CodPaisOrigen;
                  PUER_CodOrigen.ComboIntSelectedValue = Presenter.Item.PUER_CodigoOrigen;

                  TIPO_CodPAIDestino.TiposSelectedValue = Presenter.Item.TIPO_CodPaisDestino;
               }

               Presenter.ItemTipoMND = TIPO_CodMnd.TiposSelectedItem;
               Presenter.ItemPaquete = PACK_Codigo.ComboSelectedItem.IntCodigo.HasValue ? Presenter.ListPaquetes.Where(pack => pack.PACK_Codigo == PACK_Codigo.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null;
               Presenter.ItemTipoPAIOrigen = TIPO_CodPAIOrigen.TiposSelectedItem;
               Presenter.ItemPuertoOrigen = (PUER_CodOrigen.ComboSelectedItem != null && PUER_CodOrigen.ComboSelectedItem.IntCodigo.HasValue) ? Presenter.ListPuertos.Where(pack => pack.PUER_Codigo == PUER_CodOrigen.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null;
               Presenter.ItemTipoPAIDestino = TIPO_CodPAIDestino.TiposSelectedItem;
               Presenter.ItemPuertoDestino = (PUER_CodDestino.ComboSelectedItem != null && PUER_CodDestino.ComboSelectedItem.IntCodigo.HasValue) ? Presenter.ListPuertos.Where(pack => pack.PUER_Codigo == PUER_CodDestino.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null;
            }
            else
            {
               if (Presenter.ItemTipoPAIOrigen != null)
               { TIPO_CodPAIOrigen.TiposSelectedValue = Presenter.ItemTipoPAIOrigen.TIPO_CodTipo; }
               if (Presenter.ItemPuertoOrigen != null)
               { PUER_CodOrigen.ComboIntSelectedValue = Presenter.ItemPuertoOrigen.PUER_Codigo; }
               if (Presenter.ItemTipoPAIDestino != null)
               { TIPO_CodPAIDestino.TiposSelectedValue = Presenter.ItemTipoPAIDestino.TIPO_CodTipo; }
               if (Presenter.ItemPuertoDestino != null)
               { PUER_CodDestino.ComboIntSelectedValue = Presenter.ItemPuertoDestino.PUER_Codigo; }
            }
            CONT_Numero.Select();

            HashFormulario = Infrastructure.Client.FormClose.FormValidateChanges.iniciarComparacionFormulario(this);
         }
         catch (Exception)
         { }
      }
      public void EnableItem(Boolean x_Enabled, Boolean x_EnabledCopy)
      {
         try
         {
            CONT_Codigo.Enabled = x_Enabled;
            CONT_Numero.Enabled = x_EnabledCopy;
            //CONT_Activo.Enabled = x_EnabledCopy;
            CONT_FecEmi.Enabled = x_EnabledCopy;
            //CONT_Descrip.Enabled = x_EnabledCopy;
            //CONT_FecIni.Enabled = x_EnabledCopy;
            //CONT_FecFin.Enabled = x_EnabledCopy;
            ENTC_CodTransportista.Enabled = x_Enabled;
            ENTC_CodTransportista.Enabled = x_Enabled;
            ENTC_CodCliente.Enabled = x_Enabled;
            ENTC_CodCliente.Enabled = x_Enabled;
            CONS_CodRGM.Enabled = x_Enabled;
            CONS_CodVia.Enabled = x_Enabled;
            TIPO_CodMnd.Enabled = x_Enabled;
         }
         catch (Exception)
         { }
      }

      public void ShowTarifas(DataTable DTTarifario)
      {
         try
         {
            grdItems.Rows.Clear();
            grdItems.Columns.Clear();
            grdItems.Enabled = true;

            DTTarifario.DefaultView.Sort = "PUER_Nombre";
            DTTarifario = DTTarifario.DefaultView.ToTable();

            foreach (DataColumn columna in DTTarifario.Columns)
            {
               if (!String.IsNullOrEmpty(columna.ColumnName.ToString()) && columna.ColumnName.ToString().Contains('#'))
               {
                  String[] valores = columna.ColumnName.Split('#');
                  //grdItems.Columns.Add(valores[0], valores[1]);

                  Telerik.WinControls.UI.GridViewDecimalColumn column = new Telerik.WinControls.UI.GridViewDecimalColumn(System.Type.GetType("System.Decimal"), valores[0], valores[0]);
                  column.HeaderText = valores[1];
                  //column.FormatString = "###'###,##0.00";
                  column.FormatString = "{0:N}";
                  column.FormatInfo = System.Globalization.CultureInfo.CreateSpecificCulture("es-PE");
                  column.TextAlignment = ContentAlignment.MiddleRight;

                  grdItems.Columns.Add(column);

               }
               else
               { grdItems.Columns.Add(columna.ColumnName, columna.ColumnName); }
            }

            foreach (DataRow fila in DTTarifario.Rows)
            {

               Telerik.WinControls.UI.GridViewRowInfo nuevafila = grdItems.Rows.NewRow();

               string _columnname = "";
               Boolean _firstColumn = true;
               foreach (DataColumn columna in DTTarifario.Columns)
               {
                  if (!String.IsNullOrEmpty(columna.ColumnName.ToString()) && columna.ColumnName.ToString().Contains('#'))
                  {
                     String[] valores = columna.ColumnName.Split('#');
                     _columnname = valores[0];
                  }
                  else
                  { _columnname = columna.ColumnName; }

                  if (fila[columna.ColumnName] != DBNull.Value && !String.IsNullOrEmpty(fila[columna.ColumnName].ToString()) && fila[columna.ColumnName].ToString().Contains('#'))
                  {
                     String[] valores = fila[columna.ColumnName].ToString().Split('#');

                     Int32 _tari_codigo = -1;
                     if (Int32.TryParse(valores[0], out _tari_codigo))
                     {
                        if (_tari_codigo > 0)
                        { nuevafila.Cells[_columnname].Tag = _tari_codigo; }
                        else
                        { nuevafila.Cells[_columnname].Tag = null; }
                     }

                     Decimal _tari_costo = (Decimal)0.00;
                     if (Decimal.TryParse(valores[1], out _tari_costo))
                     {
                        if (_tari_costo > (Decimal)0.00)
                        { nuevafila.Cells[_columnname].Value = _tari_costo; }
                        else
                        { nuevafila.Cells[_columnname].Value = null; }
                     }
                     else if (_firstColumn)
                     { nuevafila.Cells[_columnname].Value = valores[1]; }

                     _firstColumn = false;
                  }
                  else
                  {
                     if (fila[columna.ColumnName] != DBNull.Value)
                     { nuevafila.Cells[_columnname].Value = fila[columna.ColumnName].ToString(); }
                  }
               }

               grdItems.Rows.Add(nuevafila);
            }

            if (Presenter.Item.CONS_CodRGM == Delfin.Controls.variables.CONSRGM_Importacion)
            { grdItems.Columns[0].HeaderText = "Puerto Origen"; }
            else
            { grdItems.Columns[0].HeaderText = "Puerto Destino"; }

            Infrastructure.WinForms.Controls.GridAutoFit.Fit(this.grdItems);
            grdItems.ShowFilteringRow = false;
            grdItems.EnableFiltering = false;
            grdItems.MasterTemplate.EnableFiltering = false;
            grdItems.EnableGrouping = false;
            grdItems.MasterTemplate.EnableGrouping = false;
            grdItems.EnableSorting = false;
            grdItems.MasterTemplate.EnableCustomSorting = false;
            grdItems.MasterTemplate.Columns[0].IsPinned = true;

            grdItems.EnableHotTracking = true;

            this.grdItems.ReadOnly = false;
            this.grdItems.AllowEditRow = true;
            this.grdItems.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.CellSelect;

            Boolean ReadOnly = true;
            foreach (var column in this.grdItems.Columns)
            {
               column.IsPinned = ReadOnly;
               column.ReadOnly = ReadOnly;
               ReadOnly = false;
            }

            lblTIPO_CodPAIOrigen.Enabled = false;
            TIPO_CodPAIOrigen.Enabled = false;
            lblPUER_CodOrigen.Enabled = false;
            PUER_CodOrigen.Enabled = false;
            lblTIPO_CodPAIDestino.Enabled = false;
            TIPO_CodPAIDestino.Enabled = false;
            lblPUER_CodDestino.Enabled = false;
            PUER_CodDestino.Enabled = false;
            lblPACK_Codigo.Enabled = false;
            PACK_Codigo.Enabled = false;
            btnCargar.Enabled = false;
            btnLimpiar.Enabled = true;

         }
         catch (Exception)
         { }
      }
      public void ShowValidation()
      {
         try
         {
            Infrastructure.Client.FormClose.FormShowErrorProvider<Entities.Contrato>.Validate(Presenter.Item, this, errorProvider1);
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos ]
      private void Importar()
      {
         try
         {
            errorProvider1.Clear();

            if (!String.IsNullOrEmpty(CONT_Archivo.Text) && !String.IsNullOrEmpty(CONT_Archivo.FullPath) && System.IO.File.Exists(CONT_Archivo.FullPath))
            {
               Entities.Tipos ItemTipoMND = TIPO_CodMnd.TiposSelectedItem;
               Entities.Paquete ItemPaquete = PACK_Codigo.ComboSelectedItem != null && PACK_Codigo.ComboSelectedItem.IntCodigo.HasValue ? Presenter.ListPaquetes.Where(pack => pack.PACK_Codigo == PACK_Codigo.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null;
               Entities.Tipos ItemTipoPAIOrigen = TIPO_CodPAIOrigen.TiposSelectedItem;
               Entities.Puerto ItemPuertoOrigen = (PUER_CodOrigen.ComboSelectedItem != null && PUER_CodOrigen.ComboSelectedItem.IntCodigo.HasValue) ? Presenter.ListPuertos.Where(pack => pack.PUER_Codigo == PUER_CodOrigen.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null;
               Entities.Tipos ItemTipoPAIDestino = TIPO_CodPAIDestino.TiposSelectedItem;
               Entities.Puerto ItemPUertoDestino = (PUER_CodDestino.ComboSelectedItem != null && PUER_CodDestino.ComboSelectedItem.IntCodigo.HasValue) ? Presenter.ListPuertos.Where(pack => pack.PUER_Codigo == PUER_CodDestino.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null;

               Decimal _TARI_ValorAdicionar = TARI_Servicio1.Value + TARI_Servicio2.Value + TARI_Servicio3.Value + TARI_Servicio4.Value;

               Presenter.Importar(ItemTipoMND, ItemPaquete, ItemTipoPAIOrigen, ItemPuertoOrigen, ItemTipoPAIDestino, ItemPUertoDestino, CONT_Archivo.FullPath, _TARI_ValorAdicionar);
            }
            else
            { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar un archivo que sea válido."); }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al importar.", ex); }
      }
      private void Copiar()
      {
         try
         {
            Presenter.Copiar();
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al copiar.", ex); }
      }

      private void ConfigurarPuertos()
      {
         try
         {
            if (CONS_CodRGM.ConstantesSelectedItem == null)
            {
               lblTIPO_CodPAIOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               lblPUER_CodOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               if (TIPO_CodPAIOrigen.DataSource != null) { TIPO_CodPAIOrigen.SelectedIndex = 0; }
               TIPO_CodPAIOrigen.Enabled = false;
               PUER_CodOrigen.Enabled = false;

               lblTIPO_CodPAIDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               lblPUER_CodDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               if (TIPO_CodPAIDestino.DataSource != null) { TIPO_CodPAIDestino.SelectedIndex = 0; }
               TIPO_CodPAIDestino.Enabled = false;
               PUER_CodDestino.Enabled = false;

               lblTIPO_CodPAI.Text = "País:";
               lblPUER_Codigo.Text = "Puerto:";
               lblTIPO_CodPAI.Enabled = false;
               TIPO_CodPAI.Enabled = false;
               lblPUER_Codigo.Enabled = false;
               PUER_Codigo.Enabled = false;

               TIPO_CodPAI.LoadControl(Presenter.ContainerService, "Tabla Países", "PAI", "< Seleccionar País >", ListSortDirection.Ascending);
            }
            else if (CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Importacion)
            {
               lblTIPO_CodPAIOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               lblPUER_CodOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               lblTIPO_CodPAIDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               lblPUER_CodDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

               TIPO_CodPAIOrigen.Enabled = true;
               PUER_CodOrigen.Enabled = true;
               TIPO_CodPAIDestino.Enabled = true;
               PUER_CodDestino.Enabled = true;

               lblTIPO_CodPAI.Text = "País Destino:";
               lblPUER_Codigo.Text = "Puerto Destino:";
               lblTIPO_CodPAI.Enabled = true;
               TIPO_CodPAI.Enabled = true;
               lblPUER_Codigo.Enabled = true;
               PUER_Codigo.Enabled = true;

               TIPO_CodPAI.LoadControl(Presenter.ContainerService, "Tabla Países", "PAI", "< Seleccionar País Destino >", ListSortDirection.Ascending);
            }
            else if (CONS_CodRGM.ConstantesSelectedItem.CONS_CodTipo == Delfin.Controls.variables.CONSRGM_Exportacion)
            {
               lblTIPO_CodPAIOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               lblPUER_CodOrigen.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               lblTIPO_CodPAIDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               lblPUER_CodDestino.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

               TIPO_CodPAIOrigen.Enabled = true;
               PUER_CodOrigen.Enabled = true;
               TIPO_CodPAIDestino.Enabled = true;
               PUER_CodDestino.Enabled = true;

               lblTIPO_CodPAI.Text = "País Origen:";
               lblPUER_Codigo.Text = "Puerto Origen:";
               lblTIPO_CodPAI.Enabled = true;
               TIPO_CodPAI.Enabled = true;
               lblPUER_Codigo.Enabled = true;
               PUER_Codigo.Enabled = true;

               TIPO_CodPAI.LoadControl(Presenter.ContainerService, "Tabla Países", "PAI", "< Seleccionar País Origen >", ListSortDirection.Ascending);
            }
         }
         catch (Exception)
         { throw; }
      }
      private void LoadPuertos()
      {
         try
         {
            Boolean _inicializar = true;
            if (TIPO_CodPAI.TiposSelectedItem != null && CONS_CodVia.ConstantesSelectedItem != null)
            {
               ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.PUER_Favorito && puer.TIPO_CodPais == TIPO_CodPAI.TiposSelectedItem.TIPO_CodTipo && puer.CONS_CodVia == CONS_CodVia.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection();
               if (_items != null && _items.Count > 0)
               {
                  foreach (Entities.Puerto _puerto in _items)
                  {
                     PUER_Codigo.AddComboBoxItem(_puerto.PUER_Codigo, _puerto.PUER_Nombre, _inicializar);
                     _inicializar = false;
                  }
                  PUER_Codigo.LoadComboBox("< Seleccionar Puerto Origen >", ListSortDirection.Ascending);
                  PUER_Codigo.Enabled = true;
               }
               else
               {
                  PUER_Codigo.DataSource = null;
                  PUER_Codigo.Enabled = false;
               }
            }
            else
            {
               PUER_Codigo.DataSource = null;
               PUER_Codigo.Enabled = false;
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos.", ex); }
      }
      private void LoadPuertosOrigen()
      {
         try
         {
            Boolean _inicializar = true;
            if (TIPO_CodPAIOrigen.TiposSelectedItem != null && CONS_CodVia.ConstantesSelectedItem != null)
            {
               ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.PUER_Favorito && puer.TIPO_CodPais == TIPO_CodPAIOrigen.TiposSelectedItem.TIPO_CodTipo && puer.CONS_CodVia == CONS_CodVia.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection();
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
            if (TIPO_CodPAIDestino.TiposSelectedItem != null && CONS_CodVia.ConstantesSelectedItem != null)
            {
               ObservableCollection<Entities.Puerto> _items = Presenter.ListPuertos.Where(puer => puer.PUER_Favorito && puer.TIPO_CodPais == TIPO_CodPAIDestino.TiposSelectedItem.TIPO_CodTipo && puer.CONS_CodVia == CONS_CodVia.ConstantesSelectedItem.CONS_CodTipo).ToObservableCollection();
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
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al cargar los puertos de destino.", ex); }
      }

      private void LoadTarifas()
      {
         try
         {
            errorProvider1.Clear();

            Entities.Tipos ItemTipoMND = TIPO_CodMnd.TiposSelectedItem;
            Entities.Paquete ItemPaquete = ((PACK_Codigo.ComboSelectedItem != null && PACK_Codigo.ComboSelectedItem.IntCodigo.HasValue) ? Presenter.ListPaquetes.Where(pack => pack.PACK_Codigo == PACK_Codigo.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null);
            Entities.Tipos ItemTipoPAIOrigen = TIPO_CodPAIOrigen.TiposSelectedItem;
            Entities.Puerto ItemPuertoOrigen = ((PUER_CodOrigen.ComboSelectedItem != null && PUER_CodOrigen.ComboSelectedItem.IntCodigo.HasValue) ? Presenter.ListPuertos.Where(pack => pack.PUER_Codigo == PUER_CodOrigen.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null);
            Entities.Tipos ItemTipoPAIDestino = TIPO_CodPAIDestino.TiposSelectedItem;
            Entities.Puerto ItemPUertoDestino = ((PUER_CodDestino.ComboSelectedItem != null && PUER_CodDestino.ComboSelectedItem.IntCodigo.HasValue) ? Presenter.ListPuertos.Where(pack => pack.PUER_Codigo == PUER_CodDestino.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null);

            Presenter.LoadTarifas(ItemTipoMND, ItemPaquete, ItemTipoPAIOrigen, ItemPuertoOrigen, ItemTipoPAIDestino, ItemPUertoDestino);
         }
         catch (Exception)
         { }
      }
      private void LimpiarTarifas()
      {
         try
         {
            grdItems.Rows.Clear();
            grdItems.Columns.Clear();

            grdItems.Enabled = false;

            lblTIPO_CodPAIOrigen.Enabled = true;
            TIPO_CodPAIOrigen.Enabled = true;
            lblPUER_CodOrigen.Enabled = true;
            PUER_CodOrigen.Enabled = true;
            lblTIPO_CodPAIDestino.Enabled = true;
            TIPO_CodPAIDestino.Enabled = true;
            lblPUER_CodDestino.Enabled = true;
            PUER_CodDestino.Enabled = true;
            lblPACK_Codigo.Enabled = true;
            PACK_Codigo.Enabled = true;
            btnCargar.Enabled = true;
            btnLimpiar.Enabled = false;
         }
         catch (Exception)
         { }
      }
      private void EditTarifa()
      {
         try
         {
            Int32 _puer_codigo = -1;
            Int32 _pack_codigo = -1;
            Int32 _tari_codigo = -1;
            Decimal _tari_costo = (Decimal)0.00;

            Int32.TryParse(this.grdItems.Columns[colIndex].Name, out _pack_codigo);

            Telerik.WinControls.UI.GridViewCellInfo _puerto = this.grdItems.Rows[rowIndex].Cells[0];
            if (_puerto.Tag != null && !String.IsNullOrEmpty(_puerto.Tag.ToString()))
            { Int32.TryParse(_puerto.Tag.ToString(), out _puer_codigo); }

            Telerik.WinControls.UI.GridViewCellInfo _tarifa = this.grdItems.Rows[rowIndex].Cells[colIndex];
            if (_tarifa.Value != null && !String.IsNullOrEmpty(_tarifa.Value.ToString()))
            { Decimal.TryParse(_tarifa.Value.ToString(), out _tari_costo); }
            if (_tarifa.Tag != null && !String.IsNullOrEmpty(_tarifa.Tag.ToString()))
            { Int32.TryParse(_tarifa.Tag.ToString(), out _tari_codigo); }

            if (_puer_codigo > 0 && _pack_codigo > 0)
            {
               Int32 _puer_codigo2 = -1;
               if (CONS_CodRGM.ConstantesSelectedValue == Delfin.Controls.variables.CONSRGM_Importacion)
               { _puer_codigo2 = PUER_CodDestino.ComboIntSelectedValue.Value; }
               else
               { _puer_codigo2 = PUER_CodOrigen.ComboIntSelectedValue.Value; }

               if (_tari_codigo <= 0)
               { Presenter.NuevoTarifa(TIPO_CodMnd.TiposSelectedItem, _puer_codigo, _puer_codigo2, _pack_codigo, _tari_costo); }
               else
               { Presenter.EditarTarifa(TIPO_CodMnd.TiposSelectedItem, _puer_codigo, _puer_codigo2, _pack_codigo, _tari_codigo, _tari_costo); }
            }
         }
         catch (Exception)
         { }
      }
      #endregion

      #region [ Metodos Actualizar Tarifa ]
      private void btnActualizarTarifas_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar(false, false))
            {
               //TARI_CampoAplicar
               //PACK_CodigoAplicar
               //TARI_ValorAplicar

               //if (!TARI_CampoAplicar.ComboIntSelectedValue.HasValue)
               //{
               //   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar el Campo Actualizar.");
               //   return;
               //}

               if (!PACK_CodigoAplicar.ComboIntSelectedValue.HasValue)
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar el Embalaje Actualizar.");
                  return;
               }

               if (((TARI_Costo.Value <= (Decimal)0.00) && (TARI_Profit1.Value <= (Decimal)0.00) && (TARI_Profit2.Value <= (Decimal)0.00) && (TARI_Profit3.Value <= (Decimal)0.00) && (TARI_Profit4.Value <= (Decimal)0.00)))
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar un Valor a Actualizar.");
                  return;
               }

               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Esta seguro que desea actualizar con el valor ingresado en el campo seleccionado de las tarifas?") == System.Windows.Forms.DialogResult.OK)
               {
                  Presenter.ItemsTarifa = new ObservableCollection<Entities.Tarifa>();

                  Int32 _TARI_Campo = -1; //TARI_CampoAplicar.ComboIntSelectedValue.Value;
                  Int32 _PACK_Codigo = PACK_CodigoAplicar.ComboIntSelectedValue.Value;
                  Decimal _TARI_Valor = TARI_Costo.Value;
                  Int32 _PUER_CodigoOrigen = -1;
                  Int32 _PUER_CodigoDestino = -1;
                  Int32 _TARI_Codigo = -1;
                  Decimal _TARI_Costo = (Decimal)0.00;
                  foreach (Telerik.WinControls.UI.GridViewRowInfo item in grdItems.Rows)
                  {
                     _PUER_CodigoOrigen = -1;
                     _TARI_Codigo = -1;
                     _TARI_Costo = (Decimal)0.00;

                     Telerik.WinControls.UI.GridViewCellInfo _tarifa = item.Cells[_PACK_Codigo.ToString()];
                     if (_tarifa.Tag != null && !String.IsNullOrEmpty(_tarifa.Tag.ToString()))
                     { Int32.TryParse(_tarifa.Tag.ToString(), out _TARI_Codigo); }
                     if (_tarifa.Value != null && !String.IsNullOrEmpty(_tarifa.Value.ToString()))
                     { Decimal.TryParse(_tarifa.Value.ToString(), out _TARI_Costo); }

                     if (_PACK_Codigo > 0)
                     {

                        Telerik.WinControls.UI.GridViewCellInfo _puerto = item.Cells[0];
                        if (CONS_CodRGM.ConstantesSelectedValue == Delfin.Controls.variables.CONSRGM_Importacion)
                        {
                           if (_puerto.Tag != null && !String.IsNullOrEmpty(_puerto.Tag.ToString()))
                           { Int32.TryParse(_puerto.Tag.ToString(), out _PUER_CodigoOrigen); }
                           _PUER_CodigoDestino = PUER_CodDestino.ComboIntSelectedValue.Value;
                        }
                        else
                        {
                           if (_puerto.Tag != null && !String.IsNullOrEmpty(_puerto.Tag.ToString()))
                           { Int32.TryParse(_puerto.Tag.ToString(), out _PUER_CodigoDestino); }
                           _PUER_CodigoOrigen = PUER_CodOrigen.ComboIntSelectedValue.Value;
                        }
                     }

                     if (_PACK_Codigo > 0 && _PUER_CodigoOrigen > 0 && _PUER_CodigoDestino > 0)
                     {
                        Decimal _TARI_CostoActualizar = TARI_Costo.Value;
                        Decimal _TARI_Profit1Actualizar = TARI_Profit1.Value;
                        Decimal _TARI_Profit2Actualizar = TARI_Profit2.Value;
                        Decimal _TARI_Profit3Actualizar = TARI_Profit3.Value;
                        Decimal _TARI_Profit4Actualizar = TARI_Profit4.Value;

                        Presenter.ActualizarTarifa(_TARI_Codigo, _PUER_CodigoOrigen, _PUER_CodigoDestino, _PACK_Codigo, _TARI_Campo, _TARI_Valor, _TARI_CostoActualizar, _TARI_Profit1Actualizar, _TARI_Profit2Actualizar, _TARI_Profit3Actualizar, _TARI_Profit4Actualizar, _TARI_Costo);
                     }
                  }

                  if (Presenter.GuardarTarifas())
                  {
                     //SetItem();
                     CONT_Codigo.Text = Presenter.Item.CONT_Codigo.ToString();
                     LoadTarifas();

                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Se ha aplicado satisfactoriamente el cambio.");

                     TARI_CampoAplicar.ComboIntSelectedValue = null;
                     PACK_CodigoAplicar.ComboIntSelectedValue = null;

                     TARI_Costo.Value = (Decimal)0.00;
                     TARI_Profit1.Value = (Decimal)0.00;
                     TARI_Profit2.Value = (Decimal)0.00;
                     TARI_Profit3.Value = (Decimal)0.00;
                     TARI_Profit4.Value = (Decimal)0.00;

                     TARI_Costo.Text = "0.00";
                     TARI_Profit1.Text = "0.00";
                     TARI_Profit2.Text = "0.00";
                     TARI_Profit3.Text = "0.00";
                     TARI_Profit4.Text = "0.00";
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Ha Ocurrido un error aplicadando el cambio."); }
               }
            }
         }
         catch (Exception)
         { throw; }
      }
      private void btnSumarTarifas_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar(false, false))
            {
               //TARI_CampoAplicar
               //PACK_CodigoAplicar
               //TARI_ValorAplicar

               //if (!TARI_CampoAplicar.ComboIntSelectedValue.HasValue)
               //{
               //   Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar el Campo Actualizar.");
               //   return;
               //}

               if (!PACK_CodigoAplicar.ComboIntSelectedValue.HasValue)
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe seleccionar el Embalaje Actualizar.");
                  return;
               }

               if (((TARI_Costo.Value <= (Decimal)0.00) && (TARI_Profit1.Value <= (Decimal)0.00) && (TARI_Profit2.Value <= (Decimal)0.00) && (TARI_Profit3.Value <= (Decimal)0.00) && (TARI_Profit4.Value <= (Decimal)0.00)))
               {
                  Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Debe ingresar un Valor a Actualizar.");
                  return;
               }

               if (Infrastructure.WinForms.Controls.Dialogos.MostrarMensajePregunta(Presenter.Title, "¿Esta seguro que desea adicionar el valor ingresado en el campo seleccionado de las tarifas?") == System.Windows.Forms.DialogResult.OK)
               {
                  Presenter.ItemsTarifa = new ObservableCollection<Entities.Tarifa>();

                  Int32 _TARI_Campo = -1; //TARI_CampoAplicar.ComboIntSelectedValue.Value;
                  Int32 _PACK_Codigo = PACK_CodigoAplicar.ComboIntSelectedValue.Value;
                  Decimal _TARI_Valor = TARI_Costo.Value;
                  Int32 _PUER_CodigoOrigen = -1;
                  Int32 _PUER_CodigoDestino = -1;
                  Int32 _TARI_Codigo = -1;
                  Decimal _TARI_Costo = (Decimal)0.00;
                  foreach (Telerik.WinControls.UI.GridViewRowInfo item in grdItems.Rows)
                  {
                     _PUER_CodigoOrigen = -1;
                     _TARI_Codigo = -1;
                     _TARI_Costo = (Decimal)0.00;

                     Telerik.WinControls.UI.GridViewCellInfo _tarifa = item.Cells[_PACK_Codigo.ToString()];
                     if (_tarifa.Tag != null && !String.IsNullOrEmpty(_tarifa.Tag.ToString()))
                     { Int32.TryParse(_tarifa.Tag.ToString(), out _TARI_Codigo); }
                     if (_tarifa.Value != null && !String.IsNullOrEmpty(_tarifa.Value.ToString()))
                     { Decimal.TryParse(_tarifa.Value.ToString(), out _TARI_Costo); }

                     if (_PACK_Codigo > 0)
                     {

                        Telerik.WinControls.UI.GridViewCellInfo _puerto = item.Cells[0];
                        if (CONS_CodRGM.ConstantesSelectedValue == Delfin.Controls.variables.CONSRGM_Importacion)
                        {
                           if (_puerto.Tag != null && !String.IsNullOrEmpty(_puerto.Tag.ToString()))
                           { Int32.TryParse(_puerto.Tag.ToString(), out _PUER_CodigoOrigen); }
                           _PUER_CodigoDestino = PUER_CodDestino.ComboIntSelectedValue.Value;
                        }
                        else
                        {
                           if (_puerto.Tag != null && !String.IsNullOrEmpty(_puerto.Tag.ToString()))
                           { Int32.TryParse(_puerto.Tag.ToString(), out _PUER_CodigoDestino); }
                           _PUER_CodigoOrigen = PUER_CodOrigen.ComboIntSelectedValue.Value;
                        }
                     }

                     if (_PACK_Codigo > 0 && _PUER_CodigoOrigen > 0 && _PUER_CodigoDestino > 0)
                     {
                        Decimal _TARI_CostoActualizar = TARI_Costo.Value;
                        Decimal _TARI_Profit1Actualizar = TARI_Profit1.Value;
                        Decimal _TARI_Profit2Actualizar = TARI_Profit2.Value;
                        Decimal _TARI_Profit3Actualizar = TARI_Profit3.Value;
                        Decimal _TARI_Profit4Actualizar = TARI_Profit4.Value;

                        Presenter.SumarTarifa(_TARI_Codigo, _PUER_CodigoOrigen, _PUER_CodigoDestino, _PACK_Codigo, _TARI_Campo, _TARI_Valor, _TARI_CostoActualizar, _TARI_Profit1Actualizar, _TARI_Profit2Actualizar, _TARI_Profit3Actualizar, _TARI_Profit4Actualizar, _TARI_Costo);
                     }

                  }


                  if (Presenter.GuardarTarifas())
                  {
                     //SetItem();
                     CONT_Codigo.Text = Presenter.Item.CONT_Codigo.ToString();
                     LoadTarifas();

                     Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeSatisfactorio(Presenter.Title, "Se ha aplicado satisfactoriamente el cambio.");
                     TARI_CampoAplicar.ComboIntSelectedValue = null;
                     PACK_CodigoAplicar.ComboIntSelectedValue = null;

                     TARI_Costo.Value = (Decimal)0.00;
                     TARI_Profit1.Value = (Decimal)0.00;
                     TARI_Profit2.Value = (Decimal)0.00;
                     TARI_Profit3.Value = (Decimal)0.00;
                     TARI_Profit4.Value = (Decimal)0.00;

                     TARI_Costo.Text = "0.00";
                     TARI_Profit1.Text = "0.00";
                     TARI_Profit2.Text = "0.00";
                     TARI_Profit3.Text = "0.00";
                     TARI_Profit4.Text = "0.00";
                  }
                  else
                  { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeInformacion(Presenter.Title, "Ha Ocurrido un error aplicadando el cambio."); }
               }
            }
         }
         catch (Exception)
         { throw; }

      }
      #endregion

      #region [ Eventos ]
      private void btnImportar_Click(object sender, EventArgs e)
      { Importar(); }
      private void btnGuardar_Click(object sender, EventArgs e)
      {
         try
         {
            Entities.Tipos ItemTipoMND = TIPO_CodMnd.TiposSelectedItem;
            Entities.Paquete ItemPaquete = (PACK_Codigo.ComboSelectedItem != null && PACK_Codigo.ComboSelectedItem.IntCodigo.HasValue) ? Presenter.ListPaquetes.Where(pack => pack.PACK_Codigo == PACK_Codigo.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null;
            Entities.Tipos ItemTipoPAIOrigen = TIPO_CodPAIOrigen.TiposSelectedItem;
            Entities.Puerto ItemPuertoOrigen = (PUER_CodOrigen.ComboSelectedItem != null && PUER_CodOrigen.ComboSelectedItem.IntCodigo.HasValue) ? Presenter.ListPuertos.Where(pack => pack.PUER_Codigo == PUER_CodOrigen.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null;
            Entities.Tipos ItemTipoPAIDestino = TIPO_CodPAIDestino.TiposSelectedItem;
            Entities.Puerto ItemPUertoDestino = (PUER_CodDestino.ComboSelectedItem != null && PUER_CodDestino.ComboSelectedItem.IntCodigo.HasValue) ? Presenter.ListPuertos.Where(pack => pack.PUER_Codigo == PUER_CodDestino.ComboSelectedItem.IntCodigo.Value).FirstOrDefault() : null;

            if (Presenter.Guardar(true, false))
            {
               //this.FormClosing -= MView_FormClosing;
               //errorProvider1.Dispose();
               ////Presenter.Actualizar();
               //this.Close();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al guardar el formulario.", ex); }
      }
      private void btnGuardaryCerrar_Click(object sender, EventArgs e)
      {
         try
         {
            if (Presenter.Guardar(true, true))
            {
               this.FormClosing -= MView_FormClosing;
               errorProvider1.Dispose();
               this.Close();
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
            errorProvider1.Dispose();
            if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario) || Presenter.EsCopia)
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
      private void btnCopiar_Click(object sender, EventArgs e)
      {
         Copiar();
      }

      private void btnCargar_Click(object sender, EventArgs e)
      { LoadTarifas(); }
      private void btnLimpiar_Click(object sender, EventArgs e)
      { LimpiarTarifas(); }

      private void CONS_CodRGM_SelectedIndexChanged(object sender, EventArgs e)
      { ConfigurarPuertos(); }
      private void TIPO_CodPAI_SelectedIndexChanged(object sender, EventArgs e)
      { LoadPuertos(); }
      private void TIPO_CodPAIOrigen_SelectedIndexChanged(object sender, EventArgs e)
      { LoadPuertosOrigen(); }
      private void TIPO_CodPAIDestino_SelectedIndexChanged(object sender, EventArgs e)
      { LoadPuertosDestino(); }

      Int32 rowIndex = -1;
      Int32 colIndex = -1;
      private void grdItems_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         try
         {
            rowIndex = (this.grdItems.CurrentCell != null) ? this.grdItems.CurrentCell.RowIndex : -1;
            colIndex = (this.grdItems.CurrentCell != null) ? this.grdItems.CurrentCell.ColumnIndex : -1;

            if (rowIndex >= 0 && colIndex > 0)
            {
               EditTarifa();
               this.grdItems.EndEdit();
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      Telerik.WinControls.UI.GridSpinEditorElement element;
      private void grdItems_CellEditorInitialized(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
      {
         try
         {
            Telerik.WinControls.UI.GridSpinEditor editor = e.ActiveEditor as Telerik.WinControls.UI.GridSpinEditor;
            if (editor != null)
            {

               ((Telerik.WinControls.UI.GridSpinEditorElement)editor.EditorElement).ShowUpDownButtons = false;

               element = editor.EditorElement as Telerik.WinControls.UI.GridSpinEditorElement;
               element.TextBoxItem.HostedControl.DoubleClick += new EventHandler(HostedControl_DoubleClick);
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }
      private void HostedControl_DoubleClick(object sender, EventArgs e)
      {
         try
         {
            if (element != null)
            {
               element.TextBoxItem.HostedControl.DoubleClick -= HostedControl_DoubleClick;
               element = null;

               rowIndex = (this.grdItems.CurrentCell != null) ? this.grdItems.CurrentCell.RowIndex : -1;
               colIndex = (this.grdItems.CurrentCell != null) ? this.grdItems.CurrentCell.ColumnIndex : -1;

               if (rowIndex >= 0 && colIndex > 0)
               {
                  EditTarifa();
                  this.grdItems.EndEdit();
               }
            }
         }
         catch (Exception ex)
         { Infrastructure.WinForms.Controls.Dialogos.MostrarMensajeError(Presenter.Title, "Ha ocurrido un error al seleccionar el item.", ex); }
      }

      private void MView_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if (Closing != true)
            {
               this.FormClosing -= MView_FormClosing;
               if (Infrastructure.Client.FormClose.FormValidateChanges.verificarCambioFormulario(this, HashFormulario) || Presenter.EsCopia)
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
      private void btnAuditoriaContrato_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCONT_Codigo", FilterValue = Presenter.Item.CONT_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_COM_Contrato, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }
      private void btnAuditoriaTarifario_Click(object sender, EventArgs e)
      {
         try
         {
            ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL> _filters = new ObservableCollection<Infrastructure.Aspect.DataAccess.DataAccessFilterSQL>();
            _filters.Add(new Infrastructure.Aspect.DataAccess.DataAccessFilterSQL() { FilterName = "@pintCONT_Codigo", FilterValue = Presenter.Item.CONT_Codigo, FilterType = Infrastructure.Aspect.DataAccess.DataAccessFilterTypes.Int32, FilterSize = 4 });

            Delfin.Controls.AuditoriaView _auditoriaView = new Controls.AuditoriaView(Presenter.ContainerService, Delfin.Controls.TipoAuditoria.AUDI_COM_Tarifa, _filters);
            _auditoriaView.Show();
         }
         catch (Exception)
         { }
      }
      #endregion

   }
}

