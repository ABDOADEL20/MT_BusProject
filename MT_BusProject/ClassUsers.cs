using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject
{
    class ClassUsers
    {
        int VUser_ID;
        string VFullName;
        string VUsername;
        string VPassword;

        public int User_ID
        {
            get { return VUser_ID; }
            set { VUser_ID = value; }
        }

        public string FullName
        {
            get { return VFullName; }
            set { VFullName = value; }
        }

        public string Username
        {
            get { return VUsername; }
            set { VUsername = value; }
        }

        public string Password
        {
            get { return VPassword; }
            set { VPassword = value; }
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
            cmd.CommandText = "insert into Users(User_ID,FullName,Username,Password) values (@User_ID,@FullName,@Username,@Password)";
            cmd.Parameters.Add("@User_ID", System.Data.SqlDbType.Int).Value = User_ID;
            cmd.Parameters.Add("@FullName", System.Data.SqlDbType.VarChar, 50).Value = FullName;
            cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = Username;
            cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = Password;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Users set FullName= @FullName,Username= @Username,Password= @Password where User_ID =@User_ID ";
            cmd.Parameters.Add("@User_ID", System.Data.SqlDbType.Int).Value = User_ID;
            cmd.Parameters.Add("@FullName", System.Data.SqlDbType.VarChar, 50).Value = FullName;
            cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = Username;
            cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = Password;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Users where User_ID = @User_ID";
            cmd.Parameters.Add("@User_ID", System.Data.SqlDbType.Int).Value = User_ID;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Users";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
    }
}
