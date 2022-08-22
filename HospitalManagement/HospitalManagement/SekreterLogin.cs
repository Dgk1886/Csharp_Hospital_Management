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
    public partial class SekreterLogin : Form
    {
        public SekreterLogin()
        {
            InitializeComponent();
        }
        Sqlbaglanti sb = new Sqlbaglanti();
        
        private void loginbutton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Table_Sekreter where SekreterTC = @p1 and SekreterSifre = @p2", sb.baglanti());
            cmd.Parameters.AddWithValue("@p1", mskTC.Text);
            cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                SekreterDetay sd = new SekreterDetay();
                sd.tc = mskTC.Text;
                sd.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı ve şifre", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sb.baglanti().Close();
        }
    }
}
