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
    public partial class FormExpenses : UserControl
    {
        public FormExpenses()
        {
            InitializeComponent();
        }

        private void FormExpenses_Load(object sender, EventArgs e)
        {
           if(guna2Button1.Checked == true)
            {
                UserControlsExpenses.Form_Exp_Driver form_Exp_Driver = new UserControlsExpenses.Form_Exp_Driver();
                addUserControl(form_Exp_Driver);
            }
        }

        private void addUserControl(UserControl userControl)
        {
            bunifuPanel3.Controls.Clear();
            bunifuPanel3.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UserControlsExpenses.Form_Exp_Driver form_Exp_Driver = new UserControlsExpenses.Form_Exp_Driver();
            addUserControl(form_Exp_Driver);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UserControlsExpenses.Form_Exp_Employe form_Exp_Employe = new UserControlsExpenses.Form_Exp_Employe();
            addUserControl(form_Exp_Employe);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UserControlsExpenses.Form_Exp_Wash form_Exp_Wash = new UserControlsExpenses.Form_Exp_Wash();
            addUserControl(form_Exp_Wash);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UserControlsExpenses.Form_Exp_Gas form_Exp_Gas = new UserControlsExpenses.Form_Exp_Gas();
            addUserControl(form_Exp_Gas);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            UserControlsExpenses.Form_Exp_RoadService form_Exp_RoadService = new UserControlsExpenses.Form_Exp_RoadService();
            addUserControl(form_Exp_RoadService);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            UserControlsExpenses.Form_Exp_Other form_Exp_Other = new UserControlsExpenses.Form_Exp_Other();
            addUserControl(form_Exp_Other);
        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }
    }
}
