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
            this.label1 = new System.Windows.Forms.Label();
            this.Typ = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Modus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Wert = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Runden = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.WertAnzeige = new System.Windows.Forms.Label();
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
            this.neuladenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
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
            this.öffneEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.öffneEditorToolStripMenuItem.Text = "Öffne Editor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Modifier Typ";
            // 
            // Typ
            // 
            this.Typ.FormattingEnabled = true;
            this.Typ.Items.AddRange(new object[] {
            "Additiv I",
            "Multiplikativ I",
            "Additiv II",
            "Multiplikativ II",
            "Additiv III"});
            this.Typ.Location = new System.Drawing.Point(244, 111);
            this.Typ.Name = "Typ";
            this.Typ.Size = new System.Drawing.Size(136, 21);
            this.Typ.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Value";
            // 
            // Modus
            // 
            this.Modus.FormattingEnabled = true;
            this.Modus.Items.AddRange(new object[] {
            "Static",
            "Counting"});
            this.Modus.Location = new System.Drawing.Point(244, 84);
            this.Modus.Name = "Modus";
            this.Modus.Size = new System.Drawing.Size(136, 21);
            this.Modus.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Modifier Modus";
            // 
            // Wert
            // 
            this.Wert.Location = new System.Drawing.Point(244, 141);
            this.Wert.Name = "Wert";
            this.Wert.Size = new System.Drawing.Size(136, 20);
            this.Wert.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(244, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Teste mich!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Runden
            // 
            this.Runden.Location = new System.Drawing.Point(244, 167);
            this.Runden.Name = "Runden";
            this.Runden.Size = new System.Drawing.Size(136, 20);
            this.Runden.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Vergangene Runden";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ergebnis";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(129, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Konglomerierter Wert:";
            // 
            // WertAnzeige
            // 
            this.WertAnzeige.AutoSize = true;
            this.WertAnzeige.Location = new System.Drawing.Point(387, 143);
            this.WertAnzeige.Name = "WertAnzeige";
            this.WertAnzeige.Size = new System.Drawing.Size(30, 13);
            this.WertAnzeige.TabIndex = 16;
            this.WertAnzeige.Text = "Wert";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 619);
            this.Controls.Add(this.WertAnzeige);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Runden);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Wert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Modus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Typ);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Typ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Modus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Wert;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Runden;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label WertAnzeige;

    }
}

