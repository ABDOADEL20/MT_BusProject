using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuButton;

namespace MT_BusProject
{
    public partial class Form1 : Form
    {
        public static string name_emp = "";
        public static string user_id = "";

        FormBooking1 booking1 = new FormBooking1();

        public Form1()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel1);
        }

        void SelectBtn(BunifuButton2 btn)
        {
            FormBooking1 userControl = new FormBooking1();
            //formBooking.TopLevel = true;
            panel1.Controls.Clear();
            switch(btn.Name)
            {
                case "btnBooking": btn.TabIndex = 1;break;
                case "btnShipping": btn.TabIndex = 3; break;
                case "btnExp": btn.TabIndex = 5; break;
                case "btnReport": btn.TabIndex = 7; break;
                case "btnAddTime": btn.TabIndex = 9; break;
                case "btnAddStation": btn.TabIndex = 11; break;
                default:break;
            }
            panel1.Controls.Add(userControl);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

  
        private void btnShipping_Click_1(object sender, EventArgs e)
        {
            FormShipping formShipping = new FormShipping();
            panel1.Controls.Clear();
            panel1.Controls.Add(formShipping);
        }

        private void btnExp_Click_1(object sender, EventArgs e)
        {
            FormExpenses formExpenses = new FormExpenses();
            formExpenses.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(formExpenses);
        }

        private void btnReport_Click_1(object sender, EventArgs e)
        {
            FormReport formReport = new FormReport();
            formReport.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(formReport);
        }

        private void btnAddTime_Click_1(object sender, EventArgs e)
        {
            FormAddTimes1 formAddTimes1 = new FormAddTimes1();
            panel1.Controls.Clear();
            panel1.Controls.Add(formAddTimes1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            name_emp = Login1.SetValueForText1;
            user_id = Login1.SetValueForText2;
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            FormBooking1 formBooking1 = new FormBooking1();
            FormBooking1.name_emp = Login1.SetValueForText1;
            panel1.Controls.Clear();
            panel1.Controls.Add(formBooking1);

            name_emp = Login1.SetValueForText1;
            user_id = Login1.SetValueForText2;
        }

        private void btnAddStation_Click(object sender, EventArgs e)
        {
            FormAddStations1 formAddStations1 = new FormAddStations1();
            //FormBooking1.name_emp = Login1.SetValueForText1;
            panel1.Controls.Clear();
            panel1.Controls.Add(formAddStations1);
        }
    }
}
