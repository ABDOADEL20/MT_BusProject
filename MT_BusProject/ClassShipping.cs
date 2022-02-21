using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject
{
    class ClassShipping
    {
        int VID_Shipping;
        string VUsername;
        string VType_Shipping;
        string VName_Sender;
        string VPhone_Sender;
        string VTo_Address;
        int VCost_Shipping;
        DateTime VDate_Shipping;
        string VName_Receiver;
        string VPhone_Receiver;
        string VReceipt_type;
        string VCollection_type;
        int VID_User;

        public int ID_Shipping
        {
            get { return VID_Shipping; }
            set { VID_Shipping = value; }
        }
        public string Username
        {
            get { return VUsername; }
            set { VUsername = value; }
        }
        public string Type_Shipping
        {
            get { return VType_Shipping; }
            set { VType_Shipping = value; }
        }
        public string Name_Sender
        {
            get { return VName_Sender; }
            set { VName_Sender = value; }
        }
        public string Phone_Sender
        {
            get { return VPhone_Sender; }
            set { VPhone_Sender = value; }
        }
        public string To_Address
        {
            get { return VTo_Address; }
            set { VTo_Address = value; }
        }
        public int Cost_Shipping
        {
            get { return VCost_Shipping; }
            set { VCost_Shipping = value; }
        }
        public DateTime Date_Shipping
        {
            get { return VDate_Shipping; }
            set { VDate_Shipping = value; }
        }
        public string Name_Receiver
        {
            get { return VName_Receiver; }
            set { VName_Receiver = value; }
        }
        public string Phone_Receiver
        {
            get { return VPhone_Receiver; }
            set { VPhone_Receiver = value; }
        }
        public string Receipt_type
        {
            get { return VReceipt_type; }
            set { VReceipt_type = value; }
        }
        public string Collection_type
        {
            get { return VCollection_type; }
            set { VCollection_type = value; }
        }
        public int ID_User
        {
            get { return VID_User; }
            set { VID_User = value; }
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
            cmd.CommandText = "insert into Shipping(ID_Shipping,Username,Type_Shipping,Name_Sender,Phone_Sender,To_Address,Cost_Shipping,Date_Shipping,Name_Receiver,Phone_Receiver,Receipt_type,Collection_type,ID_User) values" +
                              " (@ID_Shipping,@Username,@Type_Shipping,@Name_Sender,@Phone_Sender,@To_Address,@Cost_Shipping,@Date_Shipping,@Name_Receiver,@Phone_Receiver,@Receipt_type,@Collection_type,@ID_User)";
            cmd.Parameters.Add("@ID_Shipping", System.Data.SqlDbType.Int).Value = ID_Shipping;
            cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = Username;
            cmd.Parameters.Add("@Type_Shipping", System.Data.SqlDbType.VarChar, 50).Value = Type_Shipping;
            cmd.Parameters.Add("@Name_Sender", System.Data.SqlDbType.VarChar, 50).Value = Name_Sender;
            cmd.Parameters.Add("@Phone_Sender", System.Data.SqlDbType.VarChar, 50).Value = Phone_Sender;
            cmd.Parameters.Add("@To_Address", System.Data.SqlDbType.VarChar, 50).Value = To_Address;
            cmd.Parameters.Add("@Cost_Shipping", System.Data.SqlDbType.Int).Value = Cost_Shipping;
            cmd.Parameters.Add("@Date_Shipping", System.Data.SqlDbType.Date).Value = Date_Shipping;
            cmd.Parameters.Add("@Name_Receiver", System.Data.SqlDbType.VarChar, 50).Value = Name_Receiver;
            cmd.Parameters.Add("@Phone_Receiver", System.Data.SqlDbType.VarChar, 50).Value = Phone_Receiver;
            cmd.Parameters.Add("@Receipt_type", System.Data.SqlDbType.VarChar, 50).Value = Receipt_type;
            cmd.Parameters.Add("@Collection_type", System.Data.SqlDbType.VarChar, 50).Value = Collection_type;
            cmd.Parameters.Add("@ID_User", System.Data.SqlDbType.Int).Value = ID_User;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Shipping set Username= @Username,Type_Shipping= @Type_Shipping, Name_Sender=@Name_Sender, Phone_Sender=@Phone_Sender,To_Address=@To_Address, Cost_Shipping=@Cost_Shipping, Date_Shipping=@Date_Shipping, Name_Receiver=@Name_Receiver, Phone_Receiver=@Phone_Receiver, Receipt_type=@Receipt_type, Collection_type = @Collection_type, ID_User=@ID_User where ID_Shipping=@ID_Shipping";
            cmd.Parameters.Add("@ID_Shipping", System.Data.SqlDbType.Int).Value = ID_Shipping;
            cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = Username;
            cmd.Parameters.Add("@Type_Shipping", System.Data.SqlDbType.VarChar, 50).Value = Type_Shipping;
            cmd.Parameters.Add("@Name_Sender", System.Data.SqlDbType.VarChar, 50).Value = Name_Sender;
            cmd.Parameters.Add("@Phone_Sender", System.Data.SqlDbType.VarChar, 50).Value = Phone_Sender;
            cmd.Parameters.Add("@To_Address", System.Data.SqlDbType.VarChar, 50).Value = To_Address;
            cmd.Parameters.Add("@Cost_Shipping", System.Data.SqlDbType.Int).Value = Cost_Shipping;
            cmd.Parameters.Add("@Date_Shipping", System.Data.SqlDbType.Date).Value = Date_Shipping;
            cmd.Parameters.Add("@Name_Receiver", System.Data.SqlDbType.VarChar, 50).Value = Name_Receiver;
            cmd.Parameters.Add("@Phone_Receiver", System.Data.SqlDbType.VarChar, 50).Value = Phone_Receiver;
            cmd.Parameters.Add("@Receipt_type", System.Data.SqlDbType.VarChar, 50).Value = Receipt_type;
            cmd.Parameters.Add("@Collection_type", System.Data.SqlDbType.VarChar, 50).Value = Collection_type;
            cmd.Parameters.Add("@ID_User", System.Data.SqlDbType.Int).Value = ID_User;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Shipping where ID_Shipping = @ID_Shipping";
            cmd.Parameters.Add("@ID_Shipping", System.Data.SqlDbType.Int).Value = ID_Shipping;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }
        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Shipping";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
    }
}
