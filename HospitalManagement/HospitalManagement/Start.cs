using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaLogin has = new HastaLogin();
            has.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoktorLogin doc = new DoktorLogin();
            doc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SekreterLogin sec = new SekreterLogin();
            sec.Show();
            this.Hide();
        }
    }
}
