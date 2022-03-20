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
    public partial class KanTransferi : Form
    {
        public KanTransferi()
        {
            InitializeComponent();
            fillHastaCb();

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TLTN1FO\;Initial Catalog=BankaKanDb;Integrated Security=True");

        private void fillHastaCb()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HNum from Hasta1TBL", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HNum", typeof(int));
            dt.Load(rdr);
            HastaIdCb.ValueMember = "HNum";
            HastaIdCb.DataSource = dt;
            baglanti.Close();


        }

        private void VeriAl()
        {
            baglanti.Open();
            string query = "select * from Hasta1TBL where HNum= " + HastaIdCb.SelectedValue.ToString() + "";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                HastaAdTb.Text = dr["HAdSoyad"].ToString();
                HKGrupTbs.Text = dr["HKGrup"].ToString();


            }
            baglanti.Close();


        }

        int stokk;
        private void Stok(string Kgrup)
        {
            baglanti.Open();
            string query = "select * from Kan1Tbl where KGrup= '" + Kgrup + "'";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stokk = Convert.ToInt32(dr["KStok"].ToString());


            }
            baglanti.Close();


        }


        private void KanTransferi_Load(object sender, EventArgs e)
        {

        }

        private void HastaIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VeriAl();
            Stok(HKGrupTbs.Text);
            if (stokk > 0)
            {
                TransferBtn.Visible = true;
                Uygunlbl.Text = "Dostupné";
                Uygunlbl.Visible = true;

            }
            else
            {
                
                Uygunlbl.Text = "Nedostupné";
                Uygunlbl.Visible = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Hasta ha = new Hasta();
            ha.Show();
            this.Hide();

        }

        private void Reset ()
        {
            HastaAdTb.Text = "";
            HKGrupTbs.Text = "";
            Uygunlbl.Visible = false;
            TransferBtn.Visible = false;

        }
        private void kanGuncelle()
        {
            int yenistok = stokk - 1;

            try
            {
                string query = "update Kan1Tbl set KStok =" + yenistok + " where KGrup = '" + HKGrupTbs.Text + "';";



                baglanti.Open();
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.ExecuteNonQuery();
                //MessageBox.Show("Hasta Basariyla Guncellendi");
                baglanti.Close();
                 



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void TransferBtn_Click(object sender, EventArgs e)
        {
            if (HastaAdTb.Text == "")
            {
                MessageBox.Show("Chýbajúce informácie! ");
            }
            else
            {
                try
                {
                    string query = "insert into TransferTbl values('" + HastaAdTb.Text + "'," + HKGrupTbs.Text + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Úspešný Transfer!");
                    baglanti.Close();
                    Stok(HKGrupTbs.Text);
                    kanGuncelle();
                    Reset();           ///// BUNU DAHA SONRA SILEBILIRIM

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

        }   }

        private void label5_Click(object sender, EventArgs e)
        {
            KanStogu ks = new KanStogu();
            ks.Show();
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
            Login log = new Login();
            log.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            HastaListesi hl = new HastaListesi();
            hl.Show();
            this.Show();

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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Uygunlbl_Click(object sender, EventArgs e)
        {

        }
    }
}
