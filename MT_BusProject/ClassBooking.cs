using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT_BusProject
{
    class ClassBooking
    {
        int VID_Booking;
        string VUsername;
        string VTicket_office;
        DateTime VDate_Booking;
        int VSeat_Number;
        string VName_Customer;
        string VPhone_Customer;
        int VTicket_Price;
        string VTime_Start;
        string VStart_Station;
        string VTime_End;
        string VEnd_Station;
        DateTime VDate_Travel;
        int VID_Customer;
        int VID_User;

        public int ID_Booking
        {
            get { return VID_Booking; }
            set { VID_Booking = value; }
        }

        public string Username
        {
            get { return VUsername; }
            set { VUsername = value; }
        }

        public string Ticket_office
        {
            get { return VTicket_office; }
            set { VTicket_office = value; }
        }

        public DateTime Date_Booking
        {
            get { return VDate_Booking; }
            set { VDate_Booking = value; }
        }

        public int Seat_Number
        {
            get { return VSeat_Number; }
            set { VSeat_Number = value; }
        }

        public string Name_Customer
        {
            get { return VName_Customer; }
            set { VName_Customer = value; }
        }

        public string Phone_Customer
        {
            get { return VPhone_Customer; }
            set { VPhone_Customer = value; }
        }

        public int Ticket_Price
        {
            get { return VTicket_Price; }
            set { VTicket_Price = value; }
        }

        public string Time_Start
        {
            get { return VTime_Start; }
            set { VTime_Start = value; }
        }

        public string Start_Station
        {
            get { return VStart_Station; }
            set { VStart_Station = value; }
        }

        public string Time_End
        {
            get { return VTime_End; }
            set { VTime_End = value; }
        }

        public string End_Station
        {
            get { return VEnd_Station; }
            set { VEnd_Station = value; }
        }

        public DateTime Date_Travel
        {
            get { return VDate_Travel; }
            set { VDate_Travel = value; }
        }

        public int ID_Customer
        {
            get { return VID_Customer; }
            set { VID_Customer = value; }
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
            cmd.CommandText = "insert into Booking(ID_Booking,Username,Ticket_office,Date_Booking,Seat_Number,Name_Customer,Phone_Customer,Ticket_Price,Time_Start,Start_Station,Time_End,End_Station,Date_Travel,ID_Customer,ID_User)" +
                              " values (@ID_Booking,@Username,@Ticket_office,@Date_Booking,@Seat_Number,@Name_Customer,@Phone_Customer,@Ticket_Price,@Time_Start,@Start_Station,@Time_End,@End_Station,@Date_Travel,@ID_Customer,@ID_User)";
            cmd.Parameters.Add("@ID_Booking", System.Data.SqlDbType.Int).Value = ID_Booking;
            cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar,50).Value = Username;
            cmd.Parameters.Add("@Ticket_office", System.Data.SqlDbType.VarChar, 50).Value = Ticket_office;
            cmd.Parameters.Add("@Date_Booking", System.Data.SqlDbType.Date).Value = Date_Booking;
            cmd.Parameters.Add("@Seat_Number", System.Data.SqlDbType.Int).Value = Seat_Number;
            cmd.Parameters.Add("@Name_Customer", System.Data.SqlDbType.VarChar,50).Value = Name_Customer;
            cmd.Parameters.Add("@Phone_Customer", System.Data.SqlDbType.VarChar, 50).Value = Phone_Customer;
            cmd.Parameters.Add("@Ticket_Price", System.Data.SqlDbType.Int).Value = Ticket_Price;
            cmd.Parameters.Add("@Time_Start", System.Data.SqlDbType.VarChar, 50).Value = Time_Start;
            cmd.Parameters.Add("@Start_Station", System.Data.SqlDbType.VarChar, 50).Value = Start_Station;
            cmd.Parameters.Add("@Time_End", System.Data.SqlDbType.VarChar, 50).Value = Time_End;
            cmd.Parameters.Add("@End_Station", System.Data.SqlDbType.VarChar, 50).Value = End_Station;
            cmd.Parameters.Add("@Date_Travel", System.Data.SqlDbType.Date).Value = Date_Travel;
            cmd.Parameters.Add("@ID_Customer", System.Data.SqlDbType.Int).Value = ID_Customer;
            cmd.Parameters.Add("@ID_User", System.Data.SqlDbType.Int).Value = ID_User;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Booking set Username = @Username , Ticket_office = @Ticket_office , Date_Booking = @Date_Booking , Seat_Number = @Seat_Number , Name_Customer = @Name_Customer" +
                ", Phone_Customer = @Phone_Customer, Ticket_Price = @Ticket_Price , Time_Start = @Time_Start ,Start_Station = @Start_Station" +
                ", Time_End = @Time_End , End_Station = @End_Station , Date_Travel = @Date_Travel , ID_Customer = @ID_Customer , ID_User = @ID_User  where ID_Booking =@ID_Booking ";
            cmd.Parameters.Add("@ID_Booking", System.Data.SqlDbType.Int).Value = ID_Booking;
            cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = Username;
            cmd.Parameters.Add("@Ticket_office", System.Data.SqlDbType.VarChar, 50).Value = Ticket_office;
            cmd.Parameters.Add("@Date_Booking", System.Data.SqlDbType.Date).Value = Date_Booking;
            cmd.Parameters.Add("@Seat_Number", System.Data.SqlDbType.Int).Value = Seat_Number;
            cmd.Parameters.Add("@Name_Customer", System.Data.SqlDbType.VarChar, 50).Value = Name_Customer;
            cmd.Parameters.Add("@Phone_Customer", System.Data.SqlDbType.VarChar, 50).Value = Phone_Customer;
            cmd.Parameters.Add("@Ticket_Price", System.Data.SqlDbType.Int).Value = Ticket_Price;
            cmd.Parameters.Add("@Time_Start", System.Data.SqlDbType.VarChar, 50).Value = Time_Start;
            cmd.Parameters.Add("@Start_Station", System.Data.SqlDbType.VarChar, 50).Value = Start_Station;
            cmd.Parameters.Add("@Time_End", System.Data.SqlDbType.VarChar, 50).Value = Time_End;
            cmd.Parameters.Add("@End_Station", System.Data.SqlDbType.VarChar, 50).Value = End_Station;
            cmd.Parameters.Add("@Date_Travel", System.Data.SqlDbType.Date).Value = Date_Travel;
            cmd.Parameters.Add("@ID_Customer", System.Data.SqlDbType.Int).Value = ID_Customer;
            cmd.Parameters.Add("@ID_User", System.Data.SqlDbType.Int).Value = ID_User;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Booking where ID_Booking = @ID_Booking";
            cmd.Parameters.Add("@ID_Booking", System.Data.SqlDbType.Int).Value = ID_Booking;
            cmd.Connection = DB_Connection();
            cmd.ExecuteNonQuery();
        }

        public SqlDataAdapter Read_all()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Booking";
            cmd.Connection = DB_Connection();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            return da;
        }
    }
}
