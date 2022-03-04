using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");

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
            Total_Expenses();
            Total_Sales();
        }

        private void btnExp_Click_1(object sender, EventArgs e)
        {
            FormExpenses formExpenses = new FormExpenses();
            formExpenses.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(formExpenses);
            Total_Expenses();
            Total_Sales();
        }

        private void btnReport_Click_1(object sender, EventArgs e)
        {
            FormReport formReport = new FormReport();
            formReport.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(formReport);
            Total_Expenses();
            Total_Sales();
        }

        private void btnAddTime_Click_1(object sender, EventArgs e)
        {
            FormAddTimes1 formAddTimes1 = new FormAddTimes1();
            panel1.Controls.Clear();
            panel1.Controls.Add(formAddTimes1);
            Total_Expenses();
            Total_Sales();
        }
        private void Total_Sales()
        {
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select ISNULL(sum(Ticket_Price),0)as 'Total sales' from ( select Date_Booking, Ticket_Price from Booking WHERE Date_Booking = '" + label10.Text + "' union all select Date_Shipping, Cost_Shipping from Shipping WHERE Date_Shipping = '" + label10.Text + "') t group by Date_Booking";
            cmd1.Connection = sqlcon;
            SqlDataAdapter sqlData1 = new SqlDataAdapter(cmd1);
            DataTable dataTable1 = new DataTable();
            sqlData1.Fill(dataTable1);
            if (dataTable1.Rows.Count > 0)
            {
                label3.Text = dataTable1.Rows[0][0].ToString() + " " + "جنيه";
            }
            else
            {
                label3.Text = "0" + " " + "جنيه";
            }
        }

        private void Total_Expenses()
        {
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "select ISNULL(sum(Gas_Cost),0) as 'Total Expenses' from (" +
    "select Date, Gas_Cost from BusGas WHERE Date = '" + label10.Text + "'" +
    "union all  select Date, Wash_Cost from BusWash WHERE Date = '" + label10.Text + "'" +
    "union all select Date, Drive_Money from Driver_Expenses WHERE Date = '" + label10.Text + "'" +
    "union all select Date, Emp_money from Emp_Expenses WHERE Date = '" + label10.Text + "'" +
    "union all select Date, Cost from OtherExpenses WHERE Date = '" + label10.Text + "'" +
    "union all select Date, ServiceRoad_Cost from RoadServices WHERE Date = '" + label10.Text + "') t group by Date";
            cmd2.Connection = sqlcon;
            SqlDataAdapter sqlData2 = new SqlDataAdapter(cmd2);
            DataTable dataTable2 = new DataTable();
            sqlData2.Fill(dataTable2);
            if (dataTable2.Rows.Count > 0)
            {
                label4.Text = dataTable2.Rows[0][0].ToString() + " " + "جنيه";
            }
            else
            {
                label4.Text = "0" + " " + "جنيه";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.Date.ToShortDateString();

            //Total Sales
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select ISNULL(sum(Ticket_Price),0)as 'Total sales' from ( select Date_Booking, Ticket_Price from Booking WHERE Date_Booking = '"+label10.Text+ "' union all select Date_Shipping, Cost_Shipping from Shipping WHERE Date_Shipping = '" + label10.Text + "') t group by Date_Booking";
            cmd1.Connection = sqlcon;
            SqlDataAdapter sqlData1 = new SqlDataAdapter(cmd1);
            DataTable dataTable1 = new DataTable();
            sqlData1.Fill(dataTable1);
            if (dataTable1.Rows.Count > 0)
            {
                label3.Text = dataTable1.Rows[0][0].ToString()+" "+"جنيه";
            }
            else
            {
                label3.Text = "0"+" "+"جنيه";
            }

            //Total Expenses
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "select ISNULL(sum(Gas_Cost),0) as 'Total Expenses' from ("+
    "select Date, Gas_Cost from BusGas WHERE Date = '" + label10.Text + "'" +
    "union all  select Date, Wash_Cost from BusWash WHERE Date = '" + label10.Text + "'" +
    "union all select Date, Drive_Money from Driver_Expenses WHERE Date = '" + label10.Text + "'" +
    "union all select Date, Emp_money from Emp_Expenses WHERE Date = '" + label10.Text + "'" +
    "union all select Date, Cost from OtherExpenses WHERE Date = '" + label10.Text + "'" +
    "union all select Date, ServiceRoad_Cost from RoadServices WHERE Date = '" + label10.Text + "') t group by Date";
            cmd2.Connection = sqlcon;
            SqlDataAdapter sqlData2 = new SqlDataAdapter(cmd2);
            DataTable dataTable2 = new DataTable();
            sqlData2.Fill(dataTable2);
            if (dataTable2.Rows.Count > 0)
            {
                label4.Text = dataTable2.Rows[0][0].ToString() + " " + "جنيه";
            }
            else
            {
                label4.Text = "0" +" "+ "جنيه";
            }

            name_emp = Login1.SetValueForText1;
            user_id = Login1.SetValueForText2;

            if(name_emp=="محمود هاني")
            {
                btnAddStation.Enabled = true;
                btnAddTime.Enabled = true;
                btnBooking.Enabled = true;
                btnExp.Enabled = true;
                btnReport.Enabled = true;
                btnShipping.Enabled = true;
            }
            else
            {
                btnAddStation.Enabled = false;
                btnAddTime.Enabled = false;
                btnBooking.Enabled = true;
                btnExp.Enabled = false;
                btnReport.Enabled = false;
                btnShipping.Enabled = true;
            }
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            FormBooking1 formBooking1 = new FormBooking1();
            FormBooking1.name_emp = Login1.SetValueForText1;
            panel1.Controls.Clear();
            panel1.Controls.Add(formBooking1);
            Total_Expenses();
            Total_Sales();

            name_emp = Login1.SetValueForText1;
            user_id = Login1.SetValueForText2;
        }

        private void btnAddStation_Click(object sender, EventArgs e)
        {
            FormAddStations1 formAddStations1 = new FormAddStations1();
            //FormBooking1.name_emp = Login1.SetValueForText1;
            panel1.Controls.Clear();
            panel1.Controls.Add(formAddStations1);
            Total_Expenses();
            Total_Sales();
        }
    }
}
