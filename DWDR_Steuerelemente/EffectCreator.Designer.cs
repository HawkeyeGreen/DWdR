namespace DWDR_Steuerelemente
{
    partial class EffectCreator
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createMe = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.deployOptions = new System.Windows.Forms.TabPage();
            this.effectOptions = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.effectOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.createMe);
            this.groupBox1.Location = new System.Drawing.Point(108, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 337);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Neuer Effekt";
            // 
            // createMe
            // 
            this.createMe.Location = new System.Drawing.Point(78, 308);
            this.createMe.Name = "createMe";
            this.createMe.Size = new System.Drawing.Size(75, 23);
            this.createMe.TabIndex = 0;
            this.createMe.Text = "Erstellen!";
            this.createMe.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Anzeigename:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.deployOptions);
            this.tabControl1.Controls.Add(this.effectOptions);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(298, 283);
            this.tabControl1.TabIndex = 3;
            // 
            // deployOptions
            // 
            this.deployOptions.Location = new System.Drawing.Point(4, 22);
            this.deployOptions.Name = "deployOptions";
            this.deployOptions.Padding = new System.Windows.Forms.Padding(3);
            this.deployOptions.Size = new System.Drawing.Size(290, 257);
            this.deployOptions.TabIndex = 0;
            this.deployOptions.Text = "Verteilung";
            this.deployOptions.UseVisualStyleBackColor = true;
            // 
            // effectOptions
            // 
            this.effectOptions.Controls.Add(this.textBox1);
            this.effectOptions.Controls.Add(this.label1);
            this.effectOptions.Location = new System.Drawing.Point(4, 22);
            this.effectOptions.Name = "effectOptions";
            this.effectOptions.Padding = new System.Windows.Forms.Padding(3);
            this.effectOptions.Size = new System.Drawing.Size(290, 257);
            this.effectOptions.TabIndex = 1;
            this.effectOptions.Text = "Effekt";
            this.effectOptions.UseVisualStyleBackColor = true;
            // 
            // EffectCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "EffectCreator";
            this.Size = new System.Drawing.Size(800, 450);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.effectOptions.ResumeLayout(false);
            this.effectOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage deployOptions;
        private System.Windows.Forms.TabPage effectOptions;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createMe;
    }
}
