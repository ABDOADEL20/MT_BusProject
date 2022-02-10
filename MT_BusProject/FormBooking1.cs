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
        string[] NameB;
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
            if (button1 != null)
            {
                button1.BackColor = (button1.BackColor == Color.White) ? Color.Red : Color.White;
               
            }
            else
            {
                ResetButtonBackColor(sender);
            }
           
        }

        private void ResetAllColor(PictureBox control)
        {
            
            control.BackColor = SystemColors.Control;
            if (control.HasChildren)
            {
                foreach(PictureBox childcontrol in control.Controls)
                {
                    ResetAllColor(childcontrol);
                }
            }
        }
       // private void Color_Chair_NotSelected(object sender)
       // {
          //  var button1 = (PictureBox)sender;
           // if (button1 == null)
          //  {
            //    button1.BackColor = (button1.BackColor == Color.Red) ? Color.White : Color.Red;
         //   }
       // }

       // private void SetButtonsBackColorToRed(Object sender)
       // {

           // foreach (var control in this.Controls)
          //  {
              //  if (control is PictureBox && (PictureBox)sender != control && ((PictureBox)control).BackColor == Color.Red)
              //  {
                 //   ((PictureBox)control).BackColor = Color.White;
              //  }
          //  }
     //   }

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

        private void Enable_false(Object sender)
        {
            var button1 = (PictureBox)sender;
            if (button1.Enabled==true)
            {
                Chair_1.Enabled = false;
                Chair_2.Enabled = false;
                Chair_3.Enabled = false;
                Chair_4.Enabled = false;
                Chair_5.Enabled = false;
                Chair_6.Enabled = false;
                Chair_7.Enabled = false;
                Chair_8.Enabled = false;
                Chair_9.Enabled = false;
                Chair_10.Enabled = false;
                Chair_11.Enabled = false;
                Chair_12.Enabled = false;
                Chair_13.Enabled = false;
                Chair_14.Enabled = false;
                Chair_15.Enabled = false;
                Chair_16.Enabled = false;
                Chair_17.Enabled = false;
                Chair_18.Enabled = false;
                Chair_19.Enabled = false;
                Chair_20.Enabled = false;
                Chair_21.Enabled = false;
                Chair_22.Enabled = false;
                Chair_23.Enabled = false;
                Chair_24.Enabled = false;
                Chair_25.Enabled = false;
                Chair_26.Enabled = false;
                Chair_27.Enabled = false;
                Chair_28.Enabled = false;
                Chair_29.Enabled = false;
                Chair_30.Enabled = false;
                Chair_31.Enabled = false;
                Chair_32.Enabled = false;
                Chair_33.Enabled = false;
                Chair_34.Enabled = false;
                Chair_35.Enabled = false;
                Chair_36.Enabled = false;
                Chair_37.Enabled = false;
                Chair_38.Enabled = false;
                Chair_39.Enabled = false;
                Chair_40.Enabled = false;
                Chair_41.Enabled = false;
                Chair_42.Enabled = false;
                Chair_43.Enabled = false;
                Chair_44.Enabled = false;
                Chair_45.Enabled = false;
                Chair_46.Enabled = false;
                Chair_47.Enabled = false;
                Chair_48.Enabled = false;
                Chair_49.Enabled = false;
                Chair_50.Enabled = false;

                button1.Enabled = true;
            }

        }
        private void Enable_true(Object sender)
        {
            var button1 = (PictureBox)sender;
            if (Chair_1.Enabled == false || Chair_2.Enabled == false || Chair_3.Enabled == false
                || Chair_4.Enabled == false || Chair_5.Enabled == false || Chair_6.Enabled == false
                || Chair_7.Enabled == false || Chair_8.Enabled == false || Chair_9.Enabled == false
                || Chair_10.Enabled == false || Chair_11.Enabled == false || Chair_12.Enabled == false
                || Chair_13.Enabled == false || Chair_14.Enabled == false || Chair_15.Enabled == false
                || Chair_16.Enabled == false || Chair_17.Enabled == false || Chair_18.Enabled == false
                || Chair_19.Enabled == false || Chair_20.Enabled == false || Chair_21.Enabled == false
                || Chair_21.Enabled == false || Chair_22.Enabled == false || Chair_23.Enabled == false
                || Chair_24.Enabled == false || Chair_25.Enabled == false || Chair_26.Enabled == false
                || Chair_27.Enabled == false || Chair_28.Enabled == false || Chair_29.Enabled == false
                || Chair_30.Enabled == false || Chair_31.Enabled == false || Chair_32.Enabled == false
                || Chair_33.Enabled == false || Chair_34.Enabled == false || Chair_35.Enabled == false
                || Chair_36.Enabled == false || Chair_37.Enabled == false || Chair_38.Enabled == false
                || Chair_39.Enabled == false || Chair_40.Enabled == false || Chair_41.Enabled == false
                || Chair_42.Enabled == false || Chair_43.Enabled == false || Chair_44.Enabled == false
                || Chair_45.Enabled == false || Chair_46.Enabled == false || Chair_47.Enabled == false
                || Chair_48.Enabled == false || Chair_49.Enabled == false || Chair_50.Enabled == false)
            {
                Chair_1.Enabled = true;
                Chair_2.Enabled = true;
                Chair_3.Enabled = true;
                Chair_4.Enabled = true;
                Chair_5.Enabled = true;
                Chair_6.Enabled = true;
                Chair_7.Enabled = true;
                Chair_8.Enabled = true;
                Chair_9.Enabled = true;
                Chair_10.Enabled = true;
                Chair_11.Enabled = true;
                Chair_12.Enabled = true;
                Chair_13.Enabled = true;
                Chair_14.Enabled = true;
                Chair_15.Enabled = true;
                Chair_16.Enabled = true;
                Chair_17.Enabled = true;
                Chair_18.Enabled = true;
                Chair_19.Enabled = true;
                Chair_20.Enabled = true;
                Chair_22.Enabled = true;
                Chair_23.Enabled = true;
                Chair_24.Enabled = true;
                Chair_25.Enabled = true;
                Chair_26.Enabled = true;
                Chair_27.Enabled = true;
                Chair_28.Enabled = true;
                Chair_29.Enabled = true;
                Chair_30.Enabled = true;
                Chair_31.Enabled = true;
                Chair_32.Enabled = true;
                Chair_33.Enabled = true;
                Chair_34.Enabled = true;
                Chair_35.Enabled = true;
                Chair_36.Enabled = true;
                Chair_37.Enabled = true;
                Chair_38.Enabled = true;
                Chair_39.Enabled = true;
                Chair_40.Enabled = true;
                Chair_41.Enabled = true;
                Chair_42.Enabled = true;
                Chair_43.Enabled = true;
                Chair_44.Enabled = true;
                Chair_45.Enabled = true;
                Chair_46.Enabled = true;
                Chair_47.Enabled = true;
                Chair_48.Enabled = true;
                Chair_49.Enabled = true;
                Chair_50.Enabled = true;
                button1.Enabled = true;
            }

        }
        private void ResetButtonBackColor(Object sender)
        {
            var button1 = (PictureBox)sender;

            if (Chair_1.BackColor == Color.Gold || Chair_2.BackColor == Color.Gold || Chair_3.BackColor == Color.Gold
                || Chair_4.BackColor == Color.Gold || Chair_5.BackColor == Color.Gold || Chair_6.BackColor == Color.Gold
                || Chair_7.BackColor == Color.Gold || Chair_8.BackColor == Color.Gold || Chair_9.BackColor == Color.Gold
                || Chair_10.BackColor == Color.Gold || Chair_11.BackColor == Color.Gold || Chair_12.BackColor == Color.Gold
                || Chair_13.BackColor == Color.Gold || Chair_14.BackColor == Color.Gold || Chair_15.BackColor == Color.Gold
                || Chair_16.BackColor == Color.Gold || Chair_17.BackColor == Color.Gold || Chair_18.BackColor == Color.Gold
                || Chair_19.BackColor == Color.Gold || Chair_20.BackColor == Color.Gold || Chair_21.BackColor == Color.Gold
                || Chair_22.BackColor == Color.Gold || Chair_23.BackColor == Color.Gold || Chair_24.BackColor == Color.Gold
                || Chair_25.BackColor == Color.Gold || Chair_26.BackColor == Color.Gold || Chair_27.BackColor == Color.Gold
                || Chair_28.BackColor == Color.Gold || Chair_29.BackColor == Color.Gold || Chair_30.BackColor == Color.Gold
                || Chair_31.BackColor == Color.Gold || Chair_32.BackColor == Color.Gold || Chair_33.BackColor == Color.Gold
                || Chair_34.BackColor == Color.Gold || Chair_35.BackColor == Color.Gold || Chair_36.BackColor == Color.Gold
                || Chair_37.BackColor == Color.Gold || Chair_38.BackColor == Color.Gold || Chair_39.BackColor == Color.Gold
                || Chair_40.BackColor == Color.Gold || Chair_41.BackColor == Color.Gold || Chair_42.BackColor == Color.Gold
                || Chair_43.BackColor == Color.Gold || Chair_44.BackColor == Color.Gold || Chair_45.BackColor == Color.Gold
                || Chair_46.BackColor == Color.Gold || Chair_47.BackColor == Color.Gold || Chair_48.BackColor == Color.Gold
                || Chair_49.BackColor == Color.Gold || Chair_50.BackColor == Color.Gold)
            {
                Chair_Number.Text = "ــــ";
                button1.BackColor = Color.White;
                Enable_true(sender);
            }
            else
            {
                Enable_false(sender);
                button1.BackColor = Color.Gold;
                Chair_Number.Text = button1.Tag.ToString();
            }

        }

        private void Chair_1_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
            //Color_Chair_Select(sender);
        }

        private void Chair_2_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
            //Color_Chair_Select(sender);
        }

        private void Chair_3_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_4_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_5_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_6_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_7_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_8_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_9_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_10_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_11_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_12_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_13_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_14_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_15_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_16_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_43_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_18_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_19_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_20_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_21_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_22_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_23_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_24_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_25_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_26_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_27_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_28_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_29_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_30_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_31_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_32_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_33_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_34_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_35_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_36_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_37_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);

        }

        private void Chair_38_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_39_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_40_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_41_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_42_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_17_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_44_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_45_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_46_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_47_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_48_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_49_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_50_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuGroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
