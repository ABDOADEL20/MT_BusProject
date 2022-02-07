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
        string id;
        private bool buttonClicked = false;
       
        public FormBooking1()
        {
            InitializeComponent();

            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView1, bunifuVScrollBar1);
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView2, bunifuVScrollBar2);
        }

        private void FormBooking1_Load(object sender, EventArgs e)
        {
        
            Get_Max();
            label6.Text = DateTime.Now.ToShortDateString();

            bunifuVScrollBar1.BorderRadius = 14;
            bunifuVScrollBar2.BorderRadius = 14;

            Read_Data_Booking();
            this.Dock = DockStyle.Fill;

            bunifuDataGridView1.RowHeadersWidth = 180;
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

        private void Get_Max()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select isnull (max(cast(ID_Booking as int)),0)+1 from Booking", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            ID_Booking.Text = dt.Rows[0][0].ToString();
        }

        private void Color_Chair_Select(object sender)
        {
            var button1 = (PictureBox)sender;
            button1.BackColor = Color.Red;
        }

        private void Color_Chair_NotSelected(object sender)
        {
            var button = (PictureBox)sender;
            button.BackColor = Color.White;
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

        private void bunifuDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                label14.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                label19.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                label16.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                label21.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
        }

 

        private void Chair_1_Click(object sender, EventArgs e)
        {

            Chair_Number.Text = "1";
        }

        private void Chair_2_Click(object sender, EventArgs e)
        {


            Chair_Number.Text = "2";
        }

        private void Chair_3_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "3";
        }

        private void Chair_4_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "4";
        }

        private void Chair_5_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "5";
        }

        private void Chair_6_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "6";
        }

        private void Chair_7_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "7";
        }

        private void Chair_8_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "8";
        }

        private void Chair_9_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "9";
        }

        private void Chair_10_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "10";
        }

        private void Chair_11_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "11";
        }

        private void Chair_12_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "12";
        }

        private void Chair_13_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "13";
        }

        private void Chair_14_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "14";
        }

        private void Chair_15_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "15";
        }

        private void Chair_16_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "16";
        }

        private void Chair_43_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "43";
        }

        private void Chair_18_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "18";
        }

        private void Chair_19_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "19";
        }

        private void Chair_20_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "20";
        }

        private void Chair_21_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "21";
        }

        private void Chair_22_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "22";
        }

        private void Chair_23_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "23";
        }

        private void Chair_24_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "24";
        }

        private void Chair_25_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "25";
        }

        private void Chair_26_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "26";
        }

        private void Chair_27_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "27";
        }

        private void Chair_28_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "28";
        }

        private void Chair_29_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "29";
        }

        private void Chair_30_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "30";
        }

        private void Chair_31_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "31";
        }

        private void Chair_32_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "32";
        }

        private void Chair_33_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "33";
        }

        private void Chair_34_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "34";
        }

        private void Chair_35_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "35";
        }

        private void Chair_36_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "36";
        }

        private void Chair_37_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "37";
        }

        private void Chair_38_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "38";
        }

        private void Chair_39_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "39";
        }

        private void Chair_40_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "40";
        }

        private void Chair_41_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "41";
        }

        private void Chair_42_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "42";
        }

        private void Chair_17_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "17";
        }

        private void Chair_44_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "44";
        }

        private void Chair_45_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "45";
        }

        private void Chair_46_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "46";
        }

        private void Chair_47_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "47";
        }

        private void Chair_48_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "48";
        }

        private void Chair_49_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "49";
        }

        private void Chair_50_Click(object sender, EventArgs e)
        {
            Chair_Number.Text = "50";
        }

       
    }
}
