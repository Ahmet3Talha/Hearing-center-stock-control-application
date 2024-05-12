namespace loreca
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stokMenüsüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokTemizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.satışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(90)))), ((int)(((byte)(116)))));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stokMenüsüToolStripMenuItem,
            this.satışToolStripMenuItem,
            this.raporlamaToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(890, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stokMenüsüToolStripMenuItem
            // 
            this.stokMenüsüToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(90)))), ((int)(((byte)(116)))));
            this.stokMenüsüToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stokEkleToolStripMenuItem,
            this.stokGüncelleToolStripMenuItem,
            this.stokTemizleToolStripMenuItem});
            this.stokMenüsüToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.stokMenüsüToolStripMenuItem.Name = "stokMenüsüToolStripMenuItem";
            this.stokMenüsüToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.stokMenüsüToolStripMenuItem.Text = "Stok Yönetimi";
            this.stokMenüsüToolStripMenuItem.Click += new System.EventHandler(this.stokMenüsüToolStripMenuItem_Click);
            // 
            // stokEkleToolStripMenuItem
            // 
            this.stokEkleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(90)))), ((int)(((byte)(116)))));
            this.stokEkleToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.stokEkleToolStripMenuItem.Name = "stokEkleToolStripMenuItem";
            this.stokEkleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stokEkleToolStripMenuItem.Text = "Ekle";
            this.stokEkleToolStripMenuItem.Click += new System.EventHandler(this.stokEkleToolStripMenuItem_Click);
            // 
            // stokGüncelleToolStripMenuItem
            // 
            this.stokGüncelleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(90)))), ((int)(((byte)(116)))));
            this.stokGüncelleToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.stokGüncelleToolStripMenuItem.Name = "stokGüncelleToolStripMenuItem";
            this.stokGüncelleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stokGüncelleToolStripMenuItem.Text = "Çıkar";
            this.stokGüncelleToolStripMenuItem.Click += new System.EventHandler(this.stokGüncelleToolStripMenuItem_Click);
            // 
            // stokTemizleToolStripMenuItem
            // 
            this.stokTemizleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(90)))), ((int)(((byte)(116)))));
            this.stokTemizleToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.stokTemizleToolStripMenuItem.Name = "stokTemizleToolStripMenuItem";
            this.stokTemizleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stokTemizleToolStripMenuItem.Text = "Güncelle";
            // 
            // satışToolStripMenuItem
            // 
            this.satışToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.satışToolStripMenuItem.Name = "satışToolStripMenuItem";
            this.satışToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.satışToolStripMenuItem.Text = "Satış";
            // 
            // raporlamaToolStripMenuItem
            // 
            this.raporlamaToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.raporlamaToolStripMenuItem.Name = "raporlamaToolStripMenuItem";
            this.raporlamaToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.raporlamaToolStripMenuItem.Text = "Raporlama";
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(117)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(890, 462);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Giriş Ekranı";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stokMenüsüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokTemizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem satışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
    }
}

