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
    public partial class HastaKayit : Form
    {
        public HastaKayit()
        {
            InitializeComponent();
        }
        Sqlbaglanti sb = new Sqlbaglanti();

        public string tc { get; internal set; }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Table_Hasta (HastaAd,HastaSoyad,HastaTC,HastaTel,HastaSifre,HastaGender) values (@h1,@h2,@h3,@h4,@h5,@h6)", sb.baglanti());
            cmd.Parameters.AddWithValue("@h1", txtAd.Text);
            cmd.Parameters.AddWithValue("@h2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@h3", mskTC.Text);
            cmd.Parameters.AddWithValue("@h4", mskTel.Text);
            cmd.Parameters.AddWithValue("@h5", txtSifre.Text);
            cmd.Parameters.AddWithValue("@h6", cmbGender.Text);
            cmd.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Kaydınız başarıyla gerçekleşmiştir. Şifreniz:" + txtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
