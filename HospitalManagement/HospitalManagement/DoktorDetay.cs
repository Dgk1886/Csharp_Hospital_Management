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
    public partial class DoktorDetay : Form
    {
        public DoktorDetay()
        {
            InitializeComponent();
        }
        Sqlbaglanti sb = new Sqlbaglanti();
        public string TCno;
        private void DoktorDetay_Load(object sender, EventArgs e)
        {
            DocTC.Text = TCno;

            //Doktor Ad Soyad getirme
            SqlCommand cmd = new SqlCommand("Select DocAd,DocSoyad from Table_Doc where DocTC = @p1", sb.baglanti());
            cmd.Parameters.AddWithValue("@p1", DocTC.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DocAdSoyad.Text = dr[0] + " " + dr[1];
            }
            sb.baglanti().Close();

            //Randevu Listesi
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Table_Randevu where RandevuDoktor = '" + DocAdSoyad.Text + "'", sb.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorBilgiDüzenle db = new DoktorBilgiDüzenle();
            db.TC = DocTC.Text;
            db.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

        }
    }
}
