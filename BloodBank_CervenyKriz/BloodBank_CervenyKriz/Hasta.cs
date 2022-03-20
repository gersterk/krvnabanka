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
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TLTN1FO\;Initial Catalog=BankaKanDb;Integrated Security=True");


        private void Reset()                        ////This Method reset the datas have taken from the user after saving...
        {
            HAdSoyadTb.Text = "";
            HYasTb.Text = "";
            HCinsiyetCb.SelectedIndex = -1;
            HPhoneTb.Text = "";
            HAdresTb.Text = "";
            HKGrupCb.SelectedIndex = -1;

        }



        private void HKaydetButton_Click(object sender, EventArgs e)
        {
            if (HAdSoyadTb.Text == "" || HYasTb.Text == "" || HAdresTb.Text == "" || HPhoneTb.Text == "" || HKGrupCb.SelectedIndex == -1 || HCinsiyetCb.SelectedIndex == -1)  
            {
                MessageBox.Show("Eksik Bilgi Girdiniz ");
            }
            else
            {
                try
                {
                    string query = "insert into Hasta1TBL values('" + HAdSoyadTb.Text + "'," + HYasTb.Text + ",'" + HAdresTb.Text + "', '" + HPhoneTb.Text + "', '" + HKGrupCb.SelectedItem.ToString() + "', '" + HCinsiyetCb.SelectedItem.ToString() + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hasta Basariyla kaydedildi");
                    baglanti.Close();
                    Reset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void label2_Click(object sender, EventArgs e)   //To Hasta Listesi

        {
            HastaListesi Hl = new HastaListesi();
            Hl.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            KanTransferi kt = new KanTransferi();
            kt.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            KontrolPaneli kp = new KontrolPaneli();
            kp.Show();
            this.Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            KanStogu ks = new KanStogu();
            ks.Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            DonorList dl = new DonorList();
            dl.Show();
            this.Hide();

        }

        private void labelDonor_Click(object sender, EventArgs e)
        {
            Donor dnr = new Donor();
            dnr.Show();
            this.Hide();

        }

        private void label15_Click(object sender, EventArgs e)
        {
            KanBagisi kb = new KanBagisi();
            kb.Show();
            this.Hide();

        }
    }
}
