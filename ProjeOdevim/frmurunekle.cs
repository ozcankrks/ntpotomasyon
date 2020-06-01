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
    public partial class frmurunekle : Form
    {
        public frmurunekle()
        {
            InitializeComponent();
        }
        void listeguncelle()
        {
            listView1.Items.Clear();
            SqlCommand sorgu = new SqlCommand("select * from urun ", baglanti);
            SqlDataReader sdr;
            baglanti.Open();
            sdr = sorgu.ExecuteReader();
            int sayac = 0;
            while (sdr.Read())
            {
                sayac++;
                ListViewItem itm = new ListViewItem();
                itm.Text = sdr[1].ToString();
                itm.SubItems.Add(sayac.ToString());
                itm.SubItems.Add(sdr[2].ToString());
                itm.SubItems.Add(sdr[3].ToString());
                itm.SubItems.Add(sdr[4].ToString());
                itm.SubItems.Add(sdr[5].ToString());
                itm.SubItems.Add(sdr[6].ToString());
                itm.SubItems.Add(sdr[7].ToString());
                itm.SubItems.Add(sdr[8].ToString());

                listView1.Items.Add(itm);
            }
            baglanti.Close();
        }

        string dosyaadi1, dosyayolu1;
        private void btnfotoekle_Click(object sender, EventArgs e)
        {
            foto.InitialDirectory = "g:\\";//fotoyu nereden alacağını göster
            if (foto.ShowDialog() == DialogResult.OK)//arayüzü açmak için
            {
                dosyayolu1 = foto.FileName;//dosyanının yolunu al
                dosyaadi1 = foto.SafeFileName;//dosyanın adını al
                pictureBox1.Image = Image.FromFile(dosyayolu1);//dosyayı pictureBox ta göster
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;//fotoyu sığdır
                pictureBox1.Image.Save(foto.SafeFileName);
            }


        }
        SqlConnection baglanti = new SqlConnection("server=OZCANKARAKUS;Database = UyeKayit; Trusted_Connection = True;");


        private void btndonus_Click(object sender, EventArgs e)
        {
            frmadmin frmadmin = new frmadmin();
            frmadmin.Show();
            this.Hide();
        }

        private void btnurunlerigoster_Click(object sender, EventArgs e)
        {
            listeguncelle();
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int guncelstok = Convert.ToInt16(textBox3.Text);
            int guncelfiyat = Convert.ToInt16(textBox2.Text);
            string secilen = listView1.SelectedItems[0].Text;
            if (secilen==txtkulbilgigetir.Text)
            {
                 SqlCommand sorguguncelle = new SqlCommand("update urun set urunadi=@yeniurunadi,stok=@yenistok,fiyati=@yenifiyati,ram=@yeniram,ekrankarti=@yeniekran,islemci=@yenislemci,harddisk=@yeniharddisk where urunadi=@urunadi", baglanti);
            sorguguncelle.Parameters.AddWithValue("@urunadi", secilen);

            sorguguncelle.Parameters.AddWithValue("@yeniurunadi", textBox1.Text);
            sorguguncelle.Parameters.AddWithValue("@yenistok", guncelstok);
            sorguguncelle.Parameters.AddWithValue("@yenifiyati", guncelfiyat);
            sorguguncelle.Parameters.AddWithValue("@yeniram", textBox5.Text);
            sorguguncelle.Parameters.AddWithValue("@yeniekran", textBox6.Text);
            sorguguncelle.Parameters.AddWithValue("@yenislemci", textBox4.Text);
            sorguguncelle.Parameters.AddWithValue("@yeniharddisk", textBox7.Text);
            baglanti.Open();
            sorguguncelle.ExecuteNonQuery();
            baglanti.Close();
            listeguncelle();
            }
            else
            {
                MessageBox.Show("Lütfen Yazdığınız Ürünü Güncelleyin !!!");
            }
           



        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string secilen = listView1.SelectedItems[0].Text;
            SqlCommand sorguguncelle = new SqlCommand("DELETE  from urun where urunadi=@urunadi", baglanti);
            sorguguncelle.Parameters.AddWithValue("@urunadi", secilen);
            baglanti.Open();
            sorguguncelle.ExecuteNonQuery();
            baglanti.Close();
            listeguncelle();
        }

        private void btnurunekle_Click(object sender, EventArgs e)
        {
            int fiyat = Convert.ToInt32(txtfiyat.Text);
            int stok = Convert.ToInt32(txtstok.Text);
            SqlCommand sorgu = new SqlCommand("insert into urun (urunadi,fiyati,stok,resim,ram,ekrankarti,islemci,harddisk) values (@urunadi,@fiyati,@stok,@resim,@ram,@ekrankarti,@islemci,@harddisk)", baglanti);
            sorgu.Parameters.AddWithValue("@urunadi", txturun.Text);
            sorgu.Parameters.AddWithValue("@fiyati", fiyat);
            sorgu.Parameters.AddWithValue("@stok", stok);
            sorgu.Parameters.AddWithValue("@resim", dosyaadi1);
            sorgu.Parameters.AddWithValue("@ram", txtram.Text);
            sorgu.Parameters.AddWithValue("@ekrankarti", txtekrankarti.Text);
            sorgu.Parameters.AddWithValue("@islemci", txtislemci.Text);
            sorgu.Parameters.AddWithValue("@harddisk", txtharddisk.Text);

            baglanti.Open();
            int hata = sorgu.ExecuteNonQuery();
            if (hata > 1)
            {

                MessageBox.Show("HATA!!");

            }
            else MessageBox.Show("Ürün Eklendi");
            baglanti.Close();
        }

        private void btngetir_Click(object sender, EventArgs e)
        {
            SqlCommand sorgucek = new SqlCommand("select * from urun where urunadi=@urunadi ", baglanti);
            sorgucek.Parameters.AddWithValue("@urunadi", txtkulbilgigetir.Text);

            SqlDataReader alan;

            baglanti.Open();
            alan = sorgucek.ExecuteReader();

            while (alan.Read())
            {
                textBox1.Text = alan[1].ToString();
                textBox2.Text = alan[2].ToString();
                textBox3.Text = alan[3].ToString();
                pictureBox3.Image = Image.FromFile(alan[4].ToString());              
                textBox4.Text = alan[5].ToString();
                textBox5.Text = alan[6].ToString();
                textBox6.Text = alan[7].ToString();
                textBox7.Text = alan[8].ToString();
            }
            baglanti.Close();
        }
        string dosyayolu, dosyaadi;
        Font baslik = new Font("Verdana",12,FontStyle.Bold);
        Font govde = new Font("Verdana",12);
        SolidBrush solid = new SolidBrush(Color.Black);
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            SqlCommand sorgu = new SqlCommand("select * from urun ", baglanti);
            SqlDataReader sdr;
            baglanti.Open();
            sdr = sorgu.ExecuteReader();
            int sayac = 0;
            
            
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(" Ürün Listeleri ve Stokları", baslik,solid,200,100);
            e.Graphics.DrawString("     Ürün Adı         İşlemci         Ram         Stok Adedi          Fiyatı", baslik,solid,7,150);
            e.Graphics.DrawString("__________________________________________", baslik,solid,70,150);
            while (sdr.Read())
            {
                sayac++;
                e.Graphics.DrawString(sdr[1].ToString(), govde, solid, 50, 190+(sayac*30));
                e.Graphics.DrawString(sdr[7].ToString(), govde, solid, 180, 190+(sayac*30));
                e.Graphics.DrawString(sdr[5].ToString(), govde, solid, 290, 190+(sayac*30));
                e.Graphics.DrawString(sdr[3].ToString(), govde, solid, 400, 190+(sayac*30));
                e.Graphics.DrawString(sdr[2].ToString()+" TL", govde, solid, 510, 190+(sayac*30));
              
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foto.InitialDirectory = "g:\\";//fotoyu nereden alacağını göster
            if (foto.ShowDialog() == DialogResult.OK)//arayüzü açmak için
            {
                dosyayolu = foto.FileName;//dosyanının yolunu al
                dosyaadi = foto.SafeFileName;//dosyanın adını al
                pictureBox3.Image = Image.FromFile(dosyayolu);//dosyayı pictureBox ta göster
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;//fotoyu sığdır
                pictureBox3.Image.Save(foto.SafeFileName);
            }
        }

        private void fotoğrafGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string secilen = listView1.SelectedItems[0].Text;
            SqlCommand sorguguncelle = new SqlCommand("update urun set resim=@resim where urunadi=@urunadi", baglanti);
            sorguguncelle.Parameters.AddWithValue("@urunadi", txtkulbilgigetir.Text);
            sorguguncelle.Parameters.AddWithValue("@resim", dosyaadi);
            baglanti.Open();
            sorguguncelle.ExecuteNonQuery();
            baglanti.Close();
            listeguncelle();
        }
    }
}