using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject.UserControlsExpenses
{
    class ClassExpEmp
    {
        int VID_EmpExp;
        string VEmp_name;
        string VEmp_phone;
        int VEmp_money;
        DateTime VDate;

        public int ID_EmpExp
        {
            get { return VID_EmpExp; }
            set { VID_EmpExp = value; }
        }
        public string Emp_name
        {
            get { return VEmp_name; }
            set { VEmp_name = value; }
        }
        public string Emp_phone
        {
            get { return VEmp_phone; }
            set { VEmp_phone = value; }
        }
        public int Emp_money
        {
            get { return VEmp_money; }
            set { VEmp_money = value; }
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
            cmd.CommandText = "insert into Emp_Expenses(ID_EmpExp,Emp_name,Emp_phone,Emp_money,Date) values (@ID_EmpExp,@Emp_name,@Emp_phone,@Emp_money,@Date)";
            cmd.Parameters.Add("@ID_EmpExp", System.Data.SqlDbType.Int).Value = ID_EmpExp;
            cmd.Parameters.Add("@Emp_name", System.Data.SqlDbType.VarChar, 50).Value = Emp_name;
            cmd.Parameters.Add("@Emp_phone", System.Data.SqlDbType.VarChar, 50).Value = Emp_phone;
            cmd.Parameters.Add("@Emp_money", System.Data.SqlDbType.Int).Value = Emp_money;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Emp_Expenses set Emp_name= @Emp_name,Emp_phone=@Emp_phone,Emp_money=@Emp_money,Date=@Date where ID_EmpExp =@ID_EmpExp";
            cmd.Parameters.Add("@ID_EmpExp", System.Data.SqlDbType.Int).Value = ID_EmpExp;
            cmd.Parameters.Add("@Emp_name", System.Data.SqlDbType.VarChar, 50).Value = Emp_name;
            cmd.Parameters.Add("@Emp_phone", System.Data.SqlDbType.VarChar, 50).Value = Emp_phone;
            cmd.Parameters.Add("@Emp_money", System.Data.SqlDbType.Int).Value = Emp_money;
            cmd.Parameters.Add("@Date", System.Data.SqlDbType.Date).Value = Date;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Emp_Expenses where ID_EmpExp = @ID_EmpExp";
            cmd.Parameters.Add("@ID_EmpExp", System.Data.SqlDbType.Int).Value = ID_EmpExp;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Emp_Expenses";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
    }
}
