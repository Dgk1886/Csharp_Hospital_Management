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
    public partial class HastaBilgiDüzenle : Form
    {
        public HastaBilgiDüzenle()
        {
            InitializeComponent();
        }
        Sqlbaglanti sb = new Sqlbaglanti();
        public string tcNo;
        private void HastaBilgiDüzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = tcNo;
            SqlCommand cmd = new SqlCommand("Select * from Table_Hasta where HastaTC ="+ tcNo, sb.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1] + "";
                txtSoyad.Text = dr[2] + "";
                mskTC.Text = dr[3] + "";
                txtSifre.Text = dr[5] + "";
                cmbGender.Text = dr[6] + "";
                mskTel.Text = dr[4] + "";
            }
            sb.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Update Table_Hasta set HastaAd=@p1, HastaSoyad=@p2, HastaTel=@p3, HastaSifre=@p4, HastaGender=@p5 where HastaTC=@p6 ", sb.baglanti());
            cmd2.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd2.Parameters.AddWithValue("@p3", mskTC.Text);
            cmd2.Parameters.AddWithValue("@p4", txtSifre.Text);
            cmd2.Parameters.AddWithValue("@p5", cmbGender.Text);
            cmd2.Parameters.AddWithValue("@p6", mskTel.Text);
            cmd2.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Bilgieriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
