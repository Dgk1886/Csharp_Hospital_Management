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
    public partial class DoktorlarPaneli : Form
    {
        public DoktorlarPaneli()
        {
            InitializeComponent();
        }
        Sqlbaglanti sb = new Sqlbaglanti();

        private void DoktorlarPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Table_Doc", sb.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Branşları Combobox'a Aktarma
            SqlCommand cmd2 = new SqlCommand("Select BransAd from Table_Brans", sb.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0].ToString());
            }
            sb.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Table_Doc (DocAd,DocSoyad,DocSifre,DocBrans,DocTC) values (@p1,@p2,@p3,@p4,@p5)", sb.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", txtSifre.Text);
            cmd.Parameters.AddWithValue("@p4", cmbBrans.Text);
            cmd.Parameters.AddWithValue("@p5", mskTC.Text);
            cmd.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Doktor Eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Table_Doc where DocTC=@p1",sb.baglanti());
            cmd.Parameters.AddWithValue("@p1", mskTC.Text);
            cmd.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Doktor Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Table_Doc set DocAd = @d1, DocSoyad=@d2, DocBrans = @d3,DocSifre=@d5 where DocTC=@d4",sb.baglanti());
            cmd.Parameters.AddWithValue("@d1", txtAd.Text);
            cmd.Parameters.AddWithValue("@d2", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@d3", cmbBrans.Text);
            cmd.Parameters.AddWithValue("@d4", mskTC.Text);
            cmd.Parameters.AddWithValue("@d5", txtSifre.Text);
            cmd.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Doktor Eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
