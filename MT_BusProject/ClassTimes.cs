using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject
{
    class ClassTimes
    {
        int VID_Time;
        string VStart_Station;
        string VStart_Time;
        string VEnd_Station;
        string VEnd_Time;
        int VTicket_Price;

        public int ID_Time
        {
            get { return VID_Time; }
            set { VID_Time = value; }
        }

        public string Start_Station
        {
            get { return VStart_Station; }
            set { VStart_Station = value; }
        }

        public string Start_Time
        {
            get { return VStart_Time; }
            set { VStart_Time = value; }
        }

        public string End_Time
        {
            get { return VEnd_Time; }
            set { VEnd_Time = value; }
        }

        public string End_Station
        {
            get { return VEnd_Station; }
            set { VEnd_Station = value; }
        }

        public int Ticket_Price
        {
            get { return VTicket_Price; }
            set { VTicket_Price = value; }
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
            cmd.CommandText = "insert into Times(ID_Time,Start_Station,Start_Time,End_Time,End_Station,Ticket_Price) values (@ID_Time,@Start_Station,@Start_Time,@End_Time,@End_Station,@Ticket_Price)";
            cmd.Parameters.Add("@ID_Time", System.Data.SqlDbType.Int).Value = ID_Time;
            cmd.Parameters.Add("@Start_Station", System.Data.SqlDbType.VarChar, 50).Value = Start_Station;
            cmd.Parameters.Add("@Start_Time", System.Data.SqlDbType.VarChar, 50).Value = Start_Time;
            cmd.Parameters.Add("@End_Time", System.Data.SqlDbType.VarChar, 50).Value = End_Time;
            cmd.Parameters.Add("@End_Station", System.Data.SqlDbType.VarChar, 50).Value = End_Station;
            cmd.Parameters.Add("@Ticket_Price", System.Data.SqlDbType.Int).Value = Ticket_Price;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Times set Start_Station= @Start_Station,Start_Time= @Start_Time,End_Time=@End_Time,End_Station= @End_Station, Ticket_Price= @Ticket_Price where ID_Time =@ID_Time ";
            cmd.Parameters.Add("@ID_Time", System.Data.SqlDbType.Int).Value = ID_Time;
            cmd.Parameters.Add("@Start_Station", System.Data.SqlDbType.VarChar, 50).Value = Start_Station;
            cmd.Parameters.Add("@Start_Time", System.Data.SqlDbType.VarChar, 50).Value = Start_Time;
            cmd.Parameters.Add("@End_Time", System.Data.SqlDbType.VarChar, 50).Value = End_Time;
            cmd.Parameters.Add("@End_Station", System.Data.SqlDbType.VarChar, 50).Value = End_Station;
            cmd.Parameters.Add("@Ticket_Price", System.Data.SqlDbType.Int).Value = Ticket_Price;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Times where ID_Time = @ID_Time";
            cmd.Parameters.Add("@ID_Time", System.Data.SqlDbType.Int).Value = ID_Time;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Times";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }


    }
}
