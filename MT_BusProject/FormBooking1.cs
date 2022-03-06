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
    public partial class FormBooking1 : UserControl
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True");
        ClassTimes classTimes = new ClassTimes();
        ClassBooking classBooking = new ClassBooking();
        public static string name_emp = "";

        float price_ticket;
        public FormBooking1()
        {
            InitializeComponent();
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView1, bunifuVScrollBar1);
            Bunifu.Utils.ScrollbarBinder.BindDatagridView(bunifuDataGridView2, bunifuVScrollBar2);

        }

        AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
        private void AutoCompleteTextBox()
        {
            string con = "select Full_Name from Customers";
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

            string con = "select phone from Customers where Full_Name='" + bunifuTextBox1.Text + "'";
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

        private void FormBooking1_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            bunifuDatePicker1.MinDate = DateTime.Now.Date;

            AutoCompleteTextBox();
            AutoCompleteTextBox2();

            Get_Max();
            label6.Text = DateTime.Now.ToString("dd/MM/yyyy");

            bunifuVScrollBar1.BorderRadius = 14;
            bunifuVScrollBar2.BorderRadius = 14;

            Read_Data_Booking();
            this.Dock = DockStyle.Fill;

            bunifuDataGridView1.RowHeadersWidth = 180;
            bunifuDataGridView1.Columns[0].HeaderCell.Value = "رقم التذكرة";
            bunifuDataGridView1.Columns[1].HeaderCell.Value = "إسم الموظف";
            bunifuDataGridView1.Columns[2].HeaderCell.Value = "مكتب الحجز";
            bunifuDataGridView1.Columns[3].HeaderCell.Value = "تاريخ الحجز";
            bunifuDataGridView1.Columns[4].HeaderCell.Value = "رقم المقعد";
            bunifuDataGridView1.Columns[5].HeaderCell.Value = "إسم العميل";
            bunifuDataGridView1.Columns[6].HeaderCell.Value = "رقم الهاتف";
            bunifuDataGridView1.Columns[7].HeaderCell.Value = "سعر التذكرة";
            bunifuDataGridView1.Columns[8].HeaderCell.Value = "وقت القيام";
            bunifuDataGridView1.Columns[9].HeaderCell.Value = "محطة القيام";
            bunifuDataGridView1.Columns[10].HeaderCell.Value = "الوقت المتوقع للوصول";
            bunifuDataGridView1.Columns[11].HeaderCell.Value = "محطة الوصول";
            bunifuDataGridView1.Columns[12].HeaderCell.Value = "تاريخ السفر";
            bunifuDataGridView1.Columns[13].HeaderCell.Value = "الرقم التعريفي للعميل";
            bunifuDataGridView1.Columns[14].HeaderCell.Value = "الرقم التعريفي للموظف";

            Read_Data_Times();
            //dataGridView1.ColumnHeadersHeight = 30;
            bunifuDataGridView2.Columns[0].HeaderCell.Value = "الرقم التعريفي";
            bunifuDataGridView2.Columns[1].HeaderCell.Value = "محطة القيام";
            bunifuDataGridView2.Columns[2].HeaderCell.Value = "وقت القيام";
            bunifuDataGridView2.Columns[3].HeaderCell.Value = "محطة الوصول";
            bunifuDataGridView2.Columns[4].HeaderCell.Value = "الوقت المتوقع للوصول";
            bunifuDataGridView2.Columns[4].Width = 135;
            bunifuDataGridView2.Columns[5].HeaderCell.Value = "سعر التذكرة";
        }

        private void Read_Data_Booking()
        {
            DataSet ds = new DataSet();
            classBooking.Read_all().Fill(ds);
            bunifuDataGridView1.DataSource = ds.Tables[0];
        }
        private void Read_Data_Times()
        {
            DataSet ds = new DataSet();
            classTimes.Read_all().Fill(ds);
            bunifuDataGridView2.DataSource = ds.Tables[0];
        }

        private void Get_Max()
        {
            SqlDataAdapter ada = new SqlDataAdapter("Select isnull (max(cast(ID_Booking as int)),0)+1 from Booking", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            ID_Booking.Text = dt.Rows[0][0].ToString();
        }

        private void ResetAllColor()
        {
            if (Chair_1.BackColor == Color.Red)
            {
                Chair_1.BackColor = Color.White; Chair_1.Enabled = true;
            }
            if (Chair_2.BackColor == Color.Red)
            {
                Chair_2.BackColor = Color.White;
                Chair_2.Enabled = true;
            }
            if (Chair_3.BackColor == Color.Red)
            {
                Chair_3.BackColor = Color.White; Chair_3.Enabled = true;
            }
            if (Chair_4.BackColor == Color.Red)
            {
                Chair_4.BackColor = Color.White; Chair_4.Enabled = true;
            }
            if (Chair_5.BackColor == Color.Red)
            {
                Chair_5.BackColor = Color.White; Chair_5.Enabled = true;
            }
            if (Chair_6.BackColor == Color.Red)
            {
                Chair_6.BackColor = Color.White; Chair_6.Enabled = true;
            }
            if (Chair_7.BackColor == Color.Red)
            {
                Chair_7.BackColor = Color.White; Chair_7.Enabled = true;
            }
            if (Chair_8.BackColor == Color.Red)
            {
                Chair_8.BackColor = Color.White; Chair_8.Enabled = true;
            }
            if (Chair_9.BackColor == Color.Red)
            {
                Chair_9.BackColor = Color.White; Chair_9.Enabled = true;
            }
            if (Chair_10.BackColor == Color.Red)
            {
                Chair_10.BackColor = Color.White; Chair_10.Enabled = true;
            }
            if (Chair_11.BackColor == Color.Red)
            {
                Chair_11.BackColor = Color.White; Chair_11.Enabled = true;
            }
            if (Chair_12.BackColor == Color.Red)
            {
                Chair_12.BackColor = Color.White; Chair_12.Enabled = true;
            }
            if (Chair_13.BackColor == Color.Red)
            {
                Chair_13.BackColor = Color.White; Chair_13.Enabled = true;
            }
            if (Chair_14.BackColor == Color.Red)
            {
                Chair_14.BackColor = Color.White; Chair_14.Enabled = true;
            }
            if (Chair_15.BackColor == Color.Red)
            {
                Chair_15.BackColor = Color.White; Chair_15.Enabled = true;
            }
            if (Chair_16.BackColor == Color.Red)
            {
                Chair_16.BackColor = Color.White; Chair_16.Enabled = true;
            }
            if (Chair_17.BackColor == Color.Red)
            {
                Chair_17.BackColor = Color.White; Chair_17.Enabled = true;
            }
            if (Chair_18.BackColor == Color.Red)
            {
                Chair_18.BackColor = Color.White; Chair_18.Enabled = true;
            }
            if (Chair_19.BackColor == Color.Red)
            {
                Chair_19.BackColor = Color.White; Chair_19.Enabled = true;
            }
            if (Chair_20.BackColor == Color.Red)
            {
                Chair_20.BackColor = Color.White; Chair_20.Enabled = true;
            }
            if (Chair_21.BackColor == Color.Red)
            {
                Chair_21.BackColor = Color.White; Chair_21.Enabled = true;
            }
            if (Chair_22.BackColor == Color.Red)
            {
                Chair_22.BackColor = Color.White; Chair_22.Enabled = true;
            }
            if (Chair_23.BackColor == Color.Red)
            {
                Chair_23.BackColor = Color.White; Chair_23.Enabled = true;
            }
            if (Chair_24.BackColor == Color.Red)
            {
                Chair_24.BackColor = Color.White; Chair_24.Enabled = true;
            }
            if (Chair_25.BackColor == Color.Red)
            {
                Chair_25.BackColor = Color.White; Chair_25.Enabled = true;
            }
            if (Chair_26.BackColor == Color.Red)
            {
                Chair_26.BackColor = Color.White; Chair_26.Enabled = true;
            }
            if (Chair_27.BackColor == Color.Red)
            {
                Chair_27.BackColor = Color.White; Chair_27.Enabled = true;
            }
            if (Chair_28.BackColor == Color.Red)
            {
                Chair_28.BackColor = Color.White; Chair_28.Enabled = true;
            }
            if (Chair_29.BackColor == Color.Red)
            {
                Chair_29.BackColor = Color.White; Chair_29.Enabled = true;
            }
            if (Chair_30.BackColor == Color.Red)
            {
                Chair_30.BackColor = Color.White; Chair_30.Enabled = true;
            }
            if (Chair_31.BackColor == Color.Red)
            {
                Chair_31.BackColor = Color.White; Chair_31.Enabled = true;
            }
            if (Chair_32.BackColor == Color.Red)
            {
                Chair_32.BackColor = Color.White; Chair_32.Enabled = true;
            }
            if (Chair_33.BackColor == Color.Red)
            {
                Chair_33.BackColor = Color.White; Chair_33.Enabled = true;
            }
            if (Chair_34.BackColor == Color.Red)
            {
                Chair_34.BackColor = Color.White; Chair_34.Enabled = true;
            }
            if (Chair_35.BackColor == Color.Red)
            {
                Chair_35.BackColor = Color.White; Chair_35.Enabled = true;
            }
            if (Chair_36.BackColor == Color.Red)
            {
                Chair_36.BackColor = Color.White; Chair_36.Enabled = true;
            }
            if (Chair_37.BackColor == Color.Red)
            {
                Chair_37.BackColor = Color.White; Chair_37.Enabled = true;
            }
            if (Chair_38.BackColor == Color.Red)
            {
                Chair_38.BackColor = Color.White; Chair_38.Enabled = true;
            }
            if (Chair_39.BackColor == Color.Red)
            {
                Chair_39.BackColor = Color.White; Chair_39.Enabled = true;
            }
            if (Chair_40.BackColor == Color.Red)
            {
                Chair_40.BackColor = Color.White; Chair_40.Enabled = true;
            }
            if (Chair_41.BackColor == Color.Red)
            {
                Chair_41.BackColor = Color.White; Chair_41.Enabled = true;
            }
            if (Chair_42.BackColor == Color.Red)
            {
                Chair_42.BackColor = Color.White; Chair_42.Enabled = true;
            }
            if (Chair_43.BackColor == Color.Red)
            {
                Chair_43.BackColor = Color.White; Chair_43.Enabled = true;
            }
            if (Chair_44.BackColor == Color.Red)
            {
                Chair_44.BackColor = Color.White; Chair_44.Enabled = true;
            }
            if (Chair_45.BackColor == Color.Red)
            {
                Chair_45.BackColor = Color.White; Chair_45.Enabled = true;
            }
            if (Chair_46.BackColor == Color.Red)
            {
                Chair_46.BackColor = Color.White; Chair_46.Enabled = true;
            }
            if (Chair_47.BackColor == Color.Red)
            {
                Chair_47.BackColor = Color.White; Chair_47.Enabled = true;
            }
            if (Chair_48.BackColor == Color.Red)
            {
                Chair_48.BackColor = Color.White; Chair_48.Enabled = true;
            }
            if (Chair_49.BackColor == Color.Red)
            {
                Chair_49.BackColor = Color.White; Chair_49.Enabled = true;
            }
            if (Chair_50.BackColor == Color.Red)
            {
                Chair_50.BackColor = Color.White; Chair_50.Enabled = true;
            }
        }

        private void Selected_Color_Chair(int i)
        {
            if (i == 1)
            {
                Chair_1.BackColor = Color.Red;
                Chair_1.Enabled = false;
            }
            if (i == 2)
            {
                Chair_2.BackColor = Color.Red;
                Chair_2.Enabled = false;
            }
            if (i == 3)
            {
                Chair_3.BackColor = Color.Red;
                Chair_3.Enabled = false;
            }
            if (i == 4)
            {
                Chair_4.BackColor = Color.Red;
                Chair_4.Enabled = false;
            }
            if (i == 5)
            {
                Chair_5.BackColor = Color.Red;
                Chair_5.Enabled = false;
            }
            if (i == 6)
            {
                Chair_6.BackColor = Color.Red;
                Chair_6.Enabled = false;
            }
            if (i == 7)
            {
                Chair_7.BackColor = Color.Red;
                Chair_7.Enabled = false;
            }
            if (i == 8)
            {
                Chair_8.BackColor = Color.Red;
                Chair_8.Enabled = false;
            }
            if (i == 9)
            {
                Chair_9.BackColor = Color.Red;
                Chair_9.Enabled = false;
            }
            if (i == 10)
            {
                Chair_10.BackColor = Color.Red;
                Chair_10.Enabled = false;
            }
            if (i == 11)
            {
                Chair_11.BackColor = Color.Red;
                Chair_11.Enabled = false;
            }
            if (i == 12)
            {
                Chair_12.BackColor = Color.Red;
                Chair_12.Enabled = false;
            }
            if (i == 13)
            {
                Chair_13.BackColor = Color.Red;
                Chair_13.Enabled = false;
            }
            if (i == 14)
            {
                Chair_14.BackColor = Color.Red;
                Chair_14.Enabled = false;
            }
            if (i == 15)
            {
                Chair_15.BackColor = Color.Red;
                Chair_15.Enabled = false;
            }
            if (i == 16)
            {
                Chair_16.BackColor = Color.Red;
                Chair_16.Enabled = false;
            }
            if (i == 17)
            {
                Chair_17.BackColor = Color.Red;
                Chair_17.Enabled = false;
            }
            if (i == 18)
            {
                Chair_18.BackColor = Color.Red;
                Chair_18.Enabled = false;
            }
            if (i == 19)
            {
                Chair_19.BackColor = Color.Red;
                Chair_19.Enabled = false;
            }
            if (i == 20)
            {
                Chair_20.BackColor = Color.Red;
                Chair_20.Enabled = false;
            }
            if (i == 21)
            {
                Chair_21.BackColor = Color.Red;
                Chair_21.Enabled = false;
            }
            if (i == 22)
            {
                Chair_22.BackColor = Color.Red;
                Chair_22.Enabled = false;
            }
            if (i == 23)
            {
                Chair_23.BackColor = Color.Red;
                Chair_23.Enabled = false;
            }
            if (i == 24)
            {
                Chair_24.BackColor = Color.Red;
                Chair_24.Enabled = false;
            }
            if (i == 25)
            {
                Chair_25.BackColor = Color.Red;
                Chair_25.Enabled = false;
            }
            if (i == 26)
            {
                Chair_26.BackColor = Color.Red;
                Chair_26.Enabled = false;
            }
            if (i == 27)
            {
                Chair_27.BackColor = Color.Red;
                Chair_27.Enabled = false;
            }
            if (i == 28)
            {
                Chair_28.BackColor = Color.Red;
                Chair_28.Enabled = false;
            }
            if (i == 29)
            {
                Chair_29.BackColor = Color.Red;
                Chair_29.Enabled = false;
            }
            if (i == 30)
            {
                Chair_30.BackColor = Color.Red;
                Chair_30.Enabled = false;
            }
            if (i == 31)
            {
                Chair_31.BackColor = Color.Red;
                Chair_31.Enabled = false;
            }
            if (i == 32)
            {
                Chair_32.BackColor = Color.Red;
                Chair_32.Enabled = false;
            }
            if (i == 33)
            {
                Chair_33.BackColor = Color.Red;
                Chair_33.Enabled = false;
            }
            if (i == 34)
            {
                Chair_34.BackColor = Color.Red;
                Chair_34.Enabled = false;
            }
            if (i == 35)
            {
                Chair_35.BackColor = Color.Red;
                Chair_35.Enabled = false;
            }
            if (i == 36)
            {
                Chair_36.BackColor = Color.Red;
                Chair_36.Enabled = false;
            }
            if (i == 37)
            {
                Chair_37.BackColor = Color.Red;
                Chair_37.Enabled = false;
            }
            if (i == 38)
            {
                Chair_38.BackColor = Color.Red;
                Chair_38.Enabled = false;
            }
            if (i == 39)
            {
                Chair_39.BackColor = Color.Red;
                Chair_39.Enabled = false;
            }
            if (i == 40)
            {
                Chair_40.BackColor = Color.Red;
                Chair_40.Enabled = false;
            }
            if (i == 41)
            {
                Chair_41.BackColor = Color.Red;
                Chair_41.Enabled = false;
            }
            if (i == 42)
            {
                Chair_42.BackColor = Color.Red;
                Chair_42.Enabled = false;
            }
            if (i == 43)
            {
                Chair_43.BackColor = Color.Red;
                Chair_43.Enabled = false;
            }
            if (i == 44)
            {
                Chair_44.BackColor = Color.Red;
                Chair_44.Enabled = false;
            }
            if (i == 45)
            {
                Chair_45.BackColor = Color.Red;
                Chair_45.Enabled = false;
            }
            if (i == 46)
            {
                Chair_46.BackColor = Color.Red;
                Chair_46.Enabled = false;
            }
            if (i == 47)
            {
                Chair_47.BackColor = Color.Red;
                Chair_47.Enabled = false;
            }
            if (i == 48)
            {
                Chair_48.BackColor = Color.Red;
                Chair_48.Enabled = false;
            }
            if (i == 49)
            {
                Chair_49.BackColor = Color.Red;
                Chair_49.Enabled = false;
            }
            if (i == 50)
            {
                Chair_50.BackColor = Color.Red;
                Chair_50.Enabled = false;
            }
        }

        private void Selected_Chair()
        {
            try
            {
                if (label14.Text != "ــــ" && label16.Text != "ــــ" && label19.Text != "ــــ" && label21.Text != "ــــ")
                {
                    ResetAllColor();
                    SqlDataAdapter ada = new SqlDataAdapter("select Seat_Number from Booking where Date_Travel='" + bunifuDatePicker1.Value.ToShortDateString() + "'and Time_Start='" + label19.Text + "' and End_Station = '" + label16.Text + "' and Time_End ='" + label21.Text + "'", sqlcon);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= 50; i++)
                        {
                            bool contains = dt.AsEnumerable().Any(row => i == row.Field<int>("Seat_Number"));
                            if (contains.Equals(true))
                            {
                                Selected_Color_Chair(i);
                            }

                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void bunifuHScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuHScrollBar.ScrollEventArgs e)
        {
            try
            {
                bunifuDataGridView1.FirstDisplayedScrollingColumnIndex = bunifuDataGridView1.Columns[e.Value].Index;
            }
            catch (Exception)
            {

            }
        }

        private void bunifuDataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                bunifuHScrollBar1.Maximum = bunifuDataGridView1.ColumnCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bunifuDataGridView1_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                bunifuHScrollBar1.Maximum = bunifuDataGridView1.ColumnCount - 1;
            }
            catch (Exception)
            {

            }
        }

        private void bunifuDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                Chair_Number.Text = "ــــ";
                label14.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                label19.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                label16.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                label21.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                label12.Text = bunifuDataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                price_ticket = int.Parse(bunifuDataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString());
                Selected_Chair();
                if (bunifuTextBox1.Text != "")
                {
                    SqlDataAdapter ada2 = new SqlDataAdapter("SELECT COUNT (Name_Customer) FROM Booking WHERE Name_Customer='" + bunifuTextBox1.Text + "'", sqlcon);
                    DataTable dt2 = new DataTable();
                    ada2.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        string count = dt2.Rows[0][0].ToString();
                        //label12.Text = count;
                        if (int.Parse(count) >= 5)
                        {
                            double Price = price_ticket - (price_ticket * 0.25);
                            label12.Text = (Price).ToString();
                        }
                        if (int.Parse(count) >= 7)
                        {
                            label12.Text = (0).ToString();
                        }
                        if (int.Parse(count) < 5)
                        {
                            label12.Text = (price_ticket).ToString();
                        }
                    }
                    else
                    {
                        label12.Text = price_ticket.ToString();
                    }
                }
            }   

        }

        private void Enable_false(Object sender)
        {
            var button1 = (PictureBox)sender;
            if (button1.Enabled == true)
            {
                Chair_1.Enabled = false;
                Chair_2.Enabled = false;
                Chair_3.Enabled = false;
                Chair_4.Enabled = false;
                Chair_5.Enabled = false;
                Chair_6.Enabled = false;
                Chair_7.Enabled = false;
                Chair_8.Enabled = false;
                Chair_9.Enabled = false;
                Chair_10.Enabled = false;
                Chair_11.Enabled = false;
                Chair_12.Enabled = false;
                Chair_13.Enabled = false;
                Chair_14.Enabled = false;
                Chair_15.Enabled = false;
                Chair_16.Enabled = false;
                Chair_17.Enabled = false;
                Chair_18.Enabled = false;
                Chair_19.Enabled = false;
                Chair_20.Enabled = false;
                Chair_21.Enabled = false;
                Chair_22.Enabled = false;
                Chair_23.Enabled = false;
                Chair_24.Enabled = false;
                Chair_25.Enabled = false;
                Chair_26.Enabled = false;
                Chair_27.Enabled = false;
                Chair_28.Enabled = false;
                Chair_29.Enabled = false;
                Chair_30.Enabled = false;
                Chair_31.Enabled = false;
                Chair_32.Enabled = false;
                Chair_33.Enabled = false;
                Chair_34.Enabled = false;
                Chair_35.Enabled = false;
                Chair_36.Enabled = false;
                Chair_37.Enabled = false;
                Chair_38.Enabled = false;
                Chair_39.Enabled = false;
                Chair_40.Enabled = false;
                Chair_41.Enabled = false;
                Chair_42.Enabled = false;
                Chair_43.Enabled = false;
                Chair_44.Enabled = false;
                Chair_45.Enabled = false;
                Chair_46.Enabled = false;
                Chair_47.Enabled = false;
                Chair_48.Enabled = false;
                Chair_49.Enabled = false;
                Chair_50.Enabled = false;

                button1.Enabled = true;
            }

        }
        private void Enable_true()
        {

            if (Chair_1.Enabled == false || Chair_2.Enabled == false || Chair_3.Enabled == false
                || Chair_4.Enabled == false || Chair_5.Enabled == false || Chair_6.Enabled == false
                || Chair_7.Enabled == false || Chair_8.Enabled == false || Chair_9.Enabled == false
                || Chair_10.Enabled == false || Chair_11.Enabled == false || Chair_12.Enabled == false
                || Chair_13.Enabled == false || Chair_14.Enabled == false || Chair_15.Enabled == false
                || Chair_16.Enabled == false || Chair_17.Enabled == false || Chair_18.Enabled == false
                || Chair_19.Enabled == false || Chair_20.Enabled == false || Chair_21.Enabled == false
                || Chair_21.Enabled == false || Chair_22.Enabled == false || Chair_23.Enabled == false
                || Chair_24.Enabled == false || Chair_25.Enabled == false || Chair_26.Enabled == false
                || Chair_27.Enabled == false || Chair_28.Enabled == false || Chair_29.Enabled == false
                || Chair_30.Enabled == false || Chair_31.Enabled == false || Chair_32.Enabled == false
                || Chair_33.Enabled == false || Chair_34.Enabled == false || Chair_35.Enabled == false
                || Chair_36.Enabled == false || Chair_37.Enabled == false || Chair_38.Enabled == false
                || Chair_39.Enabled == false || Chair_40.Enabled == false || Chair_41.Enabled == false
                || Chair_42.Enabled == false || Chair_43.Enabled == false || Chair_44.Enabled == false
                || Chair_45.Enabled == false || Chair_46.Enabled == false || Chair_47.Enabled == false
                || Chair_48.Enabled == false || Chair_49.Enabled == false || Chair_50.Enabled == false)
            {
                Chair_1.Enabled = true;
                Chair_2.Enabled = true;
                Chair_3.Enabled = true;
                Chair_4.Enabled = true;
                Chair_5.Enabled = true;
                Chair_6.Enabled = true;
                Chair_7.Enabled = true;
                Chair_8.Enabled = true;
                Chair_9.Enabled = true;
                Chair_10.Enabled = true;
                Chair_11.Enabled = true;
                Chair_12.Enabled = true;
                Chair_13.Enabled = true;
                Chair_14.Enabled = true;
                Chair_15.Enabled = true;
                Chair_16.Enabled = true;
                Chair_17.Enabled = true;
                Chair_18.Enabled = true;
                Chair_19.Enabled = true;
                Chair_20.Enabled = true;
                Chair_22.Enabled = true;
                Chair_23.Enabled = true;
                Chair_24.Enabled = true;
                Chair_25.Enabled = true;
                Chair_26.Enabled = true;
                Chair_27.Enabled = true;
                Chair_28.Enabled = true;
                Chair_29.Enabled = true;
                Chair_30.Enabled = true;
                Chair_31.Enabled = true;
                Chair_32.Enabled = true;
                Chair_33.Enabled = true;
                Chair_34.Enabled = true;
                Chair_35.Enabled = true;
                Chair_36.Enabled = true;
                Chair_37.Enabled = true;
                Chair_38.Enabled = true;
                Chair_39.Enabled = true;
                Chair_40.Enabled = true;
                Chair_41.Enabled = true;
                Chair_42.Enabled = true;
                Chair_43.Enabled = true;
                Chair_44.Enabled = true;
                Chair_45.Enabled = true;
                Chair_46.Enabled = true;
                Chair_47.Enabled = true;
                Chair_48.Enabled = true;
                Chair_49.Enabled = true;
                Chair_50.Enabled = true;
            }

        }
        private void ResetButtonBackColor(Object sender)
        {
            var button1 = (PictureBox)sender;

            if (Chair_1.BackColor == Color.Gold || Chair_2.BackColor == Color.Gold || Chair_3.BackColor == Color.Gold
                || Chair_4.BackColor == Color.Gold || Chair_5.BackColor == Color.Gold || Chair_6.BackColor == Color.Gold
                || Chair_7.BackColor == Color.Gold || Chair_8.BackColor == Color.Gold || Chair_9.BackColor == Color.Gold
                || Chair_10.BackColor == Color.Gold || Chair_11.BackColor == Color.Gold || Chair_12.BackColor == Color.Gold
                || Chair_13.BackColor == Color.Gold || Chair_14.BackColor == Color.Gold || Chair_15.BackColor == Color.Gold
                || Chair_16.BackColor == Color.Gold || Chair_17.BackColor == Color.Gold || Chair_18.BackColor == Color.Gold
                || Chair_19.BackColor == Color.Gold || Chair_20.BackColor == Color.Gold || Chair_21.BackColor == Color.Gold
                || Chair_22.BackColor == Color.Gold || Chair_23.BackColor == Color.Gold || Chair_24.BackColor == Color.Gold
                || Chair_25.BackColor == Color.Gold || Chair_26.BackColor == Color.Gold || Chair_27.BackColor == Color.Gold
                || Chair_28.BackColor == Color.Gold || Chair_29.BackColor == Color.Gold || Chair_30.BackColor == Color.Gold
                || Chair_31.BackColor == Color.Gold || Chair_32.BackColor == Color.Gold || Chair_33.BackColor == Color.Gold
                || Chair_34.BackColor == Color.Gold || Chair_35.BackColor == Color.Gold || Chair_36.BackColor == Color.Gold
                || Chair_37.BackColor == Color.Gold || Chair_38.BackColor == Color.Gold || Chair_39.BackColor == Color.Gold
                || Chair_40.BackColor == Color.Gold || Chair_41.BackColor == Color.Gold || Chair_42.BackColor == Color.Gold
                || Chair_43.BackColor == Color.Gold || Chair_44.BackColor == Color.Gold || Chair_45.BackColor == Color.Gold
                || Chair_46.BackColor == Color.Gold || Chair_47.BackColor == Color.Gold || Chair_48.BackColor == Color.Gold
                || Chair_49.BackColor == Color.Gold || Chair_50.BackColor == Color.Gold)
            {
                Chair_Number.Text = "ــــ";
                button1.BackColor = Color.White;
                Enable_true();
            }
            else
            {
                Enable_false(sender);
                button1.BackColor = Color.Gold;
                Chair_Number.Text = button1.Tag.ToString();
            }

        }

        private void Chair_1_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
            //Color_Chair_Select(sender);
        }

        private void Chair_2_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
            //Color_Chair_Select(sender);
        }

        private void Chair_3_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_4_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_5_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_6_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_7_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_8_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_9_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_10_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_11_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_12_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_13_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_14_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_15_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_16_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_43_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_18_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_19_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_20_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_21_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_22_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_23_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_24_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_25_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_26_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_27_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_28_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_29_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_30_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_31_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_32_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_33_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_34_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_35_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_36_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_37_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);

        }

        private void Chair_38_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_39_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_40_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_41_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_42_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_17_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_44_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_45_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_46_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_47_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_48_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_49_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }

        private void Chair_50_Click(object sender, EventArgs e)
        {
            ResetButtonBackColor(sender);
        }


        private void insert_control()
        {
            classBooking.ID_Booking = int.Parse(ID_Booking.Text);
            classBooking.Ticket_office = label4.Text;
            classBooking.Date_Booking = DateTime.Parse(label6.Text);
            classBooking.Start_Station = label14.Text;
            classBooking.End_Station = label16.Text;
            classBooking.Date_Travel = DateTime.Parse(bunifuDatePicker1.Value.ToShortDateString());
            classBooking.Time_Start = label19.Text;
            classBooking.Time_End = label21.Text;
            classBooking.Seat_Number = int.Parse(Chair_Number.Text);
            classBooking.Ticket_Price = float.Parse(label12.Text);
            classBooking.Name_Customer = bunifuTextBox1.Text;
            classBooking.Phone_Customer = bunifuTextBox2.Text;

            classBooking.Username = Form1.name_emp;

            SqlDataAdapter ada = new SqlDataAdapter("select ID_Customer from Customers where Full_Name ='" + bunifuTextBox1.Text + "'", sqlcon);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            string id = dt.Rows[0][0].ToString();
            if (dt.Rows.Count > 0)
            {
                classBooking.ID_Customer = int.Parse(id);
            }
            else
            {
                SqlDataAdapter ada2 = new SqlDataAdapter("Select isnull (max(cast(ID_Customer as int)),0)+1 from Customers", sqlcon);
                DataTable dt2 = new DataTable();
                ada2.Fill(dt2);
                string id2 = dt2.Rows[0][0].ToString();
                classBooking.ID_Customer = int.Parse(id2);
            }

            classBooking.ID_User = int.Parse(Form1.user_id);
        }

        private void Fill_Data()
        {
            DataSet ds = new DataSet();
            classBooking.Read_all().Fill(ds);
            bunifuDataGridView1.DataSource = ds.Tables[0];
        }

        private void Clear()
        {
            label14.Text = "ــــ";
            label16.Text = "ــــ";
            label19.Text = "ــــ";
            label21.Text = "ــــ";
            Chair_Number.Text = "ــــ";
            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear();
            bunifuTextBox3.Clear();
            bunifuDatePicker1.Text = DateTime.Now.Date.ToShortDateString();
        }



        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {

                if (Chair_Number.Text == "ــــ")
                {
                    MessageBox.Show("الرجاء اختيار رقم المقعد");
                }
                else if (label4.Text == "ــــ" || label16.Text == "ــــ" || label19.Text == "ــــ" || label21.Text == "ــــ")
                {
                    MessageBox.Show("الرجاء اختيار الميعاد المناسب");
                }
                else if (bunifuTextBox1.Text == "")
                {
                    MessageBox.Show("الرجاء إدخال اسم العميل");
                }
                else if (bunifuTextBox2.Text == "")
                {
                    MessageBox.Show("الرجاء إدخال رقم هاتف العميل");
                }
                else
                {

                    SqlDataAdapter ada = new SqlDataAdapter("select Full_Name from Customers where Full_Name ='" + bunifuTextBox1.Text + "'", sqlcon);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    string name = bunifuTextBox1.Text;
                    if (dt.Rows.Count > 0)
                    {
                        bool contains = dt.AsEnumerable().Any(row => name == row.Field<string>("Full_Name"));
                        if (contains.Equals(true))
                        {
                            SqlDataAdapter ada2 = new SqlDataAdapter("Select ID_Customer from Customers where Full_Name ='" + bunifuTextBox1.Text + "'", sqlcon);
                            DataTable dt2 = new DataTable();
                            ada2.Fill(dt2);
                            string id_custom = dt2.Rows[0][0].ToString();
                            ClassCustomers classCustomers = new ClassCustomers();
                            classCustomers.ID_Customer = int.Parse(id_custom);
                            classCustomers.Full_Name = bunifuTextBox1.Text;
                            classCustomers.phone = bunifuTextBox2.Text;
                            classCustomers.Update();
                        }
                    }
                    else
                    {
                        SqlDataAdapter ada3 = new SqlDataAdapter("Select isnull (max(cast(ID_Customer as int)),0)+1 from Customers", sqlcon);
                        DataTable dt3 = new DataTable();
                        ada3.Fill(dt3);
                        string id_custom = dt3.Rows[0][0].ToString();
                        ClassCustomers classCustomers = new ClassCustomers();
                        classCustomers.ID_Customer = int.Parse(id_custom);
                        classCustomers.Full_Name = bunifuTextBox1.Text;
                        classCustomers.phone = bunifuTextBox2.Text;
                        classCustomers.save();
                        MessageBox.Show("تم تسجيل عميل جديد");
                    }

                    Get_Max();
                    insert_control();
                    classBooking.save();
                    Selected_Chair();
                    Enable_true();
                    Fill_Data();
                    MessageBox.Show("تم الحجز بنجاح !");
                    Clear();
                    ResetAllColor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ يرجى إعادة المحاولة");
            }
        }


        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            Selected_Chair();
        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            AutoCompleteTextBox2();
            SqlDataAdapter ada = new SqlDataAdapter("Select phone from Customers where Full_Name='" + bunifuTextBox1.Text + "'", sqlcon);
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

            if (bunifuTextBox1.Text != "") {
                SqlDataAdapter ada2 = new SqlDataAdapter("SELECT COUNT (Name_Customer) FROM Booking WHERE Name_Customer='" + bunifuTextBox1.Text + "'", sqlcon);
                DataTable dt2 = new DataTable();
                ada2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    string count = dt2.Rows[0][0].ToString();
                    //label12.Text = count;
                    if (int.Parse(count) >= 4)
                    {
                        float Price = (float)(price_ticket - (price_ticket * 0.25));
                        label12.Text = (Price).ToString();
                    }
                    if (int.Parse(count) >= 6)
                    {
                        label12.Text = (0).ToString();
                    }
                    if (int.Parse(count) < 5)
                    {
                        label12.Text = (price_ticket).ToString();
                    }
                }
                else
                {
                    label12.Text = price_ticket.ToString();
                }
            }
        }

        private void Enable_False()
        {
            btn_Save.Enabled = true;
            bunifuButton22.Enabled = false;
            bunifuButton23.Enabled = false;
            bunifuButton24.Enabled = false;
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {

            try
            {

                insert_control();
                classBooking.Update();
                Selected_Chair();
                Enable_true();
                Fill_Data();
                MessageBox.Show("تم التعديل بنجاح ^_^");
                Clear();
                Enable_False();
                ResetAllColor();
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
                DateTime test = DateTime.Parse(bunifuDataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString());
                if (test.Date >= DateTime.Now.Date)
                {
                    btn_Save.Enabled = false;
                    bunifuButton22.Enabled = true;
                    bunifuButton23.Enabled = true;
                    bunifuButton24.Enabled = true;
                    ID_Booking.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    Chair_Number.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    bunifuTextBox1.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    bunifuTextBox2.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    label12.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    label19.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    label14.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                    label21.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    label16.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                    bunifuDatePicker1.Text = bunifuDataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                    Selected_Chair();
                }
                else
                {
                    MessageBox.Show("عفواً ... لا يمكن تعديل هذا الحجز نظراً لمضي تاريخه");
                }

            }



        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            try
            {
                insert_control();
                classBooking.Delete();
                Selected_Chair();
                Enable_true();
                Fill_Data();
                MessageBox.Show("تم الحذف بنجاح ^_^");
                Clear();
                Enable_False();
                ResetAllColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("يوجد خطأ يرجى إعادة المحاولة");
            }
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            Fill_Data();
            ResetAllColor();
            Enable_true();
            Get_Max();
            Clear();
            Enable_False();
        }

        private void bunifuTextBox3_TextChange(object sender, EventArgs e)
        {
            if (bunifuTextBox3.Text == "")
            {
                Read_Data_Booking();
            }
            else
            {
                SqlDataAdapter ada = new SqlDataAdapter("Select * from Booking where Name_Customer like '%" + bunifuTextBox3.Text + "%'", sqlcon);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                bunifuDataGridView1.DataSource = dt;
            }
        }
    }
}
