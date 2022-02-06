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
    
    public partial class Login : Form
    {
        
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            CheckID checkID = new CheckID();
            checkID.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Users WHERE Username='" + usernametext.Text + "' AND Password='" + passwordtext.Text + "'", sqlcon);
               
                /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlDataAdapter sda2 = new SqlDataAdapter("SELECT FullName FROM Users WHERE Username='" + usernametext.Text + "'", sqlcon);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    string name = dt2.Rows[0][0].ToString();
                    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                    MessageBox.Show( " ^_^ "+"مرحباً بك "+name);
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

      
    }
}
