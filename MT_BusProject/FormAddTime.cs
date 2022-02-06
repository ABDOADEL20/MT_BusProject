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
    public partial class FormAddTime : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassTimes classTimes = new ClassTimes();
        string id;
        public FormAddTime()
        {
            InitializeComponent();
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
                comboBox1.DataSource = dt;
                comboBox1.ValueMember = "Name_Station";
            }
            foreach (DataRow row in dt2.Rows)
            {
                //Add Item to ListView.
                comboBox2.DataSource = dt2;
                comboBox2.ValueMember = "Name_Station";
            }

        }

        private void Fill_Data()
        {
            DataSet ds = new DataSet();
            classTimes.Read_all().Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void Enable_False()
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void insert_control()
        {
            classTimes.ID_Time = int.Parse(id);
            classTimes.Start_Station = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            classTimes.End_Station = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            classTimes.Start_Time = textBox1.Text;
            classTimes.End_Time = textBox2.Text;
            classTimes.Ticket_Price = int.Parse(textBox3.Text);
        }

        private void FormAddTime_Load(object sender, EventArgs e)
        {
            try 
            {
                Get_Max();
                Fill_Data();
                Fill_Data_ComboBox();
                dataGridView1.ColumnHeadersHeight = 30;
                dataGridView1.Columns[0].HeaderCell.Value = "الرقم التعريفي";
                dataGridView1.Columns[1].HeaderCell.Value = "محطة القيام";
                dataGridView1.Columns[2].HeaderCell.Value = "وقت القيام";
                dataGridView1.Columns[3].HeaderCell.Value = "محطة الوصول";
                dataGridView1.Columns[4].HeaderCell.Value = "الوقت المتوقع للوصول";
                dataGridView1.Columns[4].Width = 135;
                dataGridView1.Columns[5].HeaderCell.Value = "سعر التذكرة";
                DB_Connection();
            }
            catch(Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fill_Data();
            Get_Max();
            Clear();
            Enable_False();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                insert_control();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("برجاء إدخال ميعاد القيام");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("برجاء إدخال الميعاد المتوقع للوصول");
                }
                else if (textBox3.Text == "")
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

        private void button2_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            if (e.RowIndex != -1)
            {

                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
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
