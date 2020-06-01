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
    public partial class frmKayit : Form
    {
        public frmKayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=OZCANKARAKUS;Database = UyeKayit; Trusted_Connection = True;");

        private void frmKayit_Load(object sender, EventArgs e)
        {
            for (int s = 1; s <= 31; s++)
            {
               cmbgun.Items.Add(s);
            }

            for (int c = 1; c <=12; c++)
            {
                cmbay.Items.Add(c);
            }
            for (int i = 2016; i >= 1950; i--)
            {
                cmbyil.Items.Add(i);
            }
        }
       string ay = ""; string gun = ""; string yil = ""; string dogumtarihi = ""; string cinsiyet = "";string gizlisoru = "";
        private void btnkayitol_Click(object sender, EventArgs e)
        {
            int sayaciki = 0;
            sayaciki++;
            if (sayaciki==1)
            {
                string girlenad = txtkuladi.Text;
                SqlCommand sorgucek = new SqlCommand("select * from UyeKayitlarii  ", baglanti);
                SqlDataReader alan;
                baglanti.Open();
                alan = sorgucek.ExecuteReader();
                int sayac = 0;
                while (alan.Read())
                {
                    string gelenkuladi = alan[6].ToString();
                    if (gelenkuladi==girlenad)
                    {
                        sayac++;
                        MessageBox.Show("Bu Kullanıcı Adı Kullanımda !");                    
                    }                  
                }               
                baglanti.Close();
                if (sayac==0)
                {
                    dogumtarihi = gun + "." + ay + "." + yil.ToString();
                    if (rdioerkek.Checked == true) cinsiyet = rdioerkek.Text;
                    if (rdiokiz.Checked == true) cinsiyet = rdiokiz.Text;
                    SqlCommand sorgu = new SqlCommand("insert into UyeKayitlarii (ad,soyad,cinsiyet,dogumtarihi,email,kuladi,sifre,telno,adres,gizlisoru,cevap,resim) values (@ad,@soyad,@cinsiyet,@dogumtarihi,@email,@kuladi,@sifre,@telno,@adres,@gizlisoru,@cevap,@resim)", baglanti);
                    sorgu.Parameters.AddWithValue("@ad", txtad.Text);
                    sorgu.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                    sorgu.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                    sorgu.Parameters.AddWithValue("@dogumtarihi", dogumtarihi);
                    sorgu.Parameters.AddWithValue("@email", txtemail.Text);
                    sorgu.Parameters.AddWithValue("@kuladi", txtkuladi.Text);
                    sorgu.Parameters.AddWithValue("@sifre", txtsifre.Text);
                    sorgu.Parameters.AddWithValue("@telno", txttelno.Text);
                    sorgu.Parameters.AddWithValue("@adres", richtxtadres.Text);
                    sorgu.Parameters.AddWithValue("@gizlisoru", gizlisoru);
                    sorgu.Parameters.AddWithValue("@cevap", txtcevab.Text);
                    sorgu.Parameters.AddWithValue("@resim", dosyaadi);
                    {
                        baglanti.Open();
                        int hata = sorgu.ExecuteNonQuery();
                        if (hata > 1)
                        {
                            MessageBox.Show("HATA!!");
                        }
                        else MessageBox.Show("Bilgiler başarılı bir şekilde kayıt edilmiştir");
                        baglanti.Close();

                    }


                }

            }
        }

        private void btndonus_Click(object sender, EventArgs e)
        {
            frmGiris frm1 = new frmGiris();
            frm1.Show();
            this.Hide();
        }

        private void cmbgizlisoru_SelectedIndexChanged(object sender, EventArgs e)
        {
            gizlisoru = cmbgizlisoru.Text;
        }

   

        private void cmbyil_SelectedIndexChanged(object sender, EventArgs e)
        {
 yil =cmbyil.Text;
        }

       

        private void cmbgun_SelectedIndexChanged(object sender, EventArgs e)
        {
gun = cmbgun.Text;
        }

        private void cmbay_SelectedIndexChanged_1(object sender, EventArgs e)
        {
ay = cmbay.Text;
        }
        string dosyaadi, dosyayolu;

        private void btn_Click(object sender, EventArgs e)
        {
            frmGiris frmgiris = new frmGiris();
            frmgiris.Show();
            this.Hide();
        }

        private void btnfoto_Click(object sender, EventArgs e)
        {
            foto.InitialDirectory = "g:\\";//fotoyu nereden alacağını göster
            if (foto.ShowDialog() == DialogResult.OK)//arayüzü açmak için
            {
                dosyayolu = foto.FileName;//dosyanının yolunu al
                dosyaadi = foto.SafeFileName;//dosyanın adını al
                pctureresim.Image = Image.FromFile(dosyayolu);//dosyayı pictureBox ta göster
                pctureresim.SizeMode = PictureBoxSizeMode.StretchImage;//fotoyu sığdır
                pctureresim.Image.Save(foto.SafeFileName);
            }
        }
    }
}
