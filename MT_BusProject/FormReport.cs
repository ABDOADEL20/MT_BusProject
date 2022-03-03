using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MT_BusProject
{
    public partial class FormReport : UserControl
    {
        int CountTicket, CountShipping, SumCostTicket, SumCostShipping, SumExpEmp, SumExpDriver, SumExpWashBus,
            SumExpGas, SumExpRoadSer, SumExpOther;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        public FormReport()
        {
            InitializeComponent();
        }

        private void btn_ReportDay_Click(object sender, EventArgs e)
        {
            //CountTicket
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "SElECT COUNT (ID_Booking) From Booking where Date_Booking ='"+bunifuDatePicker1.Text+"'";
            cmd1.Connection = sqlcon;
            SqlDataAdapter sqlData1 = new SqlDataAdapter(cmd1);
            DataTable dataTable1 = new DataTable();
            sqlData1.Fill(dataTable1);
            if (dataTable1.Rows.Count > 0)
            {
                CountTicket = int.Parse(dataTable1.Rows[0][0].ToString());
            }
            else
            {
                CountTicket = 0;
            }

            //CountShipping
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "SElECT COUNT (ID_Shipping) From Shipping where Date_Shipping ='" + bunifuDatePicker1.Text + "'";
            cmd2.Connection = sqlcon;
            SqlDataAdapter sqlData2 = new SqlDataAdapter(cmd2);
            DataTable dataTable2 = new DataTable();
            sqlData2.Fill(dataTable2);
            if (dataTable2.Rows.Count > 0)
            {
                CountShipping = int.Parse(dataTable2.Rows[0][0].ToString());
            }
            else
            {
                CountShipping = 0;
            }

            //SumCostTicket
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "SElECT SUM (Ticket_Price) From Booking where Date_Booking ='" + bunifuDatePicker1.Text + "'";
            cmd3.Connection = sqlcon;
            SqlDataAdapter sqlData3 = new SqlDataAdapter(cmd3);
            DataTable dataTable3 = new DataTable();
            sqlData3.Fill(dataTable3);
            if (dataTable3.Rows.Count > 0)
            {
                SumCostTicket = int.Parse(dataTable3.Rows[0][0].ToString());
            }
            else
            {
                SumCostTicket = 0;
            }

            //SumCostShipping
            SqlCommand cmd4 = new SqlCommand();
            cmd4.CommandText = "SElECT SUM (Cost_Shipping) From Shipping where Date_Shipping ='" + bunifuDatePicker1.Text + "'";
            cmd4.Connection = sqlcon;
            SqlDataAdapter sqlData4 = new SqlDataAdapter(cmd4);
            DataTable dataTable4 = new DataTable();
            sqlData4.Fill(dataTable4);
            if (dataTable4.Rows.Count > 0)
            {
                SumCostShipping = int.Parse(dataTable4.Rows[0][0].ToString());
            }
            else
            {
                SumCostShipping = 0;
            }

            //SumExpEmp
            SqlCommand cmd5 = new SqlCommand();
            cmd5.CommandText = "SElECT SUM (Emp_money) From Emp_Expenses where Date ='" + bunifuDatePicker1.Text + "'";
            cmd5.Connection = sqlcon;
            SqlDataAdapter sqlData5 = new SqlDataAdapter(cmd5);
            DataTable dataTable5 = new DataTable();
            sqlData5.Fill(dataTable5);
            if (dataTable5.Rows.Count > 0)
            {
                SumExpEmp = int.Parse(dataTable5.Rows[0][0].ToString());
            }
            else
            {
                SumExpEmp = 0;
            }

            //SumExpDriver
            SqlCommand cmd6 = new SqlCommand();
            cmd6.CommandText = "SElECT SUM (Drive_Money) From Driver_Expenses where Date ='" + bunifuDatePicker1.Text + "'";
            cmd6.Connection = sqlcon;
            SqlDataAdapter sqlData6 = new SqlDataAdapter(cmd6);
            DataTable dataTable6 = new DataTable();
            sqlData6.Fill(dataTable6);
            if (dataTable6.Rows.Count > 0)
            {
               SumExpDriver = int.Parse(dataTable6.Rows[0][0].ToString());
            }
            else
            {
                SumExpDriver = 0;
            }

            //SumExpWashBus
            SqlCommand cmd7 = new SqlCommand();
            cmd7.CommandText = "SElECT SUM (Wash_Cost) From BusWash where Date ='" + bunifuDatePicker1.Text + "'";
            cmd7.Connection = sqlcon;
            SqlDataAdapter sqlData7 = new SqlDataAdapter(cmd7);
            DataTable dataTable7 = new DataTable();
            sqlData7.Fill(dataTable7);
            if (dataTable7.Rows.Count > 0)
            {
                SumExpWashBus = int.Parse(dataTable7.Rows[0][0].ToString());
            }
            else
            {
                SumExpWashBus = 0;
            }

            //SumExpGas
            SqlCommand cmd8 = new SqlCommand();
            cmd8.CommandText = "SELECT SUM(Gas_Cost) from BusGas where Date ='" + bunifuDatePicker1.Text + "'";
            cmd8.Connection = sqlcon;
            SqlDataAdapter sqlData8 = new SqlDataAdapter(cmd8);
            DataTable dataTable8 = new DataTable();
            sqlData8.Fill(dataTable8);
            if (dataTable8.Rows.Count > 0)
            {
                SumExpGas = int.Parse(dataTable8.Rows[0][0].ToString());
            }
            else
            {
                SumExpGas = 0;
            }

            //SumExpRoadSer
            SqlCommand cmd9 = new SqlCommand();
            cmd9.CommandText = "SELECT SUM(ServiceRoad_Cost) from RoadServices where Date ='" + bunifuDatePicker1.Text + "'";
            cmd9.Connection = sqlcon;
            SqlDataAdapter sqlData9 = new SqlDataAdapter(cmd9);
            DataTable dataTable9 = new DataTable();
            sqlData9.Fill(dataTable9);
            if (dataTable9.Rows.Count > 0)
            {
                SumExpRoadSer = int.Parse(dataTable9.Rows[0][0].ToString());
            }
            else
            {
                SumExpRoadSer = 0;
            }

            //SumExpOther
            SqlCommand cmd10 = new SqlCommand();
            cmd10.CommandText = "SELECT SUM(Cost) from OtherExpenses where Date ='" + bunifuDatePicker1.Text + "'";
            cmd10.Connection = sqlcon;
            SqlDataAdapter sqlData10 = new SqlDataAdapter(cmd10);
            DataTable dataTable10 = new DataTable();
            sqlData10.Fill(dataTable10);
            if (dataTable10.Rows.Count > 0)
            {
                SumExpOther = int.Parse(dataTable10.Rows[0][0].ToString());
            }
            else
            {
                SumExpOther = 0;
            }

            ReportDay reportDay = new ReportDay();
            reportDay.SetParameterValue("DateReport", bunifuDatePicker1.Text);
            reportDay.SetParameterValue("CountTickets", CountTicket);
            reportDay.SetParameterValue("CountShipping", CountShipping);
            reportDay.SetParameterValue("SumCostTicket", SumCostTicket);
            reportDay.SetParameterValue("SumCostShipping", SumCostShipping);
            reportDay.SetParameterValue("SumExpEmp", SumExpEmp);
            reportDay.SetParameterValue("SumExpDriver", SumExpDriver);
            reportDay.SetParameterValue("SumExpWashBus", SumExpWashBus);
            reportDay.SetParameterValue("SumExpGas", SumExpGas);
            reportDay.SetParameterValue("SumExpRoadSer", SumExpRoadSer);
            reportDay.SetParameterValue("SumExpOther", SumExpOther);

            crystalReportViewer1.ReportSource = reportDay;
            bunifuGroupBox1.Dock = DockStyle.Fill;
            bunifuGroupBox1.Visible = true;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            //bunifuDatePicker1.MinDate = DateTime.Now.Date;
            bunifuDatePicker2.Format = DateTimePickerFormat.Custom;
            bunifuDatePicker2.CustomFormat = "MM/yyyy"; // this line gives you only the month and year.
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
