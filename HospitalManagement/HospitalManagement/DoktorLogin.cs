using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HospitalManagement
{
    public partial class DoktorLogin : Form
    {
        public DoktorLogin()
        {
            InitializeComponent();
        }
        Sqlbaglanti sb = new Sqlbaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from table_Doc where DocTC = @p1 and DocSifre = @p2", sb.baglanti());
            cmd.Parameters.AddWithValue("@p1", mskTC.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                DoktorDetay de = new DoktorDetay();
                de.TCno = mskTC.Text;
                de.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı ve şifre", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            sb.baglanti().Close();
        }
    }
}
