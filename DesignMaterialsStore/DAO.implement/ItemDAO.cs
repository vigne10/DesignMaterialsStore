using DesignMaterialsStore.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;

namespace DesignMaterialsStore.DAO.implement
{
    public class ItemDAO : DAO<Item>
    {

        //Constructor
        public ItemDAO(MySqlConnection conn) : base(conn) { } //call the constructor of DAO class

        //Override methods
        public override bool create(Item i)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "INSERT INTO item (name, description, price, active) VALUES (@Name, @Description, @Price, @Active)";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Name", i.Name);
                cmd.Parameters.AddWithValue("@Description", i.Description);
                cmd.Parameters.AddWithValue("@Price", i.Price);
                cmd.Parameters.AddWithValue("@Active", i.Active);
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

        public override bool update(Item i)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "UPDATE item SET name=@Name, description=@Description, price=@Price, active=@Active WHERE id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Name", i.Name);
                cmd.Parameters.AddWithValue("@Description", i.Description);
                cmd.Parameters.AddWithValue("@Price", i.Price);
                cmd.Parameters.AddWithValue("@Active", i.Active);
                cmd.Parameters.AddWithValue("@Id", i.Id);
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

        public override bool delete(Item i)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "DELETE FROM item WHERE id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Id", i.Id);
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

        public override ObservableCollection<Item> findAll()
        {
            try
            {
                ObservableCollection<Item> list = new ObservableCollection<Item>();
                string sql = "SELECT * FROM item";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Item i = new Item(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("description"), dataReader.GetDouble("price"), dataReader.GetBoolean("active"));
                    if (i != null)
                    {
                        list.Add(i);
                    }
                }
                dataReader.Close();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        //Specific methods
        public Item findById(int id)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT * FROM item WHERE id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    Item i = new Item(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("description"), dataReader.GetDouble("price"), dataReader.GetBoolean("active"));
                    dataReader.Close();
                    trans.Commit();
                    return i;
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

        public Item findByName(string name)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT * FROM item WHERE name=@Name";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Name", name);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    Item i = new Item(dataReader.GetInt32("id"), dataReader.GetString("name"), dataReader.GetString("description"), dataReader.GetDouble("price"), dataReader.GetBoolean("active"));
                    dataReader.Close();
                    trans.Commit();
                    return i;
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

        public bool CheckIfCanBeDelete(Item i)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT count(i.idInvoice) AS count FROM invoice_item i WHERE idItem = @Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Id", i.Id);
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

        public bool CheckIfExist(string name)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT * FROM item WHERE name=@Name";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Name", name);
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

    }//end class
}//end namespace
