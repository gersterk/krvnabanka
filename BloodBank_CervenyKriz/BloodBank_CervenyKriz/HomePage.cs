using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank_CervenyKriz
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void labelDonor_Click(object sender, EventArgs e)
        {
            Donor dnr = new Donor();
            dnr.Show();
            this.Hide();


        }

        private void label8_Click(object sender, EventArgs e)
        {
            KanBagisi knb = new KanBagisi();
            knb.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DonorList dnrl = new DonorList();
            dnrl.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Hasta hst = new Hasta();
            hst.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            HastaListesi hstl = new HastaListesi();
            hstl.Show();
            this.Hide();

               
        }

        private void label5_Click(object sender, EventArgs e)
        {
            KanStogu kns = new KanStogu();
            kns.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            KanTransferi kntr = new KanTransferi();
            kntr.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KontrolPaneli kp = new KontrolPaneli();
            kp.Show();
            this.Hide();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
