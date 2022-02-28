using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject.UserControlsExpenses
{
    class ClassRoadServices
    {
        int VID_BusSeRoad;
        int VBus_Number;
        string VDriver_Name;
        int VServiceRoad_Cost;
        DateTime VDate;

        public int ID_BusSeRoad
        {
            get { return VID_BusSeRoad; }
            set { VID_BusSeRoad = value; }
        }
        public int Bus_Number
        {
            get { return VBus_Number; }
            set { VBus_Number = value; }
        }
        public string Driver_Name
        {
            get { return VDriver_Name; }
            set { VDriver_Name = value; }
        }
        public int ServiceRoad_Cost
        {
            get { return VServiceRoad_Cost; }
            set { VServiceRoad_Cost = value; }
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
            cmd.CommandText = "insert into RoadServices(ID_BusSeRoad,Bus_Number,Driver_Name,ServiceRoad_Cost,Date) values (@ID_BusSeRoad,@Bus_Number,@Driver_Name,@ServiceRoad_Cost,@Date)";
            cmd.Parameters.Add("@ID_BusSeRoad", System.Data.SqlDbType.Int).Value = ID_BusSeRoad;
            cmd.Parameters.Add("@Bus_Number", System.Data.SqlDbType.Int).Value = Bus_Number;
            cmd.Parameters.Add("@Driver_Name", System.Data.SqlDbType.VarChar, 50).Value = Driver_Name;
            cmd.Parameters.Add("@ServiceRoad_Cost", System.Data.SqlDbType.Int).Value = ServiceRoad_Cost;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update RoadServices set Bus_Number= @Bus_Number,Driver_Name=@Driver_Name,ServiceRoad_Cost=@ServiceRoad_Cost,Date=@Date where ID_BusSeRoad =@ID_BusSeRoad";
            cmd.Parameters.Add("@ID_BusSeRoad", System.Data.SqlDbType.Int).Value = ID_BusSeRoad;
            cmd.Parameters.Add("@Bus_Number", System.Data.SqlDbType.Int).Value = Bus_Number;
            cmd.Parameters.Add("@Driver_Name", System.Data.SqlDbType.VarChar, 50).Value = Driver_Name;
            cmd.Parameters.Add("@ServiceRoad_Cost", System.Data.SqlDbType.Int).Value = ServiceRoad_Cost;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from RoadServices where ID_BusSeRoad = @ID_BusSeRoad";
            cmd.Parameters.Add("@ID_BusSeRoad", System.Data.SqlDbType.Int).Value = ID_BusSeRoad;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from RoadServices";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
    }
}
