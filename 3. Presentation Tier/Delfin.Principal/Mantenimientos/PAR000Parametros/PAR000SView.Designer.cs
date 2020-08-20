namespace Delfin.Principal
{
   partial class PAR000SView
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
         this.pnlBotones = new System.Windows.Forms.Panel();
         this.btnCancelar = new System.Windows.Forms.Button();
         this.btnAceptar = new System.Windows.Forms.Button();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.SERVADICIONAL = new Delfin.Controls.AyudaServicio();
         this.lblCONS_CodRGM = new System.Windows.Forms.Label();
         this.btnAgregar = new System.Windows.Forms.Button();
         this.grdItems = new Telerik.WinControls.UI.RadGridView();
         this.pnlBotones.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).BeginInit();
         this.SuspendLayout();
         // 
         // pnlBotones
         // 
         this.pnlBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.pnlBotones.Controls.Add(this.btnCancelar);
         this.pnlBotones.Controls.Add(this.btnAceptar);
         this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.pnlBotones.Location = new System.Drawing.Point(0, 265);
         this.pnlBotones.Name = "pnlBotones";
         this.pnlBotones.Size = new System.Drawing.Size(479, 34);
         this.pnlBotones.TabIndex = 1;
         // 
         // btnCancelar
         // 
         this.btnCancelar.Location = new System.Drawing.Point(397, 6);
         this.btnCancelar.Name = "btnCancelar";
         this.btnCancelar.Size = new System.Drawing.Size(75, 23);
         this.btnCancelar.TabIndex = 1;
         this.btnCancelar.Text = "Cancelar";
         this.btnCancelar.UseVisualStyleBackColor = true;
         // 
         // btnAceptar
         // 
         this.btnAceptar.Location = new System.Drawing.Point(316, 6);
         this.btnAceptar.Name = "btnAceptar";
         this.btnAceptar.Size = new System.Drawing.Size(75, 23);
         this.btnAceptar.TabIndex = 0;
         this.btnAceptar.Text = "Aceptar";
         this.btnAceptar.UseVisualStyleBackColor = true;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.AutoSize = true;
         this.tableLayoutPanel1.ColumnCount = 5;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.SERVADICIONAL, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.lblCONS_CodRGM, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.btnAgregar, 3, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(479, 27);
         this.tableLayoutPanel1.TabIndex = 2;
         // 
         // SERVADICIONAL
         // 
         this.SERVADICIONAL.ActivarAyudaAuto = false;
         this.SERVADICIONAL.EnabledAyuda = true;
         this.SERVADICIONAL.EnabledAyudaButton = true;
         this.SERVADICIONAL.EsFiltro = false;
         this.SERVADICIONAL.Location = new System.Drawing.Point(83, 3);
         this.SERVADICIONAL.LongitudAceptada = 0;
         this.SERVADICIONAL.MyInstanciaAyuda = Infrastructure.WinForms.Controls.TextBoxAyuda.InstanciaAyuda.Habilitado;
         this.SERVADICIONAL.Name = "SERVADICIONAL";
         this.SERVADICIONAL.RellenaCeros = false;
         this.SERVADICIONAL.Size = new System.Drawing.Size(294, 20);
         this.SERVADICIONAL.TabIndex = 60;
         this.SERVADICIONAL.Tipo = Infrastructure.WinForms.Controls.TextBoxAyuda.TipoTextBoxAyuda.Numerico;
         this.SERVADICIONAL.TipoAyudaServicio = Delfin.Controls.AyudaServicio.TipoAyuda.Codigo;
         this.SERVADICIONAL.Value = null;
         // 
         // lblCONS_CodRGM
         // 
         this.lblCONS_CodRGM.AutoSize = true;
         this.lblCONS_CodRGM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblCONS_CodRGM.Location = new System.Drawing.Point(10, 7);
         this.lblCONS_CodRGM.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.lblCONS_CodRGM.Name = "lblCONS_CodRGM";
         this.lblCONS_CodRGM.Size = new System.Drawing.Size(58, 13);
         this.lblCONS_CodRGM.TabIndex = 59;
         this.lblCONS_CodRGM.Text = "Servicio:";
         // 
         // btnAgregar
         // 
         this.btnAgregar.Location = new System.Drawing.Point(398, 3);
         this.btnAgregar.Name = "btnAgregar";
         this.btnAgregar.Size = new System.Drawing.Size(74, 21);
         this.btnAgregar.TabIndex = 61;
         this.btnAgregar.Text = "Agregar";
         this.btnAgregar.UseVisualStyleBackColor = true;
         // 
         // grdItems
         // 
         this.grdItems.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItems.Location = new System.Drawing.Point(0, 27);
         this.grdItems.Name = "grdItems";
         // 
         // 
         // 
         this.grdItems.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 27, 240, 150);
         this.grdItems.Size = new System.Drawing.Size(479, 238);
         this.grdItems.TabIndex = 50;
         this.grdItems.TabStop = false;
         // 
         // PAR000SView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.ClientSize = new System.Drawing.Size(479, 299);
         this.ControlBox = false;
         this.Controls.Add(this.grdItems);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.pnlBotones);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PAR000SView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Servicios";
         this.pnlBotones.ResumeLayout(false);
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems.MasterTemplate)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel pnlBotones;
      private System.Windows.Forms.Button btnCancelar;
      private System.Windows.Forms.Button btnAceptar;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label lblCONS_CodRGM;
      private Controls.AyudaServicio SERVADICIONAL;
      private System.Windows.Forms.Button btnAgregar;
      private Telerik.WinControls.UI.RadGridView grdItems;
   }
}