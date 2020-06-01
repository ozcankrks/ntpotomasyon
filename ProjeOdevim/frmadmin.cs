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
    public partial class frmadmin : Form
    {
        public frmadmin()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=OZCANKARAKUS;Database = UyeKayit; Trusted_Connection = True;");

        private void btngoster_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SqlCommand sorgu = new SqlCommand("select * from UyeKayitlarii ", baglanti);
            SqlDataReader sdr;
            baglanti.Open();
            sdr = sorgu.ExecuteReader();
            int sayac = 0;
            while (sdr.Read())
            {
                sayac++;
                ListViewItem itm = new ListViewItem();
                itm.Text = sdr[0].ToString();
                itm.SubItems.Add(sdr[1].ToString());
                itm.SubItems.Add(sdr[2].ToString());
                itm.SubItems.Add(sdr[3].ToString());
                itm.SubItems.Add(sdr[4].ToString());
                itm.SubItems.Add(sdr[5].ToString());
                itm.SubItems.Add(sdr[6].ToString());
                itm.SubItems.Add(sdr[7].ToString());
                itm.SubItems.Add(sdr[8].ToString());
                itm.SubItems.Add(sdr[9].ToString());
                itm.SubItems.Add(sdr[10].ToString());
                itm.SubItems.Add(sdr[11].ToString());             
                listView1.Items.Add(itm);
            }
            baglanti.Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            frmurunekle frmurunekle = new frmurunekle();
            frmurunekle.Show();
            this.Hide();
        }

        private void btndonus_Click(object sender, EventArgs e)
        {
            frmGiris frmgiris = new frmGiris();
            frmgiris.Show();
            this.Hide();
        }

        private void btnsatinalinanurunler_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            SqlCommand sorgu = new SqlCommand("select * from satinalinanurunler ", baglanti);
            SqlDataReader sdr;
            baglanti.Open();
            sdr = sorgu.ExecuteReader();
            int sayac = 0;
            while (sdr.Read())
            {
                sayac++;
                ListViewItem itm = new ListViewItem();
                itm.Text = sayac.ToString();
                itm.SubItems.Add(sdr[1].ToString());
                itm.SubItems.Add(sdr[3].ToString());
                itm.SubItems.Add(sdr[4].ToString());
               
                listView2.Items.Add(itm);
            }
            baglanti.Close();
        }

        private void frmadmin_Load(object sender, EventArgs e)
        {


        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmurunekle frmurunekle = new frmurunekle();
            frmurunekle.Show();
            this.Hide();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGiris frmGiris = new frmGiris();
            frmGiris.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ürünleriYazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
        string dosyayolu, dosyaadi;
        Font baslik = new Font("Verdana", 12, FontStyle.Bold);
        Font govde = new Font("Verdana", 12);
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
            e.Graphics.DrawString(" Ürün Listeleri ve Stokları", baslik, solid, 200, 100);
            e.Graphics.DrawString("     Ürün Adı         İşlemci         Ram         Stok Adedi          Fiyatı", baslik, solid, 7, 150);
            e.Graphics.DrawString("__________________________________________", baslik, solid, 70, 150);
            while (sdr.Read())
            {
                sayac++;
                e.Graphics.DrawString(sdr[1].ToString(), govde, solid, 50, 190 + (sayac * 30));
                e.Graphics.DrawString(sdr[7].ToString(), govde, solid, 180, 190 + (sayac * 30));
                e.Graphics.DrawString(sdr[5].ToString(), govde, solid, 290, 190 + (sayac * 30));
                e.Graphics.DrawString(sdr[3].ToString(), govde, solid, 400, 190 + (sayac * 30));
                e.Graphics.DrawString(sdr[2].ToString() + " TL", govde, solid, 510, 190 + (sayac * 30));

            }
            baglanti.Close();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
