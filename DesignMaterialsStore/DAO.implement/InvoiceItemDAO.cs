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
    public class InvoiceItemDAO : DAO<InvoiceItem>
    {
        //Constructor
        public InvoiceItemDAO(MySqlConnection conn) : base(conn) { } //call the constructor of DAO class

        //Override methods
        public override bool create(InvoiceItem i)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "INSERT INTO invoice_item (idInvoice, idItem, quantity) VALUES (@InvoiceID, @ItemID, @Quantity)";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@InvoiceID", i.Invoice.Id);
                cmd.Parameters.AddWithValue("@ItemID", i.Item.Id);
                cmd.Parameters.AddWithValue("@Quantity", i.Quantity);
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

        public override bool update(InvoiceItem i)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "UPDATE invoice_item SET quantity=@Quantity WHERE idInvoice=@InvoiceID AND idItem=@ItemID";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@Quantity", i.Quantity);
                cmd.Parameters.AddWithValue("@InvoiceID", i.Invoice.Id);
                cmd.Parameters.AddWithValue("@ItemID", i.Item.Id);
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

        public override bool delete(InvoiceItem i)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "DELETE FROM invoice_item WHERE idInvoice=@InvoiceID AND idItem=@ItemID";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@InvoiceID", i.Invoice.Id);
                cmd.Parameters.AddWithValue("@ItemID", i.Item.Id);
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

        public override ObservableCollection<InvoiceItem> findAll()
        {
            return null;
        }

        //Specific methods
        public bool deleteAllInvoiceItems(int id)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "DELETE FROM invoice_item WHERE idInvoice=@InvoiceID";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@InvoiceID", id);
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

        public ObservableCollection<InvoiceItem> findAllByInvoiceID(int id)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                ObservableCollection<InvoiceItem> list = new ObservableCollection<InvoiceItem>();
                string sql = "SELECT * FROM invoice_item WHERE idInvoice=@InvoiceID";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@InvoiceID", id);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                List<Tuple<int, int, int>> dataList = new List<Tuple<int, int, int>>();
                while (dataReader.Read())
                {
                    int idInvoice = dataReader.GetInt32("idInvoice");
                    int idItem = dataReader.GetInt32("idItem");
                    int quantity = dataReader.GetInt32("quantity");
                    dataList.Add(Tuple.Create(idInvoice, idItem, quantity));
                }
                dataReader.Close();
                trans.Commit();

                InvoiceDAO invoiceDAO = DAOFactory.getInvoiceDAO();
                ItemDAO itemDAO = DAOFactory.getItemDAO();
                foreach (Tuple<int, int, int> dataTuple in dataList)
                {
                    Invoice invoice = invoiceDAO.findById(dataTuple.Item1);
                    Item item = itemDAO.findById(dataTuple.Item2);
                    InvoiceItem i = new InvoiceItem(invoice, item, dataTuple.Item3);
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

        public bool updateAllInvoiceItems(ObservableCollection<InvoiceItem> invoiceItems)
        {
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "DELETE FROM invoice_item WHERE idInvoice=@InvoiceID";
                MySqlCommand cmd = new MySqlCommand(sql, conn, trans);
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceItems[0].Invoice.Id);
                cmd.ExecuteNonQuery();
                trans.Commit();

                for(int i = 0; i < invoiceItems.Count; i++)
                {
                    create(invoiceItems[i]);
                }

                return true;
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
