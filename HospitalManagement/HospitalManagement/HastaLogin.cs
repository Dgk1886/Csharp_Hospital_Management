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

namespace HospitalManagement
{
    public partial class HastaLogin : Form
    {
        public HastaLogin()
        {
            InitializeComponent();
        }
        Sqlbaglanti sbl = new Sqlbaglanti();
        private void linksignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaKayit hastaKayit = new HastaKayit();
            hastaKayit.Show();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Table_Hasta Where HastaTC = @p1 and HastaSifre = @p2", sbl.baglanti());
            cmd.Parameters.AddWithValue("@p1", mskTC.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                HastaDetay hd = new HastaDetay();
                hd.tc = mskTC.Text;
                hd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı adı girdiniz", "Hata",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
            sbl.baglanti().Close();

        }
    }
}
