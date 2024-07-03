using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace loreca
{
    public partial class Form3 : Form
    {
        const string baglantı = "server=localhost; Database=dbisitme_merkezi; user ID=postgres; password=123";
        NpgsqlConnection conn = new NpgsqlConnection(baglantı);
        NpgsqlCommand cmd;
        NpgsqlDataAdapter da;
        DataTable dt;
        string sql;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            render_table();
            musteri_combobox();
            cihaz_combobox();
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

        private void musteri_combobox()
        {
            try
            {
                conn.Open();
                sql = "SELECT * FROM musteri";
                cmd = new NpgsqlCommand(sql, conn);
                da = new NpgsqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);


                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "ad_soyad";
                comboBox1.ValueMember = "id";

                comboBox1.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Teslim işlemi yapılırken combobox1'de bir hata oluştu: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }

        }
        private void cihaz_combobox()
        {
            try
            {
                conn.Open();
                sql = "SELECT marka, barkod FROM cihaz";
                cmd = new NpgsqlCommand(sql, conn);
                da = new NpgsqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    row["marka"] = row["marka"] + " - " + row["barkod"];
                }

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "marka";
                comboBox2.ValueMember = "barkod";

                comboBox2.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Teslim işlemi yapılırken combobox2'de bir hata oluştu: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }
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

        private void stokEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void stokTemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.Show();
        }
        private void raporlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            form5.Show();
        }

        private void musteri_sil()
        {
            try
            {
                conn.Open();

                // Seçilen müşteri ID'sini alın (integer olarak)
                int musteriID = Convert.ToInt32(comboBox1.SelectedValue);

                // Cihaz tablosundaki ilgili kayıtların cihaz_id'sini null olarak güncelle
                string cihazUpdateSql = $"UPDATE cihaz SET cihaz_id = NULL WHERE cihaz_id IN (SELECT id FROM musteri WHERE id = @musteriID)";
                NpgsqlCommand cihazUpdateCmd = new NpgsqlCommand(cihazUpdateSql, conn);
                cihazUpdateCmd.Parameters.AddWithValue("@musteriID", musteriID);
                cihazUpdateCmd.ExecuteNonQuery();

                // Müşteri tablosundan ilgili müşteriyi sil
                string musteriDeleteSql = $"DELETE FROM musteri WHERE id = @musteriID";
                NpgsqlCommand musteriDeleteCmd = new NpgsqlCommand(musteriDeleteSql, conn);
                musteriDeleteCmd.Parameters.AddWithValue("@musteriID", musteriID);
                musteriDeleteCmd.ExecuteNonQuery();

                // DataGridView'i güncel veri tablosuyla yeniden doldur
                dataGridView1.DataSource = dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri eklerken bir hata oluştu: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        private void cihaz_sil()
        {
            try
            {
                string barkod = comboBox2.SelectedValue.ToString();
                conn.Open();
                string sql = $"DELETE FROM cihaz WHERE barkod = '{barkod}'";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Teslim işleminde bir hata oluştu: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            musteri_sil();
            render_table();
            musteri_combobox();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cihaz_sil();
            render_table();
            musteri_combobox();
        }

        
    }
}
