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
    public partial class FormAddStations1 : UserControl
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassStations classStations = new ClassStations();
        int ID;
        public FormAddStations1()
        {
            InitializeComponent();
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView1, bunifuVScrollBar2);
        }
        private void Fill_Data()
        {
            DataSet ds = new DataSet();
            classStations.Read_all().Fill(ds);
            bunifuDataGridView1.DataSource = ds.Tables[0];
            bunifuDataGridView1.Columns[0].HeaderCell.Value = "الــمــحــطــات";
        }
        private void Enable_False()
        {
            btn_Save.Enabled = true;
            bunifuButton22.Enabled = false;
            bunifuButton23.Enabled = false;
            bunifuButton24.Enabled = false;
        }
        private void Get_ID()
        {
            if (bunifuTextBox2.Text != "")
            {
                SqlDataAdapter ada = new SqlDataAdapter("Select ID_Station from Stations where Name_Station = '" + bunifuTextBox2.Text + "'", sqlcon);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                ID = int.Parse(dt.Rows[0][0].ToString());
            }
        }
        private void FormAddStations1_Load(object sender, EventArgs e)
        {
            bunifuVScrollBar2.BorderRadius = 14;
            this.Dock = DockStyle.Fill;
            try
            {
                Fill_Data();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            
            Fill_Data();
            bunifuTextBox2.Clear();
            Enable_False();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                classStations.Name_Station = bunifuTextBox2.Text;
                if (bunifuTextBox2.Text == "")
                {
                    MessageBox.Show("برجاء إدخال إسم المحطة");
                }
                else
                {
                    classStations.save();
                    
                    Fill_Data();
                    MessageBox.Show("تم التسجيل بنجاح ^_^");
                    bunifuTextBox2.Clear();
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
                classStations.Name_Station = bunifuTextBox2.Text;
                
                classStations.ID_Station = ID;
                classStations.Update();
                
                Fill_Data();
                MessageBox.Show("تم التعديل بنجاح ^_^");
                bunifuTextBox2.Clear();
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
                classStations.Name_Station = bunifuTextBox2.Text;
                classStations.ID_Station = ID;
                classStations.Delete();
                
                Fill_Data();
                MessageBox.Show("تم الحذف بنجاح ^_^");
                bunifuTextBox2.Clear();
                Enable_False();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void bunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                bunifuTextBox2.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Get_ID();
                btn_Save.Enabled = false;
                bunifuButton22.Enabled = true;
                bunifuButton23.Enabled = true;
                bunifuButton24.Enabled = true;
            }
        }
    }
}
