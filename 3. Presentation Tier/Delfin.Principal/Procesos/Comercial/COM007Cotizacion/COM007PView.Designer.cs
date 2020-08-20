namespace Delfin.Principal
{
   partial class COM007PView
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
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.ENTC_Codigo = new Delfin.Controls.Entidad(this.components);
         this.btnAceptar = new Telerik.WinControls.UI.RadButton();
         this.btnCancelar = new Telerik.WinControls.UI.RadButton();
         this.TIPE_Codigo = new Infrastructure.WinForms.Controls.ComboBox.ComboBox(this.components);
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
         this.SuspendLayout();
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
         this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.ENTC_Codigo, 1, 1);
         this.tableLayoutPanel1.Controls.Add(this.TIPE_Codigo, 1, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(737, 54);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(10, 7);
         this.label1.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(70, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Tipo Entidad:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(10, 34);
         this.label2.Margin = new System.Windows.Forms.Padding(10, 7, 3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(46, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Entidad:";
         // 
         // ENTC_Codigo
         // 
         this.ENTC_Codigo.ActivarAyudaAuto = false;
         this.tableLayoutPanel1.SetColumnSpan(this.ENTC_Codigo, 4);
         this.ENTC_Codigo.ContainerService = null;
         this.ENTC_Codigo.EnabledAyudaButton = true;
         this.ENTC_Codigo.Location = new System.Drawing.Point(153, 30);
         this.ENTC_Codigo.LongitudAceptada = 0;
         this.ENTC_Codigo.MyInstanciaAyuda = Delfin.Controls.Entidad.InstanciaAyuda.Habilitado;
         this.ENTC_Codigo.Name = "ENTC_Codigo";
         this.ENTC_Codigo.RellenaCeros = false;
         this.ENTC_Codigo.Size = new System.Drawing.Size(559, 20);
         this.ENTC_Codigo.TabIndex = 2;
         this.ENTC_Codigo.Tipo = Delfin.Controls.Entidad.TipoTextBoxAyuda.AlfaNumerico;
         this.ENTC_Codigo.TipoEntidad = Delfin.Controls.TiposEntidad.TIPE_Proveedor;
         this.ENTC_Codigo.Value = null;
         // 
         // btnAceptar
         // 
         this.btnAceptar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnAceptar.Location = new System.Drawing.Point(510, 61);
         this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.btnAceptar.Name = "btnAceptar";
         this.btnAceptar.Size = new System.Drawing.Size(93, 30);
         this.btnAceptar.TabIndex = 6;
         this.btnAceptar.Text = "Aceptar";
         this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
         // 
         // btnCancelar
         // 
         this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancelar.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnCancelar.Location = new System.Drawing.Point(609, 61);
         this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.btnCancelar.Name = "btnCancelar";
         this.btnCancelar.Size = new System.Drawing.Size(103, 30);
         this.btnCancelar.TabIndex = 7;
         this.btnCancelar.Text = "Cancelar";
         // 
         // TIPE_Codigo
         // 
         this.TIPE_Codigo.ComboIntSelectedValue = null;
         this.TIPE_Codigo.ComboSelectedItem = null;
         this.TIPE_Codigo.ComboStrSelectedValue = null;
         this.TIPE_Codigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.TIPE_Codigo.FormattingEnabled = true;
         this.TIPE_Codigo.Location = new System.Drawing.Point(153, 3);
         this.TIPE_Codigo.Name = "TIPE_Codigo";
         this.TIPE_Codigo.Size = new System.Drawing.Size(194, 21);
         this.TIPE_Codigo.TabIndex = 3;
         // 
         // COM007PView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.LightSteelBlue;
         this.CancelButton = this.btnCancelar;
         this.ClientSize = new System.Drawing.Size(737, 98);
         this.ControlBox = false;
         this.Controls.Add(this.btnAceptar);
         this.Controls.Add(this.btnCancelar);
         this.Controls.Add(this.tableLayoutPanel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "COM007PView";
         this.Text = "Seleccionar Proveedor";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private Controls.Entidad ENTC_Codigo;
      private Telerik.WinControls.UI.RadButton btnAceptar;
      private Telerik.WinControls.UI.RadButton btnCancelar;
      private Infrastructure.WinForms.Controls.ComboBox.ComboBox TIPE_Codigo;
   }
}