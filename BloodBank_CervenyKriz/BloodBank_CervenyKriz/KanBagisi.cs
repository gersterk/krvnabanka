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
    public partial class KanBagisi : Form
    {
        public KanBagisi()
        {
            InitializeComponent();
            uyeler();
            KanStok();
             

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TLTN1FO\;Initial Catalog=BankaKanDb;Integrated Security=True");

        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from DonorTbl";                        //// Takes datas from previous, recorded, form of DONORTBL...
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KBagisiDGV.DataSource = ds.Tables[0];
            baglanti.Close();


        }

        private void KanStok()
        {
            baglanti.Open();
            string query = "select *from Kan1Tbl";                        //// Takes datas from previous, recorded, form of DONORTBL...
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KStoguDGV.DataSource = ds.Tables[0];
            baglanti.Close();



        }

        private void KanBagisi_Load(object sender, EventArgs e)
        {

        }
        int eskistok;
        private void Stok (string Kgrup)
        {
            baglanti.Open();
            string query = "select * from Kan1Tbl where KGrup= '" + Kgrup + "'";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                eskistok = Convert.ToInt32(dr["KStok"].ToString());


            }
            baglanti.Close();

              
        }

        private void KBagisiDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DAdSoyadTb.Text = KBagisiDGV.SelectedRows[0].Cells[1].Value.ToString();
            DKGrubuTb.Text = KBagisiDGV.SelectedRows[0].Cells[5].Value.ToString();
            Stok(DKGrubuTb.Text);

        }

        private void Reset()
        {
            DAdSoyadTb.Text = "";
            DKGrubuTb.Text = "";


        }


        private void KBagisiButton_Click(object sender, EventArgs e)
        {
            if (DAdSoyadTb.Text == "")
            {
                MessageBox.Show("Vybrať darcu");
            }
            else
            {
                try
                {
                    int stok = eskistok + 1;
                    string query = "update Kan1Tbl set KStok = '" + stok + "' where KGrup='" + DKGrubuTb.Text + "';";

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Darované!");
                    baglanti.Close();
                    Reset();
                    KanStok();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void label4_Click(object sender, EventArgs e)
        {
            KanTransferi kt = new KanTransferi();
            kt.Show();
            this.Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            KanStogu ks = new KanStogu();
            ks.Show();
            this.Hide();


        }

        private void label2_Click(object sender, EventArgs e)
        {
            HastaListesi hl = new HastaListesi();
            hl.Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Hasta hs = new Hasta();
            hs.Show();
            this.Hide();

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

        private void KStoguDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DKGrubuTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
