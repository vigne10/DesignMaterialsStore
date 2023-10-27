using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignMaterialsStore.Singleton
{
    public class DBconnection
    {

        //Fields
        private const string user = ""; // user
        private const string password = ""; // password
        private const string dbName = ""; // DB name
        private const string connectionString = "SERVER=localhost;DATABASE=" + dbName + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";"; // connection string
        private volatile static MySqlConnection _conn;
        private static DBconnection _single;

        //Constructors
        private DBconnection()
        {
            try
            {
                Conn = new MySqlConnection(connectionString);
                Conn.Open();
                Console.WriteLine("Connection opened successfully !");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.ToString());
            }
        }

        //Properties
        public static DBconnection Single { get => _single; set => _single = value; }

        public MySqlConnection Conn { get => _conn; set => _conn = value; }

        //Methods
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static MySqlConnection getInstance()
        {
            if (_conn == null)
            {
                _single = new DBconnection();
            }
            return _conn;
        }

    }//end class
}//end namespace
