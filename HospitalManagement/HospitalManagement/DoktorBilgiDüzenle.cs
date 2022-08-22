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
    public partial class DoktorBilgiDüzenle : Form
    {
        public DoktorBilgiDüzenle()
        {
            InitializeComponent();
        }

        Sqlbaglanti sb = new Sqlbaglanti();
        public string TC;
        private void DoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TC;
            SqlCommand cmd = new SqlCommand("Select * from Table_Doc where DocTC= @p1",sb.baglanti());
            cmd.Parameters.AddWithValue("@p1",mskTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                txtSifre.Text = dr[3].ToString();
                cmbBrans.Text = dr[4].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Table_Doc set DocAd = @p1,DocSoyad=@p2,DocSifre=@p3,DocBrans=@p4 where DocTC=@p5",sb.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", txtSifre.Text);
            cmd.Parameters.AddWithValue("@p4", cmbBrans.Text);
            cmd.Parameters.AddWithValue("@p5", mskTC.Text);
            cmd.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi");
        }
    }
}
