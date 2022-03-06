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
    public partial class Form_Exp_Wash : UserControl
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassExpWash classExpWash = new ClassExpWash();
        public Form_Exp_Wash()
        {
            InitializeComponent();
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView2, bunifuVScrollBar1);
        }
        private void Read_ExpWash()
        {
            DataSet ds = new DataSet();
            classExpWash.Read_all().Fill(ds);
            bunifuDataGridView2.DataSource = ds.Tables[0];
        }
        private void Get_Max()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select isnull (max(cast(ID_BusWash as int)),0)+1 from BusWash", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            ID_WashExp.Text = dt.Rows[0][0].ToString();
        }
        private void Clear()
        {
            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear();
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
            classExpWash.ID_BusWash = int.Parse(ID_WashExp.Text);
            classExpWash.Drive_name = bunifuTextBox1.Text;
            classExpWash.Drive_Phone = bunifuTextBox2.Text;
            classExpWash.Wash_Cost = int.Parse(bunifuTextBox3.Text);
            classExpWash.Bus_Number = int.Parse(bunifuTextBox4.Text);
            classExpWash.Date = DateTime.Parse(bunifuDatePicker1.Value.ToShortDateString());
        }
        private void Form_Exp_Wash_Load(object sender, EventArgs e)
        {
            //bunifuDatePicker1.MinDate = DateTime.Now;
            bunifuDatePicker1.Value = DateTime.Now.Date;
            this.Dock = DockStyle.Fill;
            AutoCompleteTextBox2();
            AutoCompleteTextBox();
            bunifuVScrollBar1.BorderRadius = 14;
            try
            {
                Read_ExpWash();
                Get_Max();
                // bunifuDataGridView2.ColumnHeadersHeight = 30;
                bunifuDataGridView2.Columns[0].HeaderCell.Value = "رقم البند";
                bunifuDataGridView2.Columns[1].HeaderCell.Value = "إسم السائق";
                bunifuDataGridView2.Columns[2].HeaderCell.Value = "رقم السائق";
                bunifuDataGridView2.Columns[3].HeaderCell.Value = "رقم الباص";
                bunifuDataGridView2.Columns[4].HeaderCell.Value = "تكلفة الغسيل";
                bunifuDataGridView2.Columns[5].HeaderCell.Value = "التاريخ";
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
                else if (bunifuTextBox2.Text == "")
                {
                    MessageBox.Show("برجاء إدخال رقم هاتف السائق");
                }
                else if (bunifuTextBox3.Text == "")
                {
                    MessageBox.Show("برجاء إدخال تكلفة الغسيل");
                }
                else
                {
                    Get_Max();
                    insert_control();
                    classExpWash.save();
                    Read_ExpWash();
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
                classExpWash.Update();
                Read_ExpWash();
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
                classExpWash.Delete();
                Read_ExpWash();
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
            Read_ExpWash();
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
                ID_WashExp.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                bunifuTextBox1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                bunifuTextBox2.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                bunifuTextBox3.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                bunifuTextBox4.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                bunifuDatePicker1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void bunifuTextBox6_TextChange(object sender, EventArgs e)
        {
            if (bunifuTextBox6.Text == "")
            {
                Read_ExpWash();
            }
            else
            {
                SqlDataAdapter ada = new SqlDataAdapter("Select * from BusWash where Drive_name like '%" + bunifuTextBox6.Text + "%'", sqlcon);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                bunifuDataGridView2.DataSource = dt;
            }
        }

        AutoCompleteStringCollection stringCollection2 = new AutoCompleteStringCollection();
        private void AutoCompleteTextBox2()
        {

            string con = "select Drive_Phone from BusWash where Drive_name='" + bunifuTextBox1.Text + "'";
            SqlCommand aCommand = new SqlCommand(con, sqlcon);
            sqlcon.Open();
            SqlDataReader aReader = aCommand.ExecuteReader();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    stringCollection2.Add(aReader[0].ToString());
                }
            }
            aReader.Close();
            sqlcon.Close();
            bunifuTextBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            bunifuTextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            bunifuTextBox2.AutoCompleteCustomSource = stringCollection2;
        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            AutoCompleteTextBox2();
            SqlDataAdapter ada = new SqlDataAdapter("Select Drive_Phone from BusWash where Drive_name='" + bunifuTextBox1.Text + "'", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                bunifuTextBox2.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                bunifuTextBox2.Clear();
            }
        }

        AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
        private void AutoCompleteTextBox()
        {
            string con = "select Drive_name from BusWash";
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
    }
}
