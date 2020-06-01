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
    public partial class urunsatinalma : Form
    {
        string urunfoto,urunadi,fiyati,stok,ram,ekrankarti,islemci,harddisk,sifre,adres,urun;

        string kullaniciadi = frmGiris.kullaniciadi;
       
        private void btnsatinal_Click(object sender, EventArgs e)
        {            
            SqlCommand sorgusoru = new SqlCommand("select * from UyeKayitlarii where kuladi=@kuladi  ", baglanti);
            sorgusoru.Parameters.AddWithValue("@kuladi", kullaniciadi);         
            SqlDataReader sdr;
            baglanti.Open();
            sdr = sorgusoru.ExecuteReader();
            while (sdr.Read())
            {               
                sifre = sdr[7].ToString();
                adres = sdr[9].ToString();
                urun = lblurunadi.Text;
            }                       
            baglanti.Close();

            SqlCommand sorgu = new SqlCommand("insert into satinalinanurunler (kullaniciadi,sifre,adres,urunadi) values (@kullaniciadi,@sifre,@adres,@urunadi)", baglanti);
            sorgu.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
            sorgu.Parameters.AddWithValue("@sifre", sifre);
            sorgu.Parameters.AddWithValue("@adres", adres);
            sorgu.Parameters.AddWithValue("@urunadi", urunadi);           
            {              
                baglanti.Open();
                sorgu.ExecuteNonQuery();
                baglanti.Close();

                int stoki = Convert.ToInt16(lblstok.Text);   
                if (stoki <= 0) { btnsatinal.Enabled = false; }
                else MessageBox.Show("Ürün Satın Alınmıştır");                               
                stoki--;
                lblstok.Text = stoki.ToString();
                if (stoki <= 0)
                {
                    MessageBox.Show("Son Ürün Satın Alındı");
                    btnsatinal.Enabled = false;
                }

                SqlCommand sorguguncelle = new SqlCommand("update urun set stok=@yenistok where urunadi=@urunadi", baglanti);
                sorguguncelle.Parameters.AddWithValue("@urunadi", lblurunadi.Text);
                sorguguncelle.Parameters.AddWithValue("@yenistok", lblstok.Text);

                baglanti.Open();
                sorguguncelle.ExecuteNonQuery();
                baglanti.Close();

            }



        }
        SqlConnection baglanti = new SqlConnection("server=OZCANKARAKUS;Database = UyeKayit; Trusted_Connection = True;");

        public urunsatinalma(string urnfoto,string urnadi,string fyati,string stk,string rm,string ekrnkrti,string islmci,string hrddsk)
        {
            urunfoto = urnfoto;
            urunadi = urnadi;
            fiyati = fyati;
            stok = stk;
            ram = rm;
            ekrankarti = ekrnkrti;
            islemci = islmci;
            harddisk = hrddsk;
           
            InitializeComponent();
        }

        private void urunsatinalma_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(urunfoto);           
            lblurunadi.Text = urunadi;
            lblfiyati.Text = fiyati;
            lblstok.Text = stok;
            lblram.Text = ram;
            lblekrankarti.Text = ekrankarti;
            lblislemci.Text = islemci;
            lblharddisk.Text = harddisk;
            int stokk = Convert.ToInt16(lblstok.Text);
            if (stokk <= 0) { btnsatinal.Enabled = false; }
        }

        private void btndonus_Click(object sender, EventArgs e)
        {
            frmlaptop frmlap = new frmlaptop();
            frmlap.Show();
            this.Hide();
        }
    }
}
