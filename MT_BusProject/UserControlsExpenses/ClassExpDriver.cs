using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject.UserControlsExpenses
{
    class ClassExpDriver
    {
        int VID_DriveExp;
        string VDrive_name;
        string VDrive_Phone;
        int VDrive_Money;
        DateTime VDate;

        public int ID_DriveExp
        {
            get { return VID_DriveExp; }
            set { VID_DriveExp = value; }
        }
        public string Drive_name
        {
            get { return VDrive_name; }
            set { VDrive_name = value; }
        }
        public string Drive_Phone
        {
            get { return VDrive_Phone; }
            set { VDrive_Phone = value; }
        }
        public int Drive_Money
        {
            get { return VDrive_Money; }
            set { VDrive_Money = value; }
        }
        public DateTime Date
        {
            get { return VDate; }
            set { VDate = value; }
        }
        private SqlConnection DB_Connection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=MT_BUS;Integrated Security=True";
            con.Open();
            return con;
        }
        public void save()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Driver_Expenses(ID_DriveExp,Drive_name,Drive_Phone,Drive_Money,Date) values (@ID_DriveExp,@Drive_name,@Drive_Phone,@Drive_Money,@Date)";
            cmd.Parameters.Add("@ID_DriveExp", System.Data.SqlDbType.Int).Value = ID_DriveExp;
            cmd.Parameters.Add("@Drive_name", System.Data.SqlDbType.VarChar, 50).Value = Drive_name;
            cmd.Parameters.Add("@Drive_Phone", System.Data.SqlDbType.VarChar, 50).Value = Drive_Phone;
            cmd.Parameters.Add("@Drive_Money", System.Data.SqlDbType.Int).Value = Drive_Money;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Driver_Expenses set Drive_name= @Drive_name,Drive_Phone=@Drive_Phone,Drive_Money=@Drive_Money,Date=@Date where ID_DriveExp =@ID_DriveExp";
            cmd.Parameters.Add("@ID_DriveExp", System.Data.SqlDbType.Int).Value = ID_DriveExp;
            cmd.Parameters.Add("@Drive_name", System.Data.SqlDbType.VarChar, 50).Value = Drive_name;
            cmd.Parameters.Add("@Drive_Phone", System.Data.SqlDbType.VarChar, 50).Value = Drive_Phone;
            cmd.Parameters.Add("@Drive_Money", System.Data.SqlDbType.Int).Value = Drive_Money;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Driver_Expenses where ID_DriveExp = @ID_DriveExp";
            cmd.Parameters.Add("@ID_DriveExp", System.Data.SqlDbType.Int).Value = ID_DriveExp;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Driver_Expenses";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
    }
}
