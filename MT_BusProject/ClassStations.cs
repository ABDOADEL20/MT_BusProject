using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject
{
    class ClassStations
    {
        int VID_Station;
        string VName_Station;

        public int ID_Station
        {
            get { return VID_Station; }
            set { VID_Station = value; }
        }

        public string Name_Station
        {
            get { return VName_Station; }
            set { VName_Station = value; }
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
            cmd.CommandText = "insert into Stations(Name_Station) values (@Name_Station)";
            cmd.Parameters.Add("@Name_Station", System.Data.SqlDbType.VarChar, 50).Value = Name_Station;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Stations set Name_Station= @Name_Station where ID_Station =@ID_Station ";
            cmd.Parameters.Add("@ID_Station", System.Data.SqlDbType.Int).Value = ID_Station;
            cmd.Parameters.Add("@Name_Station", System.Data.SqlDbType.VarChar, 50).Value = Name_Station;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Stations where ID_Station = @ID_Station";
            cmd.Parameters.Add("@ID_Station", System.Data.SqlDbType.Int).Value = ID_Station;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Name_Station from Stations";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
    }
}
