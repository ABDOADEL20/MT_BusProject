using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject.UserControlsExpenses
{
    class ClassExpWash
    {
        int VID_BusWash;
        string VDrive_name;
        string VDrive_Phone;
        int VBus_Number;
        int VWash_Cost;
        DateTime VDate;
        public int ID_BusWash
        {
            get { return VID_BusWash; }
            set { VID_BusWash = value; }
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
        public int Bus_Number
        {
            get { return VBus_Number; }
            set { VBus_Number = value; }
        }
        public int Wash_Cost
        {
            get { return VWash_Cost; }
            set { VWash_Cost = value; }
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
            cmd.CommandText = "insert into BusWash(ID_BusWash,Drive_name,Drive_Phone,Bus_Number,Wash_Cost,Date) values (@ID_BusWash,@Drive_name,@Drive_Phone,@Bus_Number,@Wash_Cost,@Date)";
            cmd.Parameters.Add("@ID_BusWash", System.Data.SqlDbType.Int).Value = ID_BusWash;
            cmd.Parameters.Add("@Drive_name", System.Data.SqlDbType.VarChar, 50).Value = Drive_name;
            cmd.Parameters.Add("@Drive_Phone", System.Data.SqlDbType.VarChar, 50).Value = Drive_Phone;
            cmd.Parameters.Add("@Bus_Number", System.Data.SqlDbType.Int).Value = Bus_Number;
            cmd.Parameters.Add("@Wash_Cost", System.Data.SqlDbType.Int).Value = Wash_Cost;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update BusWash set Drive_name= @Drive_name,Drive_Phone=@Drive_Phone,Bus_Number=@Bus_Number,Wash_Cost=@Wash_Cost,Date=@Date where ID_BusWash =@ID_BusWash";
            cmd.Parameters.Add("@ID_BusWash", System.Data.SqlDbType.Int).Value = ID_BusWash;
            cmd.Parameters.Add("@Drive_name", System.Data.SqlDbType.VarChar, 50).Value = Drive_name;
            cmd.Parameters.Add("@Drive_Phone", System.Data.SqlDbType.VarChar, 50).Value = Drive_Phone;
            cmd.Parameters.Add("@Bus_Number", System.Data.SqlDbType.Int).Value = Bus_Number;
            cmd.Parameters.Add("@Wash_Cost", System.Data.SqlDbType.Int).Value = Wash_Cost;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from BusWash where ID_BusWash = @ID_BusWash";
            cmd.Parameters.Add("@ID_BusWash", System.Data.SqlDbType.Int).Value = ID_BusWash;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from BusWash";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
    }
}
