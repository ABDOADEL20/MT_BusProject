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
    public partial class Login1 : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";

        public Login1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            try
            {

                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Users WHERE Username='" + bunifuTextBox1.Text + "' AND Password='" + bunifuTextBox2.Text + "'", sqlcon);

                /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlDataAdapter sda2 = new SqlDataAdapter("SELECT FullName FROM Users WHERE Username='" + bunifuTextBox1.Text + "'", sqlcon);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    string name = dt2.Rows[0][0].ToString();
                    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                    MessageBox.Show(" ^_^ " + "مرحباً بك " + name);
                    SetValueForText1 = name;

                    SqlDataAdapter sda3 = new SqlDataAdapter("SELECT User_ID FROM Users WHERE Username='" + bunifuTextBox1.Text + "'", sqlcon);
                    DataTable dt3 = new DataTable();
                    sda3.Fill(dt3);
                    string name3 = dt3.Rows[0][0].ToString();
                    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                    SetValueForText2 = name3;

                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.Closed += (s, args) => this.Close();
                    form1.Show();
                }
                else
                {
                    MessageBox.Show("خطأ في إسم المستخدم أو كلمة المرور");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            CheckID1 checkID1 = new CheckID1();
            checkID1.Show();
        }
    }
}
