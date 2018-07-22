namespace DWDR_SL_Client
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.menüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.universumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inhalteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basistypenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffneEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 597);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1547, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menüToolStripMenuItem,
            this.inhalteToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1547, 24);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // menüToolStripMenuItem
            // 
            this.menüToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.universumToolStripMenuItem,
            this.beendenToolStripMenuItem});
            this.menüToolStripMenuItem.Name = "menüToolStripMenuItem";
            this.menüToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menüToolStripMenuItem.Text = "Menü";
            // 
            // universumToolStripMenuItem
            // 
            this.universumToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuladenToolStripMenuItem});
            this.universumToolStripMenuItem.Name = "universumToolStripMenuItem";
            this.universumToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.universumToolStripMenuItem.Text = "Universum";
            // 
            // neuladenToolStripMenuItem
            // 
            this.neuladenToolStripMenuItem.Name = "neuladenToolStripMenuItem";
            this.neuladenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.neuladenToolStripMenuItem.Text = "Neuladen";
            this.neuladenToolStripMenuItem.Click += new System.EventHandler(this.neuladenToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // inhalteToolStripMenuItem
            // 
            this.inhalteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basistypenToolStripMenuItem});
            this.inhalteToolStripMenuItem.Name = "inhalteToolStripMenuItem";
            this.inhalteToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.inhalteToolStripMenuItem.Text = "Inhalte";
            // 
            // basistypenToolStripMenuItem
            // 
            this.basistypenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffneEditorToolStripMenuItem});
            this.basistypenToolStripMenuItem.Name = "basistypenToolStripMenuItem";
            this.basistypenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.basistypenToolStripMenuItem.Text = "Basistypen";
            // 
            // öffneEditorToolStripMenuItem
            // 
            this.öffneEditorToolStripMenuItem.Name = "öffneEditorToolStripMenuItem";
            this.öffneEditorToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.öffneEditorToolStripMenuItem.Text = "Öffne Editor";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 619);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem universumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inhalteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basistypenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffneEditorToolStripMenuItem;

    }
}

