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
    public partial class FormAddStation : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassStations classStations = new ClassStations();
        int ID;
        public FormAddStation()
        {
            InitializeComponent();
          
        }

        private void Fill_Data()
        {
            DataTable dt = new DataTable();
            classStations.Read_all().Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                //Add Item to ListView.
                ListViewItem item = new ListViewItem(row["Name_Station"].ToString());
                item.SubItems.Add(row["ID_Station"].ToString());
                listView1.Items.Add(item);
            }
            listView1.View = View.List;
        }

        private void Enable_False()
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void Get_ID()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select ID_Station where Name_Station='"+stationtext.Text+"'", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            ID = int.Parse(dt.Rows[0][0].ToString());
        }

        private void FormAddStation_Load(object sender, EventArgs e)
        {
            try
            {
                Fill_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ID = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                stationtext.Text =  listView1.SelectedItems[0].Text;
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            Fill_Data();
            stationtext.Clear();
            Enable_False();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                classStations.Name_Station = stationtext.Text;
                if (stationtext.Text == "")
                {
                    MessageBox.Show("برجاء إدخال إسم المحطة");
                }
                else
                {
                    classStations.save();
                    listView1.Clear();
                    Fill_Data();
                    MessageBox.Show("تم التسجيل بنجاح ^_^");
                    stationtext.Clear();
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
                
                classStations.Name_Station = stationtext.Text;
                classStations.ID_Station = ID;
                classStations.Update();
                listView1.Clear();
                Fill_Data();
                MessageBox.Show("تم التعديل بنجاح ^_^");
                stationtext.Clear();
                Enable_False();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                classStations.Name_Station = stationtext.Text;
                classStations.ID_Station = ID;
                classStations.Delete();
                listView1.Clear();
                Fill_Data();
                MessageBox.Show("تم الحذف بنجاح ^_^");
                stationtext.Clear();
                Enable_False();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }
    }
}
