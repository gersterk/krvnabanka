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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private string kullanici = "admin";
        private string sifre = "123456";

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void textBoxKullaniciPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (textBoxKullanici.Text == kullanici  && textBoxKullaniciPass.Text == sifre)
            {
                HomePage hp = new HomePage();
                hp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nesprávne Používateľské Meno alebo Heslo");

            } 
             
        }
    }
}
