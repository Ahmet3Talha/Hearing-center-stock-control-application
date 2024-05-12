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
            //int roundness = 20;

            // Yuvarlak buton oluştur
            //GraphicsPath path = new GraphicsPath();
            //path.AddArc(0, 0, roundness, roundness, 180, 90);
            //path.AddArc(button3.Width - roundness, 0, roundness, roundness, 270, 90);
            //path.AddArc(button3.Width - roundness, button3.Height - roundness, roundness, roundness, 0, 90);
            //path.AddArc(0, button3.Height - roundness, roundness, roundness, 90, 90);
            //path.CloseFigure();

            //// Butonun Region özelliğine elipsi ata

            //button3.Region = new Region(path);
            //button4.Region = new Region(path);

            render_table();

            musteri_combobox();
            cihaz_combobox();
            iptal_combobox();
        }

   

        private void render_table()
        {
            try
            {
                conn.Open();
                sql= "SELECT musteri.tcno, musteri.ad_soyad, cihaz.marka, cihaz.barkod, cihaz.seri_no FROM musteri FULL OUTER JOIN cihaz ON musteri.id = cihaz.cihaz_id ORDER BY 2;";
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

        private void iptal_combobox()
        {
            try
            {
                conn.Open();
                sql = "SELECT marka, barkod FROM cihaz WHERE cihaz_id IS NOT NULL";
                cmd = new NpgsqlCommand(sql, conn);
                da = new NpgsqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    row["marka"] = row["marka"] + " - " + row["barkod"];
                }

                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "marka";
                comboBox3.ValueMember = "barkod";

                comboBox3.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Teslim işlemi yapılırken combobox3'de bir hata oluştu: " + ex.Message);
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
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
                {
                    conn.Open();

                    int musteriID = Convert.ToInt32(comboBox1.SelectedValue);
                    string barkod = comboBox2.SelectedValue.ToString();

                    string sql = "UPDATE cihaz SET cihaz_id = @musteriID WHERE barkod = @barkod;";

                    cmd = new NpgsqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@musteriID", musteriID);
                    cmd.Parameters.AddWithValue("@barkod", barkod);

                    cmd.ExecuteNonQuery();
                }
                else if (comboBox1.SelectedValue == null && comboBox2.SelectedValue != null)
                {
                    MessageBox.Show($"İşlemin gerçekleşmesi için {label9.Text} seçeneğine bir değer vermeniz gerekmektedir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (comboBox2.SelectedValue == null && comboBox1.SelectedValue != null)
                {
                    MessageBox.Show($"İşlemin gerçekleşmesi için {label10.Text} seçeneğine bir değer vermeniz gerekmektedir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"İşlemin gerçekleşmesi için {label9.Text} ve {label10.Text} seçeneklerine bir değer vermeniz gerekmektedir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

        private void CihazIdDegerleriniNullYap()
        {
            try
            {


                conn.Open();

                string sql = $"UPDATE cihaz SET cihaz_id = NULL WHERE barkod='{comboBox3.SelectedValue}';";

                cmd = new NpgsqlCommand(sql, conn);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show($" '{comboBox2.SelectedValue}' cihazının cihaz_id değeri null yapılmaya çalışılırken bir hata oluştu: " + ex.Message);
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
                MessageBox.Show("Müşteri eklerken bir hata oluştu: " + ex.Message);
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
            musteri_combobox();
            cihaz_combobox();
            iptal_combobox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            musteri_ekle();
            render_table();
            musteri_combobox();
            cihaz_combobox();
            iptal_combobox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            teslim_islemi();
            render_table();
            musteri_combobox();
            cihaz_combobox();
            iptal_combobox();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CihazIdDegerleriniNullYap();
            render_table();
            cihaz_combobox();
            iptal_combobox();
        }

        private void anaEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void stokGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.Show();
        }

        private void stokTemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
