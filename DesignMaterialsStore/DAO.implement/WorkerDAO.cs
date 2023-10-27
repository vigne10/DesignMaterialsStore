using DesignMaterialsStore.Model;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesignMaterialsStore.DAO.implement
{
    public class WorkerDAO : DAO<Worker>
    {

        //Constructor
        public WorkerDAO(MySqlConnection conn) : base(conn) { } //call the constructor of DAO class

        //Override methods
        public override bool create(Worker w)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "INSERT INTO worker (name, surname, address, login, password, active) VALUES (@Name, @Surname, @Address, @Login, @Password, @Active)";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Name", w.Name);
                cmd.Parameters.AddWithValue("@Surname", w.Surname);
                cmd.Parameters.AddWithValue("@Address", w.Address);
                cmd.Parameters.AddWithValue("@Login", w.Login);
                cmd.Parameters.AddWithValue("@Password", ComputeHash(w.Password));
                cmd.Parameters.AddWithValue("@Active", true);
                cmd.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                trans.Rollback();
            }
            return false;
        }

        public override bool update(Worker w)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "UPDATE worker SET name=@Name, surname=@Surname, address=@Address, login=@Login, active=@Active WHERE id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Name", w.Name);
                cmd.Parameters.AddWithValue("@Surname", w.Surname);
                cmd.Parameters.AddWithValue("@Address", w.Address);
                cmd.Parameters.AddWithValue("@Login", w.Login);
                cmd.Parameters.AddWithValue("@Active", w.Active);
                cmd.Parameters.AddWithValue("@Id", w.Id);
                cmd.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                trans.Rollback();
            }
            return false;
        }

        public bool updatePassword(Worker w)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "UPDATE worker SET password=@Password WHERE id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Password", ComputeHash(w.Password));
                cmd.Parameters.AddWithValue("@Id", w.Id);
                cmd.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                trans.Rollback();
            }
            return false;
        }

        public override bool delete(Worker w)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "DELETE FROM worker WHERE id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Id", w.Id);
                cmd.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                trans.Rollback();
            }
            return false;
        }

        public override ObservableCollection<Worker> findAll()
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                ObservableCollection<Worker> list = new ObservableCollection<Worker>();
                string sql = "SELECT * FROM worker";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    byte[] passwordBytes = (byte[])dataReader["password"];
                    SecureString passwordSec = BytesToSecureString(passwordBytes);

                    Worker w = new Worker(
                        dataReader.GetInt32("id"),
                        dataReader.GetString("name"),
                        dataReader.GetString("surname"),
                        dataReader.GetString("address"),
                        dataReader.GetString("login"),
                        passwordSec,
                        dataReader.GetBoolean("active"));
                    if (w != null)
                    {
                        list.Add(w);
                    }
                }
                dataReader.Close();
                trans.Commit();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                trans.Rollback();
            }
            return null;
        }

        //Specific methods
        public bool AuthenticateWorker(string UserName, SecureString Password)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            bool validUser = false;
            string sql = "SELECT * FROM worker where login=@Login and password=@Password";
            MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
            cmd.Parameters.AddWithValue("@Login", UserName);
            cmd.Parameters.AddWithValue("@Password", ComputeHash(Password));
            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                validUser = true;
            }
            dataReader.Close();
            trans.Commit();
            return validUser;
        }

        public Worker findById(int id)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT * FROM worker WHERE id =@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    string passwordStr = dataReader.GetString("password");
                    SecureString passwordSec = new SecureString();
                    foreach (char c in passwordStr)
                    {
                        passwordSec.AppendChar(c);
                    }
                    passwordSec.MakeReadOnly();
                    Worker w = new Worker(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("surname"), dataReader.GetString("address"), dataReader.GetString("login"), passwordSec, dataReader.GetBoolean("active"));
                    dataReader.Close();
                    trans.Commit();
                    return w;
                };
                dataReader.Close();
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                trans.Rollback();
            }

            return null;
        }

        public Worker findByLogin(string login)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT * FROM worker WHERE login=@Login";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Login", login);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    string passwordStr = dataReader.GetString("password");
                    SecureString passwordSec = new SecureString();
                    foreach (char c in passwordStr)
                    {
                        passwordSec.AppendChar(c);
                    }
                    passwordSec.MakeReadOnly();
                    Worker w = new Worker(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("surname"), dataReader.GetString("address"), dataReader.GetString("login"), passwordSec, dataReader.GetBoolean("active"));
                    dataReader.Close();
                    trans.Commit();
                    return w;
                };
                dataReader.Close();
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                trans.Rollback();
            }

            return null;
        }

        public bool CheckIfExist(string name, string surname)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT * FROM worker WHERE name=@Name AND surname=@Surname";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    dataReader.Close();
                    trans.Commit();
                    return true;
                };
                dataReader.Close();
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                trans.Rollback();
            }

            return false;
        }

        public bool CheckIfCanBeDelete(Worker w)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT count(i.id) AS count FROM invoice i WHERE idWorker =@IdW";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@IdW", w.Id);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.GetInt32("count") != 0)
                {
                    dataReader.Close();
                    trans.Commit();
                    return false;
                }
                dataReader.Close();
                trans.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                trans.Rollback();
            }
            return true;
        }

        /// <summary>
        /// Compute a hash password to add in DB
        /// </summary>
        /// <param name="secureString">SecureString to hash</param>
        /// <returns>the hash password</returns>
        public byte[] ComputeHash(SecureString secureString)
        {
            IntPtr ptr = IntPtr.Zero;
            byte[] hashBytes;

            try
            {
                // Copy the SecureString to an unmanaged string in memory
                ptr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                string password = Marshal.PtrToStringUni(ptr);

                // Compute the hash of the password using SHA256
                using (SHA256 sha256 = SHA256.Create())
                {
                    hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                }
            }
            finally
            {
                // Clear the unmanaged memory
                Marshal.ZeroFreeGlobalAllocUnicode(ptr);
            }

            return hashBytes;
        }

        /// <summary>
        /// transforms a hashed password into a securestring who can be use with the objects of this project
        /// </summary>
        /// <param name="passwordBytes">Hashed password to transform into a SecureString</param>
        /// <returns>SecureString password</returns>
        private SecureString BytesToSecureString(byte[] passwordBytes)
        {
            SecureString secureString = new SecureString();

            // Convert the byte array to a hex string
            string hexString = BitConverter.ToString(passwordBytes).Replace("-", "");

            // Convert each pair of hex characters to Unicode characters and add them to the SecureString
            for (int i = 0; i < hexString.Length; i += 4)
            {
                char c = (char)Convert.ToInt32(hexString.Substring(i, 4), 16);
                secureString.AppendChar(c);
            }

            return secureString;
        }

    }//end class
}//end namespace
