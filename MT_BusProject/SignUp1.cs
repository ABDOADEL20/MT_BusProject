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
    public partial class SignUp1 : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassUsers classUsers = new ClassUsers();

        private void Fill_Data()
        {

            DataSet ds = new DataSet();
            classUsers.Read_all().Fill(ds);
            bunifuDataGridView2.DataSource = ds.Tables[0];
        }

        private void Get_Max()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select isnull (max(cast(User_ID as int)),0)+1 from Users", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            bunifuTextBox2.Text = dt.Rows[0][0].ToString();
        }

        private void Clear()
        {
            bunifuTextBox1.Clear();
            bunifuTextBox3.Clear();
            bunifuTextBox4.Clear();
        }

        private void insert_control()
        {
            classUsers.User_ID = int.Parse(bunifuTextBox2.Text);
            classUsers.FullName = bunifuTextBox1.Text;
            classUsers.Username = bunifuTextBox3.Text;
            classUsers.Password = bunifuTextBox4.Text;
        }

        private void Enable_False()
        {
            btn_Save.Enabled = true;
            btn_edit.Enabled = false;
            btn_new.Enabled = false;
            btn_delete.Enabled = false;
        }

        public SignUp1()
        {
            InitializeComponent();
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView2, bunifuVScrollBar2);
        }

        private void SignUp1_Load(object sender, EventArgs e)
        {
            bunifuVScrollBar2.BorderRadius = 14;
            try
            {
                Get_Max();
                Fill_Data();
                bunifuDataGridView2.Columns[0].HeaderCell.Value = "الرقم التعريفي";
                bunifuDataGridView2.Columns[1].HeaderCell.Value = "إسم الموظف";
                bunifuDataGridView2.Columns[2].HeaderCell.Value = "إسم المستخدم";
                bunifuDataGridView2.Columns[3].HeaderCell.Value = "كلمة المرور";
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
               try
             {
                insert_control();
                if (bunifuTextBox1.Text == "")
                {
                    MessageBox.Show("برجاء إدخال إسم الموظف");
                }
                else if (bunifuTextBox3.Text == "")
                {
                    MessageBox.Show("برجاء إدخال إسم المستخدم");
                }
                else if (bunifuTextBox4.Text == "")
                {
                    MessageBox.Show("برجاء إدخال كلمة المرور");
                }
                else
                {
                    classUsers.save();
                    Fill_Data();
                    Get_Max();
                    MessageBox.Show("تم التسجيل بنجاح ^_^");
                    Clear();
                }
             }
            catch (Exception ex)
             {
              MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
             }
        }

        private void bunifuDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Save.Enabled = false;
            btn_edit.Enabled = true;
            btn_new.Enabled = true;
            btn_delete.Enabled = true;
            if (e.RowIndex != -1)
            {
                bunifuTextBox2.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                bunifuTextBox1.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                bunifuTextBox3.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                bunifuTextBox4.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                insert_control();
                classUsers.Update();
                Fill_Data();
                Get_Max();
                MessageBox.Show("تم التعديل بنجاح ^_^");
                Clear();
                Enable_False();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                insert_control();
                classUsers.Delete();
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

        private void btn_new_Click(object sender, EventArgs e)
        {
            Fill_Data();
            Get_Max();
            Clear();
            Enable_False();
        }
    }
}
