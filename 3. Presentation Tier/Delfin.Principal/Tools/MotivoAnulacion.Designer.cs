namespace Delfin.Principal
{
   partial class MotivoAnulacion
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tableMANU = new System.Windows.Forms.TableLayoutPanel();
            this.lblTIPO_CODANU = new System.Windows.Forms.Label();
            this.lblMANU_Obs = new System.Windows.Forms.Label();
            this.lblMANU_Fecha = new System.Windows.Forms.Label();
            this.dtpFecha = new Infrastructure.WinForms.Controls.MaskTime();
            this.txtObservación = new Infrastructure.WinForms.Controls.TextBoxAlfaNumerico();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.errorValidacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel3.SuspendLayout();
            this.tableMANU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidacion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.btnAceptar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(733, 50);
            this.panel3.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Image = global::Delfin.Principal.Properties.Resources.Cancel_24x24;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(57, 0);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(61, 50);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.Image = global::Delfin.Principal.Properties.Resources.check;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAceptar.Location = new System.Drawing.Point(0, 0);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(0);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(57, 50);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // tableMANU
            // 
            this.tableMANU.AutoSize = true;
            this.tableMANU.ColumnCount = 7;
            this.tableMANU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableMANU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableMANU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableMANU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableMANU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableMANU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableMANU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableMANU.Controls.Add(this.lblTIPO_CODANU, 0, 0);
            this.tableMANU.Controls.Add(this.lblMANU_Obs, 0, 1);
            this.tableMANU.Controls.Add(this.lblMANU_Fecha, 3, 0);
            this.tableMANU.Controls.Add(this.dtpFecha, 4, 0);
            this.tableMANU.Controls.Add(this.txtObservación, 1, 1);
            this.tableMANU.Controls.Add(this.txtUsuario, 1, 0);
            this.tableMANU.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableMANU.Location = new System.Drawing.Point(0, 50);
            this.tableMANU.Name = "tableMANU";
            this.tableMANU.RowCount = 3;
            this.tableMANU.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableMANU.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableMANU.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableMANU.Size = new System.Drawing.Size(733, 81);
            this.tableMANU.TabIndex = 1;
            // 
            // lblTIPO_CODANU
            // 
            this.lblTIPO_CODANU.AutoSize = true;
            this.lblTIPO_CODANU.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIPO_CODANU.Location = new System.Drawing.Point(10, 7);
            this.lblTIPO_CODANU.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblTIPO_CODANU.Name = "lblTIPO_CODANU";
            this.lblTIPO_CODANU.Size = new System.Drawing.Size(59, 13);
            this.lblTIPO_CODANU.TabIndex = 0;
            this.lblTIPO_CODANU.Text = "Usuario :";
            // 
            // lblMANU_Obs
            // 
            this.lblMANU_Obs.AutoSize = true;
            this.lblMANU_Obs.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMANU_Obs.Location = new System.Drawing.Point(10, 34);
            this.lblMANU_Obs.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblMANU_Obs.Name = "lblMANU_Obs";
            this.lblMANU_Obs.Size = new System.Drawing.Size(83, 13);
            this.lblMANU_Obs.TabIndex = 4;
            this.lblMANU_Obs.Text = "Observación:";
            // 
            // lblMANU_Fecha
            // 
            this.lblMANU_Fecha.AutoSize = true;
            this.lblMANU_Fecha.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMANU_Fecha.Location = new System.Drawing.Point(375, 7);
            this.lblMANU_Fecha.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
            this.lblMANU_Fecha.Name = "lblMANU_Fecha";
            this.lblMANU_Fecha.Size = new System.Drawing.Size(104, 13);
            this.lblMANU_Fecha.TabIndex = 2;
            this.lblMANU_Fecha.Text = "Fecha Anulación:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Location = new System.Drawing.Point(518, 3);
            this.dtpFecha.MinimumSize = new System.Drawing.Size(100, 22);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.NSActiveMouse = false;
            this.dtpFecha.NSActiveMsgFecha = false;
            this.dtpFecha.NSChangeDate = true;
            this.dtpFecha.NSDigitos = 4;
            this.dtpFecha.NSFecha = null;
            this.dtpFecha.NSFormato = Infrastructure.WinForms.Controls.FormatoMostrado.Fecha;
            this.dtpFecha.NSSetDateNow = false;
            this.dtpFecha.Size = new System.Drawing.Size(100, 22);
            this.dtpFecha.TabIndex = 3;
            this.dtpFecha.Tag = "MANU_FechaMSGERROR";
            // 
            // txtObservación
            // 
            this.tableMANU.SetColumnSpan(this.txtObservación, 4);
            this.txtObservación.Location = new System.Drawing.Point(153, 30);
            this.txtObservación.LongitudAceptada = 0;
            this.txtObservación.Multiline = true;
            this.txtObservación.Name = "txtObservación";
            this.txtObservación.RellenaCeros = false;
            this.tableMANU.SetRowSpan(this.txtObservación, 2);
            this.txtObservación.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservación.Size = new System.Drawing.Size(559, 48);
            this.txtObservación.TabIndex = 5;
            this.txtObservación.Tipo = Infrastructure.WinForms.Controls.TextBoxAlfaNumerico.TipoTextBoxAlfaNumerico.AlfaNumerico;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(153, 3);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(194, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // errorValidacion
            // 
            this.errorValidacion.ContainerControl = this;
            // 
            // MotivoAnulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(733, 141);
            this.Controls.Add(this.tableMANU);
            this.Controls.Add(this.panel3);
            this.Name = "MotivoAnulacion";
            this.Text = "MotivoAnulacion";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableMANU.ResumeLayout(false);
            this.tableMANU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorValidacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.Button btnCancelar;
      private System.Windows.Forms.Button btnAceptar;
      private System.Windows.Forms.TableLayoutPanel tableMANU;
      private System.Windows.Forms.Label lblTIPO_CODANU;
      private System.Windows.Forms.Label lblMANU_Obs;
      private System.Windows.Forms.Label lblMANU_Fecha;
      private Infrastructure.WinForms.Controls.MaskTime dtpFecha;
      private Infrastructure.WinForms.Controls.TextBoxAlfaNumerico txtObservación;
      private System.Windows.Forms.TextBox txtUsuario;
      private System.Windows.Forms.ErrorProvider errorValidacion;
   }
}