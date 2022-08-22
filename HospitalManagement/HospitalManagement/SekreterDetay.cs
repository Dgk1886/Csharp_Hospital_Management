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
    public partial class SekreterDetay : Form
    {
        public SekreterDetay()
        {
            InitializeComponent();
        }
        Sqlbaglanti sb = new Sqlbaglanti();

        public string tc;
        private void SekreterDetay_Load(object sender, EventArgs e)
        {
            //Ad Soyad Çekme
            labelTC.Text = tc;
            SqlCommand cmd = new SqlCommand("Select SekreterAdSoyad from Table_Sekreter Where SekreterTC=@p1",sb.baglanti());
            cmd.Parameters.AddWithValue("@p1", labelTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblSekAdSoyad.Text = dr[0].ToString();
            }
            sb.baglanti().Close();

            //Branşları Görüntüleme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select BransAd from Table_Brans", sb.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Doktorları Görüntüleme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DocAd + ' ' + DocSoyad) from Table_Doc", sb.baglanti());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;


            //Branşı ComboBox'a aktarma
            SqlCommand cmd2 = new SqlCommand("Select BransAd from Table_Brans", sb.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0].ToString());
            }
            sb.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmdsave = new SqlCommand("Insert into Table_Randevu (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor,RandevuDurum) values (@p1, @p2, @p3, @p4,@p5)",sb.baglanti());
            cmdsave.Parameters.AddWithValue("@p1", mskTarih.Text);
            cmdsave.Parameters.AddWithValue("@p2", mskSaat.Text);
            cmdsave.Parameters.AddWithValue("@p3", cmbBrans.Text);
            cmdsave.Parameters.AddWithValue("@p4", cmbDoktor.Text);
            cmdsave.Parameters.AddWithValue("@p5", "False");
            cmdsave.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Randevu başarıyla oluşturuldu");
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            cmbDoktor.Text = "";
            SqlCommand cmd = new SqlCommand("Select DocAd,DocSoyad from Table_Doc where DocBrans=@p1", sb.baglanti());
            cmd.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            sb.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Table_Duyuru (duyuru) values (@p1)", sb.baglanti());
            cmd.Parameters.AddWithValue("@p1",richDuyuru.Text);
            cmd.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DoktorlarPaneli dp = new DoktorlarPaneli();
            dp.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BransPaneli bp = new BransPaneli();
            bp.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RandevuListesi rl = new RandevuListesi();
            rl.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Duyurular dy = new Duyurular();
            dy.Show();
            this.Hide();
        }
    }
}
