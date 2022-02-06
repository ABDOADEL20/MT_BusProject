using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT_BusProject
{
    public partial class SignUp : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        SqlCommand cmd;
        ClassUsers classUsers = new ClassUsers();
        string vid;
        public SignUp()
        {
            InitializeComponent();
            
        }

        private void Fill_Data()
        {

            DataSet ds = new DataSet();
            classUsers.Read_all().Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Get_Max()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select isnull (max(cast(User_ID as int)),0)+1 from Users", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            useridtext.Text = dt.Rows[0][0].ToString();
        }

        private void Clear()
        {
            nameofficertext.Clear();
            usernametext.Clear();
            passwordtext.Clear();
        }

        private void insert_control()
        {
            classUsers.User_ID = int.Parse(useridtext.Text);
            classUsers.FullName = nameofficertext.Text;
            classUsers.Username = usernametext.Text;
            classUsers.Password = passwordtext.Text;
        }

        private void Enable_False()
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            
            try
            {
                Get_Max();
                Fill_Data();
                dataGridView1.Columns[0].HeaderCell.Value = "الرقم التعريفي";
                dataGridView1.Columns[1].HeaderCell.Value = "إسم الموظف";
                dataGridView1.Columns[2].HeaderCell.Value = "إسم المستخدم";
                dataGridView1.Columns[3].HeaderCell.Value = "كلمة المرور";
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                insert_control();
                if (nameofficertext.Text == "")
                {
                    MessageBox.Show("برجاء إدخال إسم الموظف");
                }
                else if (usernametext.Text == "")
                {
                    MessageBox.Show("برجاء إدخال إسم المستخدم");
                }
                else if (passwordtext.Text == "")
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

        private void button2_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            if (e.RowIndex != -1)
            {
                useridtext.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                nameofficertext.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                usernametext.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                passwordtext.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fill_Data();
            Get_Max();
            Clear();
            Enable_False();
        }

        private void button3_Click(object sender, EventArgs e)
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

      
    }
}
