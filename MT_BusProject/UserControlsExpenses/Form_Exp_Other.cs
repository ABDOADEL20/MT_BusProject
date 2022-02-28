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
    public partial class Form_Exp_Other : UserControl
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassOtherExpenses classOtherExpenses = new ClassOtherExpenses();
        public Form_Exp_Other()
        {
            InitializeComponent();
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView2, bunifuVScrollBar1);
        }
        private void Read_ExpOtherExpenses()
        {
            DataSet ds = new DataSet();
            classOtherExpenses.Read_all().Fill(ds);
            bunifuDataGridView2.DataSource = ds.Tables[0];
        }
        private void Get_Max()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select isnull (max(cast(ID_OtherExpenses as int)),0)+1 from OtherExpenses", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            ID_OtherExpenses.Text = dt.Rows[0][0].ToString();
        }
        private void Clear()
        {
            bunifuTextBox1.Clear();
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
            classOtherExpenses.ID_OtherExpenses = int.Parse(ID_OtherExpenses.Text);
            classOtherExpenses.Other_Name = bunifuTextBox1.Text;
            classOtherExpenses.Cost = int.Parse(bunifuTextBox3.Text);
            classOtherExpenses.Date = DateTime.Parse(bunifuDatePicker1.Text);
        }
        private void Form_Exp_Other_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            AutoCompleteTextBox();
            bunifuVScrollBar1.BorderRadius = 14;
            try
            {
                Read_ExpOtherExpenses();
                Get_Max();
                // bunifuDataGridView2.ColumnHeadersHeight = 30;
                bunifuDataGridView2.Columns[0].HeaderCell.Value = "رقم البند";
                bunifuDataGridView2.Columns[1].HeaderCell.Value = "إسم البند";
                bunifuDataGridView2.Columns[2].HeaderCell.Value = "التكلفة";
                bunifuDataGridView2.Columns[3].HeaderCell.Value = "التاريخ";
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
                    MessageBox.Show("برجاء إدخال إسم البند");
                }
                else if (bunifuTextBox3.Text == "")
                {
                    MessageBox.Show("برجاء إدخال التكلفة");
                }
                else
                {
                    Get_Max();
                    insert_control();
                    classOtherExpenses.save();
                    Read_ExpOtherExpenses();
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
                classOtherExpenses.Update();
                Read_ExpOtherExpenses();
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
                classOtherExpenses.Delete();
                Read_ExpOtherExpenses();
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
            Read_ExpOtherExpenses();
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
                btn_Save.Enabled = false;
                bunifuButton22.Enabled = true;
                bunifuButton23.Enabled = true;
                bunifuButton24.Enabled = true;
                ID_OtherExpenses.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                bunifuTextBox1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                bunifuTextBox3.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                bunifuDatePicker1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void bunifuTextBox6_TextChange(object sender, EventArgs e)
        {
            if (bunifuTextBox6.Text == "")
            {
                Read_ExpOtherExpenses();
            }
            else
            {
                SqlDataAdapter ada = new SqlDataAdapter("Select * from OtherExpenses where Other_Name like '%" + bunifuTextBox6.Text + "%'", sqlcon);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                bunifuDataGridView2.DataSource = dt;
            }
        }
        AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
        private void AutoCompleteTextBox()
        {
            string con = "select Other_Name from OtherExpenses";
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
            SqlDataAdapter ada = new SqlDataAdapter("Select Other_Name from OtherExpenses where Other_Name='" + bunifuTextBox1.Text + "'", sqlcon);
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
