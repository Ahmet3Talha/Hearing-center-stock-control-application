using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace loreca
{
    public partial class Form2 : Form
    {
        const string baglantı = "server=localhost; Database=dbisitme_merkezi; user ID=postgres; password=123";
        NpgsqlConnection conn = new NpgsqlConnection(baglantı);
        NpgsqlCommand cmd;
        NpgsqlDataAdapter da;
        DataTable dt;
        string sql;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Yuvarlaklık derecesini belirleyin
            int roundness = 20;

            // Yuvarlak buton oluştur
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, roundness, roundness, 180, 90);
            path.AddArc(button1.Width - roundness, 0, roundness, roundness, 270, 90);
            path.AddArc(button1.Width - roundness, button1.Height - roundness, roundness, roundness, 0, 90);
            path.AddArc(0, button1.Height - roundness, roundness, roundness, 90, 90);
            path.CloseFigure();

            // Butonun Region özelliğine elipsi ata
            button1.Region = new Region(path);
            button2.Region = new Region(path);
            button3.Region = new Region(path);
            button4.Region = new Region(path);

            render_table();

            musteri_combobox();
            cihaz_combobox();
        }

   

        private void render_table()
        {
            try
            {
                conn.Open();
                sql="SELECT musteri.tcno, musteri.ad_soyad, cihaz.marka, cihaz.barkod, cihaz.seri_no FROM musteri FULL JOIN cihaz ON musteri.id = NULLIF(CAST(NULLIF(cihaz.cihaz_id, '') AS INTEGER), 0);";
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
                sql = "SELECT marka, barkod FROM cihaz WHERE cihaz_id IS NULL";
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

        private void teslim_islemi()
        {
            try
            {
                conn.Open();

                string musteriID = comboBox1.SelectedValue.ToString();
                string barkod = comboBox2.SelectedValue.ToString();

                string sql = "UPDATE cihaz SET cihaz_id = @musteriID WHERE barkod = @barkod;";

                // NpgsqlCommand oluştur
                cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@musteriID", musteriID);
                cmd.Parameters.AddWithValue("@barkod", barkod);

                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Teslim işlemi yapılırken bir hata oluştu: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        private void musteri_ekle()
        {
            try
            {
                conn.Open();
                sql = $"INSERT INTO musteri (tcno,ad_soyad) VALUES ('{textBox4.Text}', '{textBox5.Text}')";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Müştteri eklerken bir hata oluştu: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }


        }

        private void cihaz_ekle()
        {
            try
            {
                conn.Open();
                sql = $"INSERT INTO cihaz (marka,barkod,seri_no) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}')";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cihaz eklerken bir hata oluştu: " + ex.Message);
            }

            finally
            {
                conn.Close();
            }


        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            cihaz_ekle();
            render_table();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            musteri_ekle();
            render_table();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            teslim_islemi();
            render_table();
            musteri_combobox();
            cihaz_combobox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CihazIdDegerleriniNullYap();
            render_table();
            cihaz_combobox();
        }

        private void CihazIdDegerleriniNullYap()
        {
            try
            {
                conn.Open();

                string sql = "UPDATE cihaz SET cihaz_id = NULL";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Tüm cihaz_id değerleri null yapıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cihaz_id değerleri null yapılmaya çalışılırken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
