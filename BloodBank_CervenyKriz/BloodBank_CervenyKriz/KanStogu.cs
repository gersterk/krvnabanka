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
    public partial class KanStogu : Form
    {
        public KanStogu()
        {
            InitializeComponent();
            KanStok();

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-TLTN1FO\;Initial Catalog=BankaKanDb;Integrated Security=True");


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
        private void KanStogu_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            KanTransferi kant = new KanTransferi();
            kant.Show();
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
            this.Show();

        }

        private void labelDonor_Click(object sender, EventArgs e)
        {
            Donor dnr = new Donor();
            dnr.Show();
            this.Hide();

        }

        private void label11_Click(object sender, EventArgs e)
        {
            KanBagisi kb = new KanBagisi();
            kb.Show();
            this.Hide();

        }
    }
}
