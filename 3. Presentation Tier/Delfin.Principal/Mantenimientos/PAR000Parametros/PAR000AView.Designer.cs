namespace Delfin.Principal
{
   partial class PAR000AView
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
         this.clbList_Codigo = new System.Windows.Forms.ListView();
         this.pnlBotones.SuspendLayout();
         this.SuspendLayout();
         // 
         // pnlBotones
         // 
         this.pnlBotones.BackColor = System.Drawing.Color.LightSteelBlue;
         this.pnlBotones.Controls.Add(this.btnCancelar);
         this.pnlBotones.Controls.Add(this.btnAceptar);
         this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.pnlBotones.Location = new System.Drawing.Point(0, 275);
         this.pnlBotones.Name = "pnlBotones";
         this.pnlBotones.Size = new System.Drawing.Size(228, 34);
         this.pnlBotones.TabIndex = 1;
         // 
         // btnCancelar
         // 
         this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.btnCancelar.Location = new System.Drawing.Point(117, 6);
         this.btnCancelar.Name = "btnCancelar";
         this.btnCancelar.Size = new System.Drawing.Size(75, 23);
         this.btnCancelar.TabIndex = 1;
         this.btnCancelar.Text = "Cancelar";
         this.btnCancelar.UseVisualStyleBackColor = true;
         // 
         // btnAceptar
         // 
         this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.btnAceptar.Location = new System.Drawing.Point(36, 6);
         this.btnAceptar.Name = "btnAceptar";
         this.btnAceptar.Size = new System.Drawing.Size(75, 23);
         this.btnAceptar.TabIndex = 0;
         this.btnAceptar.Text = "Aceptar";
         this.btnAceptar.UseVisualStyleBackColor = true;
         // 
         // clbList_Codigo
         // 
         this.clbList_Codigo.BackColor = System.Drawing.Color.LightSteelBlue;
         this.clbList_Codigo.Dock = System.Windows.Forms.DockStyle.Fill;
         this.clbList_Codigo.Location = new System.Drawing.Point(0, 0);
         this.clbList_Codigo.Name = "clbList_Codigo";
         this.clbList_Codigo.Size = new System.Drawing.Size(228, 275);
         this.clbList_Codigo.TabIndex = 5;
         this.clbList_Codigo.UseCompatibleStateImageBehavior = false;
         // 
         // PAR000AView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(228, 309);
         this.ControlBox = false;
         this.Controls.Add(this.clbList_Codigo);
         this.Controls.Add(this.pnlBotones);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PAR000AView";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "AYUDA";
         this.pnlBotones.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel pnlBotones;
      private System.Windows.Forms.Button btnCancelar;
      private System.Windows.Forms.Button btnAceptar;
      private System.Windows.Forms.ListView clbList_Codigo;
   }
}