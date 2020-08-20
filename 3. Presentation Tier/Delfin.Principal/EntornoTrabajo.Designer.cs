namespace Delfin.Principal
{
   partial class EntornoTrabajo
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntornoTrabajo));
         this.cmbEmpresa = new System.Windows.Forms.ComboBox();
         this.cmbSucursal = new System.Windows.Forms.ComboBox();
         this.grpEntorno = new System.Windows.Forms.GroupBox();
         this.lblDosPuntosUSUA_Pass = new System.Windows.Forms.Label();
         this.lblDosPuntosUSUA_CodUsr = new System.Windows.Forms.Label();
         this.lblUSUA_Pass = new System.Windows.Forms.Label();
         this.lblUSUA_CodUsr = new System.Windows.Forms.Label();
         this.btnCancelar = new System.Windows.Forms.Button();
         this.btnAceptar = new System.Windows.Forms.Button();
         this.grpEntorno.SuspendLayout();
         this.SuspendLayout();
         // 
         // cmbEmpresa
         // 
         this.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbEmpresa.FormattingEnabled = true;
         this.cmbEmpresa.Location = new System.Drawing.Point(89, 20);
         this.cmbEmpresa.Name = "cmbEmpresa";
         this.cmbEmpresa.Size = new System.Drawing.Size(194, 21);
         this.cmbEmpresa.TabIndex = 2;
         // 
         // cmbSucursal
         // 
         this.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbSucursal.FormattingEnabled = true;
         this.cmbSucursal.Location = new System.Drawing.Point(89, 47);
         this.cmbSucursal.Name = "cmbSucursal";
         this.cmbSucursal.Size = new System.Drawing.Size(194, 21);
         this.cmbSucursal.TabIndex = 5;
         // 
         // grpEntorno
         // 
         this.grpEntorno.Controls.Add(this.lblDosPuntosUSUA_Pass);
         this.grpEntorno.Controls.Add(this.lblDosPuntosUSUA_CodUsr);
         this.grpEntorno.Controls.Add(this.lblUSUA_Pass);
         this.grpEntorno.Controls.Add(this.lblUSUA_CodUsr);
         this.grpEntorno.Controls.Add(this.cmbSucursal);
         this.grpEntorno.Controls.Add(this.cmbEmpresa);
         this.grpEntorno.Location = new System.Drawing.Point(9, 12);
         this.grpEntorno.Name = "grpEntorno";
         this.grpEntorno.Size = new System.Drawing.Size(297, 81);
         this.grpEntorno.TabIndex = 2;
         this.grpEntorno.TabStop = false;
         this.grpEntorno.Text = "Datos del Entorno de Trabajo";
         // 
         // lblDosPuntosUSUA_Pass
         // 
         this.lblDosPuntosUSUA_Pass.AutoSize = true;
         this.lblDosPuntosUSUA_Pass.Location = new System.Drawing.Point(74, 50);
         this.lblDosPuntosUSUA_Pass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblDosPuntosUSUA_Pass.Name = "lblDosPuntosUSUA_Pass";
         this.lblDosPuntosUSUA_Pass.Size = new System.Drawing.Size(10, 13);
         this.lblDosPuntosUSUA_Pass.TabIndex = 4;
         this.lblDosPuntosUSUA_Pass.Text = ":";
         // 
         // lblDosPuntosUSUA_CodUsr
         // 
         this.lblDosPuntosUSUA_CodUsr.AutoSize = true;
         this.lblDosPuntosUSUA_CodUsr.Location = new System.Drawing.Point(74, 23);
         this.lblDosPuntosUSUA_CodUsr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblDosPuntosUSUA_CodUsr.Name = "lblDosPuntosUSUA_CodUsr";
         this.lblDosPuntosUSUA_CodUsr.Size = new System.Drawing.Size(10, 13);
         this.lblDosPuntosUSUA_CodUsr.TabIndex = 1;
         this.lblDosPuntosUSUA_CodUsr.Text = ":";
         // 
         // lblUSUA_Pass
         // 
         this.lblUSUA_Pass.AutoSize = true;
         this.lblUSUA_Pass.Location = new System.Drawing.Point(22, 50);
         this.lblUSUA_Pass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblUSUA_Pass.Name = "lblUSUA_Pass";
         this.lblUSUA_Pass.Size = new System.Drawing.Size(48, 13);
         this.lblUSUA_Pass.TabIndex = 3;
         this.lblUSUA_Pass.Text = "Sucursal";
         // 
         // lblUSUA_CodUsr
         // 
         this.lblUSUA_CodUsr.AutoSize = true;
         this.lblUSUA_CodUsr.Location = new System.Drawing.Point(22, 23);
         this.lblUSUA_CodUsr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this.lblUSUA_CodUsr.Name = "lblUSUA_CodUsr";
         this.lblUSUA_CodUsr.Size = new System.Drawing.Size(48, 13);
         this.lblUSUA_CodUsr.TabIndex = 0;
         this.lblUSUA_CodUsr.Text = "Empresa";
         // 
         // btnCancelar
         // 
         this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancelar.Location = new System.Drawing.Point(233, 98);
         this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
         this.btnCancelar.Name = "btnCancelar";
         this.btnCancelar.Size = new System.Drawing.Size(59, 23);
         this.btnCancelar.TabIndex = 1;
         this.btnCancelar.Text = "&Cancelar";
         this.btnCancelar.UseVisualStyleBackColor = true;
         // 
         // btnAceptar
         // 
         this.btnAceptar.Location = new System.Drawing.Point(172, 98);
         this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
         this.btnAceptar.Name = "btnAceptar";
         this.btnAceptar.Size = new System.Drawing.Size(56, 23);
         this.btnAceptar.TabIndex = 0;
         this.btnAceptar.Text = "&Aceptar";
         this.btnAceptar.UseVisualStyleBackColor = true;
         this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
         // 
         // EntornoTrabajo
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.SteelBlue;
         this.ClientSize = new System.Drawing.Size(314, 127);
         this.ControlBox = false;
         this.Controls.Add(this.btnCancelar);
         this.Controls.Add(this.btnAceptar);
         this.Controls.Add(this.grpEntorno);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EntornoTrabajo";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "EntornoTrabajo";
         this.grpEntorno.ResumeLayout(false);
         this.grpEntorno.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ComboBox cmbEmpresa;
      private System.Windows.Forms.ComboBox cmbSucursal;
      private System.Windows.Forms.GroupBox grpEntorno;
      private System.Windows.Forms.Label lblDosPuntosUSUA_Pass;
      private System.Windows.Forms.Label lblDosPuntosUSUA_CodUsr;
      private System.Windows.Forms.Label lblUSUA_Pass;
      private System.Windows.Forms.Label lblUSUA_CodUsr;
      private System.Windows.Forms.Button btnCancelar;
      private System.Windows.Forms.Button btnAceptar;
   }
}