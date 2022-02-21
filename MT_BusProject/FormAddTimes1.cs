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
    public partial class FormAddTimes1 : UserControl
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassTimes classTimes = new ClassTimes();
        string id;
        public FormAddTimes1()
        {
            InitializeComponent();
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView2, bunifuVScrollBar2);
        }
        private SqlConnection DB_Connection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True";
            con.Open();
            return con;
        }
        private SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Stations";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
        private void Fill_Data_ComboBox()
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            Read_all().Fill(dt);
            Read_all().Fill(dt2);
            foreach (DataRow row in dt.Rows)
            {
                //Add Item to ListView.
                bunifuDropdown1.DataSource = dt;
                bunifuDropdown1.ValueMember = "Name_Station";
            }
            foreach (DataRow row in dt2.Rows)
            {
                //Add Item to ListView.
                bunifuDropdown2.DataSource = dt2;
                bunifuDropdown2.ValueMember = "Name_Station";
            }
        }
        private void Fill_Data()
        {
            bunifuVScrollBar2.BorderRadius = 14;
            DataSet ds = new DataSet();
            classTimes.Read_all().Fill(ds);
            bunifuDataGridView2.DataSource = ds.Tables[0];
        }
        private void Get_Max()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select isnull (max(cast(ID_Time as int)),0)+1 from Times", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            id = dt.Rows[0][0].ToString();
        }
        private void Clear()
        {
            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear();
            bunifuTextBox3.Clear();
        }
        private void Enable_False()
        {
            btn_Save.Enabled = true;
            bunifuButton22.Enabled = false;
            bunifuButton23.Enabled = false;
            bunifuButton24.Enabled = false;
        }
        private void insert_control()
        {
            classTimes.ID_Time = int.Parse(id);
            classTimes.Start_Station = this.bunifuDropdown1.GetItemText(this.bunifuDropdown1.SelectedItem);
            classTimes.End_Station = this.bunifuDropdown2.GetItemText(this.bunifuDropdown2.SelectedItem);
            classTimes.Start_Time = bunifuTextBox1.Text;
            classTimes.End_Time = bunifuTextBox2.Text;
            classTimes.Ticket_Price = int.Parse(bunifuTextBox3.Text);
        }
        private void Get_ID()
        {
            if (bunifuTextBox2.Text != "")
            {
                SqlDataAdapter ada = new SqlDataAdapter("Select ID_Time from Times where Start_Station = '" + bunifuDropdown1.Text + "' and Start_Time = '"+ bunifuTextBox1.Text + "' and End_Station = '"+ bunifuDropdown2.Text+ "' and End_Time = '"+ bunifuTextBox2.Text + "'", sqlcon);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                id = dt.Rows[0][0].ToString();
            }
        }
        private void FormAddTimes1_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            try
            {
                Get_Max();
                Fill_Data();
                Fill_Data_ComboBox();
               // bunifuDataGridView2.ColumnHeadersHeight = 30;
                bunifuDataGridView2.Columns[0].HeaderCell.Value = "الرقم التعريفي";
                bunifuDataGridView2.Columns[1].HeaderCell.Value = "محطة القيام";
                bunifuDataGridView2.Columns[2].HeaderCell.Value = "وقت القيام";
                bunifuDataGridView2.Columns[3].HeaderCell.Value = "محطة الوصول";
                bunifuDataGridView2.Columns[4].HeaderCell.Value = "الوقت المتوقع للوصول";
                bunifuDataGridView2.Columns[4].Width = 135;
                bunifuDataGridView2.Columns[5].HeaderCell.Value = "سعر التذكرة";
                DB_Connection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");

            }
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            Fill_Data();
            Get_Max();
            Clear();
            Enable_False();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                insert_control();
                if (bunifuTextBox1.Text == "")
                {
                    MessageBox.Show("برجاء إدخال ميعاد القيام");
                }
                else if (bunifuTextBox2.Text == "")
                {
                    MessageBox.Show("برجاء إدخال الميعاد المتوقع للوصول");
                }
                else if (bunifuTextBox3.Text == "")
                {
                    MessageBox.Show("برجاء إدخال سعر التذكرة");
                }
                else
                {
                    Get_Max();
                    classTimes.save();
                    Fill_Data();
                    MessageBox.Show("تم التسجيل بنجاح ^_^");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            try
            {
                insert_control();
                classTimes.Update();
                Clear();
                Fill_Data();
                MessageBox.Show("تم التعديل بنجاح ^_^");
                Enable_False();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void bunifuDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Save.Enabled = false;
            bunifuButton22.Enabled = true;
            bunifuButton23.Enabled = true;
            bunifuButton24.Enabled = true;
            if (e.RowIndex != -1)
            {
                bunifuDropdown1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                bunifuTextBox1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                bunifuDropdown2.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                bunifuTextBox2.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                bunifuTextBox3.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                Get_ID();
            }
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            try
            {
                insert_control();
                classTimes.Delete();
                Fill_Data();
                Get_Max();
                MessageBox.Show("تم الحذف بنجاح ^_^");
                Clear();
                Enable_False();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }
    }
}
