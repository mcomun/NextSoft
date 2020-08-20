namespace Delfin.Principal
{
   partial class OPE001TView
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
         this.txtTexto = new System.Windows.Forms.TextBox();
         this.pnlBotones = new System.Windows.Forms.Panel();
         this.btnCancelar = new System.Windows.Forms.Button();
         this.btnAceptar = new System.Windows.Forms.Button();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.pnlBotones.SuspendLayout();
         this.tableLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // txtTexto
         // 
         this.txtTexto.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtTexto.Location = new System.Drawing.Point(0, 0);
         this.txtTexto.Multiline = true;
         this.txtTexto.Name = "txtTexto";
         this.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.txtTexto.Size = new System.Drawing.Size(656, 230);
         this.txtTexto.TabIndex = 0;
         // 
         // pnlBotones
         // 
         this.pnlBotones.Controls.Add(this.tableLayoutPanel1);
         this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.pnlBotones.Location = new System.Drawing.Point(0, 230);
         this.pnlBotones.Name = "pnlBotones";
         this.pnlBotones.Size = new System.Drawing.Size(656, 28);
         this.pnlBotones.TabIndex = 1;
         // 
         // btnCancelar
         // 
         this.btnCancelar.Location = new System.Drawing.Point(83, 3);
         this.btnCancelar.Name = "btnCancelar";
         this.btnCancelar.Size = new System.Drawing.Size(75, 23);
         this.btnCancelar.TabIndex = 1;
         this.btnCancelar.Text = "Cancelar";
         this.btnCancelar.UseVisualStyleBackColor = true;
         // 
         // btnAceptar
         // 
         this.btnAceptar.Location = new System.Drawing.Point(3, 3);
         this.btnAceptar.Name = "btnAceptar";
         this.btnAceptar.Size = new System.Drawing.Size(74, 23);
         this.btnAceptar.TabIndex = 0;
         this.btnAceptar.Text = "Aceptar";
         this.btnAceptar.UseVisualStyleBackColor = true;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.AutoSize = true;
         this.tableLayoutPanel1.ColumnCount = 2;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 1, 0);
         this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 0, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(495, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 1;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(161, 28);
         this.tableLayoutPanel1.TabIndex = 2;
         // 
         // OPE001TView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(656, 258);
         this.ControlBox = false;
         this.Controls.Add(this.txtTexto);
         this.Controls.Add(this.pnlBotones);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OPE001TView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "OPE001TView";
         this.pnlBotones.ResumeLayout(false);
         this.pnlBotones.PerformLayout();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox txtTexto;
      private System.Windows.Forms.Panel pnlBotones;
      private System.Windows.Forms.Button btnCancelar;
      private System.Windows.Forms.Button btnAceptar;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
   }
}