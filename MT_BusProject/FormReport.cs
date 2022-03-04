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

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            SqlCommand cmd11 = new SqlCommand();
            cmd11.CommandText = ";WITH cte_DateSales AS ("+
 "select Date_Booking as 'Date', ISNULL(sum(Ticket_Price), 0) as 'Total sales' from( select Date_Booking, Ticket_Price from Booking WHERE MONTH(Date_Booking) = "+bunifuDatePicker2.Value.Month+"  and YEAR(Date_Booking) = "+bunifuDatePicker2.Value.Year+""+
 "union all select Date_Shipping, Cost_Shipping from Shipping WHERE MONTH(Date_Shipping) = "+bunifuDatePicker2.Value.Month+"  and YEAR(Date_Shipping) = "+bunifuDatePicker2.Value.Year+") t group by Date_Booking ), cte_TotalExpenses AS"+
 "( select Date as 'Date',ISNULL(sum(Gas_Cost), 0) as 'Total Expenses'from( select Date, Gas_Cost from BusGas WHERE MONTH(Date) = " + bunifuDatePicker2.Value.Month + "  and YEAR(Date) = " + bunifuDatePicker2.Value.Year + "" +
 "union all select Date, Wash_Cost from BusWash WHERE MONTH(Date) = " + bunifuDatePicker2.Value.Month + " and YEAR(Date) = " + bunifuDatePicker2.Value.Year + "" +
 "union all select Date, Drive_Money from Driver_Expenses WHERE MONTH(Date) = " + bunifuDatePicker2.Value.Month + "  and YEAR(Date) = " + bunifuDatePicker2.Value.Year + "" +
 "union all select Date, Emp_money from Emp_Expenses WHERE MONTH(Date) = " + bunifuDatePicker2.Value.Month + "  and YEAR(Date) = " + bunifuDatePicker2.Value.Year + "" +
 "union all select Date, Cost from OtherExpenses WHERE MONTH(Date) = " + bunifuDatePicker2.Value.Month + "  and YEAR(Date) = " + bunifuDatePicker2.Value.Year + "" +
 "union all select Date, ServiceRoad_Cost from RoadServices WHERE MONTH(Date) = " + bunifuDatePicker2.Value.Month + " and YEAR(Date) = " + bunifuDatePicker2.Value.Year + ") t group by Date)" +
 "SELECT c.TheDate, ISNULL(s.[Total Sales], 0) as'Total_Sales', ISNULL(e.[Total Expenses], 0) as'Total_Expenses' FROM dbo.Calendar AS c LEFT OUTER JOIN cte_DateSales AS s ON s.Date = c.TheDate LEFT OUTER JOIN cte_TotalExpenses AS e ON e.Date = c.TheDate where c.TheMonth = "+bunifuDatePicker2.Value.Month+" and c.TheYear = "+bunifuDatePicker2.Value.Year+"";
            cmd11.Connection = sqlcon;
            SqlDataAdapter sqlData11 = new SqlDataAdapter(cmd11);
            DataSet dt11 = new DataSet();
            sqlData11.Fill(dt11);

            ReportMonth reportMonth = new ReportMonth();
            reportMonth.SetDataSource(dt11.Tables[0]);
            reportMonth.SetParameterValue("DateReport2", bunifuDatePicker2.Text);
            crystalReportViewer1.ReportSource = reportMonth;
            bunifuGroupBox1.Dock = DockStyle.Fill;
            bunifuGroupBox1.Visible = true;
        }

        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        public FormReport()
        {
            InitializeComponent();
        }

        private void btn_ReportDay_Click(object sender, EventArgs e)
        {
            //CountTicket
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "SElECT ISNULL(COUNT(ID_Booking),0) From Booking where Date_Booking ='" + bunifuDatePicker1.Value+"'";
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
            cmd2.CommandText = "SElECT ISNULL(COUNT(ID_Shipping),0) From Shipping where Date_Shipping ='" + bunifuDatePicker1.Value + "'";
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
            cmd3.CommandText = "SElECT ISNULL(SUM(Ticket_Price),0) From Booking where Date_Booking ='" + bunifuDatePicker1.Value + "'";
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
            cmd4.CommandText = "SElECT ISNULL(SUM(Cost_Shipping),0) From Shipping where Date_Shipping ='" + bunifuDatePicker1.Value + "'";
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
            cmd5.CommandText = "SElECT ISNULL(SUM(Emp_money),0) From Emp_Expenses where Date ='" + bunifuDatePicker1.Value + "'";
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
            cmd6.CommandText = "SElECT ISNULL(SUM(Drive_Money),0) From Driver_Expenses where Date ='" + bunifuDatePicker1.Value + "'";
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
            cmd7.CommandText = "SElECT ISNULL(SUM(Wash_Cost),0) From BusWash where Date ='" + bunifuDatePicker1.Value + "'";
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
            cmd8.CommandText = "SELECT ISNULL(SUM(Gas_Cost),0) from BusGas where Date ='" + bunifuDatePicker1.Value + "'";
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
            cmd9.CommandText = "SELECT ISNULL(SUM(ServiceRoad_Cost),0) from RoadServices where Date ='" + bunifuDatePicker1.Value + "'";
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
            cmd10.CommandText = "SELECT ISNULL(SUM(Cost),0) from OtherExpenses where Date ='" + bunifuDatePicker1.Value + "'";
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
