using DesignMaterialsStore.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignMaterialsStore.DAO.implement
{
    public class ClientDAO : DAO<Client>
    {
        //Constructor
        public ClientDAO(MySqlConnection conn) : base(conn) { } //call the constructor of DAO class

        //Override methods
        public override bool create(Client c)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "INSERT INTO client (name, surname, address, active) VALUES (@Name, @Surname, @Address, @Active)";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Name", c.Name);
                cmd.Parameters.AddWithValue("@Surname", c.Surname);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Active", c.Active);
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

        public override bool update(Client c)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "UPDATE client SET name=@Name, surname=@Surname, address=@Address, active=@Active WHERE id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Name", c.Name);
                cmd.Parameters.AddWithValue("@Surname", c.Surname);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Active", c.Active);
                cmd.Parameters.AddWithValue("@Id", c.Id);
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

        public override bool delete(Client c)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "DELETE FROM client WHERE id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Id", c.Id);
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

        public override ObservableCollection<Client> findAll()
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                ObservableCollection<Client> list = new ObservableCollection<Client>();
                string sql = "SELECT * FROM client";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Client c = new Client(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("surname"), dataReader.GetString("address"), dataReader.GetBoolean("active"));
                    if (c != null)
                    {
                        list.Add(c);
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
        public Client findById(int id)
        {

            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT * FROM client WHERE id=@Id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if(dataReader.HasRows)
                {
                    Client c = new Client(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("surname"), dataReader.GetString("address"), dataReader.GetBoolean("active"));
                    dataReader.Close();
                    trans.Commit();
                    return c;
                }
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

        public Client findByNameAndSurname(string name, string surname)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT * FROM client WHERE name=@Name AND surname=@Surname";
                MySqlCommand cmd = new MySqlCommand(sql, conn,trans);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    Client c = new Client(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("surname"), dataReader.GetString("address"), dataReader.GetBoolean("active"));
                    dataReader.Close();
                    trans.Commit();
                    return c;
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
                string sql = "SELECT * FROM client WHERE name=@Name AND surname=@Surname";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
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

        public bool CheckIfCanBeDelete(Client c)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT count(i.id) AS count FROM invoice i WHERE idClient=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Id", c.Id);
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

    }//end class
}//end namespace
