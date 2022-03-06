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

namespace MT_BusProject.UserControlsExpenses
{
    public partial class Form_Exp_RoadService : UserControl
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassRoadServices classRoadServices = new ClassRoadServices();
        public Form_Exp_RoadService()
        {
            InitializeComponent();
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView2, bunifuVScrollBar1);
        }
        private void Read_ExpRoadServices()
        {
            DataSet ds = new DataSet();
            classRoadServices.Read_all().Fill(ds);
            bunifuDataGridView2.DataSource = ds.Tables[0];
        }
        private void Get_Max()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select isnull (max(cast(ID_BusSeRoad as int)),0)+1 from RoadServices", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            ID_RoadExp.Text = dt.Rows[0][0].ToString();
        }
        private void Clear()
        {
            bunifuTextBox1.Clear();
            bunifuTextBox3.Clear();
            bunifuTextBox4.Clear();
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
            classRoadServices.ID_BusSeRoad = int.Parse(ID_RoadExp.Text);
            classRoadServices.Driver_Name = bunifuTextBox1.Text;
            classRoadServices.ServiceRoad_Cost = int.Parse(bunifuTextBox3.Text);
            classRoadServices.Bus_Number = int.Parse(bunifuTextBox4.Text);
            classRoadServices.Date = DateTime.Parse(bunifuDatePicker1.Value.ToShortDateString());
        }
        private void Form_Exp_RoadService_Load(object sender, EventArgs e)
        {
            //bunifuDatePicker1.MinDate = DateTime.Now;
            bunifuDatePicker1.Value = DateTime.Now.Date;
            this.Dock = DockStyle.Fill;
            AutoCompleteTextBox();
            bunifuVScrollBar1.BorderRadius = 14;
            try
            {
                Read_ExpRoadServices();
                Get_Max();
                // bunifuDataGridView2.ColumnHeadersHeight = 30;
                bunifuDataGridView2.Columns[0].HeaderCell.Value = "رقم البند";
                bunifuDataGridView2.Columns[1].HeaderCell.Value = "رقم الباص";
                bunifuDataGridView2.Columns[2].HeaderCell.Value = "إسم السائق";
                bunifuDataGridView2.Columns[3].HeaderCell.Value = "التكلفة";
                bunifuDataGridView2.Columns[4].HeaderCell.Value = "التاريخ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuTextBox1.Text == "")
                {
                    MessageBox.Show("برجاء إدخال إسم السائق");
                }
                else if (bunifuTextBox3.Text == "")
                {
                    MessageBox.Show("برجاء إدخال تكلفة الكارته");
                }
                else if (bunifuTextBox4.Text == "")
                {
                    MessageBox.Show("برجاء إدخال رقم الباص");
                }
                else
                {
                    Get_Max();
                    insert_control();
                    classRoadServices.save();
                    Read_ExpRoadServices();
                    MessageBox.Show("تم التسجيل بنجاح !");
                    Get_Max();
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
                classRoadServices.Update();
                Read_ExpRoadServices();
                MessageBox.Show("تم التعديل بنجاح ^_^");
                Get_Max();
                Clear();
                Enable_False();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            try
            {
                insert_control();
                classRoadServices.Delete();
                Read_ExpRoadServices();
                MessageBox.Show("تم الحذف بنجاح ^_^");
                Get_Max();
                Clear();
                Enable_False();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            Read_ExpRoadServices();
            Get_Max();
            Clear();
            Enable_False();
        }

        private void bunifuTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void bunifuTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void bunifuDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btn_Save.Enabled = false;
                bunifuButton22.Enabled = true;
                bunifuButton23.Enabled = true;
                bunifuButton24.Enabled = true;
                ID_RoadExp.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                bunifuTextBox4.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                bunifuTextBox1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                bunifuTextBox3.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                bunifuDatePicker1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void bunifuTextBox6_TextChange(object sender, EventArgs e)
        {
            if (bunifuTextBox6.Text == "")
            {
                Read_ExpRoadServices();
            }
            else
            {
                SqlDataAdapter ada = new SqlDataAdapter("Select * from RoadServices where Driver_Name like '%" + bunifuTextBox6.Text + "%'", sqlcon);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                bunifuDataGridView2.DataSource = dt;
            }
        }

        AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
        private void AutoCompleteTextBox()
        {
            string con = "select Driver_Name from RoadServices";
            SqlCommand aCommand = new SqlCommand(con, sqlcon);
            sqlcon.Open();
            SqlDataReader aReader = aCommand.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    stringCollection.Add(aReader[0].ToString());
                }
            }
            aReader.Close();
            sqlcon.Close();
            bunifuTextBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            bunifuTextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            bunifuTextBox1.AutoCompleteCustomSource = stringCollection;
        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select Driver_Name from RoadServices where Driver_Name='" + bunifuTextBox1.Text + "'", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                bunifuTextBox1.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                bunifuTextBox1.Clear();
            }
        }
    }
}
