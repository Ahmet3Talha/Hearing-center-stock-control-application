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
    public partial class Form6 : Form
    {
        const string baglantı = "server=localhost; Database=dbisitme_merkezi; user ID=postgres; password=123";
        NpgsqlConnection conn = new NpgsqlConnection(baglantı);
        NpgsqlCommand cmd;
        NpgsqlDataAdapter da;
        DataTable dt;
        string sql;
        public Form6()
        {
            InitializeComponent();
        }
        private void kontrol()
        {
            try
            {
                conn.Open();
                string sql = "select isim,sifre from kullanicilar where isim =@isim";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@isim", textBox1.Text);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    string veritabani_sifre = dr["sifre"].ToString();

                    if (textBox2.Text == veritabani_sifre)
                    {
                            Form1 form1 = new Form1();
                             this.Hide();
                            form1.Show();     
                    }
                    else
                    {
                        MessageBox.Show("Hatalı şifre.");
                    }
                }

                else
                {
                    MessageBox.Show("Aranan kullanıcı bulunamadı");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
            }

            finally
            {

                conn.Close();
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            kontrol();
        }
    }
}
