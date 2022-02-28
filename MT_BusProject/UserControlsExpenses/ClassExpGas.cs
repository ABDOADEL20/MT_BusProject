using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject.UserControlsExpenses
{
    class ClassExpGas
    {
        int VID_BusGas;
        int VBus_Number;
        string VOfficer_Name;
        int VGas_Cost;
        DateTime VDate;

        public int ID_BusGas
        {
            get { return VID_BusGas; }
            set { VID_BusGas = value; }
        }
        public int Bus_Number
        {
            get { return VBus_Number; }
            set { VBus_Number = value; }
        }
        public string Officer_Name
        {
            get { return VOfficer_Name; }
            set { VOfficer_Name = value; }
        }
        public int Gas_Cost
        {
            get { return VGas_Cost; }
            set { VGas_Cost = value; }
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
            cmd.CommandText = "insert into BusGas(ID_BusGas,Bus_Number,Officer_Name,Gas_Cost,Date) values (@ID_BusGas,@Bus_Number,@Officer_Name,@Gas_Cost,@Date)";
            cmd.Parameters.Add("@ID_BusGas", System.Data.SqlDbType.Int).Value = ID_BusGas;
            cmd.Parameters.Add("@Bus_Number", System.Data.SqlDbType.Int).Value = Bus_Number;
            cmd.Parameters.Add("@Officer_Name", System.Data.SqlDbType.VarChar, 50).Value = Officer_Name;
            cmd.Parameters.Add("@Gas_Cost", System.Data.SqlDbType.Int).Value = Gas_Cost;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update BusGas set Bus_Number= @Bus_Number,Officer_Name=@Officer_Name,Gas_Cost=@Gas_Cost,Date=@Date where ID_BusGas =@ID_BusGas";
            cmd.Parameters.Add("@ID_BusGas", System.Data.SqlDbType.Int).Value = ID_BusGas;
            cmd.Parameters.Add("@Bus_Number", System.Data.SqlDbType.Int).Value = Bus_Number;
            cmd.Parameters.Add("@Officer_Name", System.Data.SqlDbType.VarChar, 50).Value = Officer_Name;
            cmd.Parameters.Add("@Gas_Cost", System.Data.SqlDbType.Int).Value = Gas_Cost;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from BusGas where ID_BusGas = @ID_BusGas";
            cmd.Parameters.Add("@ID_BusGas", System.Data.SqlDbType.Int).Value = ID_BusGas;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from BusGas";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
    }
}
