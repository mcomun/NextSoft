namespace Delfin.Principal
{
    partial class DOC002DView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DOC002DView));
            this.panelCaption3 = new Infrastructure.WinForms.Controls.PanelCaption();
            this.navItemsFiles = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.grdItemsFiles = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.navItemsFiles)).BeginInit();
            this.navItemsFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsFiles.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCaption3
            // 
            this.panelCaption3.AllowActive = false;
            this.panelCaption3.AntiAlias = false;
            this.panelCaption3.Caption = "Documentos Relacionados";
            this.panelCaption3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.panelCaption3.InactiveGradientHighColor = System.Drawing.Color.SteelBlue;
            this.panelCaption3.InactiveGradientLowColor = System.Drawing.Color.MidnightBlue;
            this.panelCaption3.Location = new System.Drawing.Point(0, 0);
            this.panelCaption3.Name = "panelCaption3";
            this.panelCaption3.Size = new System.Drawing.Size(463, 26);
            this.panelCaption3.TabIndex = 2;
            // 
            // navItemsFiles
            // 
            this.navItemsFiles.AddNewItem = null;
            this.navItemsFiles.BackColor = System.Drawing.Color.LightSteelBlue;
            this.navItemsFiles.CountItem = this.toolStripLabel1;
            this.navItemsFiles.DeleteItem = null;
            this.navItemsFiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navItemsFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator3});
            this.navItemsFiles.Location = new System.Drawing.Point(0, 251);
            this.navItemsFiles.MoveFirstItem = this.toolStripButton4;
            this.navItemsFiles.MoveLastItem = this.toolStripButton1;
            this.navItemsFiles.MoveNextItem = this.toolStripButton2;
            this.navItemsFiles.MovePreviousItem = this.toolStripButton3;
            this.navItemsFiles.Name = "navItemsFiles";
            this.navItemsFiles.PositionItem = this.toolStripTextBox1;
            this.navItemsFiles.Size = new System.Drawing.Size(463, 25);
            this.navItemsFiles.TabIndex = 56;
            this.navItemsFiles.Text = "bindingNavigator1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel1.Text = "de {0}";
            this.toolStripLabel1.ToolTipText = "Número total de elementos";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Mover último";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Mover siguiente";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Posición";
            this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Posición actual";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Mover anterior";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Mover primero";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // grdItemsFiles
            // 
            this.grdItemsFiles.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdItemsFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItemsFiles.Location = new System.Drawing.Point(0, 26);
            this.grdItemsFiles.Margin = new System.Windows.Forms.Padding(2, 3, 18, 3);
            this.grdItemsFiles.Name = "grdItemsFiles";
            // 
            // 
            // 
            this.grdItemsFiles.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 26, 240, 150);
            this.grdItemsFiles.RootElement.MinSize = new System.Drawing.Size(0, 0);
            this.grdItemsFiles.Size = new System.Drawing.Size(463, 225);
            this.grdItemsFiles.TabIndex = 58;
            this.grdItemsFiles.TabStop = false;
            // 
            // DOC002DView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(463, 276);
            this.Controls.Add(this.grdItemsFiles);
            this.Controls.Add(this.navItemsFiles);
            this.Controls.Add(this.panelCaption3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DOC002DView";
            this.Text = "Documentos";
            ((System.ComponentModel.ISupportInitialize)(this.navItemsFiles)).EndInit();
            this.navItemsFiles.ResumeLayout(false);
            this.navItemsFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsFiles.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemsFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infrastructure.WinForms.Controls.PanelCaption panelCaption3;
        private System.Windows.Forms.BindingNavigator navItemsFiles;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private Telerik.WinControls.UI.RadGridView grdItemsFiles;
    }
}