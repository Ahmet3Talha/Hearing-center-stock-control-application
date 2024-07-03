namespace loreca
{
    partial class Form5
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anaEkranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokMenüsüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokTemizleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(90)))), ((int)(((byte)(116)))));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaEkranToolStripMenuItem,
            this.stokMenüsüToolStripMenuItem,
            this.raporlamaToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1085, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anaEkranToolStripMenuItem
            // 
            this.anaEkranToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.anaEkranToolStripMenuItem.Name = "anaEkranToolStripMenuItem";
            this.anaEkranToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.anaEkranToolStripMenuItem.Text = "Ana Ekran";
            this.anaEkranToolStripMenuItem.Click += new System.EventHandler(this.anaEkranToolStripMenuItem_Click);
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
            // 
            // stokEkleToolStripMenuItem
            // 
            this.stokEkleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(90)))), ((int)(((byte)(116)))));
            this.stokEkleToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.stokEkleToolStripMenuItem.Name = "stokEkleToolStripMenuItem";
            this.stokEkleToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.stokEkleToolStripMenuItem.Text = "Ekle";
            this.stokEkleToolStripMenuItem.Click += new System.EventHandler(this.stokEkleToolStripMenuItem_Click);
            // 
            // stokGüncelleToolStripMenuItem
            // 
            this.stokGüncelleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(90)))), ((int)(((byte)(116)))));
            this.stokGüncelleToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.stokGüncelleToolStripMenuItem.Name = "stokGüncelleToolStripMenuItem";
            this.stokGüncelleToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.stokGüncelleToolStripMenuItem.Text = "Çıkar";
            this.stokGüncelleToolStripMenuItem.Click += new System.EventHandler(this.stokGüncelleToolStripMenuItem_Click);
            // 
            // stokTemizleToolStripMenuItem
            // 
            this.stokTemizleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(90)))), ((int)(((byte)(116)))));
            this.stokTemizleToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.stokTemizleToolStripMenuItem.Name = "stokTemizleToolStripMenuItem";
            this.stokTemizleToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.stokTemizleToolStripMenuItem.Text = "Güncelle";
            this.stokTemizleToolStripMenuItem.Click += new System.EventHandler(this.stokTemizleToolStripMenuItem_Click);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(133, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "Eldeki Cizhazlar";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(138, 609);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(272, 160);
            this.listBox1.TabIndex = 35;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(645, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(709, 754);
            this.dataGridView1.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(92, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 31);
            this.label2.TabIndex = 36;
            this.label2.Text = "Satış Durum Tablosu";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(90)))), ((int)(((byte)(116)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Snow;
            this.button4.Location = new System.Drawing.Point(344, 543);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button4.Size = new System.Drawing.Size(66, 31);
            this.button4.TabIndex = 37;
            this.button4.Text = "Kopyala";
            this.button4.UseMnemonic = false;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(117)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(1085, 832);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form5";
            this.Text = "Raporlama";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form5_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anaEkranToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokMenüsüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokTemizleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlamaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
    }
}