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
    public partial class frmsifremiunuttum : Form
    {
        public frmsifremiunuttum()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=OZCANKARAKUS;Database = UyeKayit; Trusted_Connection = True;");

        string adaminsorusu = "";
        private void frmsifremiunuttum_Load(object sender, EventArgs e)
        {
            lblgizlis.Visible = false;btnonayla.Visible = false;txtgizsorcevabi.Visible = false;            
        }

        private void btnsifremibul_Click(object sender, EventArgs e)
        {
            lblgizlis.Visible = true;btnonayla.Visible = true;txtgizsorcevabi.Visible = true;
            SqlCommand sorgucek = new SqlCommand("select * from UyeKayitlarii where kuladi=@kulad ", baglanti);
            sorgucek.Parameters.AddWithValue("@kulad",txtkuladi.Text);

            SqlDataReader alan;

            baglanti.Open();
            alan = sorgucek.ExecuteReader();


            while (alan.Read())
            {
                adaminsorusu = alan[10].ToString();
                        }
            lblgizlis.Text = adaminsorusu;
            baglanti.Close();

        }
        string adaminsifresi = "";
        private void btnonayla_Click(object sender, EventArgs e)
        {
            SqlCommand sorgucek = new SqlCommand("select * from UyeKayitlarii where kuladi=@kulad and cevap=@cevap ", baglanti);
            sorgucek.Parameters.AddWithValue("@kulad", txtkuladi.Text);
            sorgucek.Parameters.AddWithValue("@cevap", txtgizsorcevabi.Text);
            SqlDataReader sdr;
            baglanti.Open();
            sdr = sorgucek.ExecuteReader();
            int ss = 0;
            while (sdr.Read())
            {
                adaminsifresi = sdr[7].ToString();
                ss++;
                if (ss != 0) { MessageBox.Show("Tebrikler  "+txtkuladi.Text +"\n"+ adaminsifresi); }
            }
           
            if (ss == 0)
                {
                    MessageBox.Show("Yanlış Cevap !!!");
                }       
            baglanti.Close();

        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            frmGiris frmgiris = new frmGiris();
            frmgiris.Show();
            this.Hide();
        }
    }
}
