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
    public partial class Form_Exp_Driver : UserControl
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassExpDriver classExpDriver = new ClassExpDriver();
        public Form_Exp_Driver()
        {
            InitializeComponent();
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView2, bunifuVScrollBar1);
        }
        private void Read_ExpDriver()
        {
            DataSet ds = new DataSet();
            classExpDriver.Read_all().Fill(ds);
            bunifuDataGridView2.DataSource = ds.Tables[0];
        }
        private void Get_Max()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select isnull (max(cast(ID_DriveExp as int)),0)+1 from Driver_Expenses", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            ID_DriveExp.Text = dt.Rows[0][0].ToString();
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
            classExpDriver.ID_DriveExp = int.Parse(ID_DriveExp.Text);
            classExpDriver.Drive_name = bunifuTextBox1.Text;
            classExpDriver.Drive_Phone = bunifuTextBox2.Text;
            classExpDriver.Drive_Money = int.Parse(bunifuTextBox3.Text);
            classExpDriver.Date = DateTime.Parse(bunifuDatePicker1.Text);
        }
            private void Form_Exp_Driver_Load(object sender, EventArgs e)
            {
              AutoCompleteTextBox2();
              AutoCompleteTextBox();
            bunifuDatePicker1.MinDate = DateTime.Now;
            bunifuVScrollBar1.BorderRadius = 14;
            this.Dock = DockStyle.Fill;
            try
            {
                Read_ExpDriver();
                Get_Max();
                // bunifuDataGridView2.ColumnHeadersHeight = 30;
                bunifuDataGridView2.Columns[0].HeaderCell.Value = "رقم البند";
                bunifuDataGridView2.Columns[1].HeaderCell.Value = "إسم السائق";
                bunifuDataGridView2.Columns[2].HeaderCell.Value = "رقم السائق";
                bunifuDataGridView2.Columns[3].HeaderCell.Value = "مستحقات السائق";
                bunifuDataGridView2.Columns[4].HeaderCell.Value = "التاريخ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");

            }
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

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
                    MessageBox.Show("برجاء إدخال مستحقات السائق");
                }
                else
                {
                    Get_Max();
                    insert_control();
                    classExpDriver.save();
                    Read_ExpDriver();
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
                classExpDriver.Update();
                Read_ExpDriver();
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
                classExpDriver.Delete();
                Read_ExpDriver();
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
            Read_ExpDriver();
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

        private void bunifuDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
               // DateTime test = DateTime.Parse(bunifuDataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString());
               // if (test.Date >= DateTime.Now.Date)
               // {
                    btn_Save.Enabled = false;
                    bunifuButton22.Enabled = true;
                    bunifuButton23.Enabled = true;
                    bunifuButton24.Enabled = true;
                    ID_DriveExp.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    bunifuTextBox1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    bunifuTextBox2.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                    bunifuTextBox3.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                    bunifuDatePicker1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                //}
                //else
                //{
                    // MessageBox.Show("عفواً ... لا يمكن تعديل هذا الحجز نظراً لمضي تاريخه");
               // }
            }
        }

        private void bunifuTextBox6_TextChange(object sender, EventArgs e)
        {
            if (bunifuTextBox6.Text == "")
            {
                Read_ExpDriver();
            }
            else
            {
                SqlDataAdapter ada = new SqlDataAdapter("Select * from Driver_Expenses where Drive_name like '%" + bunifuTextBox6.Text + "%'", sqlcon);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                bunifuDataGridView2.DataSource = dt;
            }
        }
        AutoCompleteStringCollection stringCollection2 = new AutoCompleteStringCollection();
        private void AutoCompleteTextBox2()
        {

            string con = "select Drive_Phone from Driver_Expenses where Drive_name='" + bunifuTextBox1.Text + "'";
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
            SqlDataAdapter ada = new SqlDataAdapter("Select Drive_Phone from Driver_Expenses where Drive_name='" + bunifuTextBox1.Text + "'", sqlcon);
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
            string con = "select Drive_name from Driver_Expenses";
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
