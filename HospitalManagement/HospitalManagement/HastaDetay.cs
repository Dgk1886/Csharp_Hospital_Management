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
    public partial class HastaDetay : Form
    {
        public string tc;

        public HastaDetay()
        {
            InitializeComponent();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Table_Randevu set RandevuDurum=1, HastaTC=@p1, Hastasikayet=@p2 where randevuId=@p3",sb.baglanti());
            cmd.Parameters.AddWithValue("@p1", labelTC.Text);
            cmd.Parameters.AddWithValue("@p2", rchSikayet.Text);
            cmd.Parameters.AddWithValue("@p3", txtid.Text);
            cmd.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Randevu alınmıştır", "Bilgi", MessageBoxButtons.OK);
        }
        Sqlbaglanti sb = new Sqlbaglanti();
        private void HastaDetay_Load(object sender, EventArgs e)
        {
            //Ad Soyadı aktarma
            labelTC.Text = tc;
            SqlCommand cmd = new SqlCommand("Select HastaAd,HastaSoyad from Table_Hasta where HastaTC = @p1", sb.baglanti());
            cmd.Parameters.AddWithValue("@p1", labelTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                labelAdSoyad.Text = dr[0] + " " + dr[1];
            }
            sb.baglanti().Close();

            // Randevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Table_Randevu where HastaTC = " + tc , sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branşları çekme
            SqlCommand cmd2 = new SqlCommand("Select BransAd from Table_Brans", sb.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            sb.baglanti().Close();
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            cmbDoktor.Text = "";
            SqlCommand cmd3 = new SqlCommand("Select DocAd,DocSoyad from Table_Doc where DocBrans = @p1", sb.baglanti());
            cmd3.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            sb.baglanti().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Table_Randevu where RandevuBrans = '" + cmbBrans.Text + "' and RandevuDoktor = '" + cmbDoktor.Text + "' and RandevuDurum = 0", sb.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        private void linkBilgi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaBilgiDüzenle hbd = new HastaBilgiDüzenle();
            hbd.tcNo = labelTC.Text;
            hbd.Show();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }
    }
}
