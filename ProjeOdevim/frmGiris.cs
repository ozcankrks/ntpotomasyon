using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ProjeOdevim
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=OZCANKARAKUS;Database = UyeKayit; Trusted_Connection = True;");
     
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmKayit frmkayit = new frmKayit();
            frmkayit.Show();
            this.Hide();
        }
        public static string kullaniciadi;
        private void button1_Click(object sender, EventArgs e)
        {
            kullaniciadi = txtkuladi.Text;
            string sifre = txtsifre.Text;
            SqlCommand sorgucek = new SqlCommand("select * from UyeKayitlarii ", baglanti);
            SqlDataReader sdr;
            baglanti.Open();
            sdr = sorgucek.ExecuteReader();
            int sayac = 0;

            while (sdr.Read())
            {
                string gelenkullanici = (sdr[6]).ToString();
                string gelensifre = (sdr[7]).ToString();             

                if ((gelenkullanici == kullaniciadi) && (gelensifre == sifre))
                {
                    sayac++;
                    frmkullanici frmkul = new frmkullanici();
                    frmkul.Show();                   
                    this.Hide();
                }             
            }

            if (sayac == 0)
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre!!");
            }
            baglanti.Close();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmsifremiunuttum frmsifreunuttum = new frmsifremiunuttum();
            frmsifreunuttum.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kullaniciadi = txtkuladi.Text;
            string sifre = txtsifre.Text;
            SqlCommand sorgucek = new SqlCommand("select * from admin ", baglanti);
            SqlDataReader sdr;
            baglanti.Open();
            sdr = sorgucek.ExecuteReader();
            int sayac = 0;
            while (sdr.Read())
            {
                string gelenkullanici = (sdr[1]).ToString();
                string gelensifre = (sdr[2]).ToString();

                if ((gelenkullanici == kullaniciadi) && (gelensifre == sifre))
                {
                    sayac++;
                    frmadmin frmadmin = new frmadmin();
                    frmadmin.Show();
                    this.Hide();
                }
            }
                 if (sayac == 0)
                {
                    MessageBox.Show("Yanlış kullanıcı adı veya şifre!!");
                }
                baglanti.Close();
            }
        }
    }

