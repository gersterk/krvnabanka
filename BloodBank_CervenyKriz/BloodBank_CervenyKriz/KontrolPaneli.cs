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
    public partial class KontrolPaneli : Form
    {
        public KontrolPaneli()
        {
            InitializeComponent();
            VeriCek();

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TLTN1FO\;Initial Catalog=BankaKanDb;Integrated Security=True");

        private void VeriCek ()
        {
            baglanti.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from DonorTbl", baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLbl.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter sda1 = new SqlDataAdapter("select count (*) from TransferTbl", baglanti);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLbl.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select count (*) from Kan1Tbl", baglanti);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            int Kstok = Convert.ToInt32(dt2.Rows[0][0].ToString());
            TotalLbl.Text = "" + Kstok;

            SqlDataAdapter sda3 = new SqlDataAdapter("select KStok from Kan1Tbl where KGrup='" +"0+"+"'", baglanti);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            ZeroPlusLbl.Text = dt3.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt3.Rows[0][0].ToString()) / Kstok) * 100;
            zeroPlusBar.Value = Convert.ToInt32(OplusPercentage);

            SqlDataAdapter sda4 = new SqlDataAdapter("select KStok from Kan1Tbl where KGrup='" + "AB+" + "'", baglanti);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            AbPlusLbl.Text = dt4.Rows[0][0].ToString();
            double AbPlusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString()) / Kstok) * 100;
            AbPlusBar.Value = Convert.ToInt32(AbPlusPercentage);

            SqlDataAdapter sda5 = new SqlDataAdapter("select KStok from Kan1Tbl where KGrup='" + "0-" + "'", baglanti);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            ZeroNegLbl.Text = dt5.Rows[0][0].ToString();
            double ZeroNegPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / Kstok) * 100;
            ZeroNegBar.Value = Convert.ToInt32(ZeroNegPercentage);


            SqlDataAdapter sda6 = new SqlDataAdapter("select KStok from Kan1Tbl where KGrup='" + "AB-" + "'", baglanti);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            AbNegLbl.Text = dt6.Rows[0][0].ToString();
            double AbNegPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / Kstok) * 100;
            AbNegBar.Value = Convert.ToInt32(AbNegPercentage);




            baglanti.Close();


        }

    

        private void KontrolPaneli_Load(object sender, EventArgs e)
        {

        }



        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();

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
            Hasta hst = new Hasta();
            hst.Show();
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

        private void label15_Click(object sender, EventArgs e)
        {
            KanBagisi kb = new KanBagisi();
            kb.Show();
            this.Hide();

        }

    }
}
