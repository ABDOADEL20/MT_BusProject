using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject
{
    class ClassCustomers
    {
        int VID_Customer;
        string VFull_Name;
        string Vphone;

        public int ID_Customer
        {
            get { return VID_Customer; }
            set { VID_Customer = value; }
        }

        public string Full_Name
        {
            get { return VFull_Name; }
            set { VFull_Name = value; }
        }
        public string phone
        {
            get { return Vphone; }
            set { Vphone = value; }
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
            cmd.CommandText = "insert into Customers(ID_Customer,Full_Name,phone) values (@ID_Customer,@Full_Name,@phone)";
            cmd.Parameters.Add("@ID_Customer", System.Data.SqlDbType.Int).Value = ID_Customer;
            cmd.Parameters.Add("@Full_Name", System.Data.SqlDbType.VarChar, 50).Value = Full_Name;
            cmd.Parameters.Add("@phone", System.Data.SqlDbType.VarChar, 50).Value = phone;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Customers set Full_Name= @Full_Name,phone= @phone where ID_Customer =@ID_Customer";
            cmd.Parameters.Add("@ID_Customer", System.Data.SqlDbType.Int).Value = ID_Customer;
            cmd.Parameters.Add("@Full_Name", System.Data.SqlDbType.VarChar, 50).Value = Full_Name;
            cmd.Parameters.Add("@phone", System.Data.SqlDbType.VarChar, 50).Value = phone;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Customers where ID_Customer = @ID_Customer";
            cmd.Parameters.Add("@ID_Customer", System.Data.SqlDbType.Int).Value = ID_Customer;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Customers";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
    }
}
