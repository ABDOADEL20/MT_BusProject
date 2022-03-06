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
    public partial class FormShipping : UserControl
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassShipping classShipping = new ClassShipping();
        string Receipt_typeS, Collection_typeS;
        public FormShipping()
        {
            InitializeComponent();
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView2, bunifuVScrollBar1);
        }
        private void Read_Data_Shipping()
        {
            DataSet ds = new DataSet();
            classShipping.Read_all().Fill(ds);
            bunifuDataGridView2.DataSource = ds.Tables[0];
        }
        private void Get_Max()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select isnull (max(cast(ID_Shipping as int)),0)+1 from Shipping", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            ID_Shipping.Text = dt.Rows[0][0].ToString();
        }
        private void Clear()
        {
            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear();
            bunifuTextBox3.Clear();
            bunifuTextBox4.Clear();
            bunifuTextBox5.Clear();
            bunifuTextBox6.Clear();
            bunifuTextBox7.Clear();
            bunifuTextBox8.Clear();
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
            classShipping.ID_Shipping = int.Parse(ID_Shipping.Text);
            classShipping.Username = Form1.name_emp;
            classShipping.Type_Shipping = bunifuDropdown2.Text;
            classShipping.Name_Sender = bunifuTextBox1.Text;
            classShipping.Phone_Sender = bunifuTextBox2.Text;
            classShipping.To_Address = bunifuTextBox7.Text;
            classShipping.Cost_Shipping = int.Parse(bunifuTextBox3.Text);
            classShipping.Date_Shipping = DateTime.Parse(bunifuDatePicker1.Value.ToShortDateString());
            classShipping.Name_Receiver = bunifuTextBox4.Text;
            classShipping.Phone_Receiver = bunifuTextBox5.Text;
            classShipping.Notes = bunifuTextBox8.Text;

            if(bunifuRadioButton1.Checked == true)
            {
                Receipt_typeS = "تسليم مكتب";
            }
            if(bunifuRadioButton2.Checked == true)
            {
                Receipt_typeS = "تسليم سائق";
            }
            classShipping.Receipt_type = Receipt_typeS;

            if (bunifuRadioButton3.Checked == true)
            {
                Collection_typeS = "تحصيل مكتب آخر";
            }
            if (bunifuRadioButton4.Checked == true)
            {
                Collection_typeS = "تحصيل مكتب قنا";
            }
            classShipping.Collection_type = Collection_typeS;

            classShipping.ID_User = int.Parse(Form1.user_id);
        }

        AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
        private void AutoCompleteTextBox()
        {
            string con = "select Name_Sender from Shipping";
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

        AutoCompleteStringCollection stringCollection2 = new AutoCompleteStringCollection();
        private void AutoCompleteTextBox2()
        {
            string con = "select Phone_Sender from Shipping where Name_Sender='" + bunifuTextBox1.Text + "'";
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

        AutoCompleteStringCollection stringCollection3 = new AutoCompleteStringCollection();
        private void AutoCompleteTextBox3()
        {
            string con = "select Name_Receiver from Shipping";
            SqlCommand aCommand = new SqlCommand(con, sqlcon);
            sqlcon.Open();
            SqlDataReader aReader = aCommand.ExecuteReader();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    stringCollection3.Add(aReader[0].ToString());
                }
            }
            aReader.Close();
            sqlcon.Close();
            bunifuTextBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            bunifuTextBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;
            bunifuTextBox4.AutoCompleteCustomSource = stringCollection3;
        }

        AutoCompleteStringCollection stringCollection4 = new AutoCompleteStringCollection();
        private void AutoCompleteTextBox4()
        {
            string con = "select Phone_Receiver from Shipping where Name_Receiver='" + bunifuTextBox4.Text + "'";
            SqlCommand aCommand = new SqlCommand(con, sqlcon);
            sqlcon.Open();
            SqlDataReader aReader = aCommand.ExecuteReader();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    stringCollection4.Add(aReader[0].ToString());
                }
            }
            aReader.Close();
            sqlcon.Close();
            bunifuTextBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            bunifuTextBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;
            bunifuTextBox4.AutoCompleteCustomSource = stringCollection4;
        }
        private void FormShipping_Load(object sender, EventArgs e)
        {
            AutoCompleteTextBox();
            AutoCompleteTextBox2();
            AutoCompleteTextBox3();
            AutoCompleteTextBox4();

            bunifuDropdown2.SelectedIndex = 0;
            bunifuVScrollBar1.BorderRadius = 14;
            bunifuDatePicker1.MinDate = DateTime.Now.Date;
            this.Dock = DockStyle.Fill;
            try
            {
                Read_Data_Shipping();
                Get_Max();
                // bunifuDataGridView2.ColumnHeadersHeight = 30;
                bunifuDataGridView2.Columns[0].HeaderCell.Value = "رقم الشحنة";
                bunifuDataGridView2.Columns[1].HeaderCell.Value = "إسم الموظف";
                bunifuDataGridView2.Columns[2].HeaderCell.Value = "نوع الشحنة";
                bunifuDataGridView2.Columns[3].HeaderCell.Value = "إسم الراسل";
                bunifuDataGridView2.Columns[4].HeaderCell.Value = "هاتف الراسل";
                //bunifuDataGridView2.Columns[4].Width = 135;
                bunifuDataGridView2.Columns[5].HeaderCell.Value = "إلى محافظة";
                bunifuDataGridView2.Columns[6].HeaderCell.Value = "تكلفة الشحنة";
                bunifuDataGridView2.Columns[7].HeaderCell.Value = "تاريخ الشحن";
                bunifuDataGridView2.Columns[8].HeaderCell.Value = "إسم المرسل إليه";
                bunifuDataGridView2.Columns[9].HeaderCell.Value = "هاتف المرسل إليه";
                bunifuDataGridView2.Columns[10].HeaderCell.Value = "طريقة التسليم";
                bunifuDataGridView2.Columns[11].HeaderCell.Value = "طريقة التحصيل";
                bunifuDataGridView2.Columns[12].HeaderCell.Value = "الرقم التعريفي للموظف";
                bunifuDataGridView2.Columns[13].HeaderCell.Value = "ملاحظات";

            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");

            }
        }

        private void bunifuHScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuHScrollBar.ScrollEventArgs e)
        {
            try
            {
                bunifuDataGridView2.FirstDisplayedScrollingColumnIndex = bunifuDataGridView2.Columns[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void bunifuDataGridView2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                bunifuHScrollBar1.Maximum = bunifuDataGridView2.ColumnCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bunifuDataGridView2_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                bunifuHScrollBar1.Maximum = bunifuDataGridView2.ColumnCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuTextBox1.Text == "")
                {
                    MessageBox.Show("برجاء إدخال إسم الراسل");
                }
                else if (bunifuTextBox2.Text == "")
                {
                    MessageBox.Show("برجاء إدخال رقم هاتف الراسل");
                }
                else if (bunifuTextBox3.Text == "")
                {
                    MessageBox.Show("برجاء إدخال تكلفة الشحن");
                }
                else if (bunifuTextBox4.Text == "")
                {
                    MessageBox.Show("برجاء إدخال إسم المرسل إليه");
                }
                else if (bunifuTextBox5.Text == "")
                {
                    MessageBox.Show("برجاء إدخال رقم هاتف المرسل إليه");
                }
                else if (bunifuTextBox7.Text == "")
                {
                    MessageBox.Show("برجاء إدخال المحافظة المرسل إليها");
                }
                else
                {
                    Get_Max();
                    insert_control();
                    classShipping.save();
                    Read_Data_Shipping();
                    MessageBox.Show("تم تسجيل الشحنة بنجاح !");
                    Get_Max();
                    Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            try
            {
                insert_control();
                classShipping.Update();
                Read_Data_Shipping();
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
                classShipping.Delete();
                Read_Data_Shipping();
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
            Read_Data_Shipping();
            Get_Max();
            Clear();
            Enable_False();
        }

        private void bunifuTextBox6_TextChange(object sender, EventArgs e)
        {
            if (bunifuTextBox6.Text == "")
            {
                Read_Data_Shipping();
            }
            else
            {
                SqlDataAdapter ada = new SqlDataAdapter("Select * from Shipping where Name_Sender like '%" + bunifuTextBox6.Text + "%'", sqlcon);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                bunifuDataGridView2.DataSource = dt;
            }
        }

        private void bunifuTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteTextBox2();
            SqlDataAdapter ada = new SqlDataAdapter("Select Phone_Sender from Shipping where Name_Sender='" + bunifuTextBox1.Text + "'", sqlcon);
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
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ ... يرجى المحاولة مره أخرى");
            }
        }

        private void bunifuTextBox4_TextChange(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteTextBox3();
                SqlDataAdapter ada = new SqlDataAdapter("Select Phone_Receiver from Shipping where Name_Receiver ='" + bunifuTextBox4.Text + "'", sqlcon);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    bunifuTextBox5.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    bunifuTextBox5.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("يوجد خطأ ... يرجى المحاولة مره أخرى");
            }
        }

        private void bunifuDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DateTime test = DateTime.Parse(bunifuDataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString());
                if (test.Date >= DateTime.Now.Date)
                {
                    btn_Save.Enabled = false;
                    bunifuButton22.Enabled = true;
                    bunifuButton23.Enabled = true;
                    bunifuButton24.Enabled = true;
                    ID_Shipping.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    bunifuDropdown2.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                    bunifuTextBox1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                    bunifuTextBox2.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                    bunifuTextBox7.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                    bunifuTextBox3.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                    bunifuDatePicker1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
                    bunifuTextBox4.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
                    bunifuTextBox5.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
                    bunifuTextBox8.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString();
                    //string selected_recepit = bunifuDataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();

                    SqlDataAdapter ada = new SqlDataAdapter("Select Receipt_type from Shipping where ID_Shipping='"+ ID_Shipping.Text + "'", sqlcon);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    string recepit = dt.Rows[0][0].ToString();
                    if(recepit== "تسليم مكتب")
                    {
                        bunifuRadioButton1.Checked = true;
                        bunifuRadioButton2.Checked = false;
                    }
                    if(recepit== "تسليم سائق")
                    {
                        bunifuRadioButton2.Checked = true;
                        bunifuRadioButton1.Checked = false;
                    }

                    SqlDataAdapter ada2 = new SqlDataAdapter("Select Collection_type from Shipping where ID_Shipping='" + ID_Shipping.Text + "'", sqlcon);
                    DataTable dt2 = new DataTable();
                    ada2.Fill(dt2);
                    string collection = dt2.Rows[0][0].ToString();
                    if (collection == "تحصيل مكتب آخر")
                    {
                        bunifuRadioButton3.Checked = true;
                        bunifuRadioButton4.Checked = false;
                    }
                    if (collection == "تحصيل مكتب قنا")
                    {
                        bunifuRadioButton4.Checked = true;
                        bunifuRadioButton3.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("عفواً ... لا يمكن تعديل هذا الحجز نظراً لمضي تاريخه");
                }

            }
        }

    }
}
