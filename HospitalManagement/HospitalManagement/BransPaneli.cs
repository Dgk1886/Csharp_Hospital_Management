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
    public partial class BransPaneli : Form
    {
        public BransPaneli()
        {
            InitializeComponent();
        }
        Sqlbaglanti sb = new Sqlbaglanti();
        private void BransPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Table_Brans", sb.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Table_brans (BransAd) values (@p1)",sb.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Branş eklenmiştir", "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Delete from Table_Brans where Bransid = @p1", sb.baglanti());
            cmd2.Parameters.AddWithValue("@p1", txtId.Text);
            cmd2.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Branş silindi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("Update Table_Brans set Bransad = @p1 where Bransid = @p2", sb.baglanti());
            cmd3.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd3.Parameters.AddWithValue("@p2", txtId.Text);
            cmd3.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Brans güncellendi");

        }
    }
}
