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
    public partial class frmkulbilgiguncel : Form
    {
        public frmkulbilgiguncel()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=OZCANKARAKUS;Database = UyeKayit; Trusted_Connection = True;");

        string gizlisoru = "";




        string dosyayolu, dosyaadi, secilicinsiyet;
        string kuladi = frmGiris.kullaniciadi;
        private void button1_Click(object sender, EventArgs e)
        {
            frmkullanici frmkullanici = new frmkullanici();
            frmkullanici.Show();
            this.Hide();
        }

        private void btnguncelle_Click_1(object sender, EventArgs e)
        {
            if (rdioerkek.Checked == true) secilicinsiyet = rdioerkek.Text;
            if (rdiokiz.Checked == true) secilicinsiyet = rdiokiz.Text;
            SqlCommand sorguguncelle = new SqlCommand("update UyeKayitlarii set  ad=@ad,soyad=@soyad,cinsiyet=@cinsiyet,dogumtarihi=@dogumtarihi,email=@email,kuladi=@kuladi,sifre=@sifre,telno=@telno,adres=@adres,gizlisoru=@gizlisoru,cevap=@cevap where kuladi=@kuladi", baglanti);
            sorguguncelle.Parameters.AddWithValue("@ad", txtad.Text);
            sorguguncelle.Parameters.AddWithValue("@soyad", txtsoyad.Text);
            sorguguncelle.Parameters.AddWithValue("@cinsiyet", secilicinsiyet);
            sorguguncelle.Parameters.AddWithValue("@dogumtarihi", txttarih.Text);
            sorguguncelle.Parameters.AddWithValue("@email", txtemail.Text);
            sorguguncelle.Parameters.AddWithValue("@kuladi", txtkuladi.Text);
            sorguguncelle.Parameters.AddWithValue("@sifre", txtsifre.Text);
            sorguguncelle.Parameters.AddWithValue("@telno", txttelno.Text);
            sorguguncelle.Parameters.AddWithValue("@adres", richtxtadres.Text);
            sorguguncelle.Parameters.AddWithValue("@gizlisoru", gizlisoru);
            sorguguncelle.Parameters.AddWithValue("@cevap", txtcevab.Text);
         
            baglanti.Open();
            sorguguncelle.ExecuteNonQuery();
            baglanti.Close();

            SqlCommand guncelleiki = new SqlCommand("update satinalinanurunler set  adres=@adres where kullaniciadi=@kullaniciadi", baglanti);
            guncelleiki.Parameters.AddWithValue("@kullaniciadi", txtkuladi.Text);
            guncelleiki.Parameters.AddWithValue("@adres", richtxtadres.Text);
            baglanti.Open();
            guncelleiki.ExecuteNonQuery();
            baglanti.Close();


        }
 
        private void btngetir_Click_1(object sender, EventArgs e)
        {
          
        }

        private void frmkulbilgiguncel_Load(object sender, EventArgs e)
        {
            SqlCommand sorgucek = new SqlCommand("select * from UyeKayitlarii where kuladi=@kulad ", baglanti);
            sorgucek.Parameters.AddWithValue("@kulad", kuladi);

            SqlDataReader alan;

            baglanti.Open();
            alan = sorgucek.ExecuteReader();

            while (alan.Read())
            {
                txtad.Text = alan[1].ToString();
                txtsoyad.Text = alan[2].ToString();
                if (rdioerkek.Text == alan[3].ToString())
              {
                  rdioerkek.Checked = true;
                }
                else
                {
                    rdiokiz.Checked = true;
                }
                txttarih.Text = alan[4].ToString();
              txtemail.Text=  alan[5].ToString();
              txtkuladi.Text=  alan[6].ToString();
               txtsifre.Text= alan[7].ToString();
               txttelno.Text= alan[8].ToString();
               richtxtadres.Text= alan[9].ToString();
              cmbgizlisoru.Text=  alan[10].ToString();
              
              txtcevab.Text=  alan[11].ToString();
            }
            baglanti.Close();
            txtkuladi.Enabled = false;
            txtsifre.Enabled = false;
        }

        private void btngncel_Click(object sender, EventArgs e)
        {
            SqlCommand sorguguncelle = new SqlCommand("update UyeKayitlarii set resim=@resim where kuladi=@kuladi", baglanti);          
            sorguguncelle.Parameters.AddWithValue("@kuladi", kuladi);
            sorguguncelle.Parameters.AddWithValue("@resim", dosyaadi);
            baglanti.Open();
            sorguguncelle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void cmbgizlisoru_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            gizlisoru = cmbgizlisoru.Text;
        }

        private void btnfotodegistr_Click(object sender, EventArgs e)
        {
            foto.InitialDirectory = "g:\\";//fotoyu nereden alacağını göster
            if (foto.ShowDialog() == DialogResult.OK)//arayüzü açmak için
            {
                dosyayolu = foto.FileName;//dosyanının yolunu al
                dosyaadi = foto.SafeFileName;//dosyanın adını al
                pictureBox1.Image = Image.FromFile(dosyayolu);//dosyayı pictureBox ta göster
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//fotoyu sığdır
                pictureBox1.Image.Save(foto.SafeFileName);
            }
        }
    }
}


