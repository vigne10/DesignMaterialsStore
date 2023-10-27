using DesignMaterialsStore.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMaterialsStore.DAO.implement
{
    public class InvoiceDAO : DAO<Invoice>
    {
        //Constructor
        public InvoiceDAO(MySqlConnection conn) : base(conn) { } //call the constructor of DAO class

        //Override methods
        public override bool create(Invoice i)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            string formattedDate = i.Date.ToString("yyyy-MM-dd");

            try
            {
                string sql = "INSERT INTO invoice (idWorker, idClient, date, price) VALUES (@WorkerId, @ClientId, @Date, @Price)";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@WorkerId", i.Worker.Id);
                cmd.Parameters.AddWithValue("@ClientId", i.Client.Id);
                cmd.Parameters.AddWithValue("@Date", formattedDate);
                cmd.Parameters.AddWithValue("@Price", i.Price);
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

        public override bool update(Invoice i)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            string formattedDate = i.Date.ToString("yyyy-MM-dd");

            try
            {
                string sql = "UPDATE invoice SET idWorker=@WorkerId, idClient=@ClientId, date=@Date, price=@Price WHERE id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@WorkerId", i.Worker.Id);
                cmd.Parameters.AddWithValue("@ClientId", i.Client.Id);
                cmd.Parameters.AddWithValue("@Date", formattedDate);
                cmd.Parameters.AddWithValue("@Price", i.Price);
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

        public override bool delete(Invoice i)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "DELETE FROM invoice WHERE id =@Id";
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

        public override ObservableCollection<Invoice> findAll()
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                ObservableCollection<Invoice> list = new ObservableCollection<Invoice>();
                string sql = "SELECT * FROM Invoice";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Tuple<int, int, int, DateTime, double>> dataList = new List<Tuple<int, int, int, DateTime, double>>();
                while (dataReader.Read())
                {
                    int idInvoice = dataReader.GetInt32("id");
                    int idWorker = dataReader.GetInt32("idWorker");
                    int idClient = dataReader.GetInt32("idClient");
                    DateTime date = dataReader.GetDateTime("date");
                    double price = dataReader.GetDouble("price");
                    dataList.Add(Tuple.Create(idInvoice, idWorker, idClient, date, price));
                }
                dataReader.Close();
                trans.Commit();

                ClientDAO cd = DAOFactory.getClientDAO();
                WorkerDAO wd = DAOFactory.getWorkerDAO();
                foreach (Tuple<int, int, int, DateTime, double> dataTuple in dataList)
                {
                    Worker w = wd.findById(dataTuple.Item2);
                    Client c = cd.findById(dataTuple.Item3);
                    Invoice i = new Invoice(dataTuple.Item1, w, c, dataTuple.Item4, dataTuple.Item5);
                    if (i != null)
                    {
                        list.Add(i);
                    }
                }
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
        public Invoice findById(int id)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "SELECT * FROM invoice WHERE id =@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    int IdInvoice = dataReader.GetInt32("id");
                    int IdWorker = dataReader.GetInt32("idWorker");
                    int IdClient = dataReader.GetInt32("idClient");
                    DateTime date = dataReader.GetDateTime("date");
                    double price = dataReader.GetDouble("price");
                    dataReader.Close();
                    trans.Commit();

                    ClientDAO cd = DAOFactory.getClientDAO();
                    WorkerDAO wd = DAOFactory.getWorkerDAO();

                    Client c = cd.findById(IdClient);
                    Worker w = wd.findById(IdWorker);
                    Invoice i = new Invoice(IdInvoice, w, c, date, price);
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

        public Invoice findByWorkerClientDatePrice(Worker worker, Client client, DateTime date, double price)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                //convert date format to match with date format in DB
                string formattedDate = date.ToString("yyyy-MM-dd");

                string sql = "SELECT id, idWorker, idClient, date, price FROM invoice WHERE idWorker=@WorkerID AND idClient=@ClientID AND date=@Date AND price=@Price";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@WorkerID", worker.Id);
                cmd.Parameters.AddWithValue("@ClientID", client.Id);
                cmd.Parameters.AddWithValue("@Date", formattedDate);
                cmd.Parameters.AddWithValue("@Price", price);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    Invoice i = new Invoice(dataReader.GetInt32("id"), worker, client, date, price);
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

    }//end class
}//end namespace
