namespace Delfin.Principal
{
    partial class DOC002MView
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAuditoriaLoadingList = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.errorProviderOPE_Loading_List = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderDet_Cotizacion_OV_Novedad = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorEventoTarea = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelCaption1 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.lblLOAD_FecDevolucion = new System.Windows.Forms.Label();
            this.lblPreAlerta = new System.Windows.Forms.Label();
            this.lblNVIA_Codigo = new System.Windows.Forms.Label();
            this.txtLOAD_Codigo = new Infrastructure.WinForms.Controls.TextBoxNumerico();
            this.tableControlDocumentos = new System.Windows.Forms.TableLayoutPanel();
            this.mdtLOAD_FecDevolucion = new Infrastructure.WinForms.Controls.MaskTime();
            this.lblLOAD_HBL = new System.Windows.Forms.Label();
            this.lblLOAD_MBL = new System.Windows.Forms.Label();
            this.txtLOAD_HBL = new System.Windows.Forms.TextBox();
            this.txtLOAD_MBL = new System.Windows.Forms.TextBox();
            this.txtPreAlerta = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderOPE_Loading_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).BeginInit();
            this.tableControlDocumentos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.btnAuditoriaLoadingList);
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(741, 50);
            this.panel3.TabIndex = 0;
            // 
            // btnAuditoriaLoadingList
            // 
            this.btnAuditoriaLoadingList.AutoSize = true;
            this.btnAuditoriaLoadingList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAuditoriaLoadingList.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnAuditoriaLoadingList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditoriaLoadingList.ForeColor = System.Drawing.Color.Black;
            this.btnAuditoriaLoadingList.Image = global::Delfin.Principal.Properties.Resources.businessman_view;
            this.btnAuditoriaLoadingList.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAuditoriaLoadingList.Location = new System.Drawing.Point(681, 0);
            this.btnAuditoriaLoadingList.Margin = new System.Windows.Forms.Padding(0);
            this.btnAuditoriaLoadingList.Name = "btnAuditoriaLoadingList";
            this.btnAuditoriaLoadingList.Size = new System.Drawing.Size(60, 50);
            this.btnAuditoriaLoadingList.TabIndex = 2;
            this.btnAuditoriaLoadingList.Text = "Auditoria";
            this.btnAuditoriaLoadingList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAuditoriaLoadingList.UseVisualStyleBackColor = true;
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
            this.btnSalir.Location = new System.Drawing.Point(57, 0);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(55, 50);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = true;
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Image = global::Delfin.Principal.Properties.Resources.save;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(57, 50);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // errorProviderOPE_Loading_List
            // 
            this.errorProviderOPE_Loading_List.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderOPE_Loading_List.ContainerControl = this;
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
            // panelCaption1
            // 
            this.panelCaption1.AllowActive = false;
            this.panelCaption1.AntiAlias = false;
            this.panelCaption1.Caption = "Datos Generales";
            this.panelCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption1.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption1.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption1.Location = new System.Drawing.Point(0, 50);
            this.panelCaption1.Name = "panelCaption1";
            this.panelCaption1.Size = new System.Drawing.Size(741, 26);
            this.panelCaption1.TabIndex = 2;
            // 
            // lblLOAD_FecDevolucion
            // 
            this.lblLOAD_FecDevolucion.AutoSize = true;
            this.lblLOAD_FecDevolucion.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLOAD_FecDevolucion.Location = new System.Drawing.Point(10, 34);
            this.lblLOAD_FecDevolucion.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblLOAD_FecDevolucion.Name = "lblLOAD_FecDevolucion";
            this.lblLOAD_FecDevolucion.Size = new System.Drawing.Size(120, 13);
            this.lblLOAD_FecDevolucion.TabIndex = 18;
            this.lblLOAD_FecDevolucion.Text = "Fec. de Devolución:";
            // 
            // lblPreAlerta
            // 
            this.lblPreAlerta.AutoSize = true;
            this.lblPreAlerta.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreAlerta.Location = new System.Drawing.Point(375, 7);
            this.lblPreAlerta.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblPreAlerta.Name = "lblPreAlerta";
            this.lblPreAlerta.Size = new System.Drawing.Size(50, 13);
            this.lblPreAlerta.TabIndex = 4;
            this.lblPreAlerta.Text = "Estado:";
            // 
            // lblNVIA_Codigo
            // 
            this.lblNVIA_Codigo.AutoSize = true;
            this.lblNVIA_Codigo.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVIA_Codigo.Location = new System.Drawing.Point(10, 7);
            this.lblNVIA_Codigo.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblNVIA_Codigo.Name = "lblNVIA_Codigo";
            this.lblNVIA_Codigo.Size = new System.Drawing.Size(52, 13);
            this.lblNVIA_Codigo.TabIndex = 4;
            this.lblNVIA_Codigo.Text = "Codigo:";
            // 
            // txtLOAD_Codigo
            // 
            this.txtLOAD_Codigo.BaseTipo = Infrastructure.WinForms.Controls.EstandaresFormato.General;
            this.txtLOAD_Codigo.Decimales = 0;
            this.txtLOAD_Codigo.Enabled = false;
            this.txtLOAD_Codigo.Enteros = 11;
            this.txtLOAD_Codigo.Formato = "##,###,###,##0.";
            this.txtLOAD_Codigo.Location = new System.Drawing.Point(153, 3);
            this.txtLOAD_Codigo.MaxLength = 12;
            this.txtLOAD_Codigo.Name = "txtLOAD_Codigo";
            this.txtLOAD_Codigo.Negativo = true;
            this.txtLOAD_Codigo.ReadOnly = true;
            this.txtLOAD_Codigo.SinFormato = true;
            this.txtLOAD_Codigo.Size = new System.Drawing.Size(194, 20);
            this.txtLOAD_Codigo.TabIndex = 5;
            this.txtLOAD_Codigo.Tag = "";
            this.txtLOAD_Codigo.Text = "0";
            this.txtLOAD_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLOAD_Codigo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tableControlDocumentos
            // 
            this.tableControlDocumentos.AutoSize = true;
            this.tableControlDocumentos.ColumnCount = 7;
            this.tableControlDocumentos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableControlDocumentos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableControlDocumentos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableControlDocumentos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableControlDocumentos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableControlDocumentos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableControlDocumentos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableControlDocumentos.Controls.Add(this.txtLOAD_Codigo, 1, 0);
            this.tableControlDocumentos.Controls.Add(this.lblNVIA_Codigo, 0, 0);
            this.tableControlDocumentos.Controls.Add(this.lblPreAlerta, 3, 0);
            this.tableControlDocumentos.Controls.Add(this.lblLOAD_FecDevolucion, 0, 1);
            this.tableControlDocumentos.Controls.Add(this.mdtLOAD_FecDevolucion, 1, 1);
            this.tableControlDocumentos.Controls.Add(this.lblLOAD_HBL, 0, 2);
            this.tableControlDocumentos.Controls.Add(this.lblLOAD_MBL, 3, 2);
            this.tableControlDocumentos.Controls.Add(this.txtLOAD_HBL, 1, 2);
            this.tableControlDocumentos.Controls.Add(this.txtLOAD_MBL, 4, 2);
            this.tableControlDocumentos.Controls.Add(this.txtPreAlerta, 4, 0);
            this.tableControlDocumentos.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableControlDocumentos.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableControlDocumentos.Location = new System.Drawing.Point(0, 76);
            this.tableControlDocumentos.Name = "tableControlDocumentos";
            this.tableControlDocumentos.RowCount = 4;
            this.tableControlDocumentos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableControlDocumentos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableControlDocumentos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableControlDocumentos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableControlDocumentos.Size = new System.Drawing.Size(741, 108);
            this.tableControlDocumentos.TabIndex = 3;
            // 
            // mdtLOAD_FecDevolucion
            // 
            this.mdtLOAD_FecDevolucion.Location = new System.Drawing.Point(153, 30);
            this.mdtLOAD_FecDevolucion.MinimumSize = new System.Drawing.Size(100, 22);
            this.mdtLOAD_FecDevolucion.Name = "mdtLOAD_FecDevolucion";
            this.mdtLOAD_FecDevolucion.NSActiveMouse = false;
            this.mdtLOAD_FecDevolucion.NSActiveMsgFecha = false;
            this.mdtLOAD_FecDevolucion.NSChangeDate = true;
            this.mdtLOAD_FecDevolucion.NSDigitos = 4;
            this.mdtLOAD_FecDevolucion.NSFecha = null;
            this.mdtLOAD_FecDevolucion.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.FechaHora;
            this.mdtLOAD_FecDevolucion.NSSetDateNow = false;
            this.mdtLOAD_FecDevolucion.Size = new System.Drawing.Size(132, 22);
            this.mdtLOAD_FecDevolucion.TabIndex = 132;
            // 
            // lblLOAD_HBL
            // 
            this.lblLOAD_HBL.AutoSize = true;
            this.lblLOAD_HBL.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLOAD_HBL.Location = new System.Drawing.Point(10, 61);
            this.lblLOAD_HBL.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblLOAD_HBL.Name = "lblLOAD_HBL";
            this.lblLOAD_HBL.Size = new System.Drawing.Size(29, 13);
            this.lblLOAD_HBL.TabIndex = 18;
            this.lblLOAD_HBL.Text = "HBL";
            // 
            // lblLOAD_MBL
            // 
            this.lblLOAD_MBL.AutoSize = true;
            this.lblLOAD_MBL.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLOAD_MBL.Location = new System.Drawing.Point(375, 61);
            this.lblLOAD_MBL.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblLOAD_MBL.Name = "lblLOAD_MBL";
            this.lblLOAD_MBL.Size = new System.Drawing.Size(30, 13);
            this.lblLOAD_MBL.TabIndex = 18;
            this.lblLOAD_MBL.Text = "MBL";
            // 
            // txtLOAD_HBL
            // 
            this.txtLOAD_HBL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLOAD_HBL.Location = new System.Drawing.Point(153, 57);
            this.txtLOAD_HBL.Name = "txtLOAD_HBL";
            this.txtLOAD_HBL.Size = new System.Drawing.Size(194, 20);
            this.txtLOAD_HBL.TabIndex = 133;
            // 
            // txtLOAD_MBL
            // 
            this.txtLOAD_MBL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLOAD_MBL.Location = new System.Drawing.Point(518, 57);
            this.txtLOAD_MBL.Name = "txtLOAD_MBL";
            this.txtLOAD_MBL.Size = new System.Drawing.Size(194, 20);
            this.txtLOAD_MBL.TabIndex = 134;
            // 
            // txtPreAlerta
            // 
            this.txtPreAlerta.Location = new System.Drawing.Point(518, 3);
            this.txtPreAlerta.Name = "txtPreAlerta";
            this.txtPreAlerta.Size = new System.Drawing.Size(194, 20);
            this.txtPreAlerta.TabIndex = 135;
            // 
            // DOC002MView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(741, 188);
            this.Controls.Add(this.tableControlDocumentos);
            this.Controls.Add(this.panelCaption1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DOC002MView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Documentos";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderOPE_Loading_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDet_Cotizacion_OV_Novedad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEventoTarea)).EndInit();
            this.tableControlDocumentos.ResumeLayout(false);
            this.tableControlDocumentos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }



      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnSalir;
      private System.Windows.Forms.Button btnGuardar;
      private System.Windows.Forms.ErrorProvider errorProviderOPE_Loading_List;
      private System.Windows.Forms.ErrorProvider errorProviderDet_Cotizacion_OV_Novedad;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.ErrorProvider errorEventoTarea;
      private Infrastructure.WinForms.Controls.PanelCaption panelCaption1;
      private System.Windows.Forms.TableLayoutPanel tableControlDocumentos;
      private Infrastructure.WinForms.Controls.TextBoxNumerico txtLOAD_Codigo;
      private System.Windows.Forms.Label lblNVIA_Codigo;
      private System.Windows.Forms.Label lblPreAlerta;
      private System.Windows.Forms.Label lblLOAD_FecDevolucion;
      private Infrastructure.WinForms.Controls.MaskTime mdtLOAD_FecDevolucion;
      private System.Windows.Forms.Label lblLOAD_HBL;
      private System.Windows.Forms.Label lblLOAD_MBL;
      private System.Windows.Forms.TextBox txtLOAD_HBL;
      private System.Windows.Forms.TextBox txtLOAD_MBL;
      private System.Windows.Forms.TextBox txtPreAlerta;
      private System.Windows.Forms.Button btnAuditoriaLoadingList;
   }
}