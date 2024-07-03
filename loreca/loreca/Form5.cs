using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loreca
{
    public partial class Form5 : Form
    {
        const string baglantı = "server=localhost; Database=dbisitme_merkezi; user ID=postgres; password=123";
        NpgsqlConnection conn = new NpgsqlConnection(baglantı);
        NpgsqlCommand cmd;
        NpgsqlDataAdapter da;
        DataTable dt;
        NpgsqlDataReader dr;   
        string sql;
        public Form5()
        {
            InitializeComponent();
        }

        private void stokEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void stokGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void stokTemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }

        private void anaEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            render_table();
            listele();
        }

        private void render_table()
        {
            try
            {
                conn.Open();
                sql = "SELECT musteri.tcno, musteri.ad_soyad, cihaz.marka, cihaz.barkod, cihaz.seri_no FROM musteri FULL OUTER JOIN cihaz ON musteri.id = cihaz.cihaz_id ORDER BY 2;";
                da = new NpgsqlDataAdapter(sql, conn);
                dt = new DataTable();
                da.Fill(dt);


                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tablo yüklenirken bir hata oluştu: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }


        }

        private void listele()
        {
            try
            {
                conn.Open();
                sql = "SELECT * FROM cihaz WHERE cihaz_id IS NULL";
                cmd = new NpgsqlCommand(sql, conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string row = $"{dr["marka"]} {dr["barkod"]} {dr["seri_no"]}";
                    listBox1.Items.Add(row);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tablo yüklenirken bir hata oluştu: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        private void kopyala()
        {
            string items = string.Join(Environment.NewLine, listBox1.Items.Cast<string>());

            // Bu stringi panoya kopyalayın
            Clipboard.SetText(items);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kopyala();
        }
    }
}
