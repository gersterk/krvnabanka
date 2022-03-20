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
    public partial class HastaListesi : Form
    {
        public HastaListesi()
        {
            InitializeComponent();
            uyeler();

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TLTN1FO\;Initial Catalog=BankaKanDb;Integrated Security=True");

        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from Hasta1TBL";                        //// Takes datas from previous, recorded, form of DONORTBL...
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HastaDGV.DataSource = ds.Tables[0];
            baglanti.Close();


        }

        int key = 0;
        private void HastaListesi_Load(object sender, EventArgs e)
        {

        }
        private void HastaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HAdSoyadTb.Text = HastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            HYasTb.Text = HastaDGV.SelectedRows[0].Cells[2].Value.ToString();
            HAdresTb.Text = HastaDGV.SelectedRows[0].Cells[3].Value.ToString();
            HPhoneTb.Text = HastaDGV.SelectedRows[0].Cells[4].Value.ToString();
            HKGrupCb.Text = HastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            HCinsiyetCb.Text = HastaDGV.SelectedRows[0].Cells[6].Value.ToString();

            
                
                


            if (HAdSoyadTb.Text == "")

            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(HastaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void Reset()                        ////This Method reset the datas have taken from the user after saving...
        {
            HAdSoyadTb.Text = "";
            HYasTb.Text = "";
            HCinsiyetCb.SelectedIndex = -1;
            HPhoneTb.Text = "";
            HAdresTb.Text = "";
            HKGrupCb.SelectedIndex = -1;
            key = 0;


        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Vybrať Pacienta");

            }
            else
            {
                try
                {
                    string query = "delete from Hasta1TBL where HNum = " + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Pacient bol odstránený");
                    baglanti.Close();
                    Reset();
                    uyeler();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void label2_Click(object sender, EventArgs e)     //Hasta Listesi

        {
            HastaListesi HL = new HastaListesi();
            HL.Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)    //Hasta
        {
            Hasta ha = new Hasta();
            ha.Show();
            this.Hide();

        }
        private void updateButton_Click(object sender, EventArgs e)     //Duzenle      HPhone='" + HPhoneTb.Text +

        {
            if (HAdSoyadTb.Text == "" || HYasTb.Text == "" || HAdresTb.Text == "" || HPhoneTb.Text == "" || HKGrupCb.SelectedIndex == -1 || HCinsiyetCb.SelectedIndex == -1)
            {
                MessageBox.Show("Chýbajúce informácie");

            }
            else
            {
                try
                {
                    string query = "update Hasta1TBL set HAdSoyad ='" + HAdSoyadTb.Text + "', HYas = " + HYasTb.Text + ", HAdres ='" + HAdresTb.Text + "', HPhone='" + HPhoneTb.Text + "', HKGrup='" + HKGrupCb.SelectedItem.ToString() + "', HCinsiyet='" + HCinsiyetCb.SelectedItem.ToString() + "'where HNum =" + key + ";";

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Informácie boli upravené");
                    baglanti.Close();
                    Reset();
                    uyeler();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            KanStogu ks = new KanStogu();
            ks.Show();
            this.Hide();

        }

        private void labelDonor_Click(object sender, EventArgs e)
        {
            Donor dnr = new Donor();
            dnr.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            DonorList dnrl = new DonorList();
            dnrl.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            KanTransferi kt = new KanTransferi();
            kt.Show();
            this.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            KontrolPaneli kp = new KontrolPaneli();
            kp.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label15_Click(object sender, EventArgs e)
        {
            KanBagisi kb = new KanBagisi();
            kb.Show();
            this.Hide();

        }
    }
}
