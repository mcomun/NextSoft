namespace Delfin.Principal
{
    partial class MAN011MView
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
            this.lblNVIA_Codigo = new System.Windows.Forms.Label();
            this.lblNVIA_NroViaje = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnMAN_guardar = new System.Windows.Forms.ToolStripButton();
            this.btnMAN_salir = new System.Windows.Forms.ToolStripButton();
            this.btnPreFacturar = new System.Windows.Forms.ToolStripButton();
            this.btnEmiti_Statement = new System.Windows.Forms.ToolStripButton();
            this.btnAprobarStatement = new System.Windows.Forms.ToolStripButton();
            this.btnAbrirStatement = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar_Nave = new System.Windows.Forms.ToolStripButton();
            this.btnArchivos = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnDireccionamiento = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_VoBo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEmail = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnEmailAlmacen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelacionRecalada = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDemoraArribo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEmitir_BL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAvisosLlegada = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCargaTarjadaLCL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCargaTarjadaFCL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAuditoriaNaveViaje = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableNaveViaje = new System.Windows.Forms.TableLayoutPanel();
            this.lblCONS_CodRGM = new System.Windows.Forms.Label();
            this.CONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblNVIA_FecCutOff_EXPO = new System.Windows.Forms.Label();
            this.NVIA_FecETA_IMPO_ETD_EXPO = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblNVIA_FecETA_IMPO_ETD_EXPO = new System.Windows.Forms.Label();
            this.lblENTC_CodAgentePort_EXPO = new System.Windows.Forms.Label();
            this.lblNVIA_FecDescarga_IMPO = new System.Windows.Forms.Label();
            this.NVIA_FecDescarga_IMPO = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblNVIA_NroManifiesto = new System.Windows.Forms.Label();
            this.lblNVIA_NroManifiestoDes_IMPO = new System.Windows.Forms.Label();
            this.lblENTC_CodTermPort = new System.Windows.Forms.Label();
            this.lblENTC_CodAgentePortVoBo_IMPO = new System.Windows.Forms.Label();
            this.lblENTC_CodAgentePortVoBo2_IMPO = new System.Windows.Forms.Label();
            this.ENTC_CodTermPort = new Delfin.Controls.Entidad(this.components);
            this.ENTC_CodAgentePortVoBo_IMPO = new Delfin.Controls.Entidad(this.components);
            this.ENTC_CodAgentePortVoBo2_IMPO = new Delfin.Controls.Entidad(this.components);
            this.lblNVIA_FecRecogerDocs = new System.Windows.Forms.Label();
            this.ENTC_FecRecogerDocs = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.UsrCrea = new System.Windows.Forms.TextBox();
            this.NVIA_UsrPreFactura = new System.Windows.Forms.TextBox();
            this.NVIA_UsrCierreNave = new System.Windows.Forms.TextBox();
            this.FecCrea = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.NVIA_FecPreFactura = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.NVIA_FecCierreNave = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblUsrCrea = new System.Windows.Forms.Label();
            this.lblNVIA_UsrPreFactura = new System.Windows.Forms.Label();
            this.lblNVIA_UsrCierreNave = new System.Windows.Forms.Label();
            this.lblFecCrea = new System.Windows.Forms.Label();
            this.lblNVIA_FecPreFactura = new System.Windows.Forms.Label();
            this.lblNVIA_FecCierreNave = new System.Windows.Forms.Label();
            this.lblNVIA_FecLlega_IMPO_Zarpe_EXPO = new System.Windows.Forms.Label();
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO = new System.Windows.Forms.Label();
            this.ENTC_CodAgentePort_EXPO = new Delfin.Controls.Entidad(this.components);
            this.lblPUER_Codigo = new System.Windows.Forms.Label();
            this.ayudaPUER_Codigo = new Delfin.Controls.AyudaPuerto();
            this.lblNAVE_Codigo = new System.Windows.Forms.Label();
            this.NAVE_Codigo = new System.Windows.Forms.ComboBox();
            this.ENTC_CodTransportista = new Delfin.Controls.Entidad(this.components);
            this.lblENTC_CodTransportista = new System.Windows.Forms.Label();
            this.lblCONS_CodVia = new System.Windows.Forms.Label();
            this.CONS_CodVIA = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.NVIA_Codigo = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.lblTIPO_CodTRF = new System.Windows.Forms.Label();
            this.NVIA_NroViaje = new System.Windows.Forms.TextBox();
            this.TIPO_CodTRF = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNVIA_Estado = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.NVIA_NroManifiesto = new Delfin.Controls.NumeroManifiesto();
            this.NVIA_NroManifiestoDes_IMPO = new Delfin.Controls.NumeroManifiesto();
            this.lblNVIA_UsrEmiteStatment = new System.Windows.Forms.Label();
            this.lblNVIA_FecEmiteStatment = new System.Windows.Forms.Label();
            this.txtNVIA_UsrEmiteStatment = new System.Windows.Forms.TextBox();
            this.mdtNVIA_FecEmiteStatment = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.NVIA_FecCutOff_EXPO = new Infrastructure.WinForms.Controls.MaskTime();
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO = new Infrastructure.WinForms.Controls.MaskTime();
            this.btnEditarDetalle = new System.Windows.Forms.Button();
            this.btnNuevoDetalle = new System.Windows.Forms.Button();
            this.grdItemsDetalle = new Telerik.WinControls.UI.RadGridView();
            this.tableDetalle = new System.Windows.Forms.TableLayoutPanel();
            this.lblTIPO_CodPAIDetalle = new System.Windows.Forms.Label();
            this.lblDVIA_FecETA_EXPO_ETDMaster_IMPO = new System.Windows.Forms.Label();
            this.lblPUER_CodigoDetalle = new System.Windows.Forms.Label();
            this.TIPO_CodPAIDetalle = new Delfin.Controls.Tipos.ComboBoxTipos();
            this.PUER_CodigoDetalle = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.btnGuardarDetalle = new System.Windows.Forms.Button();
            this.btnEliminarDetalle = new System.Windows.Forms.Button();
            this.btnDeshacerDetalle = new System.Windows.Forms.Button();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAuditoriaDetNaveViaje = new System.Windows.Forms.Button();
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkChangeControl = new System.Windows.Forms.CheckBox();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.label2 = new System.Windows.Forms.Label();
            this.NVIA_FecPlazoVistoBueno = new Infrastructure.WinForms.Controls.MaskTime();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableNaveViaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle.MasterTemplate)).BeginInit();
            this.tableDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNVIA_Codigo
            // 
            this.lblNVIA_Codigo.AutoSize = true;
            this.lblNVIA_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_Codigo.Location = new System.Drawing.Point(10, 7);
            this.lblNVIA_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_Codigo.Name = "lblNVIA_Codigo";
            this.lblNVIA_Codigo.Size = new System.Drawing.Size(55, 13);
            this.lblNVIA_Codigo.TabIndex = 4;
            this.lblNVIA_Codigo.Text = "Codigo:";
            // 
            // lblNVIA_NroViaje
            // 
            this.lblNVIA_NroViaje.AutoSize = true;
            this.lblNVIA_NroViaje.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_NroViaje.Location = new System.Drawing.Point(375, 115);
            this.lblNVIA_NroViaje.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_NroViaje.Name = "lblNVIA_NroViaje";
            this.lblNVIA_NroViaje.Size = new System.Drawing.Size(71, 13);
            this.lblNVIA_NroViaje.TabIndex = 6;
            this.lblNVIA_NroViaje.Text = "Nro Viaje:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(739, 35);
            this.panel3.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMAN_guardar,
            this.btnMAN_salir,
            this.btnPreFacturar,
            this.btnEmiti_Statement,
            this.btnAprobarStatement,
            this.btnAbrirStatement,
            this.btnCerrar_Nave,
            this.btnArchivos,
            this.btnEmail,
            this.btnAuditoriaNaveViaje});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(739, 38);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnMAN_guardar
            // 
            this.btnMAN_guardar.Image = global::Delfin.Principal.Properties.Resources.save;
            this.btnMAN_guardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMAN_guardar.Name = "btnMAN_guardar";
            this.btnMAN_guardar.Size = new System.Drawing.Size(53, 35);
            this.btnMAN_guardar.Text = "Guardar";
            this.btnMAN_guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnMAN_salir
            // 
            this.btnMAN_salir.Image = global::Delfin.Principal.Properties.Resources.undo;
            this.btnMAN_salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMAN_salir.Name = "btnMAN_salir";
            this.btnMAN_salir.Size = new System.Drawing.Size(33, 35);
            this.btnMAN_salir.Text = "Salir";
            this.btnMAN_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMAN_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnPreFacturar
            // 
            this.btnPreFacturar.Image = global::Delfin.Principal.Properties.Resources.money2;
            this.btnPreFacturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreFacturar.Name = "btnPreFacturar";
            this.btnPreFacturar.Size = new System.Drawing.Size(69, 35);
            this.btnPreFacturar.Text = "Prefacturar";
            this.btnPreFacturar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPreFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPreFacturar.Visible = false;
            // 
            // btnEmiti_Statement
            // 
            this.btnEmiti_Statement.Image = global::Delfin.Principal.Properties.Resources.contract;
            this.btnEmiti_Statement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmiti_Statement.Name = "btnEmiti_Statement";
            this.btnEmiti_Statement.Size = new System.Drawing.Size(99, 35);
            this.btnEmiti_Statement.Text = "&Emitir Statement";
            this.btnEmiti_Statement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmiti_Statement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnAprobarStatement
            // 
            this.btnAprobarStatement.Image = global::Delfin.Principal.Properties.Resources.check;
            this.btnAprobarStatement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAprobarStatement.Name = "btnAprobarStatement";
            this.btnAprobarStatement.Size = new System.Drawing.Size(111, 35);
            this.btnAprobarStatement.Text = "&Aprobar Statement";
            this.btnAprobarStatement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAprobarStatement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnAbrirStatement
            // 
            this.btnAbrirStatement.Image = global::Delfin.Principal.Properties.Resources.abrir;
            this.btnAbrirStatement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrirStatement.Name = "btnAbrirStatement";
            this.btnAbrirStatement.Size = new System.Drawing.Size(94, 35);
            this.btnAbrirStatement.Text = "&Abrir Statement";
            this.btnAbrirStatement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAbrirStatement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnCerrar_Nave
            // 
            this.btnCerrar_Nave.Image = global::Delfin.Principal.Properties.Resources.forbidden;
            this.btnCerrar_Nave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrar_Nave.Name = "btnCerrar_Nave";
            this.btnCerrar_Nave.Size = new System.Drawing.Size(73, 35);
            this.btnCerrar_Nave.Text = "Cerrar Nave";
            this.btnCerrar_Nave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCerrar_Nave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnArchivos
            // 
            this.btnArchivos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDireccionamiento,
            this.btn_VoBo});
            this.btnArchivos.Image = global::Delfin.Principal.Properties.Resources.document_into;
            this.btnArchivos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArchivos.Name = "btnArchivos";
            this.btnArchivos.Size = new System.Drawing.Size(66, 35);
            this.btnArchivos.Text = "Archivos";
            this.btnArchivos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnArchivos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnDireccionamiento
            // 
            this.btnDireccionamiento.Name = "btnDireccionamiento";
            this.btnDireccionamiento.Size = new System.Drawing.Size(214, 22);
            this.btnDireccionamiento.Text = "Direccionamiento";
            // 
            // btn_VoBo
            // 
            this.btn_VoBo.Name = "btn_VoBo";
            this.btn_VoBo.Size = new System.Drawing.Size(214, 22);
            this.btn_VoBo.Text = "Carta de Desglose de VoBo";
            // 
            // btnEmail
            // 
            this.btnEmail.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEmailAlmacen,
            this.btnCancelacionRecalada,
            this.btnDemoraArribo,
            this.btnEmitir_BL,
            this.btnAvisosLlegada,
            this.btnCargaTarjadaLCL,
            this.btnCargaTarjadaFCL});
            this.btnEmail.Image = global::Delfin.Principal.Properties.Resources.mail_forward;
            this.btnEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(57, 35);
            this.btnEmail.Text = "Email\'s";
            this.btnEmail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnEmailAlmacen
            // 
            this.btnEmailAlmacen.Name = "btnEmailAlmacen";
            this.btnEmailAlmacen.Size = new System.Drawing.Size(258, 22);
            this.btnEmailAlmacen.Text = "Email a los Almacenes";
            // 
            // btnCancelacionRecalada
            // 
            this.btnCancelacionRecalada.Name = "btnCancelacionRecalada";
            this.btnCancelacionRecalada.Size = new System.Drawing.Size(258, 22);
            this.btnCancelacionRecalada.Text = "Email por Cancelación de Recalada";
            // 
            // btnDemoraArribo
            // 
            this.btnDemoraArribo.Name = "btnDemoraArribo";
            this.btnDemoraArribo.Size = new System.Drawing.Size(258, 22);
            this.btnDemoraArribo.Text = "Email por Demora en Arribo ";
            // 
            // btnEmitir_BL
            // 
            this.btnEmitir_BL.Name = "btnEmitir_BL";
            this.btnEmitir_BL.Size = new System.Drawing.Size(258, 22);
            this.btnEmitir_BL.Text = "Emisión de HBL";
            this.btnEmitir_BL.Visible = false;
            // 
            // btnAvisosLlegada
            // 
            this.btnAvisosLlegada.Name = "btnAvisosLlegada";
            this.btnAvisosLlegada.Size = new System.Drawing.Size(258, 22);
            this.btnAvisosLlegada.Text = "Avisos de Llegada";
            // 
            // btnCargaTarjadaLCL
            // 
            this.btnCargaTarjadaLCL.Name = "btnCargaTarjadaLCL";
            this.btnCargaTarjadaLCL.Size = new System.Drawing.Size(258, 22);
            this.btnCargaTarjadaLCL.Text = "Carga Tarjada LCL";
            // 
            // btnCargaTarjadaFCL
            // 
            this.btnCargaTarjadaFCL.Name = "btnCargaTarjadaFCL";
            this.btnCargaTarjadaFCL.Size = new System.Drawing.Size(258, 22);
            this.btnCargaTarjadaFCL.Text = "Carga Tarjada  FCL";
            // 
            // btnAuditoriaNaveViaje
            // 
            this.btnAuditoriaNaveViaje.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAuditoriaNaveViaje.Image = global::Delfin.Principal.Properties.Resources.businessman_view;
            this.btnAuditoriaNaveViaje.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAuditoriaNaveViaje.Name = "btnAuditoriaNaveViaje";
            this.btnAuditoriaNaveViaje.Size = new System.Drawing.Size(60, 35);
            this.btnAuditoriaNaveViaje.Text = "Auditoria";
            this.btnAuditoriaNaveViaje.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAuditoriaNaveViaje.ToolTipText = "Auditoria Nave Viaje";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // tableNaveViaje
            // 
            this.tableNaveViaje.AutoSize = true;
            this.tableNaveViaje.ColumnCount = 7;
            this.tableNaveViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableNaveViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableNaveViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableNaveViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableNaveViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableNaveViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableNaveViaje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableNaveViaje.Controls.Add(this.lblCONS_CodRGM, 0, 3);
            this.tableNaveViaje.Controls.Add(this.CONS_CodRGM, 1, 3);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_FecCutOff_EXPO, 3, 5);
            this.tableNaveViaje.Controls.Add(this.NVIA_FecETA_IMPO_ETD_EXPO, 1, 5);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_FecETA_IMPO_ETD_EXPO, 0, 5);
            this.tableNaveViaje.Controls.Add(this.lblENTC_CodAgentePort_EXPO, 0, 10);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_FecDescarga_IMPO, 0, 7);
            this.tableNaveViaje.Controls.Add(this.NVIA_FecDescarga_IMPO, 1, 7);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_NroManifiesto, 0, 8);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_NroManifiestoDes_IMPO, 3, 8);
            this.tableNaveViaje.Controls.Add(this.lblENTC_CodTermPort, 0, 11);
            this.tableNaveViaje.Controls.Add(this.lblENTC_CodAgentePortVoBo_IMPO, 0, 12);
            this.tableNaveViaje.Controls.Add(this.lblENTC_CodAgentePortVoBo2_IMPO, 0, 13);
            this.tableNaveViaje.Controls.Add(this.ENTC_CodTermPort, 1, 11);
            this.tableNaveViaje.Controls.Add(this.ENTC_CodAgentePortVoBo_IMPO, 1, 12);
            this.tableNaveViaje.Controls.Add(this.ENTC_CodAgentePortVoBo2_IMPO, 1, 13);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_FecRecogerDocs, 3, 7);
            this.tableNaveViaje.Controls.Add(this.ENTC_FecRecogerDocs, 4, 7);
            this.tableNaveViaje.Controls.Add(this.UsrCrea, 1, 14);
            this.tableNaveViaje.Controls.Add(this.NVIA_UsrPreFactura, 1, 16);
            this.tableNaveViaje.Controls.Add(this.NVIA_UsrCierreNave, 1, 17);
            this.tableNaveViaje.Controls.Add(this.FecCrea, 4, 14);
            this.tableNaveViaje.Controls.Add(this.NVIA_FecPreFactura, 4, 16);
            this.tableNaveViaje.Controls.Add(this.NVIA_FecCierreNave, 4, 17);
            this.tableNaveViaje.Controls.Add(this.lblUsrCrea, 0, 14);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_UsrPreFactura, 0, 16);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_UsrCierreNave, 0, 17);
            this.tableNaveViaje.Controls.Add(this.lblFecCrea, 3, 14);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_FecPreFactura, 3, 16);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_FecCierreNave, 3, 17);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_FecLlega_IMPO_Zarpe_EXPO, 0, 6);
            this.tableNaveViaje.Controls.Add(this.NVIA_FecLlega_IMPO_Zarpe_EXPO, 1, 6);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO, 3, 6);
            this.tableNaveViaje.Controls.Add(this.ENTC_CodAgentePort_EXPO, 1, 10);
            this.tableNaveViaje.Controls.Add(this.lblPUER_Codigo, 0, 4);
            this.tableNaveViaje.Controls.Add(this.ayudaPUER_Codigo, 1, 4);
            this.tableNaveViaje.Controls.Add(this.lblNAVE_Codigo, 3, 2);
            this.tableNaveViaje.Controls.Add(this.NAVE_Codigo, 4, 2);
            this.tableNaveViaje.Controls.Add(this.ENTC_CodTransportista, 1, 1);
            this.tableNaveViaje.Controls.Add(this.lblENTC_CodTransportista, 0, 1);
            this.tableNaveViaje.Controls.Add(this.lblCONS_CodVia, 0, 2);
            this.tableNaveViaje.Controls.Add(this.CONS_CodVIA, 1, 2);
            this.tableNaveViaje.Controls.Add(this.NVIA_Codigo, 1, 0);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_NroViaje, 3, 4);
            this.tableNaveViaje.Controls.Add(this.lblTIPO_CodTRF, 3, 3);
            this.tableNaveViaje.Controls.Add(this.NVIA_NroViaje, 4, 4);
            this.tableNaveViaje.Controls.Add(this.TIPO_CodTRF, 4, 3);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_Codigo, 0, 0);
            this.tableNaveViaje.Controls.Add(this.label1, 3, 0);
            this.tableNaveViaje.Controls.Add(this.cmbNVIA_Estado, 4, 0);
            this.tableNaveViaje.Controls.Add(this.NVIA_NroManifiesto, 1, 8);
            this.tableNaveViaje.Controls.Add(this.NVIA_NroManifiestoDes_IMPO, 4, 8);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_UsrEmiteStatment, 0, 15);
            this.tableNaveViaje.Controls.Add(this.lblNVIA_FecEmiteStatment, 3, 15);
            this.tableNaveViaje.Controls.Add(this.txtNVIA_UsrEmiteStatment, 1, 15);
            this.tableNaveViaje.Controls.Add(this.mdtNVIA_FecEmiteStatment, 4, 15);
            this.tableNaveViaje.Controls.Add(this.NVIA_FecCutOff_EXPO, 4, 5);
            this.tableNaveViaje.Controls.Add(this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO, 4, 6);
            this.tableNaveViaje.Controls.Add(this.label2, 0, 9);
            this.tableNaveViaje.Controls.Add(this.NVIA_FecPlazoVistoBueno, 1, 9);
            this.tableNaveViaje.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableNaveViaje.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableNaveViaje.Location = new System.Drawing.Point(0, 61);
            this.tableNaveViaje.Name = "tableNaveViaje";
            this.tableNaveViaje.RowCount = 18;
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableNaveViaje.Size = new System.Drawing.Size(739, 486);
            this.tableNaveViaje.TabIndex = 2;
            // 
            // lblCONS_CodRGM
            // 
            this.lblCONS_CodRGM.AutoSize = true;
            this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 88);
            this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
            this.lblCONS_CodRGM.Size = new System.Drawing.Size(67, 13);
            this.lblCONS_CodRGM.TabIndex = 8;
            this.lblCONS_CodRGM.Text = "Régimen:";
            // 
            // CONS_CodRGM
            // 
            this.CONS_CodRGM.ConstantesSelectedItem = null;
            this.CONS_CodRGM.ConstantesSelectedValue = null;
            this.CONS_CodRGM.ConstantesTitulo = null;
            this.CONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CONS_CodRGM.FormattingEnabled = true;
            this.CONS_CodRGM.Location = new System.Drawing.Point(153, 84);
            this.CONS_CodRGM.Name = "CONS_CodRGM";
            this.CONS_CodRGM.Session = null;
            this.CONS_CodRGM.Size = new System.Drawing.Size(194, 21);
            this.CONS_CodRGM.TabIndex = 9;
            this.CONS_CodRGM.Tag = "CONS_CodRGMMSGERROR";
            this.CONS_CodRGM.SelectedIndexChanged += new System.EventHandler(this.CONS_CodRGM_SelectedIndexChanged);
            // 
            // lblNVIA_FecCutOff_EXPO
            // 
            this.lblNVIA_FecCutOff_EXPO.AutoSize = true;
            this.lblNVIA_FecCutOff_EXPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_FecCutOff_EXPO.Location = new System.Drawing.Point(375, 142);
            this.lblNVIA_FecCutOff_EXPO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_FecCutOff_EXPO.Name = "lblNVIA_FecCutOff_EXPO";
            this.lblNVIA_FecCutOff_EXPO.Size = new System.Drawing.Size(86, 13);
            this.lblNVIA_FecCutOff_EXPO.TabIndex = 18;
            this.lblNVIA_FecCutOff_EXPO.Text = "Fecha CutOff:";
            // 
            // NVIA_FecETA_IMPO_ETD_EXPO
            // 
            this.NVIA_FecETA_IMPO_ETD_EXPO.Location = new System.Drawing.Point(153, 138);
            this.NVIA_FecETA_IMPO_ETD_EXPO.MinimumSize = new System.Drawing.Size(100, 22);
            this.NVIA_FecETA_IMPO_ETD_EXPO.Name = "NVIA_FecETA_IMPO_ETD_EXPO";
            this.NVIA_FecETA_IMPO_ETD_EXPO.NSActiveMouse = false;
            this.NVIA_FecETA_IMPO_ETD_EXPO.NSActiveMsgFecha = false;
            this.NVIA_FecETA_IMPO_ETD_EXPO.NSChangeDate = true;
            this.NVIA_FecETA_IMPO_ETD_EXPO.NSDigitos = 4;
            this.NVIA_FecETA_IMPO_ETD_EXPO.NSFecha = null;
            this.NVIA_FecETA_IMPO_ETD_EXPO.NSSetDateNow = false;
            this.NVIA_FecETA_IMPO_ETD_EXPO.Size = new System.Drawing.Size(118, 22);
            this.NVIA_FecETA_IMPO_ETD_EXPO.TabIndex = 17;
            this.NVIA_FecETA_IMPO_ETD_EXPO.Tag = "NVIA_FecETA_IMPO_ETD_EXPOMSGERROR";
            // 
            // lblNVIA_FecETA_IMPO_ETD_EXPO
            // 
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.AutoSize = true;
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Location = new System.Drawing.Point(10, 142);
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Name = "lblNVIA_FecETA_IMPO_ETD_EXPO";
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Size = new System.Drawing.Size(45, 13);
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.TabIndex = 16;
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Text = "Fecha:";
            // 
            // lblENTC_CodAgentePort_EXPO
            // 
            this.lblENTC_CodAgentePort_EXPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodAgentePort_EXPO.Location = new System.Drawing.Point(10, 277);
            this.lblENTC_CodAgentePort_EXPO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblENTC_CodAgentePort_EXPO.Name = "lblENTC_CodAgentePort_EXPO";
            this.lblENTC_CodAgentePort_EXPO.Size = new System.Drawing.Size(137, 16);
            this.lblENTC_CodAgentePort_EXPO.TabIndex = 20;
            this.lblENTC_CodAgentePort_EXPO.Text = "Agente Portuario:";
            // 
            // lblNVIA_FecDescarga_IMPO
            // 
            this.lblNVIA_FecDescarga_IMPO.AutoSize = true;
            this.lblNVIA_FecDescarga_IMPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_FecDescarga_IMPO.Location = new System.Drawing.Point(10, 196);
            this.lblNVIA_FecDescarga_IMPO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_FecDescarga_IMPO.Name = "lblNVIA_FecDescarga_IMPO";
            this.lblNVIA_FecDescarga_IMPO.Size = new System.Drawing.Size(121, 13);
            this.lblNVIA_FecDescarga_IMPO.TabIndex = 85;
            this.lblNVIA_FecDescarga_IMPO.Text = "Fecha de Descarga:";
            // 
            // NVIA_FecDescarga_IMPO
            // 
            this.NVIA_FecDescarga_IMPO.Location = new System.Drawing.Point(153, 192);
            this.NVIA_FecDescarga_IMPO.MinimumSize = new System.Drawing.Size(100, 22);
            this.NVIA_FecDescarga_IMPO.Name = "NVIA_FecDescarga_IMPO";
            this.NVIA_FecDescarga_IMPO.NSActiveMouse = false;
            this.NVIA_FecDescarga_IMPO.NSActiveMsgFecha = false;
            this.NVIA_FecDescarga_IMPO.NSChangeDate = true;
            this.NVIA_FecDescarga_IMPO.NSDigitos = 4;
            this.NVIA_FecDescarga_IMPO.NSFecha = null;
            this.NVIA_FecDescarga_IMPO.NSSetDateNow = false;
            this.NVIA_FecDescarga_IMPO.Size = new System.Drawing.Size(118, 22);
            this.NVIA_FecDescarga_IMPO.TabIndex = 86;
            this.NVIA_FecDescarga_IMPO.Tag = "NVIA_FecDescarga_IMPOMSGERROR";
            // 
            // lblNVIA_NroManifiesto
            // 
            this.lblNVIA_NroManifiesto.AutoSize = true;
            this.lblNVIA_NroManifiesto.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_NroManifiesto.Location = new System.Drawing.Point(10, 223);
            this.lblNVIA_NroManifiesto.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_NroManifiesto.Name = "lblNVIA_NroManifiesto";
            this.lblNVIA_NroManifiesto.Size = new System.Drawing.Size(93, 13);
            this.lblNVIA_NroManifiesto.TabIndex = 87;
            this.lblNVIA_NroManifiesto.Text = "Nro Manifiesto:";
            // 
            // lblNVIA_NroManifiestoDes_IMPO
            // 
            this.lblNVIA_NroManifiestoDes_IMPO.AutoSize = true;
            this.lblNVIA_NroManifiestoDes_IMPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_NroManifiestoDes_IMPO.Location = new System.Drawing.Point(375, 223);
            this.lblNVIA_NroManifiestoDes_IMPO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_NroManifiestoDes_IMPO.Name = "lblNVIA_NroManifiestoDes_IMPO";
            this.lblNVIA_NroManifiestoDes_IMPO.Size = new System.Drawing.Size(116, 13);
            this.lblNVIA_NroManifiestoDes_IMPO.TabIndex = 89;
            this.lblNVIA_NroManifiestoDes_IMPO.Text = "Nro Mani. Descon.:";
            // 
            // lblENTC_CodTermPort
            // 
            this.lblENTC_CodTermPort.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodTermPort.Location = new System.Drawing.Point(10, 304);
            this.lblENTC_CodTermPort.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblENTC_CodTermPort.Name = "lblENTC_CodTermPort";
            this.lblENTC_CodTermPort.Size = new System.Drawing.Size(137, 16);
            this.lblENTC_CodTermPort.TabIndex = 91;
            this.lblENTC_CodTermPort.Text = "Terminal Portuario:";
            // 
            // lblENTC_CodAgentePortVoBo_IMPO
            // 
            this.lblENTC_CodAgentePortVoBo_IMPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodAgentePortVoBo_IMPO.Location = new System.Drawing.Point(10, 331);
            this.lblENTC_CodAgentePortVoBo_IMPO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblENTC_CodAgentePortVoBo_IMPO.Name = "lblENTC_CodAgentePortVoBo_IMPO";
            this.lblENTC_CodAgentePortVoBo_IMPO.Size = new System.Drawing.Size(137, 16);
            this.lblENTC_CodAgentePortVoBo_IMPO.TabIndex = 92;
            this.lblENTC_CodAgentePortVoBo_IMPO.Text = "Agen Portuario VoBo:";
            // 
            // lblENTC_CodAgentePortVoBo2_IMPO
            // 
            this.lblENTC_CodAgentePortVoBo2_IMPO.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodAgentePortVoBo2_IMPO.Location = new System.Drawing.Point(10, 358);
            this.lblENTC_CodAgentePortVoBo2_IMPO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblENTC_CodAgentePortVoBo2_IMPO.Name = "lblENTC_CodAgentePortVoBo2_IMPO";
            this.lblENTC_CodAgentePortVoBo2_IMPO.Size = new System.Drawing.Size(137, 16);
            this.lblENTC_CodAgentePortVoBo2_IMPO.TabIndex = 93;
            this.lblENTC_CodAgentePortVoBo2_IMPO.Text = "Agen Portuario VoBo 2:";
            // 
            // ENTC_CodTermPort
            // 
            this.ENTC_CodTermPort.ActivarAyudaAuto = false;
            this.tableNaveViaje.SetColumnSpan(this.ENTC_CodTermPort, 4);
            this.ENTC_CodTermPort.ContainerService = null;
            this.ENTC_CodTermPort.EnabledAyudaButton = true;
            this.ENTC_CodTermPort.Location = new System.Drawing.Point(153, 300);
            this.ENTC_CodTermPort.LongitudAceptada = 0;
            this.ENTC_CodTermPort.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ENTC_CodTermPort.Name = "ENTC_CodTermPort";
            this.ENTC_CodTermPort.RellenaCeros = false;
            this.ENTC_CodTermPort.Size = new System.Drawing.Size(559, 20);
            this.ENTC_CodTermPort.TabIndex = 94;
            this.ENTC_CodTermPort.Tag = "ENTC_CodTermPortMSGERROR";
            this.ENTC_CodTermPort.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ENTC_CodTermPort.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.ENTC_CodTermPort.UsarTipoEntidad = true;
            this.ENTC_CodTermPort.Value = null;
            // 
            // ENTC_CodAgentePortVoBo_IMPO
            // 
            this.ENTC_CodAgentePortVoBo_IMPO.ActivarAyudaAuto = false;
            this.tableNaveViaje.SetColumnSpan(this.ENTC_CodAgentePortVoBo_IMPO, 4);
            this.ENTC_CodAgentePortVoBo_IMPO.ContainerService = null;
            this.ENTC_CodAgentePortVoBo_IMPO.EnabledAyudaButton = true;
            this.ENTC_CodAgentePortVoBo_IMPO.Location = new System.Drawing.Point(153, 327);
            this.ENTC_CodAgentePortVoBo_IMPO.LongitudAceptada = 0;
            this.ENTC_CodAgentePortVoBo_IMPO.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ENTC_CodAgentePortVoBo_IMPO.Name = "ENTC_CodAgentePortVoBo_IMPO";
            this.ENTC_CodAgentePortVoBo_IMPO.RellenaCeros = false;
            this.ENTC_CodAgentePortVoBo_IMPO.Size = new System.Drawing.Size(559, 20);
            this.ENTC_CodAgentePortVoBo_IMPO.TabIndex = 95;
            this.ENTC_CodAgentePortVoBo_IMPO.Tag = "ENTC_CodAgenPortVoBo_IMPOMSGERROR";
            this.ENTC_CodAgentePortVoBo_IMPO.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ENTC_CodAgentePortVoBo_IMPO.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_AgentePortuario;
            this.ENTC_CodAgentePortVoBo_IMPO.UsarTipoEntidad = true;
            this.ENTC_CodAgentePortVoBo_IMPO.Value = null;
            // 
            // ENTC_CodAgentePortVoBo2_IMPO
            // 
            this.ENTC_CodAgentePortVoBo2_IMPO.ActivarAyudaAuto = false;
            this.tableNaveViaje.SetColumnSpan(this.ENTC_CodAgentePortVoBo2_IMPO, 4);
            this.ENTC_CodAgentePortVoBo2_IMPO.ContainerService = null;
            this.ENTC_CodAgentePortVoBo2_IMPO.EnabledAyudaButton = true;
            this.ENTC_CodAgentePortVoBo2_IMPO.Location = new System.Drawing.Point(153, 354);
            this.ENTC_CodAgentePortVoBo2_IMPO.LongitudAceptada = 0;
            this.ENTC_CodAgentePortVoBo2_IMPO.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ENTC_CodAgentePortVoBo2_IMPO.Name = "ENTC_CodAgentePortVoBo2_IMPO";
            this.ENTC_CodAgentePortVoBo2_IMPO.RellenaCeros = false;
            this.ENTC_CodAgentePortVoBo2_IMPO.Size = new System.Drawing.Size(559, 20);
            this.ENTC_CodAgentePortVoBo2_IMPO.TabIndex = 96;
            this.ENTC_CodAgentePortVoBo2_IMPO.Tag = "ENTC_CodAgenPortVoBo2_IMPOMSGERROR";
            this.ENTC_CodAgentePortVoBo2_IMPO.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ENTC_CodAgentePortVoBo2_IMPO.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_AgentePortuario;
            this.ENTC_CodAgentePortVoBo2_IMPO.UsarTipoEntidad = true;
            this.ENTC_CodAgentePortVoBo2_IMPO.Value = null;
            // 
            // lblNVIA_FecRecogerDocs
            // 
            this.lblNVIA_FecRecogerDocs.AutoSize = true;
            this.lblNVIA_FecRecogerDocs.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_FecRecogerDocs.Location = new System.Drawing.Point(375, 196);
            this.lblNVIA_FecRecogerDocs.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_FecRecogerDocs.Name = "lblNVIA_FecRecogerDocs";
            this.lblNVIA_FecRecogerDocs.Size = new System.Drawing.Size(126, 13);
            this.lblNVIA_FecRecogerDocs.TabIndex = 85;
            this.lblNVIA_FecRecogerDocs.Text = "Fecha Recoger Doc.:";
            // 
            // ENTC_FecRecogerDocs
            // 
            this.ENTC_FecRecogerDocs.Location = new System.Drawing.Point(518, 192);
            this.ENTC_FecRecogerDocs.MinimumSize = new System.Drawing.Size(100, 22);
            this.ENTC_FecRecogerDocs.Name = "ENTC_FecRecogerDocs";
            this.ENTC_FecRecogerDocs.NSActiveMouse = false;
            this.ENTC_FecRecogerDocs.NSActiveMsgFecha = false;
            this.ENTC_FecRecogerDocs.NSChangeDate = true;
            this.ENTC_FecRecogerDocs.NSDigitos = 4;
            this.ENTC_FecRecogerDocs.NSFecha = null;
            this.ENTC_FecRecogerDocs.NSSetDateNow = false;
            this.ENTC_FecRecogerDocs.Size = new System.Drawing.Size(118, 22);
            this.ENTC_FecRecogerDocs.TabIndex = 86;
            this.ENTC_FecRecogerDocs.Tag = "ENTC_FecRecogerDocsMSGERROR";
            // 
            // UsrCrea
            // 
            this.UsrCrea.Location = new System.Drawing.Point(153, 381);
            this.UsrCrea.Name = "UsrCrea";
            this.UsrCrea.Size = new System.Drawing.Size(194, 20);
            this.UsrCrea.TabIndex = 88;
            // 
            // NVIA_UsrPreFactura
            // 
            this.NVIA_UsrPreFactura.Location = new System.Drawing.Point(153, 435);
            this.NVIA_UsrPreFactura.Name = "NVIA_UsrPreFactura";
            this.NVIA_UsrPreFactura.Size = new System.Drawing.Size(194, 20);
            this.NVIA_UsrPreFactura.TabIndex = 88;
            // 
            // NVIA_UsrCierreNave
            // 
            this.NVIA_UsrCierreNave.Location = new System.Drawing.Point(153, 462);
            this.NVIA_UsrCierreNave.Name = "NVIA_UsrCierreNave";
            this.NVIA_UsrCierreNave.Size = new System.Drawing.Size(194, 20);
            this.NVIA_UsrCierreNave.TabIndex = 88;
            // 
            // FecCrea
            // 
            this.FecCrea.Location = new System.Drawing.Point(518, 381);
            this.FecCrea.MinimumSize = new System.Drawing.Size(100, 22);
            this.FecCrea.Name = "FecCrea";
            this.FecCrea.NSActiveMouse = false;
            this.FecCrea.NSActiveMsgFecha = false;
            this.FecCrea.NSChangeDate = true;
            this.FecCrea.NSDigitos = 4;
            this.FecCrea.NSFecha = null;
            this.FecCrea.NSSetDateNow = false;
            this.FecCrea.Size = new System.Drawing.Size(118, 22);
            this.FecCrea.TabIndex = 86;
            this.FecCrea.Tag = "NVIA_FecCutOffMSGERROR";
            // 
            // NVIA_FecPreFactura
            // 
            this.NVIA_FecPreFactura.Location = new System.Drawing.Point(518, 435);
            this.NVIA_FecPreFactura.MinimumSize = new System.Drawing.Size(100, 22);
            this.NVIA_FecPreFactura.Name = "NVIA_FecPreFactura";
            this.NVIA_FecPreFactura.NSActiveMouse = false;
            this.NVIA_FecPreFactura.NSActiveMsgFecha = false;
            this.NVIA_FecPreFactura.NSChangeDate = true;
            this.NVIA_FecPreFactura.NSDigitos = 4;
            this.NVIA_FecPreFactura.NSFecha = null;
            this.NVIA_FecPreFactura.NSSetDateNow = false;
            this.NVIA_FecPreFactura.Size = new System.Drawing.Size(118, 22);
            this.NVIA_FecPreFactura.TabIndex = 86;
            this.NVIA_FecPreFactura.Tag = "NVIA_FecCutOffMSGERROR";
            // 
            // NVIA_FecCierreNave
            // 
            this.NVIA_FecCierreNave.Location = new System.Drawing.Point(518, 462);
            this.NVIA_FecCierreNave.MinimumSize = new System.Drawing.Size(100, 22);
            this.NVIA_FecCierreNave.Name = "NVIA_FecCierreNave";
            this.NVIA_FecCierreNave.NSActiveMouse = false;
            this.NVIA_FecCierreNave.NSActiveMsgFecha = false;
            this.NVIA_FecCierreNave.NSChangeDate = true;
            this.NVIA_FecCierreNave.NSDigitos = 4;
            this.NVIA_FecCierreNave.NSFecha = null;
            this.NVIA_FecCierreNave.NSSetDateNow = false;
            this.NVIA_FecCierreNave.Size = new System.Drawing.Size(118, 22);
            this.NVIA_FecCierreNave.TabIndex = 86;
            this.NVIA_FecCierreNave.Tag = "NVIA_FecCutOffMSGERROR";
            // 
            // lblUsrCrea
            // 
            this.lblUsrCrea.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsrCrea.Location = new System.Drawing.Point(10, 385);
            this.lblUsrCrea.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblUsrCrea.Name = "lblUsrCrea";
            this.lblUsrCrea.Size = new System.Drawing.Size(137, 16);
            this.lblUsrCrea.TabIndex = 20;
            this.lblUsrCrea.Text = "Usuario Creación:";
            // 
            // lblNVIA_UsrPreFactura
            // 
            this.lblNVIA_UsrPreFactura.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_UsrPreFactura.Location = new System.Drawing.Point(10, 439);
            this.lblNVIA_UsrPreFactura.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_UsrPreFactura.Name = "lblNVIA_UsrPreFactura";
            this.lblNVIA_UsrPreFactura.Size = new System.Drawing.Size(137, 16);
            this.lblNVIA_UsrPreFactura.TabIndex = 20;
            this.lblNVIA_UsrPreFactura.Text = "Usuario Pre-Factura:";
            // 
            // lblNVIA_UsrCierreNave
            // 
            this.lblNVIA_UsrCierreNave.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_UsrCierreNave.Location = new System.Drawing.Point(10, 466);
            this.lblNVIA_UsrCierreNave.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_UsrCierreNave.Name = "lblNVIA_UsrCierreNave";
            this.lblNVIA_UsrCierreNave.Size = new System.Drawing.Size(137, 16);
            this.lblNVIA_UsrCierreNave.TabIndex = 20;
            this.lblNVIA_UsrCierreNave.Text = "Usuario Cierre Nave:";
            // 
            // lblFecCrea
            // 
            this.lblFecCrea.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecCrea.Location = new System.Drawing.Point(375, 385);
            this.lblFecCrea.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblFecCrea.Name = "lblFecCrea";
            this.lblFecCrea.Size = new System.Drawing.Size(137, 16);
            this.lblFecCrea.TabIndex = 20;
            this.lblFecCrea.Text = "Fecha Creación:";
            // 
            // lblNVIA_FecPreFactura
            // 
            this.lblNVIA_FecPreFactura.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_FecPreFactura.Location = new System.Drawing.Point(375, 439);
            this.lblNVIA_FecPreFactura.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_FecPreFactura.Name = "lblNVIA_FecPreFactura";
            this.lblNVIA_FecPreFactura.Size = new System.Drawing.Size(137, 16);
            this.lblNVIA_FecPreFactura.TabIndex = 20;
            this.lblNVIA_FecPreFactura.Text = "Fecha Pre-Factura:";
            // 
            // lblNVIA_FecCierreNave
            // 
            this.lblNVIA_FecCierreNave.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_FecCierreNave.Location = new System.Drawing.Point(375, 466);
            this.lblNVIA_FecCierreNave.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_FecCierreNave.Name = "lblNVIA_FecCierreNave";
            this.lblNVIA_FecCierreNave.Size = new System.Drawing.Size(137, 16);
            this.lblNVIA_FecCierreNave.TabIndex = 20;
            this.lblNVIA_FecCierreNave.Text = "Fecha Cierre Nave:";
            // 
            // lblNVIA_FecLlega_IMPO_Zarpe_EXPO
            // 
            this.lblNVIA_FecLlega_IMPO_Zarpe_EXPO.AutoSize = true;
            this.lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Location = new System.Drawing.Point(10, 169);
            this.lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Name = "lblNVIA_FecLlega_IMPO_Zarpe_EXPO";
            this.lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Size = new System.Drawing.Size(83, 13);
            this.lblNVIA_FecLlega_IMPO_Zarpe_EXPO.TabIndex = 84;
            this.lblNVIA_FecLlega_IMPO_Zarpe_EXPO.Text = "Fecha Zarpe:";
            // 
            // NVIA_FecLlega_IMPO_Zarpe_EXPO
            // 
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.Location = new System.Drawing.Point(153, 165);
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.MinimumSize = new System.Drawing.Size(100, 22);
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.Name = "NVIA_FecLlega_IMPO_Zarpe_EXPO";
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.NSActiveMouse = false;
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.NSActiveMsgFecha = false;
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.NSChangeDate = true;
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.NSDigitos = 4;
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.NSFecha = null;
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.NSSetDateNow = false;
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.Size = new System.Drawing.Size(118, 22);
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.TabIndex = 83;
            this.NVIA_FecLlega_IMPO_Zarpe_EXPO.Tag = "NVIA_FecLlega_IMPO_Zarpe_EXPOMSGERROR";
            // 
            // lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO
            // 
            this.lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.AutoSize = true;
            this.lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.Location = new System.Drawing.Point(375, 169);
            this.lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.Name = "lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO";
            this.lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.Size = new System.Drawing.Size(85, 13);
            this.lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.TabIndex = 81;
            this.lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO.Text = "Fecha Cierre:";
            // 
            // ENTC_CodAgentePort_EXPO
            // 
            this.ENTC_CodAgentePort_EXPO.ActivarAyudaAuto = false;
            this.tableNaveViaje.SetColumnSpan(this.ENTC_CodAgentePort_EXPO, 4);
            this.ENTC_CodAgentePort_EXPO.ContainerService = null;
            this.ENTC_CodAgentePort_EXPO.EnabledAyudaButton = true;
            this.ENTC_CodAgentePort_EXPO.Location = new System.Drawing.Point(153, 273);
            this.ENTC_CodAgentePort_EXPO.LongitudAceptada = 0;
            this.ENTC_CodAgentePort_EXPO.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ENTC_CodAgentePort_EXPO.Name = "ENTC_CodAgentePort_EXPO";
            this.ENTC_CodAgentePort_EXPO.RellenaCeros = false;
            this.ENTC_CodAgentePort_EXPO.Size = new System.Drawing.Size(559, 20);
            this.ENTC_CodAgentePort_EXPO.TabIndex = 99;
            this.ENTC_CodAgentePort_EXPO.Tag = "ENTC_CodAgentePort_EXPOMSGERROR";
            this.ENTC_CodAgentePort_EXPO.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ENTC_CodAgentePort_EXPO.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Agente;
            this.ENTC_CodAgentePort_EXPO.UsarTipoEntidad = true;
            this.ENTC_CodAgentePort_EXPO.Value = null;
            // 
            // lblPUER_Codigo
            // 
            this.lblPUER_Codigo.AutoSize = true;
            this.lblPUER_Codigo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPUER_Codigo.Location = new System.Drawing.Point(10, 115);
            this.lblPUER_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPUER_Codigo.Name = "lblPUER_Codigo";
            this.lblPUER_Codigo.Size = new System.Drawing.Size(54, 13);
            this.lblPUER_Codigo.TabIndex = 14;
            this.lblPUER_Codigo.Text = "Puerto:";
            // 
            // ayudaPUER_Codigo
            // 
            this.ayudaPUER_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ayudaPUER_Codigo.CONS_CodVia = null;
            this.ayudaPUER_Codigo.CONS_TabVia = null;
            this.ayudaPUER_Codigo.DontSendTab = false;
            this.ayudaPUER_Codigo.Location = new System.Drawing.Point(153, 111);
            this.ayudaPUER_Codigo.Name = "ayudaPUER_Codigo";
            this.ayudaPUER_Codigo.SelectedItem = null;
            this.ayudaPUER_Codigo.SelectedValue = null;
            this.ayudaPUER_Codigo.Size = new System.Drawing.Size(193, 20);
            this.ayudaPUER_Codigo.TabIndex = 100;
            this.ayudaPUER_Codigo.Tag = "PUER_CodigoMSGERROR";
            this.ayudaPUER_Codigo.TIPO_CodPais = null;
            this.ayudaPUER_Codigo.TIPO_TabPais = null;
            this.ayudaPUER_Codigo.Title = null;
            // 
            // lblNAVE_Codigo
            // 
            this.lblNAVE_Codigo.AutoSize = true;
            this.lblNAVE_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNAVE_Codigo.Location = new System.Drawing.Point(375, 61);
            this.lblNAVE_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNAVE_Codigo.Name = "lblNAVE_Codigo";
            this.lblNAVE_Codigo.Size = new System.Drawing.Size(41, 13);
            this.lblNAVE_Codigo.TabIndex = 2;
            this.lblNAVE_Codigo.Text = "Nave:";
            // 
            // NAVE_Codigo
            // 
            this.NAVE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NAVE_Codigo.Enabled = false;
            this.NAVE_Codigo.FormattingEnabled = true;
            this.NAVE_Codigo.Location = new System.Drawing.Point(518, 57);
            this.NAVE_Codigo.Name = "NAVE_Codigo";
            this.NAVE_Codigo.Size = new System.Drawing.Size(194, 21);
            this.NAVE_Codigo.TabIndex = 3;
            this.NAVE_Codigo.Tag = "";
            // 
            // ENTC_CodTransportista
            // 
            this.ENTC_CodTransportista.ActivarAyudaAuto = false;
            this.tableNaveViaje.SetColumnSpan(this.ENTC_CodTransportista, 4);
            this.ENTC_CodTransportista.ContainerService = null;
            this.ENTC_CodTransportista.EnabledAyudaButton = true;
            this.ENTC_CodTransportista.Location = new System.Drawing.Point(153, 30);
            this.ENTC_CodTransportista.LongitudAceptada = 0;
            this.ENTC_CodTransportista.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
            this.ENTC_CodTransportista.Name = "ENTC_CodTransportista";
            this.ENTC_CodTransportista.RellenaCeros = false;
            this.ENTC_CodTransportista.Size = new System.Drawing.Size(559, 20);
            this.ENTC_CodTransportista.TabIndex = 80;
            this.ENTC_CodTransportista.Tag = "ENTC_CodTransportistaMSGERROR";
            this.ENTC_CodTransportista.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
            this.ENTC_CodTransportista.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Transportista;
            this.ENTC_CodTransportista.UsarTipoEntidad = true;
            this.ENTC_CodTransportista.Value = null;
            // 
            // lblENTC_CodTransportista
            // 
            this.lblENTC_CodTransportista.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblENTC_CodTransportista.Location = new System.Drawing.Point(10, 34);
            this.lblENTC_CodTransportista.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblENTC_CodTransportista.Name = "lblENTC_CodTransportista";
            this.lblENTC_CodTransportista.Size = new System.Drawing.Size(102, 17);
            this.lblENTC_CodTransportista.TabIndex = 0;
            this.lblENTC_CodTransportista.Text = "Transportista:";
            // 
            // lblCONS_CodVia
            // 
            this.lblCONS_CodVia.AutoSize = true;
            this.lblCONS_CodVia.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodVia.Location = new System.Drawing.Point(10, 61);
            this.lblCONS_CodVia.Margin = new System.Windows.Forms.Padding(10, 7, 2, 0);
            this.lblCONS_CodVia.Name = "lblCONS_CodVia";
            this.lblCONS_CodVia.Size = new System.Drawing.Size(31, 13);
            this.lblCONS_CodVia.TabIndex = 97;
            this.lblCONS_CodVia.Text = "Vía:";
            // 
            // CONS_CodVIA
            // 
            this.CONS_CodVIA.ConstantesSelectedItem = null;
            this.CONS_CodVIA.ConstantesSelectedValue = null;
            this.CONS_CodVIA.ConstantesTitulo = null;
            this.CONS_CodVIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CONS_CodVIA.Enabled = false;
            this.CONS_CodVIA.FormattingEnabled = true;
            this.CONS_CodVIA.Location = new System.Drawing.Point(152, 57);
            this.CONS_CodVIA.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CONS_CodVIA.Name = "CONS_CodVIA";
            this.CONS_CodVIA.Session = null;
            this.CONS_CodVIA.Size = new System.Drawing.Size(194, 21);
            this.CONS_CodVIA.TabIndex = 98;
            this.CONS_CodVIA.Tag = "CONS_CodViaMSGERROR";
            // 
            // NVIA_Codigo
            // 
            this.NVIA_Codigo.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
            this.NVIA_Codigo.Decimales = 0;
            this.NVIA_Codigo.Enteros = 11;
            this.NVIA_Codigo.Formato = "##,###,###,##0.";
            this.NVIA_Codigo.Location = new System.Drawing.Point(153, 3);
            this.NVIA_Codigo.MaxLength = 12;
            this.NVIA_Codigo.Name = "NVIA_Codigo";
            this.NVIA_Codigo.Negativo = true;
            this.NVIA_Codigo.ReadOnly = true;
            this.NVIA_Codigo.SinFormato = true;
            this.NVIA_Codigo.Size = new System.Drawing.Size(194, 20);
            this.NVIA_Codigo.TabIndex = 5;
            this.NVIA_Codigo.Tag = "";
            this.NVIA_Codigo.Text = "0";
            this.NVIA_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NVIA_Codigo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblTIPO_CodTRF
            // 
            this.lblTIPO_CodTRF.AutoSize = true;
            this.lblTIPO_CodTRF.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodTRF.Location = new System.Drawing.Point(375, 88);
            this.lblTIPO_CodTRF.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodTRF.Name = "lblTIPO_CodTRF";
            this.lblTIPO_CodTRF.Size = new System.Drawing.Size(50, 13);
            this.lblTIPO_CodTRF.TabIndex = 10;
            this.lblTIPO_CodTRF.Text = "Tráfico:";
            // 
            // NVIA_NroViaje
            // 
            this.NVIA_NroViaje.Location = new System.Drawing.Point(518, 111);
            this.NVIA_NroViaje.MaxLength = 50;
            this.NVIA_NroViaje.Name = "NVIA_NroViaje";
            this.NVIA_NroViaje.Size = new System.Drawing.Size(194, 20);
            this.NVIA_NroViaje.TabIndex = 7;
            this.NVIA_NroViaje.Tag = "NVIA_NroViajeMSGERROR";
            // 
            // TIPO_CodTRF
            // 
            this.TIPO_CodTRF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TIPO_CodTRF.FormattingEnabled = true;
            this.TIPO_CodTRF.Location = new System.Drawing.Point(518, 84);
            this.TIPO_CodTRF.Name = "TIPO_CodTRF";
            this.TIPO_CodTRF.Session = null;
            this.TIPO_CodTRF.Size = new System.Drawing.Size(194, 21);
            this.TIPO_CodTRF.TabIndex = 11;
            this.TIPO_CodTRF.Tag = "TIPO_CodTRFMSGERROR";
            this.TIPO_CodTRF.TiposSelectedItem = null;
            this.TIPO_CodTRF.TiposSelectedValue = null;
            this.TIPO_CodTRF.TiposTitulo = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Estado:";
            // 
            // cmbNVIA_Estado
            // 
            this.cmbNVIA_Estado.ConstantesSelectedItem = null;
            this.cmbNVIA_Estado.ConstantesSelectedValue = null;
            this.cmbNVIA_Estado.ConstantesTitulo = null;
            this.cmbNVIA_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNVIA_Estado.FormattingEnabled = true;
            this.cmbNVIA_Estado.Location = new System.Drawing.Point(518, 3);
            this.cmbNVIA_Estado.Name = "cmbNVIA_Estado";
            this.cmbNVIA_Estado.Session = null;
            this.cmbNVIA_Estado.Size = new System.Drawing.Size(194, 21);
            this.cmbNVIA_Estado.TabIndex = 101;
            this.cmbNVIA_Estado.Tag = "NVIA_EstadoMSGERROR";
            this.cmbNVIA_Estado.SelectedIndexChanged += new System.EventHandler(this.cmbNVIA_Estado_SelectedIndexChanged);
            // 
            // NVIA_NroManifiesto
            // 
            this.NVIA_NroManifiesto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NVIA_NroManifiesto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.NVIA_NroManifiesto.Location = new System.Drawing.Point(153, 219);
            this.NVIA_NroManifiesto.MaximumSize = new System.Drawing.Size(170, 21);
            this.NVIA_NroManifiesto.MinimumSize = new System.Drawing.Size(170, 21);
            this.NVIA_NroManifiesto.Name = "NVIA_NroManifiesto";
            this.NVIA_NroManifiesto.SelectedValue = null;
            this.NVIA_NroManifiesto.Size = new System.Drawing.Size(170, 21);
            this.NVIA_NroManifiesto.TabIndex = 102;
            this.NVIA_NroManifiesto.Tag = "NVIA_NroManifiestoMSGERROR";
            // 
            // NVIA_NroManifiestoDes_IMPO
            // 
            this.NVIA_NroManifiestoDes_IMPO.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NVIA_NroManifiestoDes_IMPO.BackColor = System.Drawing.Color.LightSteelBlue;
            this.NVIA_NroManifiestoDes_IMPO.Location = new System.Drawing.Point(518, 219);
            this.NVIA_NroManifiestoDes_IMPO.MaximumSize = new System.Drawing.Size(170, 21);
            this.NVIA_NroManifiestoDes_IMPO.MinimumSize = new System.Drawing.Size(170, 21);
            this.NVIA_NroManifiestoDes_IMPO.Name = "NVIA_NroManifiestoDes_IMPO";
            this.NVIA_NroManifiestoDes_IMPO.SelectedValue = null;
            this.NVIA_NroManifiestoDes_IMPO.Size = new System.Drawing.Size(170, 21);
            this.NVIA_NroManifiestoDes_IMPO.TabIndex = 103;
            this.NVIA_NroManifiestoDes_IMPO.Tag = "NVIA_NorManifiestoDesconMSGERROR";
            // 
            // lblNVIA_UsrEmiteStatment
            // 
            this.lblNVIA_UsrEmiteStatment.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_UsrEmiteStatment.Location = new System.Drawing.Point(10, 412);
            this.lblNVIA_UsrEmiteStatment.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_UsrEmiteStatment.Name = "lblNVIA_UsrEmiteStatment";
            this.lblNVIA_UsrEmiteStatment.Size = new System.Drawing.Size(137, 16);
            this.lblNVIA_UsrEmiteStatment.TabIndex = 20;
            this.lblNVIA_UsrEmiteStatment.Text = "Usu. Emite Statement:";
            // 
            // lblNVIA_FecEmiteStatment
            // 
            this.lblNVIA_FecEmiteStatment.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_FecEmiteStatment.Location = new System.Drawing.Point(375, 412);
            this.lblNVIA_FecEmiteStatment.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_FecEmiteStatment.Name = "lblNVIA_FecEmiteStatment";
            this.lblNVIA_FecEmiteStatment.Size = new System.Drawing.Size(137, 16);
            this.lblNVIA_FecEmiteStatment.TabIndex = 20;
            this.lblNVIA_FecEmiteStatment.Text = "Fec. Emi. Statement:";
            // 
            // txtNVIA_UsrEmiteStatment
            // 
            this.txtNVIA_UsrEmiteStatment.Location = new System.Drawing.Point(153, 408);
            this.txtNVIA_UsrEmiteStatment.Name = "txtNVIA_UsrEmiteStatment";
            this.txtNVIA_UsrEmiteStatment.Size = new System.Drawing.Size(194, 20);
            this.txtNVIA_UsrEmiteStatment.TabIndex = 88;
            // 
            // mdtNVIA_FecEmiteStatment
            // 
            this.mdtNVIA_FecEmiteStatment.Location = new System.Drawing.Point(518, 408);
            this.mdtNVIA_FecEmiteStatment.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtNVIA_FecEmiteStatment.Name = "mdtNVIA_FecEmiteStatment";
            this.mdtNVIA_FecEmiteStatment.NSActiveMouse = false;
            this.mdtNVIA_FecEmiteStatment.NSActiveMsgFecha = false;
            this.mdtNVIA_FecEmiteStatment.NSChangeDate = true;
            this.mdtNVIA_FecEmiteStatment.NSDigitos = 4;
            this.mdtNVIA_FecEmiteStatment.NSFecha = null;
            this.mdtNVIA_FecEmiteStatment.NSSetDateNow = false;
            this.mdtNVIA_FecEmiteStatment.Size = new System.Drawing.Size(118, 22);
            this.mdtNVIA_FecEmiteStatment.TabIndex = 86;
            this.mdtNVIA_FecEmiteStatment.Tag = "NVIA_FecCutOffMSGERROR";
            // 
            // NVIA_FecCutOff_EXPO
            // 
            this.NVIA_FecCutOff_EXPO.Location = new System.Drawing.Point(518, 138);
            this.NVIA_FecCutOff_EXPO.MinimumSize = new System.Drawing.Size(100, 22);
            this.NVIA_FecCutOff_EXPO.Name = "NVIA_FecCutOff_EXPO";
            this.NVIA_FecCutOff_EXPO.NSActiveMouse = false;
            this.NVIA_FecCutOff_EXPO.NSActiveMsgFecha = false;
            this.NVIA_FecCutOff_EXPO.NSChangeDate = true;
            this.NVIA_FecCutOff_EXPO.NSDigitos = 4;
            this.NVIA_FecCutOff_EXPO.NSFecha = null;
            this.NVIA_FecCutOff_EXPO.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.FechaHora;
            this.NVIA_FecCutOff_EXPO.NSSetDateNow = false;
            this.NVIA_FecCutOff_EXPO.Size = new System.Drawing.Size(149, 22);
            this.NVIA_FecCutOff_EXPO.TabIndex = 133;
            this.NVIA_FecCutOff_EXPO.Tag = "NVIA_FecCutOff_EXPOMSGERROR";
            // 
            // NVIA_FecCierreDire_IMPO_TermEmba_EXPO
            // 
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.Location = new System.Drawing.Point(518, 165);
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.MinimumSize = new System.Drawing.Size(100, 22);
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.Name = "NVIA_FecCierreDire_IMPO_TermEmba_EXPO";
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSActiveMouse = false;
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSActiveMsgFecha = false;
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSChangeDate = true;
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSDigitos = 4;
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSFecha = null;
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.FechaHora;
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.NSSetDateNow = false;
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.Size = new System.Drawing.Size(149, 22);
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.TabIndex = 133;
            this.NVIA_FecCierreDire_IMPO_TermEmba_EXPO.Tag = "NVIA_FecCutOff_EXPOMSGERROR";
            // 
            // btnEditarDetalle
            // 
            this.btnEditarDetalle.BackColor = System.Drawing.Color.Transparent;
            this.btnEditarDetalle.Image = global::Delfin.Principal.Properties.Resources.editar16x16;
            this.btnEditarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarDetalle.Location = new System.Drawing.Point(184, 2);
            this.btnEditarDetalle.Name = "btnEditarDetalle";
            this.btnEditarDetalle.Size = new System.Drawing.Size(25, 24);
            this.btnEditarDetalle.TabIndex = 2;
            this.btnEditarDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnEditarDetalle, "Editar Detalle NaveViaje");
            this.btnEditarDetalle.UseVisualStyleBackColor = false;
            // 
            // btnNuevoDetalle
            // 
            this.btnNuevoDetalle.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevoDetalle.Image = global::Delfin.Principal.Properties.Resources.add16x16;
            this.btnNuevoDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoDetalle.Location = new System.Drawing.Point(153, 2);
            this.btnNuevoDetalle.Name = "btnNuevoDetalle";
            this.btnNuevoDetalle.Size = new System.Drawing.Size(25, 24);
            this.btnNuevoDetalle.TabIndex = 1;
            this.btnNuevoDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnNuevoDetalle, "Nuevo Detalle NaveViaje");
            this.btnNuevoDetalle.UseVisualStyleBackColor = false;
            // 
            // grdItemsDetalle
            // 
            this.grdItemsDetalle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItemsDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItemsDetalle.Location = new System.Drawing.Point(0, 629);
            this.grdItemsDetalle.Name = "grdItemsDetalle";
            // 
            // 
            // 
            this.grdItemsDetalle.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 602, 240, 150);
            this.grdItemsDetalle.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.grdItemsDetalle.Size = new System.Drawing.Size(739, 43);
            this.grdItemsDetalle.TabIndex = 4;
            this.grdItemsDetalle.TabStop = false;
            // 
            // tableDetalle
            // 
            this.tableDetalle.AutoSize = true;
            this.tableDetalle.ColumnCount = 7;
            this.tableDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableDetalle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableDetalle.Controls.Add(this.lblTIPO_CodPAIDetalle, 0, 0);
            this.tableDetalle.Controls.Add(this.lblDVIA_FecETA_EXPO_ETDMaster_IMPO, 0, 1);
            this.tableDetalle.Controls.Add(this.lblPUER_CodigoDetalle, 3, 0);
            this.tableDetalle.Controls.Add(this.TIPO_CodPAIDetalle, 1, 0);
            this.tableDetalle.Controls.Add(this.PUER_CodigoDetalle, 4, 0);
            this.tableDetalle.Controls.Add(this.DVIA_FecETA_EXPO_ETDMaster_IMPO, 1, 1);
            this.tableDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableDetalle.Location = new System.Drawing.Point(0, 575);
            this.tableDetalle.Name = "tableDetalle";
            this.tableDetalle.RowCount = 2;
            this.tableDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDetalle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableDetalle.Size = new System.Drawing.Size(739, 54);
            this.tableDetalle.TabIndex = 3;
            // 
            // lblTIPO_CodPAIDetalle
            // 
            this.lblTIPO_CodPAIDetalle.AutoSize = true;
            this.lblTIPO_CodPAIDetalle.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CodPAIDetalle.Location = new System.Drawing.Point(10, 7);
            this.lblTIPO_CodPAIDetalle.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CodPAIDetalle.Name = "lblTIPO_CodPAIDetalle";
            this.lblTIPO_CodPAIDetalle.Size = new System.Drawing.Size(35, 13);
            this.lblTIPO_CodPAIDetalle.TabIndex = 0;
            this.lblTIPO_CodPAIDetalle.Text = "País:";
            // 
            // lblDVIA_FecETA_EXPO_ETDMaster_IMPO
            // 
            this.lblDVIA_FecETA_EXPO_ETDMaster_IMPO.AutoSize = true;
            this.lblDVIA_FecETA_EXPO_ETDMaster_IMPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDVIA_FecETA_EXPO_ETDMaster_IMPO.Location = new System.Drawing.Point(10, 34);
            this.lblDVIA_FecETA_EXPO_ETDMaster_IMPO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblDVIA_FecETA_EXPO_ETDMaster_IMPO.Name = "lblDVIA_FecETA_EXPO_ETDMaster_IMPO";
            this.lblDVIA_FecETA_EXPO_ETDMaster_IMPO.Size = new System.Drawing.Size(45, 13);
            this.lblDVIA_FecETA_EXPO_ETDMaster_IMPO.TabIndex = 4;
            this.lblDVIA_FecETA_EXPO_ETDMaster_IMPO.Text = "Fecha:";
            // 
            // lblPUER_CodigoDetalle
            // 
            this.lblPUER_CodigoDetalle.AutoSize = true;
            this.lblPUER_CodigoDetalle.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPUER_CodigoDetalle.Location = new System.Drawing.Point(375, 7);
            this.lblPUER_CodigoDetalle.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPUER_CodigoDetalle.Name = "lblPUER_CodigoDetalle";
            this.lblPUER_CodigoDetalle.Size = new System.Drawing.Size(49, 13);
            this.lblPUER_CodigoDetalle.TabIndex = 2;
            this.lblPUER_CodigoDetalle.Text = "Puerto:";
            // 
            // TIPO_CodPAIDetalle
            // 
            this.TIPO_CodPAIDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TIPO_CodPAIDetalle.FormattingEnabled = true;
            this.TIPO_CodPAIDetalle.Location = new System.Drawing.Point(153, 3);
            this.TIPO_CodPAIDetalle.Name = "TIPO_CodPAIDetalle";
            this.TIPO_CodPAIDetalle.Session = null;
            this.TIPO_CodPAIDetalle.Size = new System.Drawing.Size(194, 21);
            this.TIPO_CodPAIDetalle.TabIndex = 1;
            this.TIPO_CodPAIDetalle.Tag = "TIPO_CodPAIOrigenMSGERROR";
            this.TIPO_CodPAIDetalle.TiposSelectedItem = null;
            this.TIPO_CodPAIDetalle.TiposSelectedValue = null;
            this.TIPO_CodPAIDetalle.TiposTitulo = null;
            // 
            // PUER_CodigoDetalle
            // 
            this.PUER_CodigoDetalle.ComboIntSelectedValue = null;
            this.PUER_CodigoDetalle.ComboSelectedItem = null;
            this.PUER_CodigoDetalle.ComboStrSelectedValue = null;
            this.PUER_CodigoDetalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PUER_CodigoDetalle.FormattingEnabled = true;
            this.PUER_CodigoDetalle.Location = new System.Drawing.Point(518, 3);
            this.PUER_CodigoDetalle.Name = "PUER_CodigoDetalle";
            this.PUER_CodigoDetalle.Size = new System.Drawing.Size(194, 21);
            this.PUER_CodigoDetalle.TabIndex = 3;
            this.PUER_CodigoDetalle.Tag = "PUER_CodOrigenMSGERROR";
            // 
            // DVIA_FecETA_EXPO_ETDMaster_IMPO
            // 
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.Location = new System.Drawing.Point(153, 30);
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.MinimumSize = new System.Drawing.Size(100, 22);
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.Name = "DVIA_FecETA_EXPO_ETDMaster_IMPO";
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.NSActiveMouse = false;
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.NSActiveMsgFecha = false;
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.NSChangeDate = true;
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.NSDigitos = 4;
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.NSFecha = null;
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.NSSetDateNow = false;
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.Size = new System.Drawing.Size(101, 22);
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.TabIndex = 5;
            this.DVIA_FecETA_EXPO_ETDMaster_IMPO.Tag = "CONT_FecEmiMSGERROR";
            // 
            // btnGuardarDetalle
            // 
            this.btnGuardarDetalle.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarDetalle.Image = global::Delfin.Principal.Properties.Resources.disk_blue_ok;
            this.btnGuardarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarDetalle.Location = new System.Drawing.Point(246, 2);
            this.btnGuardarDetalle.Name = "btnGuardarDetalle";
            this.btnGuardarDetalle.Size = new System.Drawing.Size(25, 24);
            this.btnGuardarDetalle.TabIndex = 4;
            this.btnGuardarDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnGuardarDetalle, "Confirmar Edición Nuevo Detalle NaveViaje");
            this.btnGuardarDetalle.UseVisualStyleBackColor = false;
            // 
            // btnEliminarDetalle
            // 
            this.btnEliminarDetalle.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarDetalle.Image = global::Delfin.Principal.Properties.Resources.delete1;
            this.btnEliminarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarDetalle.Location = new System.Drawing.Point(215, 2);
            this.btnEliminarDetalle.Name = "btnEliminarDetalle";
            this.btnEliminarDetalle.Size = new System.Drawing.Size(25, 24);
            this.btnEliminarDetalle.TabIndex = 3;
            this.btnEliminarDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnEliminarDetalle, "Eliminar Nuevo Detalle NaveViaje");
            this.btnEliminarDetalle.UseVisualStyleBackColor = false;
            // 
            // btnDeshacerDetalle
            // 
            this.btnDeshacerDetalle.BackColor = System.Drawing.Color.Transparent;
            this.btnDeshacerDetalle.Image = global::Delfin.Principal.Properties.Resources.undo1;
            this.btnDeshacerDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeshacerDetalle.Location = new System.Drawing.Point(277, 2);
            this.btnDeshacerDetalle.Name = "btnDeshacerDetalle";
            this.btnDeshacerDetalle.Size = new System.Drawing.Size(25, 24);
            this.btnDeshacerDetalle.TabIndex = 5;
            this.btnDeshacerDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnDeshacerDetalle, "Deshacer Edición Nuevo Detalle NaveViaje");
            this.btnDeshacerDetalle.UseVisualStyleBackColor = false;
            // 
            // errorProvider2
            // 
            this.errorProvider2.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider2.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAuditoriaDetNaveViaje);
            this.panel1.Controls.Add(this.btnDeshacerDetalle);
            this.panel1.Controls.Add(this.btnNuevoDetalle);
            this.panel1.Controls.Add(this.btnGuardarDetalle);
            this.panel1.Controls.Add(this.btnEditarDetalle);
            this.panel1.Controls.Add(this.btnEliminarDetalle);
            this.panel1.Controls.Add(this.panelCaption2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 547);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 28);
            this.panel1.TabIndex = 27;
            // 
            // btnAuditoriaDetNaveViaje
            // 
            this.btnAuditoriaDetNaveViaje.BackColor = System.Drawing.Color.Transparent;
            this.btnAuditoriaDetNaveViaje.Image = global::Delfin.Principal.Properties.Resources.businessman_view;
            this.btnAuditoriaDetNaveViaje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuditoriaDetNaveViaje.Location = new System.Drawing.Point(687, 2);
            this.btnAuditoriaDetNaveViaje.Name = "btnAuditoriaDetNaveViaje";
            this.btnAuditoriaDetNaveViaje.Size = new System.Drawing.Size(25, 24);
            this.btnAuditoriaDetNaveViaje.TabIndex = 6;
            this.btnAuditoriaDetNaveViaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnAuditoriaDetNaveViaje, "Auditoria Detalle Nave Viaje");
            this.btnAuditoriaDetNaveViaje.UseVisualStyleBackColor = false;
            // 
            // panelCaption2
            // 
            this.panelCaption2.AllowActive = false;
            this.panelCaption2.AntiAlias = false;
            this.panelCaption2.Caption = "Detalle  NaveViaje";
            this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption2.Location = new System.Drawing.Point(0, 0);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(739, 27);
            this.panelCaption2.TabIndex = 0;
            // 
            // chkChangeControl
            // 
            this.chkChangeControl.AutoSize = true;
            this.chkChangeControl.BackColor = System.Drawing.Color.SteelBlue;
            this.chkChangeControl.Location = new System.Drawing.Point(573, 37);
            this.chkChangeControl.Name = "chkChangeControl";
            this.chkChangeControl.Size = new System.Drawing.Size(172, 17);
            this.chkChangeControl.TabIndex = 28;
            this.chkChangeControl.Text = "Emitir Statemet Change Control";
            this.chkChangeControl.UseVisualStyleBackColor = false;
            // 
            // panelCaption1
            // 
            this.panelCaption1.AllowActive = false;
            this.panelCaption1.AntiAlias = false;
            this.panelCaption1.Caption = "Datos de la NaveViaje";
            this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption1.Location = new System.Drawing.Point(0, 35);
            this.panelCaption1.Name = "panelCaption1";
            this.panelCaption1.Size = new System.Drawing.Size(739, 26);
            this.panelCaption1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 250);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "Plazo Visto Bueno:";
            // 
            // NVIA_FecPlazoVistoBueno
            // 
            this.NVIA_FecPlazoVistoBueno.Location = new System.Drawing.Point(153, 246);
            this.NVIA_FecPlazoVistoBueno.MinimumSize = new System.Drawing.Size(100, 22);
            this.NVIA_FecPlazoVistoBueno.Name = "NVIA_FecPlazoVistoBueno";
            this.NVIA_FecPlazoVistoBueno.NSActiveMouse = false;
            this.NVIA_FecPlazoVistoBueno.NSActiveMsgFecha = false;
            this.NVIA_FecPlazoVistoBueno.NSChangeDate = true;
            this.NVIA_FecPlazoVistoBueno.NSDigitos = 4;
            this.NVIA_FecPlazoVistoBueno.NSFecha = null;
            this.NVIA_FecPlazoVistoBueno.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.FechaHora;
            this.NVIA_FecPlazoVistoBueno.NSSetDateNow = false;
            this.NVIA_FecPlazoVistoBueno.Size = new System.Drawing.Size(149, 22);
            this.NVIA_FecPlazoVistoBueno.TabIndex = 133;
            this.NVIA_FecPlazoVistoBueno.Tag = "NVIA_FecCutOff_EXPOMSGERROR";
            // 
            // MAN011MView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(739, 672);
            this.Controls.Add(this.chkChangeControl);
            this.Controls.Add(this.grdItemsDetalle);
            this.Controls.Add(this.tableDetalle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableNaveViaje);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MAN011MView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mantenimiento Nave Viaje";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableNaveViaje.ResumeLayout(false);
            this.tableNaveViaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsDetalle)).EndInit();
            this.tableDetalle.ResumeLayout(false);
            this.tableDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infrastructure.WinForms.Controls.TextBoxNumerico NVIA_Codigo;
        private System.Windows.Forms.Label lblNVIA_Codigo;
        private System.Windows.Forms.Label lblNVIA_NroViaje;
        private System.Windows.Forms.TableLayoutPanel tableNaveViaje;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblENTC_CodTransportista;
        private System.Windows.Forms.Label lblNAVE_Codigo;
        private System.Windows.Forms.TextBox NVIA_NroViaje;
        private System.Windows.Forms.ComboBox NAVE_Codigo;
        private Infrastructure.WinForms.Controls.MaskDateTime NVIA_FecETA_IMPO_ETD_EXPO;
        private System.Windows.Forms.Label lblNVIA_FecETA_IMPO_ETD_EXPO;
        private System.Windows.Forms.Label lblENTC_CodAgentePort_EXPO;
        private System.Windows.Forms.Label lblNVIA_FecCutOff_EXPO;
        private System.Windows.Forms.Label lblTIPO_CodTRF;
        private Controls.Tipos.ComboBoxTipos TIPO_CodTRF;
        private System.Windows.Forms.Label lblCONS_CodRGM;
        private Controls.Tipos.ComboBoxConstantes CONS_CodRGM;
        private System.Windows.Forms.Button btnEditarDetalle;
        private System.Windows.Forms.Button btnNuevoDetalle;
        private Telerik.WinControls.UI.RadGridView grdItemsDetalle;
        private System.Windows.Forms.Label lblPUER_Codigo;
        private System.Windows.Forms.TableLayoutPanel tableDetalle;
        private System.Windows.Forms.Label lblTIPO_CodPAIDetalle;
        private System.Windows.Forms.Label lblDVIA_FecETA_EXPO_ETDMaster_IMPO;
        private System.Windows.Forms.Label lblPUER_CodigoDetalle;
        private Controls.Tipos.ComboBoxTipos TIPO_CodPAIDetalle;
        private Infrastructure.WinForms.Controls.ComboBox.ComboBox PUER_CodigoDetalle;
        private Infrastructure.WinForms.Controls.MaskDateTime DVIA_FecETA_EXPO_ETDMaster_IMPO;
        private System.Windows.Forms.Button btnGuardarDetalle;
        private System.Windows.Forms.Button btnEliminarDetalle;
        private System.Windows.Forms.Button btnDeshacerDetalle;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Panel panel1;
        private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
        private Controls.Entidad ENTC_CodTransportista;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblENTC_CodAgentePortVoBo2_IMPO;
        private System.Windows.Forms.Label lblNVIA_FecCierreDire_IMPO_TermEmba_EXPO;
        private System.Windows.Forms.Label lblNVIA_FecLlega_IMPO_Zarpe_EXPO;
        private Infrastructure.WinForms.Controls.MaskDateTime NVIA_FecLlega_IMPO_Zarpe_EXPO;
        private System.Windows.Forms.Label lblNVIA_FecDescarga_IMPO;
        private Infrastructure.WinForms.Controls.MaskDateTime NVIA_FecDescarga_IMPO;
        private System.Windows.Forms.Label lblNVIA_NroManifiesto;
        private System.Windows.Forms.Label lblNVIA_NroManifiestoDes_IMPO;
        private System.Windows.Forms.Label lblENTC_CodTermPort;
        private System.Windows.Forms.Label lblENTC_CodAgentePortVoBo_IMPO;
        private Controls.Entidad ENTC_CodTermPort;
        private Controls.Entidad ENTC_CodAgentePortVoBo_IMPO;
        private Controls.Entidad ENTC_CodAgentePortVoBo2_IMPO;
        private System.Windows.Forms.Label lblCONS_CodVia;
        private Controls.Tipos.ComboBoxConstantes CONS_CodVIA;
        private System.Windows.Forms.TextBox UsrCrea;
        private System.Windows.Forms.TextBox NVIA_UsrPreFactura;
        private System.Windows.Forms.TextBox NVIA_UsrCierreNave;
        private Infrastructure.WinForms.Controls.MaskDateTime FecCrea;
        private Infrastructure.WinForms.Controls.MaskDateTime NVIA_FecPreFactura;
        private Infrastructure.WinForms.Controls.MaskDateTime NVIA_FecCierreNave;
        private System.Windows.Forms.Label lblUsrCrea;
        private System.Windows.Forms.Label lblNVIA_UsrPreFactura;
        private System.Windows.Forms.Label lblNVIA_UsrCierreNave;
        private System.Windows.Forms.Label lblFecCrea;
        private System.Windows.Forms.Label lblNVIA_FecPreFactura;
        private System.Windows.Forms.Label lblNVIA_FecCierreNave;
        private System.Windows.Forms.Label lblNVIA_FecRecogerDocs;
        private Infrastructure.WinForms.Controls.MaskDateTime ENTC_FecRecogerDocs;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnMAN_guardar;
        private System.Windows.Forms.ToolStripButton btnMAN_salir;
        private System.Windows.Forms.ToolStripButton btnPreFacturar;
        private System.Windows.Forms.ToolStripDropDownButton btnEmail;
        private System.Windows.Forms.ToolStripMenuItem btnEmailAlmacen;
        private System.Windows.Forms.ToolStripMenuItem btnCancelacionRecalada;
        private System.Windows.Forms.ToolStripButton btnCerrar_Nave;
        private System.Windows.Forms.ToolStripDropDownButton btnArchivos;
        private System.Windows.Forms.ToolStripMenuItem btnDireccionamiento;
        private System.Windows.Forms.ToolStripMenuItem btn_VoBo;
        private Controls.Entidad ENTC_CodAgentePort_EXPO;
        private System.Windows.Forms.ToolStripButton btnEmiti_Statement;
        private Controls.AyudaPuerto ayudaPUER_Codigo;
        private System.Windows.Forms.Label label1;
        private Controls.Tipos.ComboBoxConstantes cmbNVIA_Estado;
        private System.Windows.Forms.ToolStripMenuItem btnDemoraArribo;
        private System.Windows.Forms.ToolStripMenuItem btnCargaTarjadaLCL;
        private System.Windows.Forms.ToolStripMenuItem btnEmitir_BL;
        private System.Windows.Forms.ToolStripButton btnAprobarStatement;
        private System.Windows.Forms.ToolStripMenuItem btnCargaTarjadaFCL;
        private System.Windows.Forms.ToolStripButton btnAbrirStatement;
        private Controls.NumeroManifiesto NVIA_NroManifiesto;
        private Controls.NumeroManifiesto NVIA_NroManifiestoDes_IMPO;
        private System.Windows.Forms.ToolStripButton btnAuditoriaNaveViaje;
        private System.Windows.Forms.Button btnAuditoriaDetNaveViaje;
        private System.Windows.Forms.Label lblNVIA_UsrEmiteStatment;
        private System.Windows.Forms.Label lblNVIA_FecEmiteStatment;
        private System.Windows.Forms.TextBox txtNVIA_UsrEmiteStatment;
        private Infrastructure.WinForms.Controls.MaskDateTime mdtNVIA_FecEmiteStatment;
        private System.Windows.Forms.CheckBox chkChangeControl;
        private Infrastructure.WinForms.Controls.MaskTime NVIA_FecCutOff_EXPO;
        private System.Windows.Forms.ToolStripMenuItem btnAvisosLlegada;
        private Infrastructure.WinForms.Controls.MaskTime NVIA_FecCierreDire_IMPO_TermEmba_EXPO;
        private System.Windows.Forms.Label label2;
        private Infrastructure.WinForms.Controls.MaskTime NVIA_FecPlazoVistoBueno;
    }
}