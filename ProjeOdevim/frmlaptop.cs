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
    public partial class frmlaptop : Form
    {
        public frmlaptop()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("server=OZCANKARAKUS;Database = UyeKayit; Trusted_Connection = True;");

        private void frmlaptop_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            SqlCommand sorgual = new SqlCommand("select * from urun ", baglanti);
            SqlDataReader alan;

            baglanti.Open();
            alan = sorgual.ExecuteReader();
            while (alan.Read())
            {
                GroupBox grp = new GroupBox();
                flowLayoutPanel1.Controls.Add(grp);
                grp.Size = new Size(220, 260);
                
                PictureBox fotograflar = new PictureBox();
               // flowLayoutPanel1.Controls.Add(fotograflar);
                grp.Controls.Add(fotograflar);
                fotograflar.Size = new Size(200, 200);
                fotograflar.Location = new Point(15,15);
                string gelenresimismi = alan["resim"].ToString();
                fotograflar.Image = Image.FromFile(gelenresimismi);
                fotograflar.SizeMode = PictureBoxSizeMode.StretchImage;
                Button btn = new Button();
                // flowLayoutPanel1.Controls.Add(btn);
                grp.Controls.Add(btn);
                btn.Text = alan["urunadi"].ToString(); //+ "  " + alan["fiyati"].ToString() + " TL";               
                btn.Size = new Size(200, 30);
                btn.Location = new Point(15,220);           
                btn.Click += Btn_Click;                          
            }
       
            baglanti.Close();
        }
       
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string butonlarinadi = btn.Text;
           
         
            SqlCommand sorgusoru = new SqlCommand("select * from urun where urunadi=@urunadi  ", baglanti);
            sorgusoru.Parameters.AddWithValue("@urunadi", butonlarinadi);
            SqlDataReader sdr;
            baglanti.Open();
            sdr = sorgusoru.ExecuteReader();
            while (sdr.Read())
            {              
                string urunadi = sdr[1].ToString();
                string fiyati = sdr[2].ToString();
                string stok = sdr[3].ToString();
                string urununfotosu = sdr[4].ToString();
                string ram = sdr[5].ToString();
                string ekrankarti = sdr[6].ToString();
                string islemci = sdr[7].ToString();
                string harddisk = sdr[8].ToString();
                
                urunsatinalma urn = new urunsatinalma(urununfotosu,urunadi,fiyati,stok,ram,ekrankarti,islemci,harddisk);
                urn.Show();
                this.Hide();

            }           
            baglanti.Close();
        }    
        private void btndonus_Click(object sender, EventArgs e)
        {
            frmkullanici frmkul = new frmkullanici();
            frmkul.Show();
            this.Hide();
        }
    }
}

    
