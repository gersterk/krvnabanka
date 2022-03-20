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

namespace BloodBank_CervenyKriz
{
    public partial class Donor : Form
    {
        public Donor()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TLTN1FO\;Initial Catalog=BankaKanDb;Integrated Security=True");



        private void Reset()                        ////This Method reset the datas have taken from the user after saving...
        {
            DAdSoyadTb.Text = "";
            DYasTb.Text = "";
            DCinscomboBox.SelectedIndex = -1;
            DPhonetb.Text = "";
            DAdresTb.Text = "";
            DKGrupComboBox.SelectedIndex = -1;

        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)         //// Avoiding Errors and handling the exceptions...                                 
        {
            if (DAdSoyadTb.Text == "" || DYasTb.Text == "" || DAdresTb.Text == "" || DPhonetb.Text== "" || DKGrupComboBox.SelectedIndex==-1 || DCinscomboBox.SelectedIndex==-1)
            {
                MessageBox.Show("Chýbajúce informácie!");
            }
            else
            {
                try
                {
                    string query = "insert into DonorTbl values('" + DAdSoyadTb.Text + "'," + DYasTb.Text + ",'" + DAdresTb.Text + "', '" + DPhonetb.Text + "', '" + DKGrupComboBox.SelectedItem.ToString() + "', '" + DCinscomboBox.SelectedItem.ToString() + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Úspešná registrácia!");
                    baglanti.Close();
                    Reset();


                    

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
          
        }

        //// PASSINGS BETWEEN PAGES
        ///

        

        private void label1_Click_1(object sender, EventArgs e)
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

        private void Donor_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            KanBagisi kb = new KanBagisi();
            kb.Show();
            this.Hide();

        }
    }
}
