using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT_BusProject
{
    public partial class CheckID1 : Form
    {
        public CheckID1()
        {
            InitializeComponent();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "30008172700654")
            {

                MessageBox.Show("تم التحقق بنجاح ^_^");
                this.Hide();
                SignUp signUp = new SignUp();
                signUp.Closed += (s, args) => this.Close();
                signUp.Show();
            }
            else
            {
                MessageBox.Show("! الرقم القومي الذي قمت بإدخاله غير صحيح");
                bunifuTextBox1.Clear();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
