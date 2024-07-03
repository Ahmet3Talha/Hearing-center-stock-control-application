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

namespace loreca
{
    public partial class Form4 : Form
    {
        const string baglantı = "server=localhost; Database=dbisitme_merkezi; user ID=postgres; password=123";
        NpgsqlConnection conn = new NpgsqlConnection(baglantı);
        NpgsqlCommand cmd;
        NpgsqlDataAdapter da;
        DataTable dt;
        string sql;

        public Form4()
        {
            InitializeComponent();
        }

        private void anaEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
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
        private void raporlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            form5.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form4_Load(object sender, EventArgs e)
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
                sql = "SELECT musteri.tcno, musteri.ad_soyad, cihaz.marka, cihaz.barkod, cihaz.seri_no FROM musteri FULL OUTER JOIN cihaz ON musteri.id = cihaz.cihaz_id ORDER BY musteri.ad_soyad;";
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

        private void musteri_guncelle()
        {
            try
            {
                conn.Open();
                sql = "UPDATE musteri SET ad_soyad = @adSoyad, tcno = @tcno WHERE id = @musteriID";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@adSoyad", textBox1.Text); // TextBox1'deki değeri ad_soyad alanı için kullan
                cmd.Parameters.AddWithValue("@tcno", textBox2.Text); // TextBox2'deki değeri tcno alanı için kullan
                cmd.Parameters.AddWithValue("@musteriID", comboBox1.SelectedValue); // ComboBox'tan seçilen müşteri ID'sini parametre olarak kullan

                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri bilgileri güncellenirken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void cihaz_guncelle()
        {
            try
            {
                conn.Open();
                sql = "UPDATE cihaz SET marka = @marka, barkod = @barkod, seri_no = @serino WHERE barkod = @cihazID";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@marka", textBox5.Text); 
                cmd.Parameters.AddWithValue("@barkod", textBox4.Text); 
                cmd.Parameters.AddWithValue("@serino", textBox3.Text); 
                cmd.Parameters.AddWithValue("@cihazID", comboBox2.SelectedValue);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri bilgileri güncellenirken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                    conn.Close();
            }
        }




        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteri_guncelle();
            render_table();
            musteri_combobox();
            cihaz_combobox();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cihaz_guncelle();
            render_table();
            musteri_combobox();
            cihaz_combobox();
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

       
    }

}
