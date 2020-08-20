namespace Delfin.Principal
{
    partial class OPE006LView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OPE006LView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCONS_CodRGM = new System.Windows.Forms.Label();
            this.CONS_CodRGM = new Delfin.Controls.Tipos.ComboBoxConstantes();
            this.lblNVIA_FecETA_IMPO_ETD_EXPO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mdtFecInicio = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.mdtFecFin = new Infrastructure.WinForms.Controls.MaskDateTime();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmMarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarTodos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDesmarcarSeleccionados = new System.Windows.Forms.ToolStripMenuItem();
            this.rvwReporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelCaption2 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.TitleView = new Infrastructure.WinForms.Controls.FormTitle();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnDeshacer);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 50);
            this.panel1.TabIndex = 40;
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.AutoSize = true;
            this.btnDeshacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeshacer.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnDeshacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeshacer.ForeColor = System.Drawing.Color.Black;
            this.btnDeshacer.Image = global::Delfin.Principal.Properties.Resources.undo;
            this.btnDeshacer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeshacer.Location = new System.Drawing.Point(58, 0);
            this.btnDeshacer.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(65, 50);
            this.btnDeshacer.TabIndex = 3;
            this.btnDeshacer.Text = "&Deshacer";
            this.btnDeshacer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeshacer.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Image = global::Delfin.Principal.Properties.Resources.search;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(0, 0);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(58, 50);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodRGM, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CONS_CodRGM, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNVIA_FecETA_IMPO_ETD_EXPO, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.mdtFecInicio, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mdtFecFin, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 102);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(950, 54);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // lblCONS_CodRGM
            // 
            this.lblCONS_CodRGM.AutoSize = true;
            this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 7);
            this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
            this.lblCONS_CodRGM.Size = new System.Drawing.Size(67, 13);
            this.lblCONS_CodRGM.TabIndex = 9;
            this.lblCONS_CodRGM.Text = "Régimen:";
            // 
            // CONS_CodRGM
            // 
            this.CONS_CodRGM.ConstantesSelectedItem = null;
            this.CONS_CodRGM.ConstantesSelectedValue = null;
            this.CONS_CodRGM.ConstantesTitulo = null;
            this.CONS_CodRGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CONS_CodRGM.FormattingEnabled = true;
            this.CONS_CodRGM.Location = new System.Drawing.Point(153, 3);
            this.CONS_CodRGM.Name = "CONS_CodRGM";
            this.CONS_CodRGM.Session = null;
            this.CONS_CodRGM.Size = new System.Drawing.Size(194, 21);
            this.CONS_CodRGM.TabIndex = 10;
            this.CONS_CodRGM.Tag = "CONS_CodRGMMSGERROR";
            // 
            // lblNVIA_FecETA_IMPO_ETD_EXPO
            // 
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.AutoSize = true;
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Location = new System.Drawing.Point(10, 34);
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Name = "lblNVIA_FecETA_IMPO_ETD_EXPO";
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Size = new System.Drawing.Size(133, 13);
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.TabIndex = 17;
            this.lblNVIA_FecETA_IMPO_ETD_EXPO.Text = "Fecha Inicio ETA/ETD:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(375, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Fecha Fin ETA/ETD:";
            // 
            // mdtFecInicio
            // 
            this.mdtFecInicio.Location = new System.Drawing.Point(153, 30);
            this.mdtFecInicio.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecInicio.Name = "mdtFecInicio";
            this.mdtFecInicio.NSActiveMouse = false;
            this.mdtFecInicio.NSActiveMsgFecha = false;
            this.mdtFecInicio.NSChangeDate = true;
            this.mdtFecInicio.NSDigitos = 4;
            this.mdtFecInicio.NSFecha = null;
            this.mdtFecInicio.NSSetDateNow = false;
            this.mdtFecInicio.Size = new System.Drawing.Size(194, 22);
            this.mdtFecInicio.TabIndex = 18;
            this.mdtFecInicio.Tag = "NVIA_FecETA_IMPO_ETD_EXPOMSGERROR";
            // 
            // mdtFecFin
            // 
            this.mdtFecFin.Location = new System.Drawing.Point(518, 30);
            this.mdtFecFin.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtFecFin.Name = "mdtFecFin";
            this.mdtFecFin.NSActiveMouse = false;
            this.mdtFecFin.NSActiveMsgFecha = false;
            this.mdtFecFin.NSChangeDate = true;
            this.mdtFecFin.NSDigitos = 4;
            this.mdtFecFin.NSFecha = null;
            this.mdtFecFin.NSSetDateNow = false;
            this.mdtFecFin.Size = new System.Drawing.Size(193, 22);
            this.mdtFecFin.TabIndex = 19;
            this.mdtFecFin.Tag = "NVIA_FecETA_IMPO_ETD_EXPOMSGERROR";
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMarcarTodos,
            this.tsmMarcarSeleccionados,
            this.tsmDesmarcarTodos,
            this.tsmDesmarcarSeleccionados});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(209, 92);
            // 
            // tsmMarcarTodos
            // 
            this.tsmMarcarTodos.Name = "tsmMarcarTodos";
            this.tsmMarcarTodos.Size = new System.Drawing.Size(208, 22);
            this.tsmMarcarTodos.Text = "Marcar Todos";
            // 
            // tsmMarcarSeleccionados
            // 
            this.tsmMarcarSeleccionados.Name = "tsmMarcarSeleccionados";
            this.tsmMarcarSeleccionados.Size = new System.Drawing.Size(208, 22);
            this.tsmMarcarSeleccionados.Text = "Marcar Seleccionados";
            // 
            // tsmDesmarcarTodos
            // 
            this.tsmDesmarcarTodos.Name = "tsmDesmarcarTodos";
            this.tsmDesmarcarTodos.Size = new System.Drawing.Size(208, 22);
            this.tsmDesmarcarTodos.Text = "Desmarcar Todos";
            // 
            // tsmDesmarcarSeleccionados
            // 
            this.tsmDesmarcarSeleccionados.Name = "tsmDesmarcarSeleccionados";
            this.tsmDesmarcarSeleccionados.Size = new System.Drawing.Size(208, 22);
            this.tsmDesmarcarSeleccionados.Text = "Desmarcar Seleccionados";
            // 
            // rvwReporte
            // 
            this.rvwReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvwReporte.Location = new System.Drawing.Point(0, 182);
            this.rvwReporte.Name = "rvwReporte";
            this.rvwReporte.Size = new System.Drawing.Size(950, 268);
            this.rvwReporte.TabIndex = 46;
            // 
            // panelCaption2
            // 
            this.panelCaption2.AllowActive = false;
            this.panelCaption2.AntiAlias = false;
            this.panelCaption2.Caption = "Consulta";
            this.panelCaption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption2.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption2.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption2.Location = new System.Drawing.Point(0, 156);
            this.panelCaption2.Name = "panelCaption2";
            this.panelCaption2.Size = new System.Drawing.Size(950, 26);
            this.panelCaption2.TabIndex = 45;
            // 
            // panelCaption1
            // 
            this.panelCaption1.AllowActive = false;
            this.panelCaption1.AntiAlias = false;
            this.panelCaption1.Caption = "Criterio de Búsqueda";
            this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption1.Location = new System.Drawing.Point(0, 76);
            this.panelCaption1.Name = "panelCaption1";
            this.panelCaption1.Size = new System.Drawing.Size(950, 26);
            this.panelCaption1.TabIndex = 43;
            // 
            // TitleView
            // 
            this.TitleView.AllowActive = false;
            this.TitleView.AntiAlias = false;
            this.TitleView.Caption = "CONSULTAR CORRELATIVOS";
            this.TitleView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleView.FormIcon = ((System.Drawing.Image)(resources.GetObject("TitleView.FormIcon")));
            this.TitleView.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.TitleView.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.TitleView.Location = new System.Drawing.Point(0, 0);
            this.TitleView.Name = "TitleView";
            this.TitleView.Size = new System.Drawing.Size(950, 26);
            this.TitleView.TabIndex = 39;
            // 
            // OPE006LView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.rvwReporte);
            this.Controls.Add(this.panelCaption2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TitleView);
            this.Name = "OPE006LView";
            this.Size = new System.Drawing.Size(950, 450);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private Infrastructure.WinForms.Controls.FormTitle TitleView;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button btnDeshacer;
      private System.Windows.Forms.Button btnBuscar;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption2;
      private System.Windows.Forms.ContextMenuStrip cmsMenu;
      private System.Windows.Forms.ToolStripMenuItem tsmMarcarTodos;
      private System.Windows.Forms.ToolStripMenuItem tsmMarcarSeleccionados;
      private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarTodos;
      private System.Windows.Forms.ToolStripMenuItem tsmDesmarcarSeleccionados;
      private Microsoft.Reporting.WinForms.ReportViewer rvwReporte;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private Controls.Tipos.ComboBoxConstantes CONS_CodRGM;
      private System.Windows.Forms.Label lblNVIA_FecETA_IMPO_ETD_EXPO;
      private System.Windows.Forms.Label label1;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtFecInicio;
      private Infrastructure.WinForms.Controls.MaskDateTime mdtFecFin;

   }
}
