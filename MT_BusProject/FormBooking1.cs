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

namespace MT_BusProject
{
    public partial class FormBooking1 : UserControl
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassTimes classTimes = new ClassTimes();
        ClassBooking classBooking = new ClassBooking();
        public FormBooking1()
        {
            InitializeComponent();

            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView1, bunifuVScrollBar1);
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView2, bunifuVScrollBar2);
        }

        private void FormBooking1_Load(object sender, EventArgs e)
        {
            bunifuVScrollBar1.BorderRadius = 14;
            bunifuVScrollBar2.BorderRadius = 14;

            Read_Data_Booking();
            this.Dock = DockStyle.Fill;

            bunifuDataGridView1.Columns[0].HeaderCell.Value = "رقم التذكرة";
            bunifuDataGridView1.Columns[1].HeaderCell.Value = "إسم الموظف";
            bunifuDataGridView1.Columns[2].HeaderCell.Value = "مكتب الحجز";
            bunifuDataGridView1.Columns[3].HeaderCell.Value = "تاريخ الحجز";
            bunifuDataGridView1.Columns[4].HeaderCell.Value = "رقم المقعد";
            bunifuDataGridView1.Columns[5].HeaderCell.Value = "إسم العميل";
            bunifuDataGridView1.Columns[6].HeaderCell.Value = "رقم الهاتف";
            bunifuDataGridView1.Columns[7].HeaderCell.Value = "سعر التذكرة";
            bunifuDataGridView1.Columns[8].HeaderCell.Value = "وقت القيام";
            bunifuDataGridView1.Columns[9].HeaderCell.Value = "محطة القيام";
            bunifuDataGridView1.Columns[10].HeaderCell.Value = "الوقت المتوقع للوصول";
            bunifuDataGridView1.Columns[11].HeaderCell.Value = "محطة الوصول";
            bunifuDataGridView1.Columns[12].HeaderCell.Value = "تاريخ السفر";
            bunifuDataGridView1.Columns[13].HeaderCell.Value = "الرقم التعريفي للعميل";
            bunifuDataGridView1.Columns[14].HeaderCell.Value = "الرقم التعريفي للموظف";

            Read_Data_Times();
            //dataGridView1.ColumnHeadersHeight = 30;
            bunifuDataGridView2.Columns[0].HeaderCell.Value = "الرقم التعريفي";
            bunifuDataGridView2.Columns[1].HeaderCell.Value = "محطة القيام";
            bunifuDataGridView2.Columns[2].HeaderCell.Value = "وقت القيام";
            bunifuDataGridView2.Columns[3].HeaderCell.Value = "محطة الوصول";
            bunifuDataGridView2.Columns[4].HeaderCell.Value = "الوقت المتوقع للوصول";
            bunifuDataGridView2.Columns[4].Width = 135;
            bunifuDataGridView2.Columns[5].HeaderCell.Value = "سعر التذكرة";
        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void Read_Data_Booking()
        {
            DataSet ds = new DataSet();
            classBooking.Read_all().Fill(ds);
            bunifuDataGridView1.DataSource = ds.Tables[0];
        }
        private void Read_Data_Times()
        {
            DataSet ds = new DataSet();
            classTimes.Read_all().Fill(ds);
            bunifuDataGridView2.DataSource = ds.Tables[0];
        }

        private void bunifuHScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuHScrollBar.ScrollEventArgs e)
        {
            try
            {
               bunifuDataGridView1.FirstDisplayedScrollingColumnIndex = bunifuDataGridView1.Columns[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void bunifuDataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
               bunifuHScrollBar1.Maximum = bunifuDataGridView1.ColumnCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bunifuDataGridView1_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                bunifuHScrollBar1.Maximum = bunifuDataGridView1.ColumnCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
