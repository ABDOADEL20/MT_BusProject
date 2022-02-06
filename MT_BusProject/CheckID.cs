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
    public partial class CheckID : Form
    {
        public CheckID()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textview1.Text == "30008172700654")
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
                textview1.Clear();
            }
        }
    }
}
