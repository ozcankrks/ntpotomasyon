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
    public partial class frmkullanici : Form
    {
       
        public frmkullanici()
        {       
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=OZCANKARAKUS;Database = UyeKayit; Trusted_Connection = True;");

        string kullaniciadi = frmGiris.kullaniciadi;
        private void frmkullanici_Load(object sender, EventArgs e)
        {
            this.Text = "Hoşgeldiniz  " + kullaniciadi;
            txtadres.Enabled = false;
            SqlCommand sorgusoru = new SqlCommand("select * from UyeKayitlarii where kuladi=@kuladi  ", baglanti);
            sorgusoru.Parameters.AddWithValue("@kuladi",kullaniciadi);
            SqlDataReader sdr;
            baglanti.Open();
            sdr = sorgusoru.ExecuteReader();
            while (sdr.Read())
            {
                lblad.Text = sdr[1].ToString();
                lblsoyad.Text = sdr[2].ToString();
                lblcinsiyet.Text = sdr[3].ToString();
                lbldogumtarihi.Text = sdr[4].ToString();
                lblemail.Text = sdr[5].ToString();
                lblkuladi.Text = sdr[6].ToString();
                lblsifre.Text = sdr[7].ToString();
                lbltelno.Text = sdr[8].ToString();
                txtadres.Text =sdr[9].ToString();
                lblgizlisoru.Text =sdr[10].ToString();
                lblcevap.Text =sdr[11].ToString();
                pcturekulres.Image =Image.FromFile(sdr[12].ToString());
               
            }
            baglanti.Close();
            listView1.Items.Clear();
            SqlCommand sorgu = new SqlCommand("select * from satinalinanurunler where kullaniciadi=@kullaniciadi ", baglanti);
            sorgu.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
            SqlDataReader alan;
            baglanti.Open();
            alan = sorgu.ExecuteReader();
            int sayac = 0;
            while (alan.Read())
            {
                sayac++;
                ListViewItem itm = new ListViewItem();
                itm.Text = sayac.ToString();
                itm.SubItems.Add(alan[1].ToString());
               
                itm.SubItems.Add(alan[4].ToString());

                listView1.Items.Add(itm);
            }
            baglanti.Close();
           
        }

        private void btnbilgiguncelle_Click(object sender, EventArgs e)
        {
            frmkulbilgiguncel frmguncel = new frmkulbilgiguncel();
            frmguncel.Show();
            this.Hide();
        }

        private void btnurunlregit_Click(object sender, EventArgs e)
        {
            frmlaptop frmlaptop = new frmlaptop();
            frmlaptop.Show();
            this.Hide();
        }

        private void btndonus_Click(object sender, EventArgs e)
        {
            frmGiris frmgiris = new frmGiris();
            frmgiris.Show();
            this.Hide();
        }
    }
}
