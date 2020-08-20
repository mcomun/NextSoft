namespace Delfin.Principal
{
   partial class OPE010View
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.components = new System.ComponentModel.Container();
            this.errorProviderCab_Cotizacion_OV = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mdtREBA_FecFinTarifa = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblREBA_FecFinTarifa = new System.Windows.Forms.Label();
            this.mdtREBA_FecIniTarifa = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblREBA_FecIniTarifa = new System.Windows.Forms.Label();
            this.cmbREBA_Tipo = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.lblREBA_Tipo = new System.Windows.Forms.Label();
            this.lblHBL = new System.Windows.Forms.Label();
            this.txtNroHBL = new System.Windows.Forms.TextBox();
            this.lblOV = new System.Windows.Forms.Label();
            this.txtNroOV = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.ayudaENTC_CodCliente = new Delfin.Controls.Entidad(this.components);
            this.lblFechaIniLlegada = new System.Windows.Forms.Label();
            this.mdtNVIA_FechaIniLlegada = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblFechaFinLlegada = new System.Windows.Forms.Label();
            this.mdtNVIA_FechaFinLlegada = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblFechaIniEmbarque = new System.Windows.Forms.Label();
            this.mdtNVIA_FechaIniEmbarque = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblFechaFinEmbarque = new System.Windows.Forms.Label();
            this.mdtNVIA_FechaFinEmbarque = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblENTC_CodTransportista = new System.Windows.Forms.Label();
            this.ayudaENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
            this.maskDateTime1 = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProviderCab_Cotizacion_OV
            // 
            this.errorProviderCab_Cotizacion_OV.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderCab_Cotizacion_OV.ContainerControl = this;
            // 
            // errorProviderDet_Cotizacion_OV_Novedad
            // 
            this.errorProviderDet_Cotizacion_OV_Novedad.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderDet_Cotizacion_OV_Novedad.ContainerControl = this;
            // 
            // errorEventoTarea
            // 
            this.errorEventoTarea.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorEventoTarea.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnCalcular);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = true;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Image = global::Delfin.Principal.Properties.Resources.undo;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(60, 0);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(55, 50);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCalcular
            // 
            this.btnCalcular.AutoSize = true;
            this.btnCalcular.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCalcular.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcular.ForeColor = System.Drawing.Color.Black;
            this.btnCalcular.Image = global::Delfin.Principal.Properties.Resources.replace21;
            this.btnCalcular.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCalcular.Location = new System.Drawing.Point(0, 0);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(0);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(60, 50);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular ";
            this.btnCalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCalcular.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.mdtREBA_FecFinTarifa, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblREBA_FecFinTarifa, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.mdtREBA_FecIniTarifa, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblREBA_FecIniTarifa, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbREBA_Tipo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblREBA_Tipo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblHBL, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtNroHBL, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblOV, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtNroOV, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblCliente, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ayudaENTC_CodCliente, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaIniLlegada, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaIniLlegada, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaFinLlegada, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaFinLlegada, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaIniEmbarque, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaIniEmbarque, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaFinEmbarque, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.mdtNVIA_FechaFinEmbarque, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblENTC_CodTransportista, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ayudaENTC_CodTransportista, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 189);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // mdtREBA_FecFinTarifa
            // 
            this.mdtREBA_FecFinTarifa.Location = new System.Drawing.Point(518, 111);
            this.mdtREBA_FecFinTarifa.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtREBA_FecFinTarifa.Name = "mdtREBA_FecFinTarifa";
            this.mdtREBA_FecFinTarifa.NSActiveMouse = false;
            this.mdtREBA_FecFinTarifa.NSActiveMsgFecha = false;
            this.mdtREBA_FecFinTarifa.NSChangeDate = true;
            this.mdtREBA_FecFinTarifa.NSDigitos = 4;
            this.mdtREBA_FecFinTarifa.NSFecha = null;
            this.mdtREBA_FecFinTarifa.NSSetDateNow = false;
            this.mdtREBA_FecFinTarifa.Size = new System.Drawing.Size(144, 22);
            this.mdtREBA_FecFinTarifa.TabIndex = 15;
            // 
            // lblREBA_FecFinTarifa
            // 
            this.lblREBA_FecFinTarifa.AutoSize = true;
            this.lblREBA_FecFinTarifa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_FecFinTarifa.Location = new System.Drawing.Point(375, 115);
            this.lblREBA_FecFinTarifa.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_FecFinTarifa.Name = "lblREBA_FecFinTarifa";
            this.lblREBA_FecFinTarifa.Size = new System.Drawing.Size(105, 13);
            this.lblREBA_FecFinTarifa.TabIndex = 14;
            this.lblREBA_FecFinTarifa.Text = "Fecha Fin Tarifa :";
            // 
            // mdtREBA_FecIniTarifa
            // 
            this.mdtREBA_FecIniTarifa.Location = new System.Drawing.Point(153, 111);
            this.mdtREBA_FecIniTarifa.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtREBA_FecIniTarifa.Name = "mdtREBA_FecIniTarifa";
            this.mdtREBA_FecIniTarifa.NSActiveMouse = false;
            this.mdtREBA_FecIniTarifa.NSActiveMsgFecha = false;
            this.mdtREBA_FecIniTarifa.NSChangeDate = true;
            this.mdtREBA_FecIniTarifa.NSDigitos = 4;
            this.mdtREBA_FecIniTarifa.NSFecha = null;
            this.mdtREBA_FecIniTarifa.NSSetDateNow = false;
            this.mdtREBA_FecIniTarifa.Size = new System.Drawing.Size(144, 22);
            this.mdtREBA_FecIniTarifa.TabIndex = 13;
            // 
            // lblREBA_FecIniTarifa
            // 
            this.lblREBA_FecIniTarifa.AutoSize = true;
            this.lblREBA_FecIniTarifa.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_FecIniTarifa.Location = new System.Drawing.Point(10, 115);
            this.lblREBA_FecIniTarifa.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_FecIniTarifa.Name = "lblREBA_FecIniTarifa";
            this.lblREBA_FecIniTarifa.Size = new System.Drawing.Size(116, 13);
            this.lblREBA_FecIniTarifa.TabIndex = 12;
            this.lblREBA_FecIniTarifa.Text = "Fecha Inicio Tarifa:";
            // 
            // cmbREBA_Tipo
            // 
            this.cmbREBA_Tipo.ComboIntSelectedValue = null;
            this.cmbREBA_Tipo.ComboSelectedItem = null;
            this.cmbREBA_Tipo.ComboStrSelectedValue = null;
            this.cmbREBA_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbREBA_Tipo.FormattingEnabled = true;
            this.cmbREBA_Tipo.Location = new System.Drawing.Point(153, 3);
            this.cmbREBA_Tipo.Name = "cmbREBA_Tipo";
            this.cmbREBA_Tipo.Size = new System.Drawing.Size(194, 21);
            this.cmbREBA_Tipo.TabIndex = 1;
            this.cmbREBA_Tipo.Tag = "REBA_TipoMSGERROR";
            // 
            // lblREBA_Tipo
            // 
            this.lblREBA_Tipo.AutoSize = true;
            this.lblREBA_Tipo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblREBA_Tipo.Location = new System.Drawing.Point(10, 7);
            this.lblREBA_Tipo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblREBA_Tipo.Name = "lblREBA_Tipo";
            this.lblREBA_Tipo.Size = new System.Drawing.Size(39, 13);
            this.lblREBA_Tipo.TabIndex = 0;
            this.lblREBA_Tipo.Text = "Tipo:";
            // 
            // lblHBL
            // 
            this.lblHBL.AutoSize = true;
            this.lblHBL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHBL.Location = new System.Drawing.Point(10, 169);
            this.lblHBL.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblHBL.Name = "lblHBL";
            this.lblHBL.Size = new System.Drawing.Size(34, 13);
            this.lblHBL.TabIndex = 18;
            this.lblHBL.Text = "HBL:";
            // 
            // txtNroHBL
            // 
            this.txtNroHBL.Location = new System.Drawing.Point(153, 165);
            this.txtNroHBL.Name = "txtNroHBL";
            this.txtNroHBL.Size = new System.Drawing.Size(194, 20);
            this.txtNroHBL.TabIndex = 19;
            // 
            // lblOV
            // 
            this.lblOV.AutoSize = true;
            this.lblOV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOV.Location = new System.Drawing.Point(375, 169);
            this.lblOV.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblOV.Name = "lblOV";
            this.lblOV.Size = new System.Drawing.Size(73, 13);
            this.lblOV.TabIndex = 20;
            this.lblOV.Text = "Numero OV";
            // 
            // txtNroOV
            // 
            this.txtNroOV.Location = new System.Drawing.Point(518, 165);
            this.txtNroOV.Name = "txtNroOV";
            this.txtNroOV.Size = new System.Drawing.Size(194, 20);
            this.txtNroOV.TabIndex = 21;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(10, 142);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(52, 13);
            this.lblCliente.TabIndex = 16;
            this.lblCliente.Text = "Cliente:";
            // 
            // ayudaENTC_CodCliente
            // 
            this.ayudaENTC_CodCliente.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ayudaENTC_CodCliente, 4);
            this.ayudaENTC_CodCliente.ContainerService = null;
            this.ayudaENTC_CodCliente.EnabledAyudaButton = true;
            this.ayudaENTC_CodCliente.Location = new System.Drawing.Point(153, 138);
            this.ayudaENTC_CodCliente.LongitudAceptada = 0;
            this.ayudaENTC_CodCliente.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ayudaENTC_CodCliente.Name = "ayudaENTC_CodCliente";
            this.ayudaENTC_CodCliente.RellenaCeros = false;
            this.ayudaENTC_CodCliente.Size = new System.Drawing.Size(559, 20);
            this.ayudaENTC_CodCliente.TabIndex = 17;
            this.ayudaENTC_CodCliente.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ayudaENTC_CodCliente.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Cliente;
            this.ayudaENTC_CodCliente.UsarTipoEntidad = true;
            this.ayudaENTC_CodCliente.Value = null;
            // 
            // lblFechaIniLlegada
            // 
            this.lblFechaIniLlegada.AutoSize = true;
            this.lblFechaIniLlegada.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIniLlegada.Location = new System.Drawing.Point(10, 88);
            this.lblFechaIniLlegada.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaIniLlegada.Name = "lblFechaIniLlegada";
            this.lblFechaIniLlegada.Size = new System.Drawing.Size(105, 13);
            this.lblFechaIniLlegada.TabIndex = 8;
            this.lblFechaIniLlegada.Text = "Fecha Inicio ETA:";
            // 
            // mdtNVIA_FechaIniLlegada
            // 
            this.mdtNVIA_FechaIniLlegada.Location = new System.Drawing.Point(153, 84);
            this.mdtNVIA_FechaIniLlegada.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaIniLlegada.Name = "mdtNVIA_FechaIniLlegada";
            this.mdtNVIA_FechaIniLlegada.NSActiveMouse = false;
            this.mdtNVIA_FechaIniLlegada.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaIniLlegada.NSChangeDate = true;
            this.mdtNVIA_FechaIniLlegada.NSDigitos = 4;
            this.mdtNVIA_FechaIniLlegada.NSFecha = null;
            this.mdtNVIA_FechaIniLlegada.NSSetDateNow = false;
            this.mdtNVIA_FechaIniLlegada.Size = new System.Drawing.Size(144, 22);
            this.mdtNVIA_FechaIniLlegada.TabIndex = 9;
            // 
            // lblFechaFinLlegada
            // 
            this.lblFechaFinLlegada.AutoSize = true;
            this.lblFechaFinLlegada.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinLlegada.Location = new System.Drawing.Point(375, 88);
            this.lblFechaFinLlegada.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaFinLlegada.Name = "lblFechaFinLlegada";
            this.lblFechaFinLlegada.Size = new System.Drawing.Size(94, 13);
            this.lblFechaFinLlegada.TabIndex = 10;
            this.lblFechaFinLlegada.Text = "Fecha Fin ETA :";
            // 
            // mdtNVIA_FechaFinLlegada
            // 
            this.mdtNVIA_FechaFinLlegada.Location = new System.Drawing.Point(518, 84);
            this.mdtNVIA_FechaFinLlegada.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaFinLlegada.Name = "mdtNVIA_FechaFinLlegada";
            this.mdtNVIA_FechaFinLlegada.NSActiveMouse = false;
            this.mdtNVIA_FechaFinLlegada.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaFinLlegada.NSChangeDate = true;
            this.mdtNVIA_FechaFinLlegada.NSDigitos = 4;
            this.mdtNVIA_FechaFinLlegada.NSFecha = null;
            this.mdtNVIA_FechaFinLlegada.NSSetDateNow = false;
            this.mdtNVIA_FechaFinLlegada.Size = new System.Drawing.Size(144, 22);
            this.mdtNVIA_FechaFinLlegada.TabIndex = 11;
            // 
            // lblFechaIniEmbarque
            // 
            this.lblFechaIniEmbarque.AutoSize = true;
            this.lblFechaIniEmbarque.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIniEmbarque.Location = new System.Drawing.Point(10, 61);
            this.lblFechaIniEmbarque.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaIniEmbarque.Name = "lblFechaIniEmbarque";
            this.lblFechaIniEmbarque.Size = new System.Drawing.Size(136, 12);
            this.lblFechaIniEmbarque.TabIndex = 4;
            this.lblFechaIniEmbarque.Text = "Fecha Inicio Embarque:";
            // 
            // mdtNVIA_FechaIniEmbarque
            // 
            this.mdtNVIA_FechaIniEmbarque.Location = new System.Drawing.Point(153, 57);
            this.mdtNVIA_FechaIniEmbarque.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaIniEmbarque.Name = "mdtNVIA_FechaIniEmbarque";
            this.mdtNVIA_FechaIniEmbarque.NSActiveMouse = false;
            this.mdtNVIA_FechaIniEmbarque.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaIniEmbarque.NSChangeDate = true;
            this.mdtNVIA_FechaIniEmbarque.NSDigitos = 4;
            this.mdtNVIA_FechaIniEmbarque.NSFecha = null;
            this.mdtNVIA_FechaIniEmbarque.NSSetDateNow = false;
            this.mdtNVIA_FechaIniEmbarque.Size = new System.Drawing.Size(144, 22);
            this.mdtNVIA_FechaIniEmbarque.TabIndex = 5;
            // 
            // lblFechaFinEmbarque
            // 
            this.lblFechaFinEmbarque.AutoSize = true;
            this.lblFechaFinEmbarque.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinEmbarque.Location = new System.Drawing.Point(375, 61);
            this.lblFechaFinEmbarque.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFechaFinEmbarque.Name = "lblFechaFinEmbarque";
            this.lblFechaFinEmbarque.Size = new System.Drawing.Size(131, 13);
            this.lblFechaFinEmbarque.TabIndex = 6;
            this.lblFechaFinEmbarque.Text = "Fecha Fin Embarque :";
            // 
            // mdtNVIA_FechaFinEmbarque
            // 
            this.mdtNVIA_FechaFinEmbarque.Location = new System.Drawing.Point(518, 57);
            this.mdtNVIA_FechaFinEmbarque.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FechaFinEmbarque.Name = "mdtNVIA_FechaFinEmbarque";
            this.mdtNVIA_FechaFinEmbarque.NSActiveMouse = false;
            this.mdtNVIA_FechaFinEmbarque.NSActiveMsgFecha = false;
            this.mdtNVIA_FechaFinEmbarque.NSChangeDate = true;
            this.mdtNVIA_FechaFinEmbarque.NSDigitos = 4;
            this.mdtNVIA_FechaFinEmbarque.NSFecha = null;
            this.mdtNVIA_FechaFinEmbarque.NSSetDateNow = false;
            this.mdtNVIA_FechaFinEmbarque.Size = new System.Drawing.Size(144, 22);
            this.mdtNVIA_FechaFinEmbarque.TabIndex = 7;
            // 
            // lblENTC_CodTransportista
            // 
            this.lblENTC_CodTransportista.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodTransportista.Location = new System.Drawing.Point(10, 34);
            this.lblENTC_CodTransportista.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblENTC_CodTransportista.Name = "lblENTC_CodTransportista";
            this.lblENTC_CodTransportista.Size = new System.Drawing.Size(102, 17);
            this.lblENTC_CodTransportista.TabIndex = 2;
            this.lblENTC_CodTransportista.Text = "Transportista:";
            // 
            // ayudaENTC_CodTransportista
            // 
            this.ayudaENTC_CodTransportista.ActivarAyudaAuto = false;
            this.tableLayoutPanel1.SetColumnSpan(this.ayudaENTC_CodTransportista, 4);
            this.ayudaENTC_CodTransportista.ContainerService = null;
            this.ayudaENTC_CodTransportista.EnabledAyudaButton = true;
            this.ayudaENTC_CodTransportista.Location = new System.Drawing.Point(153, 30);
            this.ayudaENTC_CodTransportista.LongitudAceptada = 0;
            this.ayudaENTC_CodTransportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ayudaENTC_CodTransportista.Name = "ayudaENTC_CodTransportista";
            this.ayudaENTC_CodTransportista.RellenaCeros = false;
            this.ayudaENTC_CodTransportista.Size = new System.Drawing.Size(559, 20);
            this.ayudaENTC_CodTransportista.TabIndex = 3;
            this.ayudaENTC_CodTransportista.Tag = "ENTC_CodTransportistaMSGERROR";
            this.ayudaENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ayudaENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.ayudaENTC_CodTransportista.UsarTipoEntidad = true;
            this.ayudaENTC_CodTransportista.Value = null;
            // 
            // maskDateTime1
            // 
            this.maskDateTime1.Location = new System.Drawing.Point(153, 111);
            this.maskDateTime1.MinimumSize = new System.Drawing.Size(100, 22);
            this.maskDateTime1.Name = "maskDateTime1";
            this.maskDateTime1.NSActiveMouse = false;
            this.maskDateTime1.NSActiveMsgFecha = false;
            this.maskDateTime1.NSChangeDate = true;
            this.maskDateTime1.NSDigitos = 4;
            this.maskDateTime1.NSFecha = null;
            this.maskDateTime1.NSSetDateNow = false;
            this.maskDateTime1.Size = new System.Drawing.Size(144, 22);
            this.maskDateTime1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(375, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha Fin Tarifa :";
            // 
            // OPE010View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(744, 241);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OPE010View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calcular Rebate\\GRR";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCab_Cotizacion_OV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.ErrorProvider errorProviderCab_Cotizacion_OV;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnCalcular;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaIniEmbarque;
      private System.Windows.Forms.Label lblFechaFinEmbarque;
      private System.Windows.Forms.Label lblFechaIniEmbarque;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaFinEmbarque;
      private System.Windows.Forms.Label lblCliente;
      private System.Windows.Forms.Label lblFechaIniLlegada;
      private System.Windows.Forms.Label lblFechaFinLlegada;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaIniLlegada;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FechaFinLlegada;
      private System.Windows.Forms.TextBox txtNroHBL;
      private System.Windows.Forms.TextBox txtNroOV;
      private System.Windows.Forms.Label lblOV;
      private System.Windows.Forms.Label lblHBL;
      private Controls.Entidad ayudaENTC_CodCliente;
      private Controls.Entidad ayudaENTC_CodTransportista;
      private System.Windows.Forms.Label lblENTC_CodTransportista;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox cmbREBA_Tipo;
      private System.Windows.Forms.Label lblREBA_Tipo;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtREBA_FecFinTarifa;
      private System.Windows.Forms.Label lblREBA_FecFinTarifa;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtREBA_FecIniTarifa;
      private System.Windows.Forms.Label lblREBA_FecIniTarifa;
      private Infrastructure.WinForms.Controls.MaskDateTime maskDateTime1;
      private System.Windows.Forms.Label label2;
   }
}