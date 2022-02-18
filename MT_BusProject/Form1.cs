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

        public Form1()
        {
            InitializeComponent();
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

       // void ResetBtn()
       // {
         //   foreach (var btn in TLPnlMenuControls.OfType<BunifuButton2>())
         //       btn.BackColor = Color.DodgerBlue;
         //   btnBooking.TabIndex = 0;
         //   btnShipping.TabIndex = 2;
         //   btnExp.TabIndex = 4;
         //   btnReport.TabIndex = 6;
          //  btnAddTime.TabIndex = 8;
          //  btnAddStation.TabIndex = 10;
       // }
      

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

        private void btnBooking_Click_1(object sender, EventArgs e)
        {
            // ResetBtn();
            SelectBtn(btnBooking);
        }

        private void btnShipping_Click_1(object sender, EventArgs e)
        {
            // ResetBtn();
            SelectBtn(btnShipping);
        }

        private void btnExp_Click_1(object sender, EventArgs e)
        {
            //ResetBtn();
            SelectBtn(btnExp);
        }

        private void btnReport_Click_1(object sender, EventArgs e)
        {
            // ResetBtn();
            SelectBtn(btnReport);
        }

        private void btnAddTime_Click_1(object sender, EventArgs e)
        {
            // ResetBtn();
            SelectBtn(btnAddTime);
        }

        private void btnAddStation_Click_1(object sender, EventArgs e)
        {
            //ResetBtn();
            SelectBtn(btnAddStation);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
