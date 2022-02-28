using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject.UserControlsExpenses
{
    class ClassOtherExpenses
    {
        int VID_OtherExpenses;
        string VOther_Name;
        int VCost;
        DateTime VDate;

        public int ID_OtherExpenses
        {
            get { return VID_OtherExpenses; }
            set { VID_OtherExpenses = value; }
        }
        public string Other_Name
        {
            get { return VOther_Name; }
            set { VOther_Name = value; }
        }
        public int Cost
        {
            get { return VCost; }
            set { VCost = value; }
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
            cmd.CommandText = "insert into OtherExpenses(ID_OtherExpenses,Other_Name,Cost,Date) values (@ID_OtherExpenses,@Other_Name,@Cost,@Date)";
            cmd.Parameters.Add("@ID_OtherExpenses", System.Data.SqlDbType.Int).Value = ID_OtherExpenses;
            cmd.Parameters.Add("@Other_Name", System.Data.SqlDbType.VarChar, 50).Value = Other_Name;
            cmd.Parameters.Add("@Cost", System.Data.SqlDbType.Int).Value = Cost;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update OtherExpenses set Other_Name=@Other_Name,Cost=@Cost,Date=@Date where ID_OtherExpenses =@ID_OtherExpenses";
            cmd.Parameters.Add("@ID_OtherExpenses", System.Data.SqlDbType.Int).Value = ID_OtherExpenses;
            cmd.Parameters.Add("@Other_Name", System.Data.SqlDbType.VarChar, 50).Value = Other_Name;
            cmd.Parameters.Add("@Cost", System.Data.SqlDbType.Int).Value = Cost;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from OtherExpenses where ID_OtherExpenses = @ID_OtherExpenses";
            cmd.Parameters.Add("@ID_OtherExpenses", System.Data.SqlDbType.Int).Value = ID_OtherExpenses;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from OtherExpenses";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
    }
}
